using System;
using System.Windows.Forms;

namespace PasswordChecker
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void TextToHash(object sender, EventArgs e)
        {
            string source = txtPass.Text;            // Käyttäjän syöttämä teksti
            string hash = Checker.Hashing(source);
            lblHash.Text = "Hash: " + hash + "\n5 ensimmäistä merkkiä: " + hash.Remove(5);
        }

        private async void btnSend_Click(object sender, EventArgs e)
        {
            string source = txtPass.Text;            // Käyttäjän syöttämä teksti
            string hash = Checker.Hashing(source);
            string hash2 = Checker.Hashing(source);

            if(hash == hash2) {
                string response = await Checker.SendHash(hash); // Käydään tietokannasta vertailutulokset
                hash = hash.Substring(5).ToUpper();             // Vastaus tulee isoilla kirjaimilla, joten tiiviste myös isoksi
                                                                // Lisäksi otetaan tiivisteen viisi ensimmäistä kirjainta pois, sillä ne on poistettu myös  vastauksesta

                lblResponse.Text = Checker.CompareResponseToHash(hash, response);  // Verrataan alkuperäistä tiivistettä tulokseen
            }
            else {
                lblResponse.Text = "Tiivisteen varmennus epäonnistui";
            }
        }

        private void txtPass_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Enter)) {
                btnSend_Click(sender, e);
                e.SuppressKeyPress = true;  // Hiljentää *ding*-äänen
            }
        }
    }
}
