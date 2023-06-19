using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
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
            return locations;
        }

        public static void API()
        {
            using (var client = new HttpClient())
            {
                var url = new Uri("https://lukkarit.centria.fi/rest/basket/0/events/posts");
                var tulos = client.GetAsync(url).Result;
                var json = tulos.Content.ReadAsStringAsync().Result;
                string vs = json.ToString();
                locations += "VASTAUS 1: " + vs + "\n";

                var url1 = new Uri("https://lukkarit.centria.fi/rest/locations");
                using StringContent jsonContent = new(JsonSerializer.Serialize(new { target = "locations", type = "name", text = "Neptunus", dateFrom = "", dateTo = "", filters = "", show = true }), 
                Encoding.UTF8, "application/json");
                var tulos1 = client.PostAsync(url1, jsonContent).Result;
                var json1 = tulos1.Content.ReadAsStringAsync().Result;
                string vs1 = json1.ToString();
                locations += "VASTAUS 2: " + vs1 + "\n";

                using StringContent jsonContent1 = new(JsonSerializer.Serialize(new { dateFrom = "2023-05-01", dateTo = "2023-05-08", eventType = "visible"}),
                 Encoding.UTF8, "application/json");
                var tulos2 = client.PostAsync(url, jsonContent1).Result;
                var json2 = tulos2.Content.ReadAsStringAsync().Result;
                string vs2 = json2.ToString();
                locations += "VASTAUS 3: " + vs2 + "\n";

            }
        }
    }
}
