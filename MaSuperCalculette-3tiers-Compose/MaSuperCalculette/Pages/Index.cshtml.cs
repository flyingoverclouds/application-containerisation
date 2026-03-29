using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Reflection.Metadata;
using System.Text.Encodings.Web;

namespace MaSuperCalculette.Pages
{
    public class IndexModel : PageModel
    {
        private readonly IConfiguration _config;
        public IndexModel(IConfiguration config)
        {
            this._config = config;
        }

        [BindProperty]
        public int Nombre1 { get; set; }
        [BindProperty] 
        public int Nombre2 { get; set; }
        [BindProperty] 
        public string Operation { get; set; }

        public decimal? Resultat { get; set; } = null;

        public string Erreur { get; set; } = string.Empty;

        public string ApiEnvironmentInfo { get; set; } = string.Empty;

        public void OnGet()
        {

        }

        public async Task<IActionResult> OnPostAsync()
        {
            Erreur = "";
            var calculatorUrl= _config["CalculatorUrl"];
            try
            {
                var apiUri = new Uri($"http://{calculatorUrl}/Calculator/FaireCalcul?nombre1={Nombre1}&operation={Operation.Replace("+", "%2b")}&nombre2={Nombre2}");

                HttpClient client = new();
                var resultatCalcul = await client.GetStringAsync(apiUri);
                Resultat = decimal.Parse(resultatCalcul);

                apiUri = new Uri($"http://{calculatorUrl}/Calculator/EnvironmentInfo");
                ApiEnvironmentInfo = await client.GetStringAsync(apiUri);

            }
            catch (Exception ex)
            {
                
                Erreur = calculatorUrl + " : " + ex.Message; 
            }
            return Page();
        }

    }
}
