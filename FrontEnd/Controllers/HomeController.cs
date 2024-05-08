using FrontEnd.Helpers;
using FrontEnd.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace FrontEnd.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly RestauranteHelper restauranteHelper = new RestauranteHelper();
        private readonly ActividadesPorHacerHelper actividadesHelper = new ActividadesPorHacerHelper();
        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public ActionResult Index()
        {
            List<RestauranteViewModel>? restaurantes = restauranteHelper.GetAll();
            List<ActividadesPorHacerViewModel>? actividades= actividadesHelper.GetAll();

            IndexViewModel viewModel = new IndexViewModel { ActividadesPorHacer = actividades, Restaurante = restaurantes };
            return View(viewModel); 
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