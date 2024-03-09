using System.ComponentModel.DataAnnotations;

namespace PARCIAL1B.models
{
    public class PlatosPorCombo
    {
        [Key]
        public int ElementoPorPlatoID { get; set; }

        public int? EmpresaID { get; set; }
        public int? PlatoID { get; set; }

        public int? ElementoID { get; set; }
        public int? Cantidad { get; set; }

        public int? Estado { get; set; }
    }
}
