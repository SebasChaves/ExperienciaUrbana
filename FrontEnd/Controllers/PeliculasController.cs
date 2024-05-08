using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using FrontEnd.Helpers;
using Newtonsoft.Json;
using Microsoft.Extensions.DependencyInjection;
using FrontEnd.Models;
using Microsoft.AspNetCore.Mvc.Formatters;
using static System.Net.WebRequestMethods;
using System;

namespace FrontEnd.Controllers
{
    public class PeliculasController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly PeliculasSeriesHelper helper = new PeliculasSeriesHelper();
        private static string? tipoAtributo;

        public PeliculasController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        /**
         * Cambiar en el DELETE que siempre es true
         * Cambiar el  sweetAlert en el modalPelicula para que diga si es una pelicula o una serie
         */
        public async Task<IActionResult> Index(string tipo, bool? flag, bool? eliminacionExitosa)
        {
            try
            {                
                if (String.IsNullOrEmpty(tipo) && String.IsNullOrEmpty(tipoAtributo))
                {
                    tipoAtributo = "movie";
                }
                else
                {
                    tipoAtributo = tipo;
                }
                if (eliminacionExitosa != null) {
                    ViewBag.EliminacionExitosa = eliminacionExitosa;
                    ViewBag.TipoPeliculaSerie = tipoAtributo;
                }                
                List<PeliculasSeriesDBViewModel> resultados = await ObtenerResultadosDesdeBaseDeDatos("", tipoAtributo);
                List<PeliculasSeriesDBViewModel> resultadoFinal = new List<PeliculasSeriesDBViewModel>();
                /*foreach (var resultado in resultados)
                {
                    if (resultado.Tipo == tipoAtributo)
                    {
                        resultadoFinal.Add(resultado);
                    }
                }*/

                if (resultadoFinal.Any())
                {
                    //ObtenerSitioSteaming(resultadoFinal.First());
                }
                return View("Index", resultados);
            }
            catch (HttpRequestException ex)
            {
                return BadRequest($"Error en la solicitud HTTP: {ex.Message}");
            }
        }
        [HttpGet]
        public async Task<IActionResult> GetModal(int id, string nombre, string tipo, string? isBaseDatos)
        {
            ViewBag.isBaseDatos = isBaseDatos;
            List<PeliculasSeriesDBViewModel> resultados = await ObtenerResultadosDesdeBaseDeDatos(nombre, tipoAtributo);
            ModalCompuestoViewModel proveedores = await ObtenerSitioSteaming(resultados.First());
            return PartialView("_ModalPeliculaSeriePartial", proveedores);
        }


        [HttpGet]
        public async Task<IActionResult> Buscar(string searchTerm)
        {
            List<PeliculasSeriesDBViewModel> resultadosInicial = new List<PeliculasSeriesDBViewModel>();
            List<PeliculasSeriesDBViewModel> resultados = new List<PeliculasSeriesDBViewModel>();
            try
            {                
                if (searchTerm?.Length >= 3)
                {
                    resultados = await ObtenerResultadosDesdeBaseDeDatos(searchTerm, tipoAtributo);
                }
                else
                {
                    resultados = await ObtenerResultadosDesdeBaseDeDatos("", tipoAtributo);
                }
                /*foreach (var result in resultadosInicial)
                {
                    if (result.Tipo == tipoAtributo)
                    {
                        resultados.Add(result);
                    }
                }*/
                return PartialView("_ResultadosBusquedaPartial", resultados);
            }catch (NullReferenceException e)
            {
                resultados = await ObtenerResultadosDesdeBaseDeDatos("", tipoAtributo);
                return PartialView("_ResultadosBusquedaPartial", resultados );
            }catch (Exception e)
            {
                resultados = await ObtenerResultadosDesdeBaseDeDatos("", tipoAtributo);
                return PartialView("_ResultadosBusquedaPartial", resultados);
            }
        }

        private async Task<List<PeliculasSeriesDBViewModel>> ObtenerResultadosDesdeBaseDeDatos(string searchTerm, string tipo)
        {
            //searchTerm = "Reacher";
            List<PeliculasSeriesDBViewModel> listaPeliculasSeries = new List<PeliculasSeriesDBViewModel>();

            string apiKey = "7041f31b171941645c53bf691ffe16aa";
            string language = "es-MX";
            string apiUrl = $"https://api.themoviedb.org/3/search/{tipo}?query={searchTerm}&language={language}&api_key={apiKey}";
            if (String.IsNullOrEmpty(searchTerm))
            {
                List<PeliculasSeriesDBViewModel> listaPeliculasSeriesFinal = new List<PeliculasSeriesDBViewModel>();
                listaPeliculasSeries = helper.GetAll();
                foreach (var result in listaPeliculasSeries) { 
                    if(result.Tipo == tipo)
                    {
                        listaPeliculasSeriesFinal.Add(result);
                    }
                }
                return listaPeliculasSeriesFinal;
            }
            else
            {
                try
                {
                    using (HttpClient httpClient = _httpClientFactory.CreateClient())
                    {
                        HttpResponseMessage response = await httpClient.GetAsync(apiUrl);

                        if (response.IsSuccessStatusCode)
                        {
                            // Deserializar el JSON en un objeto fuertemente tipado
                            var jsonResult = await response.Content.ReadAsStringAsync();


                            // Deserialización del JSON
                            var seriesResult = JsonConvert.DeserializeObject<PeliculasViewModel>(jsonResult);

                            if (seriesResult?.Results != null)
                            {
                                for (int i = 0; i < seriesResult?.Results.Count; i++)
                                {
                                    var id = seriesResult.Results[i].Id;
                                    string nombre;
                                    string fechaEstreno;
                                    if (tipo == "tv")
                                    {
                                        nombre = seriesResult?.Results[i].Name;
                                        fechaEstreno = seriesResult?.Results[i].first_air_date;
                                    }
                                    else
                                    {
                                        nombre = seriesResult?.Results[i].original_title;
                                        fechaEstreno = seriesResult?.Results[i].release_date;
                                    }

                                    var imagen = seriesResult?.Results[i].poster_path;
                                    var descripcion = seriesResult?.Results[i].Overview;
                                    //var fechaEstreno = seriesResult?.Results[i].release_date;
                                    if (String.IsNullOrEmpty(imagen))
                                    {
                                        imagen = "https://www.themoviedb.org/assets/2/v4/glyphicons/basic/glyphicons-basic-38-picture-grey-c2ebdbb057f2a7614185931650f8cee23fa137b93812ccb132b9df511df1cfac.svg";
                                    }
                                    else
                                    {
                                        imagen = "https://image.tmdb.org/t/p/w500//////" + imagen;
                                    }
                                    PeliculasSeriesDBViewModel peliculasSeriesDBViewModel = new PeliculasSeriesDBViewModel
                                    {
                                        PeliculaSerieId = id,
                                        Nombre = nombre,
                                        Imagen = imagen,
                                        Descripcion = descripcion,
                                        FechaEstreno = fechaEstreno
                                    };
                                    listaPeliculasSeries.Add(peliculasSeriesDBViewModel);
                                }
                            }
                            return listaPeliculasSeries;
                        }
                        else
                        {
                            return listaPeliculasSeries;
                        }
                    }
                }
                catch (HttpRequestException ex)
                {
                    return listaPeliculasSeries;
                }
            }
        }

        private async Task<ModalCompuestoViewModel> ObtenerSitioSteaming(PeliculasSeriesDBViewModel peliculaSerieDB)
        {
            ModalCompuestoViewModel listaPeliculasSeries = new ModalCompuestoViewModel();
            listaPeliculasSeries.nombreProveedor = new List<string>();
            listaPeliculasSeries.imagenProveedor = new List<string>();

            string apiKey = "7041f31b171941645c53bf691ffe16aa";
            string language = "es-MX";
            string apiUrl = $"https://api.themoviedb.org/3/{tipoAtributo}/{peliculaSerieDB.PeliculaSerieId}/watch/providers?api_key={apiKey}";

            try
            {
               
                using (HttpClient httpClient = _httpClientFactory.CreateClient())
                {
                    HttpResponseMessage response = await httpClient.GetAsync(apiUrl);

                    if (response.IsSuccessStatusCode)
                    {
                        // Deserializar el JSON en un objeto fuertemente tipado
                        var jsonResult = await response.Content.ReadAsStringAsync();


                        // Deserialización del JSON
                        var seriesResult = JsonConvert.DeserializeObject<PeliculaSerieProviderModel>(jsonResult);
                        if (seriesResult?.Results.MX != null)
                        {
                            if (seriesResult?.Results != null && seriesResult?.Results.MX.Flatrate.Count() > 0)
                            {
                                for (int i = 0; i < seriesResult?.Results.MX.Flatrate.Count(); i++)
                                {
                                    var nombre = seriesResult?.Results.MX.Flatrate[i].provider_name;
                                    var imagen = $"https://image.tmdb.org/t/p/w500///////{seriesResult?.Results.MX.Flatrate[i].logo_path}";

                                    listaPeliculasSeries.nombreProveedor?.Add(nombre);
                                    listaPeliculasSeries.imagenProveedor?.Add(imagen);
                                }
                            }
                        }
                        listaPeliculasSeries.peliculasSeriesDBViewModel = peliculaSerieDB;
                        return listaPeliculasSeries;
                    }
                    else
                    {
                        return listaPeliculasSeries;
                    }
                }
                
            }
            catch (HttpRequestException ex)
            {
                return listaPeliculasSeries;
            }

        }

        public ActionResult AddBaseDeDatos(ModalCompuestoViewModel modal)
        {
            modal.peliculasSeriesDBViewModel.Tipo = tipoAtributo;
            if (helper.Create(modal.peliculasSeriesDBViewModel))
            {
                return RedirectToAction(nameof(Index), new { tipo = modal.peliculasSeriesDBViewModel.Tipo, flag = true });
            }
            else
            {
                return RedirectToAction(nameof(Index), new { tipo = modal.peliculasSeriesDBViewModel.Tipo, flag = false });
            }

        }
        // GET: peliculasController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: peliculasController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: peliculasController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
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

        // GET: peliculasController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: peliculasController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
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



        // POST: peliculasController/Delete/5

        public ActionResult Delete(int id)
        {
            try
            {              
               bool flag = helper.Delete(id); 
                return RedirectToAction(nameof(Index), new { tipo = tipoAtributo, eliminacionExitosa = flag });
            }
            catch
            {
                return View();
            }
        }
    }
}
