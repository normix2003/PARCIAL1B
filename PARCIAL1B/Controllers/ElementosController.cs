using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace PARCIAL1B.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ElementosController : ControllerBase
    {

        private readonly equiposContext _equiposContext;
        public equiposController(equiposContext equiposContext)
        {
            _equiposContext = equiposContext;
        }

        [HttpGet]
        [Route("GetAll")]
        public IActionResult Get()
        {
            List<Equipos> ListadoEquipo = (from e in _equiposContext.Equipos
                                           select e).ToList();
            if (ListadoEquipo.Count == 0)
            { return NotFound(); }

            return Ok(ListadoEquipo);

        }
        [HttpGet]
        [Route("GetById/{id}")]
        public IActionResult Get(int id)
        {
            Equipos? equipo = (from e in _equiposContext?.Equipos where e.id_equipos == id select e).FirstOrDefault();

            if (equipo == null)
            {
                return NotFound();
            }

            return Ok(equipo);
        }

        //BUSCAR POR DESCRIPCION 
        [HttpGet]
        [Route("Find/{filtro}")]
        public IActionResult FindByDescription(string filtro)
        {
            Equipos? equipo = (from e in _equiposContext.Equipos where e.descripcion.Contains(filtro) select e).FirstOrDefault();

            if (equipo == null)
            { return NotFound(); }

            return Ok(equipo);
        }




        //crear

        [HttpPost]
        [Route("add")]
        public IActionResult GuardarEquipo([FromBody] Equipos equipos)
        {
            try

            {

                _equiposContext.Equipos.Add(equipos);
                _equiposContext.SaveChanges();

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
        public ActionResult ActualizarEquipo(int id, [FromBody] Equipos equipoModificar)
        {
            Equipos? equipoActual = (from e in _equiposContext.Equipos where e.id_equipos == id select e).FirstOrDefault();

            if (equipoActual == null)
            {
                return NotFound();
            }

            equipoActual.nombre = equipoModificar.nombre;
            equipoActual.descripcion = equipoModificar.descripcion;
            equipoActual.marca_id = equipoModificar.marca_id;
            equipoActual.vida_util = equipoModificar.vida_util;
            equipoActual.anio_compra = equipoModificar.anio_compra;
            equipoActual.costo = equipoModificar.costo;

            _equiposContext.Entry(equipoActual).State = EntityState.Modified;

            _equiposContext.SaveChanges();

            return Ok(equipoActual);
        }

        [HttpDelete]
        [Route("eliminar/{id}")]
        public ActionResult EliminarEquipo(int id)
        {
            Equipos? equipo = (from e in _equiposContext.Equipos where e.id_equipos == id select e).FirstOrDefault();

            // Verificamos que exista el registro según su ID
            if (equipo == null)
            {
                return NotFound();
            }

            _equiposContext.Equipos.Attach(equipo);
            _equiposContext.Equipos.Remove(equipo);
            _equiposContext.SaveChanges();

            return Ok(equipo);
        }
    }
}
