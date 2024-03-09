using System.ComponentModel.DataAnnotations;

namespace PARCIAL1B.models
{
    public class PlatosPorCombo
    {
        [Key]
        public int PlatosPorComboID { get; set; }

        public int? EmpresaID { get; set; }

        public int? ComboID { get; set; }
        public int? PlatoID { get; set; }

        public int? Estado { get; set; }
    }
}
