using Microsoft.EntityFrameworkCore;

namespace PARCIAL1B.models
{
    public class ElementosContext: DbContext
    {

        public ElementosContext(DbContextOptions<ElementosContext> options) : base(options)
            {

            }

            public DbSet<Elementos> Elementos { get; set; }
            public DbSet<ElementosPorPlato> ElementosPorPlato { get; set; }
            public DbSet<Platos> Platos { get; set; }
            public DbSet<PlatosPorCombo> PlatosPorCombo { get; set; }

        


        
    }
}
