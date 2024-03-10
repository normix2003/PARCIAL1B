using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PARCIAL1B.models;

namespace PARCIAL1B.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ElementosController : ControllerBase
    {

        private readonly ElementosContext _elementosContext;
        public ElementosController(ElementosContext elementosContext)
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
            List<Elementos> ListadoElementos = (from e in _elementosContext.Elementos
                                                select e).ToList();
            if (ListadoElementos.Count == 0)
            { return NotFound(); }

            return Ok(ListadoElementos);

        }




        //crear

        [HttpPost]
        [Route("add")]
        public IActionResult GuardarEquipo([FromBody] Elementos equipos)
        {
            try

            {

                _elementosContext.Elementos.Add(equipos);
                _elementosContext.SaveChanges();

                return Ok(equipos);

            }

            catch (Exception ex)

            {
                return BadRequest(ex.Message);
            }


        }


        //modificar

        [HttpPut]
        [Route("actualizar/{id}")]
        public ActionResult ActualizarEquipo(int id, [FromBody] Elementos elementoModificar)
        {
            Elementos? elementoActual = (from e in _elementosContext.Elementos where e.ElementoID == id select e).FirstOrDefault();

            if (elementoActual == null)
            {
                return NotFound();
            }

            elementoActual.ElementoID = elementoModificar.ElementoID;
            elementoActual.EmpresaID = elementoModificar.EmpresaID;
            elementoActual.CantidadMinima = elementoModificar.CantidadMaxima;
            elementoActual.CantidadMinima = elementoModificar.CantidadMinima;
            elementoActual.PlatoID = elementoModificar.PlatoID;
            elementoActual.Costo = elementoModificar.Costo;
            elementoActual.Estado = elementoModificar.Estado;
            elementoActual.Elemento = elementoModificar.Elemento;

            _elementosContext.Entry(elementoActual).State = EntityState.Modified;

            _elementosContext.SaveChanges();

            return Ok(elementoActual);
        }
        //Eliminar
        [HttpDelete]
        [Route("eliminar/{id}")]
        public ActionResult EliminarElemento(int id)
        {
            Elementos? equipo = (from e in _elementosContext.Elementos where e.ElementoID == id select e).FirstOrDefault();

            // Verificamos que exista el registro según su ID
            if (equipo == null)
            {
                return NotFound();
            }

            _elementosContext.Elementos.Attach(equipo);
            _elementosContext.Elementos.Remove(equipo);
            _elementosContext.SaveChanges();

            return Ok(equipo);
        }



        //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        [HttpGet]
        [Route("GetById/{id}")]
        public IActionResult Get(int id)
        {
            Elementos? elementos = (from e in _elementosContext?.Elementos where e.ElementoID == id select e).FirstOrDefault();

            if (elementos == null)
            {
                return NotFound();
            }

            return Ok(elementos);
        }


    }

}
