﻿using System.Text.Json;

namespace Garaje.Helper
{
    public static class SessionExtensions
    {
        //Клас для зберігання складних обєктів для корзини
        public static void SetObject<T>(this ISession session, string key, T value)
        {
            session.SetString(key, JsonSerializer.Serialize(value));
        }

        public static T? GetObject<T>(this ISession session, string key)
        {
            var value = session.GetString(key);
            return value == null ? default : JsonSerializer.Deserialize<T>(value);
        }
    }
}
