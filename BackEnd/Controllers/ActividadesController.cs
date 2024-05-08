using Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ActividadesController : ControllerBase
    {
        private readonly ExperienciaUrbanaContext context;

        public ActividadesController() { 
            context = new ExperienciaUrbanaContext();
        }
        // GET: api/<ActividadesController>
        [HttpGet]
        public JsonResult Get()
        {
            List<ActividadesPorHacer> actividades= context.ActividadesPorHacers.ToList();
            return new JsonResult(actividades);
        }

        // GET api/<ActividadesController>/5
        [HttpGet("{id}")]
        public JsonResult Get(int id)
        {
            ActividadesPorHacer? actividades = context.ActividadesPorHacers.Find(id);
            return new JsonResult(actividades);
        }

        // POST api/<ActividadesController>
        [HttpPost]
        public JsonResult Post([FromBody] ActividadesPorHacer value)
        {
            try
            {
                context.ActividadesPorHacers.Add(value);
                context.SaveChanges();
                return new JsonResult(true);
            }
            catch (Exception)
            {
                return new JsonResult(false);
            }

        }

        // PUT api/<ActividadesController>/5
        [HttpPut]
        public JsonResult Put([FromBody] ActividadesPorHacer value)
        {
            try
            {
                context.ActividadesPorHacers.Attach(value);
                this.context.Entry(value).State = EntityState.Modified;
                context.SaveChanges();
                return new JsonResult(true);
            }
            catch (Exception)
            {
                return new JsonResult(false);
            }
        }

        // DELETE api/<ActividadesController>/5
        [HttpDelete("{id}")]
        public JsonResult Delete(int id)
        {
            try
            {
                ActividadesPorHacer? actividades= context.ActividadesPorHacers.Find(id);
                if (actividades != null)
                {
                    context.ActividadesPorHacers.Remove(actividades);
                    context.SaveChanges();
                }
                else
                {
                    return new JsonResult(false);
                }

                return new JsonResult(true);
            }
            catch (Exception)
            {
                return new JsonResult(false);
            }
        }


        [HttpGet("{key}/{text}")]
        public JsonResult PreguntaUno(string key, string text)
        {
            bool flag = false;
            int tamanioKey = key.Length;
            string parteText = text.Substring(0,tamanioKey);
            int contador = 0;
            int contadorTamanio = text.Length - tamanioKey ;
            char [] array = new char[key.Length];
            for (int i = 0; i < text.Length; i++) {
                
                if (i <= contadorTamanio)
                {
                    parteText = text.Substring(i, tamanioKey);
                    if (parteText.Contains(key))
                    {
                        contador++;
                    }
                    //Cambiar if 
                    if ((tamanioKey + 1) == text.Length) {
                        parteText = text.Substring(i, tamanioKey + 1);
                        parteText = parteText.Remove(tamanioKey - 1, 1);
                        if (parteText.Contains(key))
                        {
                            contador++;
                        }
                    }
                    
                }
                else {
                    break;
                }               
              
            }

                     
            return new JsonResult(contador);
        }
    }
}
