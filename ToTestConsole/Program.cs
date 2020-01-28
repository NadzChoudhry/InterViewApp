using Demo.PersistenceLayer.Context;
using Demo.PersistenceLayer.Utils;
using System;

namespace ToTestConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                DataSeeder.AddData();
                Console.WriteLine("Datos Cargados Correctamente.");
            }
            catch (Exception exp)
            {
                Console.WriteLine("Ha Ocurrido un error al cargar Datos!");
            }

            Console.ReadKey();
        }
    }
}
