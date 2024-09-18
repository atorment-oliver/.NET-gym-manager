using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RN
{
    public class ValidationException : Exception
    {
        private List<string> errores;

        public ValidationException() : base("Errores de validación")
        {            
            errores = new List<string>();
        }
        public void AgregarError(string error)
        {
            errores.Add(error);
        }
        public List<string> Errores()
        {
            return errores;
        }
        public int Cantidad
        {
            get { return errores.Count; }
        }
        public string ListarErrores(string separador)
        {
            string lista = string.Empty;
            foreach (string error in errores)
            {
                lista += "- " + error + separador;
            }
            return lista;
        }
    }
}
