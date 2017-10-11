using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using WeStock.DAL.Interfaces;

namespace WeStock.DAL 
{
    public class SqlServerHelper
    {
        private static string connectionString;
        private static int? commandTimeout;

        static SqlServerHelper()
        {
            if (string.IsNullOrEmpty(connectionString))
            {
                //DbDacFactory fac = (DbDacFactory)DbDacFactory.Instance;
                //connectionString = fac.GetConnectionString();
                //commandTimeout = fac.GetCommandTimeout();
            }
        }

        public static bool CheckConnection()
        {
            bool resp = false;
            try
            {
                using (SqlConnection conn = GetConnection())
                {
                    conn.Open();
                }
                resp = true;
            }
            catch
            {
                 
            }
            return resp;
        }

        #region Reader
        public static void ExecuteNonQuery(string sp, List<SqlParameter> parameters)
        {
            try
            {
                using (SqlConnection conn = GetConnection())
                {
                    conn.Open();
                    // Create a command and prepare it for execution
                    using (SqlCommand cmd = GetCommand(conn))
                    {
                        cmd.CommandText = sp;
                        if (parameters != null && parameters.Count > 0)
                            cmd.Parameters.AddRange(parameters.ToArray());
                        int retval = cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception e)
            {

            }
        }

        public static IDataReader ExecuteReader(string sp, List<SqlParameter> parameters)
        {
            try
            {
                IDataReader dr = null;
                SqlConnection conn = GetConnection();
                {
                    conn.Open();
                    // Create a command and prepare it for execution
                    using (SqlCommand cmd = GetCommand(conn))
                    {
                        cmd.CommandText = sp;
                        if (parameters != null && parameters.Count > 0)
                            cmd.Parameters.AddRange(parameters.ToArray());

                        dr = cmd.ExecuteReader(CommandBehavior.CloseConnection | CommandBehavior.KeyInfo);
                    }
                }

                return dr;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public static object ExecuteScalar(string sp, List<SqlParameter> parameters)
        {
            try
            {
                object retval = null;
                using (SqlConnection conn = GetConnection())
                {
                    conn.Open();
                    // Create a command and prepare it for execution
                    using (SqlCommand cmd = GetCommand(conn))
                    {
                        cmd.CommandText = sp;
                        if (parameters != null && parameters.Count > 0)
                            cmd.Parameters.AddRange(parameters.ToArray());
                        retval = cmd.ExecuteScalar();
                    }
                }
                return retval;
            }
            catch (Exception e)
            {
                throw e;
            }
        }



        public static object ExecuteScalar(string sp, object parameters)
        {
            object col1 = null;
            try
            {


                using (SqlConnection conn = GetConnection())
                {
                    conn.Open();

                    var cmd = GetCommand(conn, sp);
                    cmd.CommandType = CommandType.StoredProcedure;

                    using (cmd)
                    {
                        buildParameters(parameters, cmd);
                        col1 = cmd.ExecuteScalar();
                    }
                }
            }
            catch (Exception e)
            {
                throw e;
            }

            return col1;
        }

        private static List<SqlParameter> buildParametrosToLog(List<Parameter> parameters)
        {
            List<SqlParameter> resp = new List<SqlParameter>();
            if (null == parameters)
            {
                return resp;
            }

            foreach (var kp in parameters)
            {
                var param = new SqlParameter();
                param.ParameterName = kp.Key;
                param.Value = parseValue(kp.Value);
                param.Direction = ParameterDirection.Input;

                resp.Add(param);
            }

            return resp;
        }

        private static SqlCommand GetCommand(SqlConnection conn)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandType = CommandType.StoredProcedure;
            if (commandTimeout.HasValue)
                cmd.CommandTimeout = commandTimeout.Value;

            return cmd;
        }

        private static SqlCommand GetCommand(SqlConnection conn, string storedProcedureName)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandType = CommandType.StoredProcedure;
            if (commandTimeout.HasValue)
                cmd.CommandTimeout = commandTimeout.Value;

            cmd.CommandText = storedProcedureName;

            return cmd;
        }

        public static SqlParameter GetParamTimeStampOuput(string param)
        {
            return new SqlParameter()
            {
                ParameterName = param,
                Direction = ParameterDirection.Output,
                SqlDbType = SqlDbType.Timestamp
            };
        }

        private static SqlConnection GetConnection()
        {
            return new SqlConnection(connectionString);
        }
        #endregion

        #region Parameters
        public static SqlParameter GetParam(string param, Guid? valor)
        {
            if (valor != null)
            {
                return new SqlParameter()
                {
                    ParameterName = param,
                    Value = valor.Value,
                    SqlDbType = SqlDbType.UniqueIdentifier
                };
            }
            else
            {
                return new SqlParameter()
                {
                    ParameterName = param,
                    Value = DBNull.Value,
                    SqlDbType = SqlDbType.UniqueIdentifier
                };
            }
        }

        internal static SqlParameter GetParam(string paramName, List<int> valor)
        {
            DataTable t = new DataTable();
            t.Columns.Add("id_r", typeof(int));
            foreach (var id_r in valor)
            {
                t.Rows.Add(id_r);
            }

            return new SqlParameter()
            {
                TypeName = "Int32List",
                ParameterName = paramName,
                Value = t,
                SqlDbType = SqlDbType.Structured
            };
        }

        public static SqlParameter GetParam(string param, int valor)
        {
            return new SqlParameter()
            {
                ParameterName = param,
                Value = valor,
                SqlDbType = SqlDbType.Int
            };
        }

        public static SqlParameter GetParam(string param, int? valor)
        {
            if (valor != null)
            {
                return new SqlParameter()
                {
                    ParameterName = param,
                    Value = valor.Value,
                    SqlDbType = SqlDbType.Int
                };
            }
            else
            {
                return new SqlParameter()
                {
                    ParameterName = param,
                    Value = DBNull.Value,
                    SqlDbType = SqlDbType.Int
                };
            }
        }

        public static SqlParameter GetParam(string param, decimal valor)
        {
            return new SqlParameter()
            {
                ParameterName = param,
                Value = valor,
                SqlDbType = SqlDbType.Decimal
            };
        }

        public static SqlParameter GetParam(string param, DateTime valor)
        {
            return new SqlParameter()
            {
                ParameterName = param,
                Value = valor,
                SqlDbType = SqlDbType.DateTime
            };
        }

        public static SqlParameter GetParamSmall(string param, DateTime valor)
        {
            return new SqlParameter()
            {
                ParameterName = param,
                Value = valor,
                SqlDbType = SqlDbType.SmallDateTime
            };
        }
        public static SqlParameter GetParamMinNull(string param, DateTime valor)
        {
            if (valor != DateTime.MinValue)
            {
                return new SqlParameter()
                {
                    ParameterName = param,
                    Value = valor,
                    SqlDbType = SqlDbType.DateTime
                };
            }
            else
            {
                return new SqlParameter()
                {
                    ParameterName = param,
                    Value = DBNull.Value,
                    SqlDbType = SqlDbType.DateTime
                };
            }
        }

        public static SqlParameter GetParam(string param, bool valor)
        {
            return new SqlParameter()
            {
                ParameterName = param,
                Value = valor,
                SqlDbType = SqlDbType.Bit
            };
        }

        public static SqlParameter GetParam(string param, long valor)
        {
            return new SqlParameter()
            {
                ParameterName = param,
                Value = valor,
                SqlDbType = SqlDbType.BigInt
            };
        }

        public static SqlParameter GetParam(string param, long? valor)
        {
            if (valor != null)
            {
                return new SqlParameter()
                {
                    ParameterName = param,
                    Value = valor,
                    SqlDbType = SqlDbType.BigInt
                };
            }
            else
            {
                return new SqlParameter()
                {
                    ParameterName = param,
                    Value = DBNull.Value,
                    SqlDbType = SqlDbType.BigInt
                };
            }
        }

        public static SqlParameter GetParam(string param, Byte[] valor)
        {
            SqlParameter p = new SqlParameter(param, SqlDbType.Timestamp);
            p.Value = valor;
            p.Direction = ParameterDirection.Input;
            return p;
        }

        public static SqlParameter GetParam(string param, string valor)
        {
            SqlParameter p = new SqlParameter(param, SqlDbType.VarChar);
            p.Value = DBNull.Value;
            p.Direction = ParameterDirection.Input;
            if (!string.IsNullOrEmpty(valor))
            {
                p.Value = valor;
            }
            return p;
        }

        public static SqlParameter GetParam(string param, decimal? valor)
        {
            if (valor != null)
            {
                return new SqlParameter()
                {
                    ParameterName = param,
                    Value = valor,
                    SqlDbType = SqlDbType.BigInt
                };
            }
            else
            {
                return new SqlParameter()
                {
                    ParameterName = param,
                    Value = DBNull.Value,
                    SqlDbType = SqlDbType.Decimal
                };
            }
        }

        public static SqlParameter GetParamFrom(string param, DateTime? valor)
        {
            SqlParameter p = new SqlParameter(param, SqlDbType.DateTime);
            p.Value = DBNull.Value;
            if (valor != null)
            {
                DateTime begin = new DateTime(valor.Value.Year, valor.Value.Month, valor.Value.Day, 0, 0, 0);
                p.Value = begin;
            }
            return p;
        }

        public static SqlParameter GetParamTo(string param, DateTime? valor)
        {
            SqlParameter p = new SqlParameter(param, SqlDbType.DateTime);
            p.Value = DBNull.Value;
            if (valor != null)
            {
                DateTime begin = new DateTime(valor.Value.Year, valor.Value.Month, valor.Value.Day, 23, 59, 59);
                p.Value = begin;
            }
            return p;
        }

        public static SqlParameter GetParamIntOuput(string param)
        {
            return new SqlParameter()
            {
                ParameterName = param,
                Direction = ParameterDirection.Output,
                SqlDbType = SqlDbType.Int
            };
        }

        public static SqlParameter GetParamByteOuput(string param)
        {
            return new SqlParameter()
            {
                ParameterName = param,
                Direction = ParameterDirection.Output,
                SqlDbType = SqlDbType.TinyInt
            };
        }

        public static SqlParameter GetParamLongOuput(string param)
        {
            return new SqlParameter()
            {
                ParameterName = param,
                Direction = ParameterDirection.Output,
                SqlDbType = SqlDbType.BigInt
            };
        }

        public static SqlParameter GetParamStringOuput(string param)
        {
            return new SqlParameter()
            {
                ParameterName = param,
                Direction = ParameterDirection.Output,
                SqlDbType = SqlDbType.VarChar,
                Size = 8000
            };
        }

        public static SqlParameter GetParamReturn()
        {
            return new SqlParameter()
            {
                Direction = ParameterDirection.ReturnValue,
            };
        }

        #endregion

 
        #region GetParameters
        public static DateTime GetDateTime(IDataReader reader, string fieldName)
        {
            int i = reader.GetOrdinal(fieldName);
            if (!reader.IsDBNull(reader.GetOrdinal(fieldName)))
                return reader.GetDateTime(i);
            else
                return new DateTime(1 / 1 / 1);
        }

        public static string GetString(IDataReader reader, String fieldName)
        {
            int i = reader.GetOrdinal(fieldName);
            if (!reader.IsDBNull(reader.GetOrdinal(fieldName)))
                return reader.GetString(i);
            else
                return string.Empty;
        }

        public static Decimal GetDecimal(IDataReader reader, string fieldName)
        {
            int i = reader.GetOrdinal(fieldName);
            if (!reader.IsDBNull(reader.GetOrdinal(fieldName)))
                return reader.GetDecimal(i);
            else
                return 0;
        }

        public static Int32 GetInt32(IDataReader reader, string fieldName)
        {
            int i = reader.GetOrdinal(fieldName);
            if (!reader.IsDBNull(reader.GetOrdinal(fieldName)))
                return reader.GetInt32(i);
            else
                return 0;
        }

        public static Int64 GetInt64(IDataReader reader, string fieldName)
        {
            int i = reader.GetOrdinal(fieldName);
            if (!reader.IsDBNull(reader.GetOrdinal(fieldName)))
                return reader.GetInt64(i);
            else
                return 0;
        }
        #endregion
        private static void buildParameters(List<Parameter> parameters, SqlCommand cmd)
        {
            if (null == parameters) return;

            foreach (var kp in parameters)
            {
                var param = new SqlParameter();
                param.ParameterName = kp.Key;
                param.Value = parseValue(kp.Value);
                param.Direction = ParameterDirection.Input;

                cmd.Parameters.Add(param);
            }

        }

        private static void buildParameters(object dto, SqlCommand cmd)
        {
            if (null == dto) return;

            foreach (var p in dto.GetType().GetProperties())
            {
                var param = new SqlParameter();
                param.ParameterName = p.Name;
                var val = p.GetValue(dto);

                if (val.GetType().IsArray) // TODO multicast?
                {
                    //param.Value = convertLongArray((long[])val);
                    //param.SqlDbType = SqlDbType.Structured;
                }
                else
                {
                    param.Value = val;
                }

                param.Direction = ParameterDirection.Input;

                cmd.Parameters.Add(param);
            }
        }


        private static object parseValue(object o)
        {
            if (o == null) return o;
            if (o.ToString().Split('/').Length >= 3)
                return DateTime.Parse(o.ToString());
            else return o;
        }

        private static string[] getColumnNames(IDataReader dr)
        {
            var count = dr.FieldCount;
            var r = new string[count];

            for (var i = 0; i < count; i++)
            {
                r[i] = dr.GetName(i);
            }

            return r;
        }
    }

    public static class DataRecordExtensions
    {
        public static bool HasColumn(this IDataRecord dr, string columnName)
        {
            for (int i = 0; i < dr.FieldCount; i++)
            {
                if (dr.GetName(i).Equals(columnName, StringComparison.InvariantCultureIgnoreCase))
                    return true;
            }
            return false;
        }
    }
}
 
public class Parameter
{ 
    public string Key { get; set; }
     
    public object Value { get; set; }
}