using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace GuildWars2.Guild.Classes
{
    internal static class Reflection
    {
        public static T1 CopyClass<T1, T2>(this T1 obj, T2 otherObject) where T1 : class where T2 : class {
            PropertyInfo[] srcFields = otherObject.GetType().GetProperties(BindingFlags.Instance | BindingFlags.Public | BindingFlags.GetProperty);
            PropertyInfo[] destFields = obj.GetType().GetProperties(BindingFlags.Instance | BindingFlags.Public | BindingFlags.SetProperty);

            foreach(var property in srcFields) {
                var dest = destFields.FirstOrDefault(x => x.Name.Equals(property.Name));

                if(dest != null && dest.CanWrite)
                    dest.SetValue(obj, property.GetValue(otherObject, null), null);
            }
            return obj;
        }

        public static T1 CopyClass<T1, T2>(T2 otherObject) where T1 : class, new() where T2 : class {
            return CopyClass(new T1(), otherObject);
        }

        public static IEnumerable<T1> CopyClass<T1, T2>(IEnumerable<T2> objects) where T1 : class, new() where T2 : class {
            var result = new List<T1>();
            foreach(var obj in objects) {
                result.Add(CopyClass<T1, T2>(obj));
            }
            return result;
        }

        public static Dictionary<string, object> CopyProps<T>(T obj) {
            return obj.GetType()
                .GetProperties(BindingFlags.Instance | BindingFlags.Public)
                .ToDictionary(prop => prop.Name, prop => prop.GetValue(obj, null));
        }
    }
}
