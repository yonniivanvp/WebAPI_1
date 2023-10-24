using API_SAT_1.DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace API_SAT_1.DAL
{
    public class DataBaseContext : DbContext
    {
        //Con este constructor me podré conectar a la BD, me brinda unas opciones de configuracion que ya estan definidas internamente
        public DataBaseContext(DbContextOptions<DataBaseContext>options) : base(options) 
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Country>().HasIndex(c => c.Name).IsUnique();// Esto es un indice para evitar nombres duplicados de paises
        }

        public DbSet<Country> Countries { get; set; } //Esta linea me toma la clase Country y me la mapea en SQL SERVER para crear una tabla llamada COUNTRIES

        //Por cada nueva entidad que yo creo, debo crearle su Dbset
    }
}
