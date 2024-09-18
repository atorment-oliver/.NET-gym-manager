using System;
using CAD.DAO;
using System.Data;
using RN.Entidades;
using System.Collections.Generic;

namespace RN.Componentes
{
    public class CConsulta
    {
        #region DMLS
        public static bool Insertar(Consulta objProxy)
        {
            ValidationException x = new ValidationException();
            if ((objProxy.ClienteId) < 0)
                x.AgregarError("Ingrese el id del cliente");

            if (x.Cantidad > 0)
                throw x;

            DAOConsulta daoProxy = new DAOConsulta();
            return daoProxy.Insertar(objProxy.ClienteId, objProxy.FechaConsulta, objProxy.Peso, objProxy.Talla, objProxy.Imc, objProxy.Pa, objProxy.Fr, objProxy.Fc, objProxy.Pulso,
            objProxy.Cabeza, objProxy.CardioPulmonar,objProxy.Abdomen, objProxy.GenitoUrinario, objProxy.Extremidades, objProxy.AntPatologicos, objProxy.EnfermedadesActuales,
            objProxy.Tabaco, objProxy.Alcohol, objProxy.Medicamentos, objProxy.EstiloActividad, objProxy.DescripcionActividad, objProxy.TipoActividad, objProxy.Conclusion,
            objProxy.Estado, objProxy.UsuarioId, objProxy.Fecha) > 0;
        }
        public static int InsertarId(Consulta objProxy)
        {
            ValidationException x = new ValidationException();
            if ((objProxy.ClienteId) < 0)
                x.AgregarError("Ingrese el id del cliente");

            if (x.Cantidad > 0)
                throw x;

            DAOConsulta daoProxy = new DAOConsulta();
            return daoProxy.Insertar(objProxy.ClienteId, objProxy.FechaConsulta, objProxy.Peso, objProxy.Talla, objProxy.Imc, objProxy.Pa, objProxy.Fr, objProxy.Fc, objProxy.Pulso,
            objProxy.Cabeza, objProxy.CardioPulmonar, objProxy.Abdomen, objProxy.GenitoUrinario, objProxy.Extremidades, objProxy.AntPatologicos, objProxy.EnfermedadesActuales,
            objProxy.Tabaco, objProxy.Alcohol, objProxy.Medicamentos, objProxy.EstiloActividad, objProxy.DescripcionActividad, objProxy.TipoActividad, objProxy.Conclusion,
            objProxy.Estado, objProxy.UsuarioId, objProxy.Fecha);
        }
        public static bool Actualizar(Consulta objProxy)
        {
            ValidationException x = new ValidationException();
            if (objProxy.Id <= 0)
                x.AgregarError("Ingrese el código");

            if ((objProxy.ClienteId) < 0)
                x.AgregarError("Ingrese el id del cliente");

            if (x.Cantidad > 0)
                throw x;

            DAOConsulta daoProxy = new DAOConsulta();
            return daoProxy.Actualizar(objProxy.Id, objProxy.ClienteId, objProxy.FechaConsulta, objProxy.Peso, objProxy.Talla, objProxy.Imc, objProxy.Pa, objProxy.Fr, objProxy.Fc, objProxy.Pulso,
            objProxy.Cabeza, objProxy.CardioPulmonar, objProxy.Abdomen, objProxy.GenitoUrinario, objProxy.Extremidades, objProxy.AntPatologicos, objProxy.EnfermedadesActuales,
            objProxy.Tabaco, objProxy.Alcohol, objProxy.Medicamentos, objProxy.EstiloActividad, objProxy.DescripcionActividad, objProxy.TipoActividad, objProxy.Conclusion,
            objProxy.Estado, objProxy.UsuarioId, objProxy.Fecha);
        }
        public static bool EliminarConsulta(int codigo)
        {
            ValidationException x = new ValidationException();
            if (codigo <= 0)
                x.AgregarError("Ingrese el código");

            if (x.Cantidad > 0)
                throw x;

            DAOConsulta daoProxy = new DAOConsulta();
            return daoProxy.Eliminar(codigo);
        }
       
        #endregion
        #region Selects
        public static List<Consulta> Traer()
        {
            DAOConsulta daoProxy = new DAOConsulta();
            DataSet dtsProxy = daoProxy.TraerConsultas();

            return CargarLista(dtsProxy.Tables[0]);
        }
        public static List<Consulta> TraerXId(int codigo)
        {
            DAOConsulta daoProxy = new DAOConsulta();
            DataSet dtsProxy = daoProxy.TraerConsultaXId(codigo);


            return CargarLista(dtsProxy.Tables[0]);
        }
        
        #endregion
        #region Metodos Privados
        private static List<Consulta> CargarLista(DataTable tabla)
        {
            List<Consulta> lstProxy = new List<Consulta>();

            foreach (DataRow fila in tabla.Rows)
            {
                lstProxy.Add(Cargar(fila));
            }
            return lstProxy;
        }
        private static Consulta Cargar(DataRow fila)
        {
            Consulta objProxy = new Consulta();
            objProxy.Id = Convert.ToInt32(fila["id"]);
            objProxy.ClienteId = Convert.ToInt32(fila["ClienteId"].ToString());
            objProxy.FechaConsulta = Convert.ToDateTime(fila["FechaConsulta"].ToString());
            objProxy.Peso = Convert.ToDouble(fila["peso"].ToString());
            objProxy.Talla = Convert.ToDouble(fila["talla"].ToString());
            objProxy.Imc = Convert.ToDouble(fila["imc"].ToString());
            objProxy.Pa = Convert.ToDouble(fila["pa"].ToString());
            objProxy.Fr = Convert.ToDouble(fila["fr"].ToString());
            objProxy.Fc = Convert.ToDouble(fila["fc"].ToString());
            objProxy.Pulso = Convert.ToDouble(fila["pulso"].ToString());
            objProxy.Cabeza = fila["Cabeza"].ToString();
            objProxy.CardioPulmonar = fila["CardioPulmonar"].ToString();
            objProxy.Abdomen = fila["Abdomen"].ToString();
            objProxy.GenitoUrinario = fila["GenitoUrinario"].ToString();
            objProxy.Extremidades = fila["Extremidades"].ToString();
            objProxy.AntPatologicos = fila["AntPatologicos"].ToString();
            objProxy.EnfermedadesActuales = fila["EnfermedadesActuales"].ToString();
            objProxy.Tabaco = Convert.ToBoolean(fila["Tabaco"].ToString());
            objProxy.Alcohol = fila["Alcohol"].ToString();
            objProxy.Medicamentos = fila["Medicamentos"].ToString();
            objProxy.EstiloActividad = fila["EstiloActividad"].ToString();
            objProxy.DescripcionActividad = fila["DescripcionActividad"].ToString();
            objProxy.TipoActividad = fila["TipoActividad"].ToString();
            objProxy.Conclusion = fila["Conclusion"].ToString();
            objProxy.Estado = Convert.ToBoolean(fila["Estado"].ToString());
            objProxy.UsuarioId = fila["UsuarioId"].ToString();
            objProxy.Fecha = Convert.ToDateTime(fila["Fecha"].ToString());
            return objProxy;
        }
        #endregion
    }
}
