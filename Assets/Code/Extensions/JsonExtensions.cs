using UnityEngine;

namespace Code.Extensions
{
    public static class JsonExtensions
    {
        public static string ToJson(this object json)
            => JsonUtility.ToJson(json);

        public static T FromJson<T>(this string json)
            => JsonUtility.FromJson<T>(json);
    }
}