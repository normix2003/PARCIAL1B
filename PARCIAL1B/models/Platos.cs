using System.ComponentModel.DataAnnotations;

namespace PARCIAL1B.models
{
    public class Platos
    {
        {
            [Key]
            public int PlatoID { get; set; }

            public int? EmpresaID { get; set; }
            public int? GrupoID { get; set; }

            public string NombrePlato { get; set; }
            public string DescripcionPlato { get; set; }
            public float? Precio { get; set; }
          

    }
}
