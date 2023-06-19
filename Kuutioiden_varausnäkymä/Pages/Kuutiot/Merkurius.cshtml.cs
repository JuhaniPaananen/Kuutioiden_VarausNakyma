using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Globalization;

namespace Kuutioiden_varausnäkymä.Pages
{
    public class MerkuriusModel : PageModel
    {
        public void OnGet()
        {
        }
        public int Viikko()
        {
            DateTime aika = DateTime.Now;
            return CultureInfo.InvariantCulture.Calendar.GetWeekOfYear(aika, System.Globalization.CalendarWeekRule.FirstDay, DayOfWeek.Sunday);
        }
    }
}
