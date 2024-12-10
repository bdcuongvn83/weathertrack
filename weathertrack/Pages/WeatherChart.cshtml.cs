/** 
    Author: DUC CUONG BUI
    Email: bdcuongvn83@gmail.com
    Release Version: 2024
*/
using System.Text.Json;
using Microsoft.AspNetCore.DataProtection.KeyManagement;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;


namespace weathertrack.Pages
{
    public class WeatherChartModel : PageModel
    {
        [BindProperty]
        public string LocationName { get; set; }
        public string SearchResults { get; set; }

        public async Task<IActionResult> OnGetAsync()
        {
            return Page();
        }

        //public IActionResult OnPostSearch()
        public async Task<IActionResult> OnPostSearchAsync()
        {
            if (string.IsNullOrEmpty(LocationName))
            {
                return Page();

            }

            string timesteps = "1h";
            //string apikey = "5kuQDcrtorf6udVH1VtYQFNjuxVeYG8E";
            string apikey = "sSLapEzWvt8aucNbUWlVA3hsWxmwUcWL";
            string apiUrl = string.Format("https://api.tomorrow.io/v4/weather/forecast?location={0}&timesteps={1}&apikey={2}", LocationName, timesteps, apikey);
            using var httpClient = new HttpClient();
            var response = await httpClient.GetAsync(apiUrl);

            // Check response status
            string jsonData = "";
            if (response.IsSuccessStatusCode)
            {
                jsonData = await response.Content.ReadAsStringAsync();
                // Deserialize JSON data into your model
                //var data = JsonSerializer.Deserialize<List<MyModel>>(jsonData);
                ViewData["Data"] = jsonData;
            }
            else
            {
                // Handle errors (e.g., log and display a friendly message)
                ViewData["Error"] = $"Error: {response.StatusCode}";
            }

        
            var model = JsonSerializer.Deserialize<Object>(jsonData);
            //WeatherData model = new WeatherData();
            //model.Time = "12";
            //model.Temperature = 10;
              //return Partial("_WeatherChartResults", model);
            return new JsonResult(model);

        }
       
    }
}
