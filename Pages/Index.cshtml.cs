using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Text.Json;
using Test3.Models;
//to acces models and get method of JsonSerializer.Deserialize

namespace Test3.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        //survive after the onget finishes
        public string RawResult = "";
        //the ? is to say that it can be empty (nothing to show yet)
        public Country? MyCountry { get; set; }

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        //methode must return task since it uses async await (thumb rule)
        public async Task OnGet()
        {
            //creating my first http client 
            var client = new HttpClient();
            //actually sending the request to get data and using await to wait and not freeze the program
            var response = await client.GetAsync("https://countries.dev/alpha/US");
            //
            var json = await response.Content.ReadAsStringAsync();//it's local
            RawResult = json;//asign it to rawresult so i don't lose my json text
            MyCountry = JsonSerializer.Deserialize<Country>(json);
        }
        
    }
}
