using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PARCIAL1B.models;

namespace PARCIAL1B.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    
    public class ElementosPorPlatoController : ControllerBase
    {
        private readonly ElementosContext _elementosContext;
        public ElementosPorPlatoController(ElementosContext elementosContext)
        {
            _elementosContext = elementosContext;
        }

        //CRUD

        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        //Obtener

        [HttpGet]
        [Route("GetAll")]
        public IActionResult Get()
        {
            List<ElementosPorPlato> ListadoElementosPorPlato = (from e in _elementosContext.ElementosPorPlato
                                                select e).ToList();
            if (ListadoElementosPorPlato.Count == 0)
            { return NotFound(); }

            return Ok(ListadoElementosPorPlato);

        }




        //crear

        [HttpPost]
        [Route("add")]
        public IActionResult GuardarElementosPorPlato([FromBody] ElementosPorPlato ElementosPorPlato)
        {
            try

            {

                _elementosContext.ElementosPorPlato.Add(ElementosPorPlato);
                _elementosContext.SaveChanges();

                return Ok(ElementosPorPlato);

            }

            catch (Exception ex)

            {
                return BadRequest(ex.Message);
            }


        }


        //modificar

        [HttpPut]
        [Route("actualizar/{id}")]
        public ActionResult ActualizarElementosPorPlato(int id, [FromBody] ElementosPorPlato ElementosPorPlatoModificar)
        {
            ElementosPorPlato? ElementosPorPlatoActual = (from e in _elementosContext.ElementosPorPlato where e.ElementoPorPlatoID == id select e).FirstOrDefault();

            if (ElementosPorPlatoActual == null)
            {
                return NotFound();
            }

            ElementosPorPlatoActual.ElementoPorPlatoID = ElementosPorPlatoModificar.ElementoPorPlatoID;
            ElementosPorPlatoActual.ElementoID = ElementosPorPlatoModificar.ElementoID;
            ElementosPorPlatoActual.PlatoID = ElementosPorPlatoModificar.PlatoID;
            ElementosPorPlatoActual.Cantidad = ElementosPorPlatoModificar.Cantidad;
            ElementosPorPlatoActual.EmpresaID = ElementosPorPlatoModificar.EmpresaID;
            ElementosPorPlatoActual.Estado = ElementosPorPlatoModificar.Estado;
            

            _elementosContext.Entry(ElementosPorPlatoActual).State = EntityState.Modified;

            _elementosContext.SaveChanges();

            return Ok(ElementosPorPlatoActual);
        }
        //Eliminar
        [HttpDelete]
        [Route("eliminar/{id}")]
        public ActionResult EliminarElementosPorPlato(int id)
        {
            ElementosPorPlato? ElementosPorPlato = (from e in _elementosContext.ElementosPorPlato where e.ElementoPorPlatoID == id select e).FirstOrDefault();

            // Verificamos que exista el registro según su ID
            if (ElementosPorPlato == null)
            {
                return NotFound();
            }

            _elementosContext.ElementosPorPlato.Attach(ElementosPorPlato);
            _elementosContext.ElementosPorPlato.Remove(ElementosPorPlato);
            _elementosContext.SaveChanges();

            return Ok(ElementosPorPlato);
        }


    }
}
