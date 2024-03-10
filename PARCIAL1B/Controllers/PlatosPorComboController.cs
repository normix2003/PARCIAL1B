using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PARCIAL1B.models;

namespace PARCIAL1B.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlatosPorComboController : ControllerBase
    {
        private readonly ElementosContext _elementosContext;
        public PlatosPorComboController(ElementosContext elementosContext)
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
            List<PlatosPorCombo> ListadoPlatosPorCombo = (from e in _elementosContext.PlatosPorCombo
                                                          select e).ToList();
            if (ListadoPlatosPorCombo.Count == 0)
            { return NotFound(); }

            return Ok(ListadoPlatosPorCombo);

        }




        //crear

        [HttpPost]
        [Route("add")]
        public IActionResult GuardarPlatosPorCombo([FromBody] PlatosPorCombo PlatosPorCombo)
        {
            try

            {

                _elementosContext.PlatosPorCombo.Add(PlatosPorCombo);
                _elementosContext.SaveChanges();

                return Ok(PlatosPorCombo);

            }

            catch (Exception ex)

            {
                return BadRequest(ex.Message);
            }


        }


        //modificar

        [HttpPut]
        [Route("actualizar/{id}")]
        public ActionResult ActualizarPlatosPorComboEquipo(int id, [FromBody] PlatosPorCombo PlatosPorComboModificar)
        {
            PlatosPorCombo? PlatosPorComboActual = (from e in _elementosContext.PlatosPorCombo where e.PlatosPorComboID == id select e).FirstOrDefault();

            if (PlatosPorComboActual == null)
            {
                return NotFound();
            }

            PlatosPorComboActual.PlatoID = PlatosPorComboModificar.PlatoID;
            PlatosPorComboActual.EmpresaID = PlatosPorComboModificar.EmpresaID;
            PlatosPorComboActual.PlatosPorComboID = PlatosPorComboModificar.PlatosPorComboID;
            PlatosPorComboActual.ComboID = PlatosPorComboModificar.ComboID;
            PlatosPorComboActual.Estado = PlatosPorComboModificar.Estado;
            

            _elementosContext.Entry(PlatosPorComboActual).State = EntityState.Modified;

            _elementosContext.SaveChanges();

            return Ok(PlatosPorComboActual);
        }
        //Eliminar
        [HttpDelete]
        [Route("eliminar/{id}")]
        public ActionResult EliminarPlatosPorCombo(int id)
        {
            PlatosPorCombo? PlatosPorCombo = (from e in _elementosContext.PlatosPorCombo where e.PlatosPorComboID == id select e).FirstOrDefault();

            // Verificamos que exista el registro según su ID
            if (PlatosPorCombo == null)
            {
                return NotFound();
            }

            _elementosContext.PlatosPorCombo.Attach(PlatosPorCombo);
            _elementosContext.PlatosPorCombo.Remove(PlatosPorCombo);
            _elementosContext.SaveChanges();

            return Ok(PlatosPorCombo);
        }
    }
}
