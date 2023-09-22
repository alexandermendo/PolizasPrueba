using Microsoft.AspNetCore.Mvc;
using NombreDeTuProyecto.Services;
using PolizasPrueba.Models; 
using System.Diagnostics;

namespace PolizasPrueba.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private readonly IPolizaService _polizaService;

        public HomeController(IPolizaService polizaService)
        {
            _polizaService = polizaService;
        }

        public IActionResult Index()
        {
            var polizas = _polizaService.ObtenerPolizas();
            return View(polizas);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}