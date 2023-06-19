using Microsoft.AspNetCore.Mvc;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using static System.Net.WebRequestMethods;
//using Newtonsoft.Json;
//using Newtonsoft.Json.Converters;

namespace Kuutioiden_varausnäkymä.Pages
{

    public class VarausController : Controller
    {

        public static string sana = "";
        public string url1 = "https://lukkarit.centria.fi/rest/locations";
        public string url2 = "https://lukkarit.centria.fi/rest/basket/0/events";
        public async Task<string> Varaus()
        {
            var client = new HttpClient();
            var response = await client.GetAsync(url2);
            return await response.Content.ReadAsStringAsync();
        }
        public string NoKetchup()
        {
            Program program = new Program();

            return "";
        }
        public string GetVaraus()
        {

            //sana += NoKetchup();
            sana += Varaus();
            return sana;
        }
        

        
    }
}