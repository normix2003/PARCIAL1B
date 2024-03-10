﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PARCIAL1B.models;

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


        //CRUD

        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        //Obtener

        [HttpGet]
        [Route("GetAll")]
        public IActionResult Get()
        {
            List<Platos> ListadoPlatos = (from e in _elementosContext.Platos
                                          select e).ToList();
            if (ListadoPlatos.Count == 0)
            { return NotFound(); }

            return Ok(ListadoPlatos);

        }




        //crear

        [HttpPost]
        [Route("add")]
        public IActionResult GuardarPlatos([FromBody] Platos Platos)
        {
            try

            {

                _elementosContext.Platos.Add(Platos);
                _elementosContext.SaveChanges();

                return Ok(Platos);

            }

            catch (Exception ex)

            {
                return BadRequest(ex.Message);
            }


        }


        //modificar

        [HttpPut]
        [Route("actualizar/{id}")]
        public ActionResult ActualizarPlatos(int id, [FromBody] Platos PlatosModificar)
        {
            Platos? PlatosActual = (from e in _elementosContext.Platos where e.PlatoID == id select e).FirstOrDefault();

            if (PlatosActual == null)
            {
                return NotFound();
            }

            PlatosActual.ElementoID = PlatosModificar.ElementoID;
            PlatosActual.EmpresaID = PlatosModificar.EmpresaID;
            PlatosActual.CantidadMinima = PlatosModificar.CantidadMaxima;
            PlatosActual.CantidadMinima = PlatosModificar.CantidadMinima;
            PlatosActual.PlatoID = PlatosModificar.PlatoID;
            PlatosActual.Costo = PlatosModificar.Costo;
            

            _elementosContext.Entry(PlatosActual).State = EntityState.Modified;

            _elementosContext.SaveChanges();

            return Ok(PlatosActual);
        }


        //Eliminar
        [HttpDelete]
        [Route("eliminar/{id}")]
        public ActionResult EliminarPlatos(int id)
        {
            Platos? Platos = (from e in _elementosContext.Platos where e.PlatoID == id select e).FirstOrDefault();

            // Verificamos que exista el registro según su ID
            if (Platos == null)
            {
                return NotFound();
            }

            _elementosContext.Platos.Attach(Platos);
            _elementosContext.Platos.Remove(Platos);
            _elementosContext.SaveChanges();

            return Ok(Platos);
        }

    }
}
