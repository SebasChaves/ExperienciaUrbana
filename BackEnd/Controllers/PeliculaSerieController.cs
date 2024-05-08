using Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PeliculaSerieController : ControllerBase
    {

        private readonly ExperienciaUrbanaContext context;

        public PeliculaSerieController() { 
            context = new ExperienciaUrbanaContext();
        }

        // GET: api/<PeliculaSerieController>
        [HttpGet]
        public JsonResult Get()
        {
            List<PeliculaSerie> peliculaSerie= context.PeliculaSeries.ToList();
            return new JsonResult(peliculaSerie);
        }

        // GET api/<RestauranteController>/5
        [HttpGet("{id}")]
        public JsonResult Get(int id)
        {
            PeliculaSerie? pelicula= context.PeliculaSeries.Find(id);
            return new JsonResult(pelicula);
        }

        // POST api/<RestauranteController>
        [HttpPost]
        public JsonResult Post([FromBody] PeliculaSerie value)
        {
            try
            {
                context.PeliculaSeries.Add(value);
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
        public JsonResult Put([FromBody] PeliculaSerie value)
        {
            try
            {
                context.PeliculaSeries.Attach(value);
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
                PeliculaSerie? restaurante = context.PeliculaSeries.Find(id);
                if (restaurante != null)
                {
                    context.PeliculaSeries.Remove(restaurante);
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
    }
}
