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

        public void nextToken()
        {
            char c;
            String buffer = "";
            while (char.IsWhiteSpace(c = (char)archivo.Read()))
            {
            }

            buffer += c;
            if (char.IsLetter(c))
            {
                setClasificacion(Tipos.Identificador);
                while (char.IsLetterOrDigit(c = (char)archivo.Peek()))
                {
                    buffer += c;
                    archivo.Read();
                }

            }
            else if (char.IsDigit(c))
            {
                setClasificacion(Tipos.Numero);
                while (char.IsDigit(c = (char)archivo.Peek()))
                {
                    buffer += c;
                    archivo.Read();
                }
            }
            else if (c == '=')
            {
                setClasificacion(Tipos.Asignacion);
                if ((c = (char)archivo.Peek()) == '=')
                {
                    setClasificacion(Tipos.OperadorRelacional);
                    buffer += c;
                    archivo.Read();
                }

            }
            else if (c == '+')
            {
                setClasificacion(Tipos.OperadorTermino);

                if ((c = (char)archivo.Peek()) == '+' || c == '=')
                {
                    setClasificacion(Tipos.IncrementoTermino);
                    buffer += c;
                    archivo.Read();
                }

            }
            else if (c == '-')
            {
                setClasificacion(Tipos.OperadorTermino);

                if ((c = (char)archivo.Peek()) == '-' || c == '=')
                {
                    setClasificacion(Tipos.IncrementoTermino);
                    buffer += c;
                    archivo.Read();
                }

            }

            else if (c == '*' || c == '/' || c == '%')
            {
                setClasificacion(Tipos.OperadorFactor);
                if ((c = (char)archivo.Peek()) == '=')
                {
                    setClasificacion(Tipos.OperadorFactor);
                    buffer += c;
                    archivo.Read();
                }
            }

            else if (c == ';')
            {
                setClasificacion(Tipos.FinSentencia);
            }
            else if (c == '{')
            {
                setClasificacion(Tipos.Inicio);
            }
            else if (c == '}')
            {
                setClasificacion(Tipos.Fin);
            }

            else if (c == '!')
            {
                setClasificacion(Tipos.OperadorLogico);
                if ((c = (char)archivo.Peek()) == '=')
                {
                    setClasificacion(Tipos.OperadorRelacional);
                    buffer += c;
                    archivo.Read();
                }
            }

            else if (c == '&')
            {
                if ((c = (char)archivo.Peek()) == '&')
                {
                    setClasificacion(Tipos.OperadorLogico);
                    buffer += c;
                    archivo.Read();
                }
                else
                {
                    setClasificacion(Tipos.Caracter);
                }
            }

            else if (c == '|')
            {
                if ((c = (char)archivo.Peek()) == '|')
                {
                    setClasificacion(Tipos.OperadorLogico);
                    buffer += c;
                    archivo.Read();
                }
                else
                {
                    setClasificacion(Tipos.Caracter);
                }
            }

            else if (c == '<' || c == '>')
            {
                setClasificacion(Tipos.OperadorRelacional);
                if ((c = (char)archivo.Peek()) == '=')
                {
                    buffer += c;
                    archivo.Read();
                }
            }

            else
            {
                setClasificacion(Tipos.Caracter);
            }
            setContenido(buffer);
            Log.WriteLine("[" + getContenido() + "] : " + getClasificacion());
        }

        public bool FinArchivo()
        {
            return archivo.EndOfStream;
        }

    }
}