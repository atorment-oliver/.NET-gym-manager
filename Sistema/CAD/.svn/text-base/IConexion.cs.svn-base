using System;
using System.Data;
using System.Collections.Generic;
using System.Data.Common;

namespace CAD
{
    public interface IConexion
    {
        DataSet EjecutarConsulta(string sql);
        DataSet EjecutarConsulta(List<DbParameter> parametros, string sql);

        bool EjecutarDML(string sql);
        bool EjecutarDML(List<DbParameter> parametros, string sql);
    }
}
