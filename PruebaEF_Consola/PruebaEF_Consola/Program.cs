using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data;
using Entidades;

namespace PruebaEF_Consola
{
    class Program
    {
        static void Main(string[] args)
        {
            TestEFContext ctx = new TestEFContext();
            if (ctx.Database.Exists()) {
                //string sql = "select * from perfiles";
                ctx.Database.Connection.Open();
                //ctx.Database.SqlQuery(sql, ctx.Database.Connection.ToString());
                ctx.Database.Connection.Close();
                Console.WriteLine("La Base esta..");
                Console.ReadLine(); 
            }

            //  Perfil p1 = ctx.Perfiles.FirstOrDefault();

            //Console.WriteLine($"{p.Descripcion}");

            //  Console.ReadLine();

            // Console.WriteLine($"{p1.Descripcion}");
            //    Usuario u = ctx.Usuarios.FirstOrDefault();

            //Console.WriteLine($"{u.Login} {u.perfil.Descripcion}");
            //Perfil p1 = new Perfil();


          
            Perfil p1 = ctx.Perfiles
                .Where(per => per.Descripcion.ToLower() == "avanzado").FirstOrDefault();
            if (p1 == null) {

                p1 = new Perfil();
                p1.Descripcion = "Avanzado";

            }

            //p1.Descripcion = "Invitados";
            Usuario u = new Usuario();

            u.Login = "thedy5";
            u.perfil = p1;

            ctx.Usuarios.Add(u);
            ctx.SaveChanges();
            
            /*
            Usuario usr = ctx.Usuarios.Where(u => u.Login == "thedy").FirstOrDefault();
            //Console.WriteLine($"{usr.Login} {usr.perfil.Descripcion}");


            Perfil p = usr.perfil;


    */



               Console.ReadLine();
            ctx.Dispose();
        }
    }
}
