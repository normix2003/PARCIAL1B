using System.ComponentModel.DataAnnotations;

namespace PARCIAL1B.models
{
    public class Elementos
    {
        [Key]
        public int ElementoID { get; set; }

        public int? EmpresaID { get; set; }
        public int? PlatoID { get; set; }

        public int? Elemento { get; set; }
        public int? CantidadMinima { get; set; }

        public int? CantidadMaxima { get; set; }
        public int? Costo { get; set; }
        public int? Estado{ get; set; }
      
    }
}
