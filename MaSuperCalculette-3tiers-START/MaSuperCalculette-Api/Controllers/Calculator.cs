using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic;
using System;
using System.Net;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace MaSuperCalculette_Api_3tiers.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class CalculatorController : ControllerBase
    {
        private readonly IConfiguration _config;
        public CalculatorController(IConfiguration config)
        {
            _config = config;       
        }

        [HttpGet(Name = "EnvironmentInfo")]
        [ProducesResponseType<decimal>(StatusCodes.Status200OK)]
        public IActionResult EnvironmentInfo()
        {
            string envStr = $"{Dns.GetHostName()} [{System.Environment.OSVersion}] \nIP [";

            foreach(var ipAdr in System.Net.Dns.GetHostAddresses(System.Net.Dns.GetHostName()))
            {
                if (ipAdr.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork)
                {
                    envStr += $" {ipAdr} ";
                }
            }
            envStr += $"]\nserved at {HttpContext.Connection.LocalIpAddress?.ToString()}:{HttpContext.Connection.LocalPort}";
            envStr += $"\nCalculLogPath={_config["CalculatorApi:CalculLogPath"]}";


            return Ok(envStr);
        }

        [HttpGet(Name = "FaireCalcul")]
        [ProducesResponseType<decimal>(StatusCodes.Status200OK)]
        [ProducesResponseType<decimal>(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType<decimal>(StatusCodes.Status501NotImplemented)]
        public async Task<IActionResult> FaireCalcul(int nombre1,string operation,int nombre2)
        {
            try
            {
                int res;
                switch (operation)
                {
                    case "+":
                        res = nombre1 + nombre2;
                        await LogCalcul($"{nombre1} + {nombre2} = {res}");
                        return Ok(res);
                    case "-":
                        res = nombre1 - nombre2;
                        await LogCalcul($"{nombre1} - {nombre2} = {res}");
                        return Ok(res);
                    case "/":
                        res = nombre1 / nombre2;
                        await LogCalcul($"{nombre1} / {nombre2} = {res}");
                        return Ok(res);
                    case "*":
                        res = nombre1 * nombre2;
                        await LogCalcul($"{nombre1} * {nombre2} = {res}");
                        return Ok(nombre1 * nombre2);
                    default:
                        await LogCalcul($"{nombre1} {operation} {nombre2} = OPERATION INCONNU");
                        return NotFound($"Operation '{operation}' non implémentée.");
                }
            }
            catch (Exception ex)
            {
                await LogCalcul($"{nombre1} {operation} {nombre2} = ERREUR {ex.Message}");
                return Problem(ex.Message);
            }
        }


        async Task LogCalcul(string calcul)
        {
            await System.IO.File.AppendAllTextAsync(
                Path.Combine(_config["CalculatorApi:CalculLogPath"],$"CalcuLog-{DateTime.Now.Year}-{DateTime.Now.Month}-{DateTime.Now.Day}.txt")
                , $"{DateTime.Now.Hour}:{DateTime.Now.Minute}:{DateTime.Now.Second}  -  {calcul}\n"
                );
        }

    }
}
