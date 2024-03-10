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
        public IActionResult GuardarElementos([FromBody] Elementos Elementos)
        {
            try

            {

                _elementosContext.Elementos.Add(Elementos);
                _elementosContext.SaveChanges();

                return Ok(Elementos);

            }

            catch (Exception ex)

            {
                return BadRequest(ex.Message);
            }


        }


        //modificar

        [HttpPut]
        [Route("actualizar/{id}")]
        public ActionResult ActualizarElementos(int id, [FromBody] Elementos elementoModificar)
        {
            Elementos? elementoActual = (from e in _elementosContext.Elementos where e.ElementosID == id select e).FirstOrDefault();

            if (elementoActual == null)
            {
                return NotFound();
            }

            elementoActual.ElementosID = elementoModificar.ElementosID;
            elementoActual.EmpresaID = elementoModificar.EmpresaID;
            elementoActual.UnidadMedida = elementoModificar.UnidadMedida;
            elementoActual.CantidadMinima = elementoModificar.CantidadMinima;
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
            Elementos? Elementos = (from e in _elementosContext.Elementos where e.ElementosID == id select e).FirstOrDefault();

            // Verificamos que exista el registro según su ID
            if (Elementos == null)
            {
                return NotFound();
            }

            _elementosContext.Elementos.Attach(Elementos);
            _elementosContext.Elementos.Remove(Elementos);
            _elementosContext.SaveChanges();

            return Ok(Elementos);
        }



        [HttpGet]
        [Route("Find/{filtro}")]
        public IActionResult FindByDescription(string filtro)
        {
            Elementos? elementos = (from e in _elementosContext.Elementos where e.Elemento.Contains(filtro) select e).FirstOrDefault();

            if (elementos == null)
            { return NotFound(); }

            return Ok(elementos);
        }

        [HttpGet]
        [Route("GetById/{id}")]
        public IActionResult Get(int id)
        {
            var elementos = (from e in _elementosContext?.Elementos
                                    join epp in _elementosContext?.ElementosPorPlato
                                        on e.ElementosID equals epp.ElementoID
                                    join p in _elementosContext?.Platos
                                        on epp.PlatoID equals p.PlatoID


                                    where e.ElementosID == id 
                                    
                                    select new {
                                      e.EmpresaID,
                                      e.CantidadMinima,
                                      e.UnidadMedida,
                                      e.Costo,
                                      e.Elemento,
                                      p.PlatoID,
                                      p.NombrePlato,
                                      p.Precio
                                    }
                                    
                                    
                                    ).ToList();

            if (elementos == null)
            {
                return NotFound();
            }

            return Ok(elementos);
        }
    }

}
