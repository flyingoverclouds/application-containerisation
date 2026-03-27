using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MaSuperCalculette.Pages
{
    public class IndexModel : PageModel
    {
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
                switch (Operation)
                {
                    case "+":
                        Resultat=Nombre1 + Nombre2;
                        break;
                    case "-":
                        Resultat = Nombre1 - Nombre2;
                        break;
                    case "/":
                        Resultat = Nombre1 / Nombre2;
                        break;
                    case "*":
                        Resultat = Nombre1 * Nombre2;
                        break;
                    default:
                        Erreur = "Operation non implémentée";
                        break;
                }
            }
            catch (Exception ex)
            {
                    Erreur= ex.Message; 
            }
            return Page();
        }

    }
}
