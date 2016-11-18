using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using Entidades;
using System.Data.Entity.ModelConfiguration;
using System.IO;

namespace Data
{
    public class TestEFContext : DbContext
    {
        StreamWriter log;
        public TestEFContext() {

            log = File.CreateText("d:\\log.txt");
            this.Database.Log = (l) => log.WriteLine(l);

        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
            log.Close();
        }
        // public DbSet<Usuario> Usuarios { get; set; }

        public DbSet<Perfil> Perfiles { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new ConfiguraPerfil() );
        }
        
    }
    public class ConfiguraPerfil : EntityTypeConfiguration<Perfil> {
        public ConfiguraPerfil() {
            this.HasKey(p => p.IDPerfil);
            this.Property(p => p.IDPerfil).HasColumnName("Id_Perfil");
            this.ToTable("Perfiles");
        }

    }
    /*
    public class ConfiguraUsuario : EntityTypeConfiguration<Usuario>
    {
        public ConfiguraUsuario()
        {

        }

    }
    */
}
