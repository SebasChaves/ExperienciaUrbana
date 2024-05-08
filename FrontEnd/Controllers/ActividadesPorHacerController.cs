using FrontEnd.Helpers;
using FrontEnd.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.FlowAnalysis;

namespace FrontEnd.Controllers
{
    public class ActividadesPorHacerController : Controller
    {
        private readonly ActividadesPorHacerHelper helper = new ActividadesPorHacerHelper();


        /*
         * AGREGAR TRY CATCH
         */
        // GET: RestauranteController
        public async Task<ActionResult> Index()
        {
            List<ActividadesPorHacerViewModel> actividades=  helper.GetAll();
            return View(actividades);
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
        public ActionResult Create(ActividadesPorHacerViewModel actividades)
        {
            if (ModelState.IsValid)
            {
                actividades.Realizada = false;
                ViewBag.CreacionExitosa = helper.Create(actividades);
            }

            return View();

        }

        // GET: RestauranteController/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, bool realizado)
        {
            ActividadesPorHacerViewModel actividad = helper.Get(id);
            actividad.Realizada=realizado;            
            bool flag = helper.Edit(actividad);

            if (flag)
            {
                return Json(new { success = flag});
            }
            else
            {
                return Json(new { success = flag });
            }
        }      

        // GET: RestauranteController/Delete/5
        [HttpPost]
        public ActionResult Delete(int id)
        {
            bool flag = true;
            //RestauranteViewModel? restaurante = helper.Get(id);
            try
            {
                flag = helper.Delete(id);
                if (flag)
                {
                    return Json(new { success = flag, message = "La tarea ha sido eliminada correctamente." });
                }
                else {
                    return Json(new { success = flag });
                }
            }
            catch
            {
                return Json(new { success = flag });
            }
        }

        
    }
}
