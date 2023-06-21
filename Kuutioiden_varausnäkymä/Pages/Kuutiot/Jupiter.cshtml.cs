using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.VisualBasic;
using System.Globalization;
using System.Text.Json;
using System.Text;
using System.Net.Http.Json;

namespace Kuutioiden_varausnäkymä.Pages.Kuutiot
{

    public class JupiterModel : PageModel
    {
        public void OnGet()
        {

        }
        public int Viikko()
        {
            DateTime aika = DateTime.Now;
            return CultureInfo.InvariantCulture.Calendar.GetWeekOfYear(aika, CalendarWeekRule.FirstDay, DayOfWeek.Sunday);
        }
    }
}