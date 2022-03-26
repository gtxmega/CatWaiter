using UnityEngine;

namespace CodeBase.Infrastructure.Data
{
    public static class DataExtensions
    {
        public static string ToJson(this object obj) => JsonUtility.ToJson(obj);
        
        public static T ToDeserialize<T>(this string json) => 
            JsonUtility.FromJson<T>(json);
    }
}