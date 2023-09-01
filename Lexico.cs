using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO;

namespace LYA1_Lexico
{
    public class Lexico : Token, IDisposable
    {
        private StreamReader archivo;
        private StreamWriter Log;
        public Lexico()
        {
            archivo = new StreamReader("prueba.cpp");
            Log = new StreamWriter("Last_Log.log");
        }
        public void Dispose()
        {
            archivo.Close();
            Log.Close();
        }

        public void nextToken(){
            char c;
            String buffer = "";
            while(char.IsWhiteSpace(c = (char)archivo.Read())){
            }
            
            buffer += c;
            if (char.IsLetter(c)){
                setClasificacion(Tipos.Identificador);
                while(char.IsLetterOrDigit(c = (char)archivo.Peek())){
                    buffer += c;
                    archivo.Read();
                }
                
            }
            else if (char.IsDigit(c)){
                setClasificacion(Tipos.Numero);
                while(char.IsDigit(c = (char)archivo.Peek())){
                    buffer += c;
                    archivo.Read();
                }
            }
            else if (c == '='){
                setClasificacion(Tipos.Asignacion);

            }
            else if (c == ';'){
                setClasificacion(Tipos.FinSentencia);
            }
            else{
                setClasificacion(Tipos.Caracter);
            }
            setContenido(buffer);
            Log.WriteLine(getContenido() + " : " + getClasificacion());
        }

    }
}