﻿using System;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using System.IO;

namespace PasswordChecker
{
    class Checker
    {
        static readonly HttpClient client = new HttpClient(); // Yhteydenottamista varten

        public static string Hashing(string source)
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

        public static async Task<String> SendHash(string hash)
        {
            try {
                string getRequest = "https://api.pwnedpasswords.com/range/" + hash.Remove(5);   // Luodaan URI tiivisteen 5:stä ensimmäisestä kirjaimesta
                var response = await client.GetStringAsync(getRequest);                         // Käydään vertaamassa tietokantaan
                return response;
            } catch (HttpRequestException e) {
                return null;
            }
        }

        public static string CompareResponseToHash(string hash, string response)
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

    }
}
