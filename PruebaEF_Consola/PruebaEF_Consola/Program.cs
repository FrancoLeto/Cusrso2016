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
            Perfil p = ctx.Perfiles.FirstOrDefault();
            Console.WriteLine($"{p.Descripcion}");
        }
    }
}
