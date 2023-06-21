using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Globalization;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Text.Json.Nodes;

namespace Kuutioiden_varausnäkymä.Pages.Kuutiot
{
    public class SetupModel : PageModel
    {
        public void OnGet()
        {
        }
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
                int idnro = 127575;
                string id = idnro.ToString();
                //var url = new Uri("lukkarit.centria.fi/rest/basket/0/events/");
                var url = new Uri("https://lukkarit.centria.fi/rest/event/" + id);
                var tulos = client.GetAsync(url).Result;
                var json = tulos.Content.ReadAsStringAsync().Result;
                string vs = json.ToString();
                //locations += "VASTAUS 1: " + vs + "\n";

                //Tyhjä id on "".

                int id_alku = 132000;
                int id_loppu = 132100;

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
                    if (varaustiedot[i].Contains("\"start_date\""))
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
                        palautus += ";Ei tietoja";
                    }
                    else if (!varaustiedot[i].Contains("\"event_id\"") && !varaustiedot[i].Contains("\"location\"") && !varaustiedot[i].Contains("\"parent\""))
                    {
                        palautus += "," + varaustiedot[i];
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
