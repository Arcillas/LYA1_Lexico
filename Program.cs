using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LYA1_Lexico
{
    class Program
    {
        static void Main(string[] args) 
        {
            try
            {
                using (Lexico L = new Lexico())
                {
                    L.setContenido("");
                    L.setClasificacion(Token.Tipos.Identificador);
                    

                    while(!L.FinArchivo())
                    {
                        L.nextToken();
                    }


                    Console.WriteLine(L.getContenido());
                    Console.WriteLine(L.getClasificacion());

                }
            } 
            catch (Exception e)
            {
                Console.WriteLine("Error: "+e.Message);
            }
        }
    }
}