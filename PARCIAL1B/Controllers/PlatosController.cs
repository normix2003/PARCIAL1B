﻿using Microsoft.AspNetCore.Http;
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


        //modificar

        [HttpPut]
        [Route("actualizar/{id}")]
        public ActionResult ActualizarEquipo(int id, [FromBody] Platos platosModificar)
        {
            Platos? platoActual = (from e in _elementosContext.Platos where e.PlatoID == id select e).FirstOrDefault();

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
