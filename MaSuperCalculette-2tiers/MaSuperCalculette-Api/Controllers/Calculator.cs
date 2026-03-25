using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace MaSuperCalculette_Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CalculatorController : ControllerBase
    {

        [HttpGet(Name = "FaireCalcul")]
        [ProducesResponseType<decimal>(StatusCodes.Status200OK)]
        [ProducesResponseType<decimal>(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType<decimal>(StatusCodes.Status501NotImplemented)]
        public IActionResult Get(int nombre1,string operation,int nombre2)
        {
            try
            {
                switch (operation)
                {
                    case "+":
                        return Ok(nombre1 + nombre2);
                    case "-":
                        return  Ok(nombre1 - nombre2);
                    case "/":
                        return  Ok(nombre1 / nombre2);
                    case "*":
                        return  Ok(nombre1 * nombre2);
                    default:
                        return NotFound($"Operation '{operation}' non implémentée.");
                }
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }
        }
    }
}
