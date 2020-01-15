using System;
using System.Text;
using System.Windows.Forms;
using System.Security.Cryptography;
using System.Net.Http;
using System.Threading.Tasks;
using System.IO;

namespace PasswordChecker
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        static readonly HttpClient client = new HttpClient();

        private void TextToHash(object sender, EventArgs e)
        {
            string source = txtPass.Text.ToString();            // Käyttäjän syöttämä teksti
            string hash = Hashing(source);
            lblHash.Text = "Hash: " + hash + "\n5 ensimmäistä kirjainta: " + hash.Remove(5);
        }

        private static string Hashing(string source)
        {
            SHA1 sha = new SHA1CryptoServiceProvider();         // Hash-algoritmi
            string hash = GetHash(sha, source);                 // Viedään teksti tiivistettäväksi
            return hash;                                        // Palautetaan tiiviste

            string GetHash(HashAlgorithm hashAlgorithm, string input)
            {
                byte[] data = hashAlgorithm.ComputeHash(Encoding.UTF8.GetBytes(input)); // Luo syötetystä tekstistä bittijonon ja laskee siitä tiivisteen
                var sBuilder = new StringBuilder();                                     // StringBuilder bittijonon muuttamiseksi takaisin stringiksi

                for (int i = 0; i < data.Length; i++) {                                 // Käydään läpi jokainen tavu ja muutetaan se heksadesimaaliksi
                    sBuilder.Append(data[i].ToString("x2"));
                }
                return sBuilder.ToString();                                             // Palautetaan heksadesimaali
            }
        }

        private async void btnSend_Click(object sender, EventArgs e)
        {
            string source = txtPass.Text.ToString();            // Käyttäjän syöttämä teksti
            string hash = Hashing(source);
            string hash2 = Hashing(source);

            if(hash == hash2) {
                var response = await SendHash(hash);                // Käydään tietokannasta vertailutulokset
                string r = response.ToString();                     // Muutetaan tulos stringiksi
                hash = hash.Substring(5).ToUpper();                 // Vastaus tulee isoilla kirjaimilla, joten tiiviste myös isoksi
                                                                    // Lisäksi otetaan tiivisteen viisi ensimmäistä kirjainta pois, sillä ne on poistettu myös  vastauksesta

                lblResponse.Text = CompareResponseToHash(hash, r);  // Verrataan alkuperäistä tiivistettä tulokseen
            }
            else {
                lblResponse.Text = "Tiivisteen varmennus epäonnistui";
            }
        }

        private static async Task<String> SendHash(string hash)
        {
            try {
                string getRequest = "https://api.pwnedpasswords.com/range/" + hash.Remove(5);   // Luodaan URI tiivisteen 5:stä ensimmäisestä kirjaimesta
                var response = await client.GetStringAsync(getRequest);                         // Käydään vertaamassa tietokantaan
                return response;
            } catch (HttpRequestException e) {
                return null;
            }
        }

        private static string CompareResponseToHash(string hash, string response)
        {
            StringReader stReader = new StringReader(response);     // Luetaan vastaus rivi kerrallaan

            string aLine = stReader.ReadLine();
            while (aLine != null) {
                string[] jako = aLine.Split(':');   // Jaetaan rivi kahteen osaan.

                if (jako[0] == hash) {
                    return "Salanasi löytyi " + jako[1] + " kertaa";
                }
                aLine = stReader.ReadLine();
            }
            return "Salasanaa ei löytynyt julkistetuista vuodoista";
        }

        private void txtPass_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Enter)) {
                btnSend_Click(sender, e);
                e.SuppressKeyPress = true;  // Hiljentää *ding* äänen
            }
        }
    }
}
