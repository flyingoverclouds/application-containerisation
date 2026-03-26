using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Net;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace MaSuperCalculette_Api.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class CalculatorController : ControllerBase
    {

     
        [HttpGet(Name = "EnvironmentInfo")]
        [ProducesResponseType<decimal>(StatusCodes.Status200OK)]
        public IActionResult EnvironmentInfo()
        {
            string envStr = $"{Dns.GetHostName()} [{System.Environment.OSVersion}] - IP [";

            foreach(var ipAdr in System.Net.Dns.GetHostAddresses(System.Net.Dns.GetHostName()))
            {
                if (ipAdr.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork)
                {
                    envStr += $" {ipAdr} ";
                }
            }
            envStr += $"] served at {HttpContext.Connection.LocalIpAddress?.ToString()}:{HttpContext.Connection.LocalPort}";


            return Ok(envStr);
        }

        [HttpGet(Name = "FaireCalcul")]
        [ProducesResponseType<decimal>(StatusCodes.Status200OK)]
        [ProducesResponseType<decimal>(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType<decimal>(StatusCodes.Status501NotImplemented)]
        public IActionResult FaireCalcul(int nombre1,string operation,int nombre2)
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
