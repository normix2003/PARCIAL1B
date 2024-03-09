using Microsoft.EntityFrameworkCore;

namespace PARCIAL1B.models
{
    public class ElementosContext: DbContext
    {

        public ElementosContext(DbContextOptions<ElementosContext> options) : base(options)
            {

            }

            public DbSet<Equipos> Equipos { get; set; }


        
    }
}
