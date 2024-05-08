using BackEnd.Models;
using Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RestauranteController : ControllerBase
    {
        private readonly ExperienciaUrbanaContext context;
        public RestauranteController()
        {
            context = new ExperienciaUrbanaContext();
        }


        // GET: api/<RestauranteController>
        [HttpGet]
        public JsonResult Get()
        {
            List<Restaurante> restaurantes = context.Restaurantes.ToList();
            return new JsonResult(restaurantes);
        }

        // GET api/<RestauranteController>/5
        [HttpGet("{id}")]
        public JsonResult Get(int id)
        {
            Restaurante? restaurante = context.Restaurantes.Find(id);
            return new JsonResult(restaurante);
        }

        // POST api/<RestauranteController>
        [HttpPost]
        public JsonResult Post([FromBody] Restaurante value)
        {
            try
            {
                context.Restaurantes.Add(value);
                context.SaveChanges();
                return new JsonResult(true);
            }
            catch (Exception)
            {
                return new JsonResult(false);
            }

        }

        // PUT api/<RestauranteController>/5
        [HttpPut]
        public JsonResult Put([FromBody] Restaurante value)
        {
            try
            {
                context.Restaurantes.Attach(value);
                this.context.Entry(value).State = EntityState.Modified;
                context.SaveChanges();
                return new JsonResult(true);
            }
            catch (Exception)
            {
                return new JsonResult(false);
            }
        }
        // DELETE api/<RestauranteController>/5
        [HttpDelete("{id}")]
        public JsonResult Delete(int id)
        {
            try
            {
                Restaurante? restaurante = context.Restaurantes.Find(id);
                if (restaurante != null)
                {
                    context.Restaurantes.Remove(restaurante);
                    context.SaveChanges();
                }
                else { 
                    return new JsonResult(false);
                }
                
                return new JsonResult(true);
            }
            catch (Exception)
            {
                return new JsonResult(false);
            }
        }
    }
}
