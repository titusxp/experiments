using Newtonsoft.Json;
using System.Collections.Generic;
using System.Text;

namespace Core.Helper2
{
    public class Hashcode<T>
    {
        public static int GetHashCodeOLD(T entity)
        {
            string serial = JsonConvert.SerializeObject(entity);
            return serial.GetHashCode();
        }

        public static string CreateCacheKey(object obj, string propName = null)
        {
            var sb = new StringBuilder();
            if (obj.GetType().IsValueType || obj is string)
                sb.AppendFormat("{0}_{1}|", propName, obj);
            else
                foreach (var prop in obj.GetType().GetProperties())
                {
                    if (typeof(IEnumerable<object>).IsAssignableFrom(prop.PropertyType))
                    {
                        var get = prop.GetGetMethod();
                        if (!get.IsStatic && get.GetParameters().Length == 0)
                        {
                            var collection = (IEnumerable<object>)get.Invoke(obj, null);
                            if (collection != null)
                                foreach (var o in collection)
                                    sb.Append(CreateCacheKey(o, prop.Name));
                        }
                    }
                    else
                        sb.AppendFormat("{0}{1}_{2}|", propName, prop.Name, prop.GetValue(obj, null));

                }
            return sb.ToString();
        }
        public static string GetHashCode(T entity)
        {
            return CreateCacheKey(entity);
        }

        public static string GetSerial(T entity)
        {
            string serial = JsonConvert.SerializeObject(entity);
            return serial;
        }
    }
}
