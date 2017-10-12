using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeStock.DAL.Interfaces;
using WeStock.Entities;

namespace WeStock.DAL
{
    public class UsuariosDAL
    {
        public static Usuario ValidarUsuario(string nombreUsuario, string password)
        {
            List<SqlParameter> lstParams = new List<SqlParameter>();
            lstParams.Add(SqlServerHelper.GetParam("@nombreUsuario", nombreUsuario));
            lstParams.Add(SqlServerHelper.GetParam("@password", password));

            using (var reader = SqlServerHelper.ExecuteReader("dbo.ValidarUsuario", lstParams))
            {
                return reader.DataReaderMapToEntity<Usuario>();
            }
        }

        public static int CrearUsuario(string nombre, string nombreUsuario, string password, string email)
        {
            List<SqlParameter> lstParams = new List<SqlParameter>();
            lstParams.Add(SqlServerHelper.GetParam("@nombre", nombre));
            lstParams.Add(SqlServerHelper.GetParam("@nombreUsuario", nombreUsuario));
            lstParams.Add(SqlServerHelper.GetParam("@password", password));
            lstParams.Add(SqlServerHelper.GetParam("@email", email));

            SqlParameter param = SqlServerHelper.GetParamIntOuput("@idUsuario");
            lstParams.Add(param);

            SqlServerHelper.ExecuteNonQuery("dbo.CrearUsuario", lstParams);

            return Convert.ToInt32(param.Value);

        }

        public static bool ValidarCreacionUsuario(string nombreUsuario, string email)
        {
            List<SqlParameter> lstParams = new List<SqlParameter>();
            lstParams.Add(SqlServerHelper.GetParam("@nombreUsuario", nombreUsuario));
            lstParams.Add(SqlServerHelper.GetParam("@email", email));

            SqlServerHelper.ExecuteNonQuery("dbo.ValidarCreacionUsuario", lstParams);
            SqlParameter param = SqlServerHelper.GetParamIntOuput("@existe");

            return Convert.ToInt32(param.Value) > 0;
        }
    }
}
