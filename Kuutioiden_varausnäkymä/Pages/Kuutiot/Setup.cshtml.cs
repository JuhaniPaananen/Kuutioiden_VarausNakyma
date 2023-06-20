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
        public string Varaukset()
        {
            VarausController controller = new VarausController();
            string sana = controller.GetVaraus();
            return sana;
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
            API();
            return "";
        }

        public static List<string> Neptunus = new List<string>();

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
                
                //Tyhjä id on "", eikä NULL! (vs)

                for(int i = 127500; i < 127600; i++)
                {
                    id = i.ToString();
                    url = new Uri("https://lukkarit.centria.fi/rest/event/" + id);
                    tulos = client.GetAsync(url).Result;
                    json = tulos.Content.ReadAsStringAsync().Result;
                    vs = json.ToString();
                    if (vs != "")
                    {
                        //if(vs.Contains("Neptunus") || vs.Contains("Jupiter"))
                        if (vs.Contains("Neptunus"))
                        {
                            //char[] merkit = { '{', '}', '[', ']' };
                            //string varaus = vs.TrimEnd(merkit);
                            //locations += "VASTAUS: " + vs + "\n";
                            Neptunus.Add(TRIMMERI(vs));
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
            //1 Start_time
            //2 End_time
            //3 Subject
            //return varaustiedot[0];
            return vs;
        }
    }
}
