using DictionaryUsage.Abstractions;
using DictionaryUsage.Abstractions.Common;
using System.Reflection;
using System.Text.Json;

namespace DictionaryUsage.Extensions
{
    public static class CommonExtensions
    {
        public static IList<T> Deserialize<T>(this string json)
        {
            return JsonSerializer.Deserialize<IList<T>>(json, new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.CamelCase });
        }

        public static void AddToDictionary<TKey, TValue>(
            this IDictionary<TKey, TValue> values,
                 IDictionary<TKey, IList<TKey>> indexes,
                 IList<TValue> users
            )
            where TKey : notnull
            where TValue : IUser
        {

            Type type = GetListType(users.First());

            users.ToList().ForEach(iUser =>
            {
                // Add all users to the "users" dictionary, associated with their UserName
                values.Add(castToKey(iUser.UserName), iUser);

                // Add all users' properties to the "indexes" dictionary
                type.GetAllProperties()
                .AsQueryable()
                .Where(p => p.PropertyType != typeof(bool) && p.Name != "UserName" && p.Name != "Password")
                .ToList()
                .ForEach(p =>
                {
                    TKey beSearchedKey = castToKey(p.GetValue(iUser).ToString());

                    if (indexes.ContainsKey(beSearchedKey))
                        indexes[beSearchedKey].Add(castToKey(iUser.UserName));
                    else
                        indexes.Add(beSearchedKey, new List<TKey> { castToKey(iUser.UserName) });
                });
            });


            TKey castToKey(object beCasted) => (TKey)beCasted;

            Type GetListType(TValue item)
            {
                if (item is IEmployee)
                    return typeof(IEmployee);
                else if (item is IStudent)
                    return typeof(IStudent);
                else if (item is ISubcontractor)
                    return typeof(ISubcontractor);
                else
                    return typeof(IUser);
            }

        }

        // Get all properties for inherited interfaces
        public static PropertyInfo[] GetAllProperties(this Type type)
        {
            if (type.IsInterface)
            {
                var propertyInfos = new List<PropertyInfo>();

                var considered = new List<Type>();
                var queue = new Queue<Type>();
                considered.Add(type);
                queue.Enqueue(type);
                while (queue.Count > 0)
                {
                    var subType = queue.Dequeue();
                    foreach (var subInterface in subType.GetInterfaces())
                    {
                        if (considered.Contains(subInterface)) continue;

                        considered.Add(subInterface);
                        queue.Enqueue(subInterface);
                    }

                    var typeProperties = subType.GetProperties(
                        BindingFlags.FlattenHierarchy
                        | BindingFlags.Public
                        | BindingFlags.Instance);

                    var newPropertyInfos = typeProperties
                        .Where(x => !propertyInfos.Contains(x));

                    propertyInfos.InsertRange(0, newPropertyInfos);
                }

                return propertyInfos.ToArray();
            }

            return type.GetProperties(BindingFlags.FlattenHierarchy
                | BindingFlags.Public | BindingFlags.Instance);
        }
    }
}
