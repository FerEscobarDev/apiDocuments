using Microsoft.EntityFrameworkCore;

namespace apiDocuments
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }

        //Aquí van los modelos de las tablas que se van a crear
        //public DbSet<NombreModelo> NombreModeloPlural { get; set; }
    }
}
