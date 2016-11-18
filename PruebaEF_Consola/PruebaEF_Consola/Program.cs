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

            string p1 = ctx.Perfiles.Select(p => p.Descripcion).FirstOrDefault();
            //Console.WriteLine($"{p.Descripcion}");
            Console.ReadLine();
            ctx.Dispose();
        }
    }
}
