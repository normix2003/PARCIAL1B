using System.ComponentModel.DataAnnotations;

namespace PARCIAL1B.models
{
    public class Elementos
    {
        [Key]
        public int ElementosID { get; set; }

        public int? EmpresaID { get; set; }

        public string? Elemento { get; set; }
        public int? CantidadMinima { get; set; }

        public float UnidadMedida { get; set; }
        public float Costo { get; set; }
        public int? Estado{ get; set; }
      
    }
}
