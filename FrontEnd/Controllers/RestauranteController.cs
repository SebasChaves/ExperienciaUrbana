using FrontEnd.Helpers;
using FrontEnd.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FrontEnd.Controllers
{
    public class RestauranteController : Controller
    {
        private readonly RestauranteHelper helper = new RestauranteHelper();


        /*
         * AGREGAR TRY CATCH
         */
        // GET: RestauranteController
        public async Task<ActionResult> Index()
        {
            List<RestauranteViewModel> restaurantes = await helper.GetAllAsync();            
            return View(restaurantes);
        }

        // GET: RestauranteController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: RestauranteController/Create
        public ActionResult Create()
        {
            // ViewBag.CreacionExitosa = true;
            return View();
        }

        // POST: RestauranteController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(RestauranteViewModel restaurante)
        {
            if (ModelState.IsValid)
            {
                ViewBag.CreacionExitosa = helper.Create(restaurante);
            }

            return View();

        }

        // GET: RestauranteController/Edit/5
        public ActionResult Edit(int id, bool? flag)
        {
            RestauranteViewModel restaurante;
            if (id == 0)
            {
                 restaurante = new RestauranteViewModel
                {
                    RestauranteId = 0,
                    Calificacion = 10,
                    Direccion = "",
                    Nombre = ""
                };
            }
            else
            {
                 restaurante = helper.Get(id);
            }

            if (flag != null)
            {
                ViewBag.EliminacionExitosa = flag;
            }
            return View(restaurante);
        }

        // POST: RestauranteController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(RestauranteViewModel restaurante)
        {
            try
            {

                if (ModelState.IsValid)
                {
                    ViewBag.EdicionExitosa = helper.Edit(restaurante);
                }                

                return View(restaurante);
            }
            catch
            {
                return View(restaurante);
            }
        }

        // GET: RestauranteController/Delete/5
        public ActionResult Delete(int id)
        {
            bool flag = true;
            //RestauranteViewModel? restaurante = helper.Get(id);
            try
            {
               
                if (ModelState.IsValid)
                {
                    flag = helper.Delete(id);
                }

                return RedirectToAction("Edit", "Restaurante", new { id = 0, flag = flag});
            }
            catch
            {
                flag = false;
                return RedirectToAction("Edit", "Restaurante", new { id = 0, flag = flag });
            }
        }

        // POST: RestauranteController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
