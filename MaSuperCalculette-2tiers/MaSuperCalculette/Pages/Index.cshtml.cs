using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Reflection.Metadata;

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
        
        
        public void OnGet()
        {

        }

        public async Task<IActionResult> OnPostAsync()
        {
            Erreur = "";
            try
            {
                string calculatorUrl = _config["Calculator:Url"];
                var apiUri = new Uri($"http://{calculatorUrl}/Calculator?nombre1={Nombre1}&operation={Operation}&nombre2={Nombre2}");

                HttpClient client = new();
                var resultatCalcul = await client.GetStringAsync(apiUri);
                Resultat = decimal.Parse(resultatCalcul);

            }
            catch (Exception ex)
            {
                    Erreur= ex.Message; 
            }
            return Page();
        }

    }
}
