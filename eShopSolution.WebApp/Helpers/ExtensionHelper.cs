using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;


namespace eShopSolution.WebApp.Helpers
{
    public static class ExtensionHelper
    {
        public static string ToVnd(this double giaTri)
        {
            return $"{giaTri:#,##0.00} đ";
        }

        public static void Set<T>(this ISession session, string key, T value)
        {
            session.SetString(key, JsonConvert.SerializeObject(value));
        }

        public static T Get<T>(this ISession session, string key)
        {
            var value = session.GetString(key);

            return value == null ? default(T) :
                JsonConvert.DeserializeObject<T>(value);
        }
    }
}
