using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PARCIAL1B.models;
using Microsoft.EntityFrameworkCore;

namespace PARCIAL1B.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlatosController : ControllerBase
    {
        private readonly ElementosContext _elementosContext;

        public PlatosController(ElementosContext elementosContext)
        {
            _elementosContext = elementosContext;
        }

        [HttpGet]
        [Route("GetAll")]
        public IActionResult Get() 
        { 
            List<Platos> listadoPlatos = (from e in _elementosContext.Platos
                                          select e).ToList();
            
            if (listadoPlatos.Count() == 0)
            {
                return NotFound();
            }

            return Ok(listadoPlatos);
        }

        //crear

        [HttpPost]
        [Route("add")]
        public IActionResult GuardarPlato([FromBody] Platos platos)
        {
            try

            {

                _elementosContext.Platos.Add(platos);
                _elementosContext.SaveChanges();

                return Ok(platos);

            }

            catch (Exception ex)

            {
                return BadRequest(ex.Message);
            }


        }


        
    }
}
