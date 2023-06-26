using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Globalization;
using System.Net.Http;
using System.Text;
//using System.Text.Json;
//using System.Text.Json.Nodes;
using Newtonsoft.Json;
using System.Runtime.Intrinsics.X86;

namespace Kuutioiden_varausnäkymä.Pages.Kuutiot
{
    public class SetupModel : PageModel
    {
        public void OnGet()
        {
        }
        public static string AikaGet = "";
        public static string OnOff(string name)
        {
            if (name == "Jupiter")
            {
                JupiterPalautus();
            }
            if (name == "Merkurius")
            {
                MerkuriusPalautus();
            }
            if (name == "Neptunus")
            {
                NeptunusPalautus();
            }
            if (name == "Quu")
            {
                QuuPalautus();
            }
            if (name == "Saturnus")
            {
                SaturnusPalautus();
            }
            return "";
        }
        public static void NeptunusPalautus()
        {
            OikeinNeptunus = 0;
            DateTime currentDateTime = DateTime.Now;
            int nytTun = Convert.ToInt32(currentDateTime.ToString("HH"));
            int nytMin = Convert.ToInt32(currentDateTime.ToString("mm"));
            int nyt = (nytTun * 100) + nytMin;
            AikaGet = nyt.ToString();
            //formattedDateTime = currentDateTime.ToString("dd");
            int pvnyt = Convert.ToInt32(currentDateTime.ToString("dd"));
            int kuunyt = Convert.ToInt32(currentDateTime.ToString("MM"));
            int vuosinyt = Convert.ToInt32(currentDateTime.ToString("yyyy"));

            foreach (string varaus in Neptunus)
        {
                string word = varaus;
                string[] tieto = word.Split(';');
                string[] aikaAlku = tieto[0].Substring(10, 6).Split(':');
                int varaustunAlk = Convert.ToInt32(aikaAlku[0]);
                int varausminAlk = Convert.ToInt32(aikaAlku[1]);
                int varausAlku = (varaustunAlk * 100) + varausminAlk;

                string[] aikaLoppu = tieto[1].Substring(10, 6).Split(':');
                int varaustunLop = Convert.ToInt32(aikaLoppu[0]);
                int varausminLop = Convert.ToInt32(aikaLoppu[1]);
                int varausLoppu = (varaustunLop * 100) + varausminLop;

                string[] varauspvtiedot = tieto[0].Split('-');
                int varauspv = Convert.ToInt32(varauspvtiedot[2].Substring(0, 2));
                int varauskuu = Convert.ToInt32(varauspvtiedot[1]);
                int varausvuosi = Convert.ToInt32(varauspvtiedot[0]);

                if (varauspv == pvnyt && varauskuu == kuunyt && varausvuosi == vuosinyt)
                {

                if (nyt <= varausLoppu)
                    {
                    if ((varausAlku - nyt) + varausLoppu <= varausLoppu)
                        {
                        OikeinNeptunus = 1;
                        break;
                    }
                }
                else
                {
                    OikeinNeptunus = 0;
                }
                }
                else
                {
                    OikeinNeptunus = 0;
                }
            }
        }
        public static void JupiterPalautus()
        {
            OikeinJupiter = 0;
            DateTime currentDateTime = DateTime.Now;
            int nytTun = Convert.ToInt32(currentDateTime.ToString("HH"));
            int nytMin = Convert.ToInt32(currentDateTime.ToString("mm"));
            int nyt = (nytTun * 100) + nytMin;
            AikaGet = nyt.ToString();
            //formattedDateTime = currentDateTime.ToString("dd");
            int pvnyt = Convert.ToInt32(currentDateTime.ToString("dd"));
            int kuunyt = Convert.ToInt32(currentDateTime.ToString("MM"));
            int vuosinyt = Convert.ToInt32(currentDateTime.ToString("yyyy"));

            foreach (string varaus in Jupiter)
            {
                string word = varaus;
                string[] tieto = word.Split(';');
                string[] aikaAlku = tieto[0].Substring(10, 6).Split(':');
                int varaustunAlk = Convert.ToInt32(aikaAlku[0]);
                int varausminAlk = Convert.ToInt32(aikaAlku[1]);
                int varausAlku = (varaustunAlk * 100) + varausminAlk;

                string[] aikaLoppu = tieto[1].Substring(10, 6).Split(':');
                int varaustunLop = Convert.ToInt32(aikaLoppu[0]);
                int varausminLop = Convert.ToInt32(aikaLoppu[1]);
                int varausLoppu = (varaustunLop * 100) + varausminLop;

                string[] varauspvtiedot = tieto[0].Split('-');
                int varauspv = Convert.ToInt32(varauspvtiedot[2].Substring(0, 2));
                int varauskuu = Convert.ToInt32(varauspvtiedot[1]);
                int varausvuosi = Convert.ToInt32(varauspvtiedot[0]);

                if (varauspv == pvnyt && varauskuu == kuunyt && varausvuosi == vuosinyt)
                {

                    if (nyt <= varausLoppu)
                    {
                        if ((varausAlku - nyt) + varausLoppu <= varausLoppu)
                        {
                            OikeinJupiter = 1;
                            break;
                        }
                    }
                    else
                    {
                        OikeinJupiter = 0;
                    }
                }
                else
                {
                    OikeinJupiter = 0;
                }
            }
        }
        public static void MerkuriusPalautus()
        {
            OikeinMerkurius = 0;
            DateTime currentDateTime = DateTime.Now;
            int nytTun = Convert.ToInt32(currentDateTime.ToString("HH"));
            int nytMin = Convert.ToInt32(currentDateTime.ToString("mm"));
            int nyt = (nytTun * 100) + nytMin;
            AikaGet = nyt.ToString();
            //formattedDateTime = currentDateTime.ToString("dd");
            int pvnyt = Convert.ToInt32(currentDateTime.ToString("dd"));
            int kuunyt = Convert.ToInt32(currentDateTime.ToString("MM"));
            int vuosinyt = Convert.ToInt32(currentDateTime.ToString("yyyy"));

            foreach (string varaus in Merkurius)
            {
                string word = varaus;
                string[] tieto = word.Split(';');
                string[] aikaAlku = tieto[0].Substring(10, 6).Split(':');
                int varaustunAlk = Convert.ToInt32(aikaAlku[0]);
                int varausminAlk = Convert.ToInt32(aikaAlku[1]);
                int varausAlku = (varaustunAlk * 100) + varausminAlk;

                string[] aikaLoppu = tieto[1].Substring(10, 6).Split(':');
                int varaustunLop = Convert.ToInt32(aikaLoppu[0]);
                int varausminLop = Convert.ToInt32(aikaLoppu[1]);
                int varausLoppu = (varaustunLop * 100) + varausminLop;

                string[] varauspvtiedot = tieto[0].Split('-');
                int varauspv = Convert.ToInt32(varauspvtiedot[2].Substring(0, 2));
                int varauskuu = Convert.ToInt32(varauspvtiedot[1]);
                int varausvuosi = Convert.ToInt32(varauspvtiedot[0]);

                if (varauspv == pvnyt && varauskuu == kuunyt && varausvuosi == vuosinyt)
                {

                    if (nyt <= varausLoppu)
                    {
                        if ((varausAlku - nyt) + varausLoppu <= varausLoppu)
                        {
                            OikeinMerkurius = 1;
                            break;
                        }
                    }
                    else
                    {
                        OikeinMerkurius = 0;
                    }
                }
                else
                {
                    OikeinMerkurius = 0;
                }
            }
        }
        public static void QuuPalautus()
        {
            OikeinQuu = 0;
            DateTime currentDateTime = DateTime.Now;
            int nytTun = Convert.ToInt32(currentDateTime.ToString("HH"));
            int nytMin = Convert.ToInt32(currentDateTime.ToString("mm"));
            int nyt = (nytTun * 100) + nytMin;
            AikaGet = nyt.ToString();
            //formattedDateTime = currentDateTime.ToString("dd");
            int pvnyt = Convert.ToInt32(currentDateTime.ToString("dd"));
            int kuunyt = Convert.ToInt32(currentDateTime.ToString("MM"));
            int vuosinyt = Convert.ToInt32(currentDateTime.ToString("yyyy"));

            foreach (string varaus in Quu)
            {
                string word = varaus;
                string[] tieto = word.Split(';');
                string[] aikaAlku = tieto[0].Substring(10, 6).Split(':');
                int varaustunAlk = Convert.ToInt32(aikaAlku[0]);
                int varausminAlk = Convert.ToInt32(aikaAlku[1]);
                int varausAlku = (varaustunAlk * 100) + varausminAlk;

                string[] aikaLoppu = tieto[1].Substring(10, 6).Split(':');
                int varaustunLop = Convert.ToInt32(aikaLoppu[0]);
                int varausminLop = Convert.ToInt32(aikaLoppu[1]);
                int varausLoppu = (varaustunLop * 100) + varausminLop;

                string[] varauspvtiedot = tieto[0].Split('-');
                int varauspv = Convert.ToInt32(varauspvtiedot[2].Substring(0, 2));
                int varauskuu = Convert.ToInt32(varauspvtiedot[1]);
                int varausvuosi = Convert.ToInt32(varauspvtiedot[0]);

                if (varauspv == pvnyt && varauskuu == kuunyt && varausvuosi == vuosinyt)
                {

                    if (nyt <= varausLoppu)
                    {
                        if ((varausAlku - nyt) + varausLoppu <= varausLoppu)
                        {
                            OikeinQuu = 1;
                            break;
                        }
                    }
                    else
                    {
                        OikeinQuu = 0;
                    }
                }
                else
                {
                    OikeinQuu = 0;
                }
            }
        }
        public static void SaturnusPalautus()
        {
            OikeinSaturnus = 0;
            DateTime currentDateTime = DateTime.Now;
            int nytTun = Convert.ToInt32(currentDateTime.ToString("HH"));
            int nytMin = Convert.ToInt32(currentDateTime.ToString("mm"));
            int nyt = (nytTun * 100) + nytMin;
            AikaGet = nyt.ToString();
            //formattedDateTime = currentDateTime.ToString("dd");
            int pvnyt = Convert.ToInt32(currentDateTime.ToString("dd"));
            int kuunyt = Convert.ToInt32(currentDateTime.ToString("MM"));
            int vuosinyt = Convert.ToInt32(currentDateTime.ToString("yyyy"));

            foreach (string varaus in Saturnus)
            {
                string word = varaus;
                string[] tieto = word.Split(';');
                string[] aikaAlku = tieto[0].Substring(10, 6).Split(':');
                int varaustunAlk = Convert.ToInt32(aikaAlku[0]);
                int varausminAlk = Convert.ToInt32(aikaAlku[1]);
                int varausAlku = (varaustunAlk * 100) + varausminAlk;

                string[] aikaLoppu = tieto[1].Substring(10, 6).Split(':');
                int varaustunLop = Convert.ToInt32(aikaLoppu[0]);
                int varausminLop = Convert.ToInt32(aikaLoppu[1]);
                int varausLoppu = (varaustunLop * 100) + varausminLop;

                string[] varauspvtiedot = tieto[0].Split('-');
                int varauspv = Convert.ToInt32(varauspvtiedot[2].Substring(0, 2));
                int varauskuu = Convert.ToInt32(varauspvtiedot[1]);
                int varausvuosi = Convert.ToInt32(varauspvtiedot[0]);


                if (varauspv == pvnyt && varauskuu == kuunyt && varausvuosi == vuosinyt)
                {

                    if (nyt <= varausLoppu)
                    {
                        if ((varausAlku - nyt) + varausLoppu <= varausLoppu)
                        {
                            OikeinSaturnus = 1;
                            break;
                        }
                    }
                    else
                    {
                        OikeinSaturnus = 0;
                    }
                }
                else
                {
                    OikeinSaturnus = 0;
                }
            }
        }
        public static int OikeinJupiter = 0;
        public static int OikeinMerkurius = 0;
        public static int OikeinNeptunus = 0;
        public static int OikeinQuu = 0;
        public static int OikeinSaturnus = 0;
        public int Viikko()
        {
            DateTime aika = DateTime.Now;
            return CultureInfo.InvariantCulture.Calendar.GetWeekOfYear(aika, CalendarWeekRule.FirstDay, DayOfWeek.Sunday);
        }
        public static string ma = Convert.ToString(DateTime.Today.AddDays(-(int)DateTime.Today.DayOfWeek + (int)DayOfWeek.Monday));

        public static string ti = Convert.ToString(DateTime.Today.AddDays(-(int)DateTime.Today.DayOfWeek + (int)DayOfWeek.Tuesday));

        public static string ke = Convert.ToString(DateTime.Today.AddDays(-(int)DateTime.Today.DayOfWeek + (int)DayOfWeek.Wednesday));

        public static string to = Convert.ToString(DateTime.Today.AddDays(-(int)DateTime.Today.DayOfWeek + (int)DayOfWeek.Thursday));

        public static string pe = Convert.ToString(DateTime.Today.AddDays(-(int)DateTime.Today.DayOfWeek + (int)DayOfWeek.Friday));
        public string Maanantai() { return ma; }
        public string Tiistai() { return ti; }
        public string Keskiviikko() { return ke; }
        public string Torstai() { return to; }
        public string Perjantai() { return pe; }

        public static string locations = "";

        public static string CallGet()
        {
            Jupiter.Clear();
            Merkurius.Clear();
            Neptunus.Clear();
            Saturnus.Clear();
            Quu.Clear();
            API();
            return "";
        }
      
        public static List<string> Jupiter = new List<string>();
        public static List<string> Merkurius = new List<string>();
        public static List<string> Neptunus = new List<string>();
        public static List<string> Saturnus = new List<string>();
        public static List<string> Quu = new List<string>();

        public static void API()
        {
            using (var client = new HttpClient())
            {
                //int idnro = 127575;
                string id = "";
                //var url = new Uri("lukkarit.centria.fi/rest/basket/0/events/");
                var url = new Uri("https://lukkarit.centria.fi/rest/event/" + id);
                var tulos = client.GetAsync(url).Result;
                var json = tulos.Content.ReadAsStringAsync().Result;
                string vs = json.ToString();
                //locations += "VASTAUS 1: " + vs + "\n";

                //Tyhjä id on "".

                int id_alku = 127475;
                int id_loppu = 127575;

                for (int i = id_alku; i < id_loppu; i++)
                {
                    id = i.ToString();
                    url = new Uri("https://lukkarit.centria.fi/rest/event/" + id);
                    tulos = client.GetAsync(url).Result;
                    json = tulos.Content.ReadAsStringAsync().Result;
                    vs = json.ToString();
                    if (vs != "")
                    {
                        if (vs.Contains("Jupiter")) 
                        {
                            Jupiter.Add(TRIMMERI(vs));
                        }
                        else if (vs.Contains("Merkurius"))
                        {
                            Merkurius.Add(TRIMMERI(vs));
                        }
                        else if (vs.Contains("Neptunus"))
                        {
                            Neptunus.Add(TRIMMERI(vs));
                        }
                        else if (vs.Contains("Saturnus"))
                        {
                            Saturnus.Add(TRIMMERI(vs));
                        }
                        else if (vs.Contains("Quu"))
                        {
                            Quu.Add(TRIMMERI(vs));
                        }
                    }
                }

            }

        }
        public static string TRIMMERI(string varaus)
        {
            string vs = varaus.Replace("{", string.Empty);
            vs = vs.Replace("}", string.Empty);
            vs = vs.Replace("[", string.Empty);
            vs = vs.Replace("]", string.Empty);
            string[] varaustiedot = vs.Split(',');
            //return vs;
            //0 event_Id
            //1 start_date
            //2 end_date
            //3 subject

            //Norm:
            //4 location
            //5 name (Kuutio)
            //6 parent (Kokkola)

            //Desc Versio:
            //4 description
            //5 location
            //6 name (Kuutio)
            //7 parent (Kokkola)
            string palautus = "";
            for (int i = 0; i < 7; i++) 
            {
                if (i != 9)
                {
                    if (!varaustiedot[i].Contains("\"name\"") && !varaustiedot[i].Contains("\"start_date\"") && !varaustiedot[i].Contains("\"end_date\"") && !varaustiedot[i].Contains("\"subject\"") && !varaustiedot[i].Contains("\"description\"") && !varaustiedot[i].Contains("\"event_id\"") && !varaustiedot[i].Contains("\"location\"") && !varaustiedot[i].Contains("\"parent\""))
                    {
                        varaustiedot[i] = varaustiedot[i].Replace("\"", string.Empty);
                        palautus += "," + varaustiedot[i];
                    }
                    else if (varaustiedot[i].Contains("\"start_date\""))
                    {
                        varaustiedot[i] = varaustiedot[i].Replace("\"", string.Empty);
                        string[] tieto = varaustiedot[i].Split(':');
                        palautus += tieto[1] + ":" + tieto[2];
                    }
                    else if (varaustiedot[i].Contains("\"end_date\""))
                    {
                        varaustiedot[i] = varaustiedot[i].Replace("\"", string.Empty);
                        string[] tieto = varaustiedot[i].Split(':');
                        palautus += ";" + tieto[1] + ":" + tieto[2];
                    }
                    else if (varaustiedot[i].Contains("\"subject\""))
                    {
                        varaustiedot[i] = varaustiedot[i].Replace("\"", string.Empty);
                        string[] tieto = varaustiedot[i].Split(':');
                        palautus += ";" + tieto[1];
                    }
                    else if (varaustiedot[i].Contains("\"name\""))
                    {
                        //Tätä kohtaa ei tarvisi enää, koska tämä olivan testi vaiheessa mukana.
                        varaustiedot[i] = varaustiedot[i].Replace("\"", string.Empty);
                        string[] tieto = varaustiedot[i].Split(':');
                        palautus += ";" + tieto[1];
                    }
                    else if (varaustiedot[i].Contains("\"description\""))
                    {
                        varaustiedot[i] = varaustiedot[i].Replace("\"", string.Empty);
                        string[] tieto = varaustiedot[i].Split(':');
                        palautus += ";" + tieto[1];
                    }
                    else if (i == 4 && !vs.Contains("\"description\""))
                    {
                        palautus += ";Ei lisätietoa";
                    }
                    else if (i == 5 && !vs.Contains("\"description\""))
                    {
                        palautus += ";Ei lisätietoa";
                    }
                }
                else
                {
                    if (i == 9999)
                    {
                        if (varaustiedot[i].Contains("\"description\""))
                        {
                            varaustiedot[i] = varaustiedot[i].Replace("\"", string.Empty);
                            string[] tieto = varaustiedot[i].Split(':');
                            int a = i + 1;
                            if (!varaustiedot[a].Contains("\"name\"") && !varaustiedot[a].Contains("\"event_id\"") && !varaustiedot[a].Contains("\"location\"") && !varaustiedot[a].Contains("\"parent\""))
                            {
                                palautus += "," + varaustiedot[a];
                            }
                            a = 0;
                        }
                    }
                }
            }
            //MUOTO:
            //0 start_date
            //1 end_date
            //2 subject
            //4 description
            //5 
            //return palautus;
            return palautus;
        }
    }
}
