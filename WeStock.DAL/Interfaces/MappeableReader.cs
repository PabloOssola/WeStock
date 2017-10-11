using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;

namespace WeStock.DAL.Interfaces
{
    public static class MappeableReader
    {
        public static List<T> DataReaderMapToList<T>(this IDataReader dr) where T : new()
        {
            List<T> list = new List<T>();
            T obj = default(T);
            List<string> columns = null;
            while (dr.Read())
            {
                if (!(dr as SqlDataReader).HasRows)
                    return null;

                obj = new T();

                if (columns == null)
                {
                    columns = dr.GetSchemaTable().Rows
                                     .Cast<DataRow>()
                                     .Select(r => ((string)r["ColumnName"]).ToLower().Replace("_", ""))
                                     .ToList();
                }
                foreach (PropertyInfo prop in obj.GetType().GetProperties())
                {
                    if (columns.IndexOf(prop.Name.ToLower()) >= 0)
                    {
                        if (!object.Equals(dr[prop.Name], DBNull.Value))
                        {
                            var targetType = IsNullableType(prop.PropertyType) ? Nullable.GetUnderlyingType(prop.PropertyType) : prop.PropertyType;
                            object value = null;
                            if (prop.PropertyType.IsEnum)
                            {
                                value = Enum<StringComparison>.ToObject(dr[prop.Name]);
                            }
                            else
                            {
                                value = Convert.ChangeType(dr[prop.Name], targetType);
                            }
                            prop.SetValue(obj, value, null);
                        }
                    }
                }
                list.Add(obj);
            }
            return list;
        }

        public static T DataReaderMapToEntity<T>(this IDataReader dr) where T : new()
        {
            
            T obj = default(T);
            while (dr.Read())
            {
                if (!(dr as SqlDataReader).HasRows)
                    return default(T);

                obj = new T();
                var columns = dr.GetSchemaTable().Rows
                                     .Cast<DataRow>()
                                     .Select(r => ((string)r["ColumnName"]).ToLower().Replace("_", ""))
                                     .ToList();

                foreach (PropertyInfo prop in obj.GetType().GetProperties())
                {
                    if (columns.IndexOf(prop.Name.ToLower()) >= 0)
                    {
                        if (!object.Equals(dr[prop.Name], DBNull.Value))
                        {
                            var targetType = IsNullableType(prop.PropertyType) ? Nullable.GetUnderlyingType(prop.PropertyType) : prop.PropertyType;
                            object value = null;
                            if (prop.PropertyType.IsEnum)
                            {
                                if (dr.GetFieldType(dr.GetOrdinal(prop.Name)) == typeof(string))
                                    value = Enum<StringComparison>.ToObject(dr[prop.Name]);
                                else
                                    value = Enum.ToObject(prop.PropertyType, dr[prop.Name]);
                            }
                            else
                            {
                                value = Convert.ChangeType(dr[prop.Name], targetType);
                            }
                            prop.SetValue(obj, value, null);
                        }
                    }
                }
            }
            return obj;
        }

        private static bool IsNullableType(Type type)
        {
            return type.IsGenericType && type.GetGenericTypeDefinition().Equals(typeof(Nullable<>));
        }
    }


    public class Enum<EnumType> where EnumType : struct, IConvertible
    {

        
        public static EnumType[] GetValues()
        {
            return (EnumType[])Enum.GetValues(typeof(EnumType));
        }

        
        public static EnumType Parse(string name)
        {
            return (EnumType)Enum.Parse(typeof(EnumType), name);
        }

        
        public static EnumType Parse(string name, bool ignoreCase)
        {
            return (EnumType)Enum.Parse(typeof(EnumType), name, ignoreCase);
        }

        
        public static EnumType ToObject(object value)
        {
            return (EnumType)Enum.ToObject(typeof(EnumType), value);
        }
    }
}

