using Microsoft.EntityFrameworkCore;
using SocialMusic.Models;

namespace SocialMusic.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        
        //Estas son las tablas
        public DbSet<CUsuarioMusico> UsuariosMusicos { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            base.OnModelCreating(modelBuilder);

            //############### TABLA usuarios_musicos
            modelBuilder.Entity<CUsuarioMusico>(tb =>
            {
                tb.ToTable("usuarios_musicos");


                tb.HasKey(col => col.Id);
                tb.HasIndex(col => col.Id);
                tb.Property(col => col.Id)
                .UseIdentityColumn().ValueGeneratedOnAdd();

                tb.Property(col => col.Name).HasMaxLength(100).IsRequired();
                tb.HasIndex(col => col.Name);

                tb.Property(col => col.Password).HasMaxLength(200).IsRequired();

                tb.Property(col => col.Email).HasMaxLength(100).IsRequired();
                tb.HasIndex(col => col.Email).IsUnique();
                
                //valor puesto desde sql
                tb.Property(col => col.CreatedAt).HasDefaultValueSql("NOW()");
                //valr puesto desde c#
                tb.Property(col => col.IsActive).HasDefaultValue(true);
            });

        }
    }
}
