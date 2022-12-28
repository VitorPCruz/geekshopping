﻿using Microsoft.AspNetCore.Mvc.Formatters;
using System.Net.Http.Headers;
using System.Text.Json;

namespace GeekShopping.Web.Utils
{
    public static class HttpClientExtensions
    {
        public static MediaTypeHeaderValue contentType = 
            new MediaTypeHeaderValue("application/json");

        public static async Task<T> GetAsync<T>(
            this HttpResponseMessage response)
        {
            if (!response.IsSuccessStatusCode)
                throw new ApplicationException(
                    $"Something went wrong calling the API: " +
                    $"{response.ReasonPhrase}");

            var dataAsString = await response.Content
                .ReadAsStringAsync()
                .ConfigureAwait(false);

            return JsonSerializer.Deserialize<T>(
                dataAsString,
                new JsonSerializerOptions { PropertyNameCaseInsensitive = true }
                );
        }

        public static Task<HttpResponseMessage> PostAsJson<T>(
            this HttpClient httpClient, string url, T data)
        {
            var dataAsString = JsonSerializer.Serialize(data);
            var content = new StringContent(dataAsString);

            // TODO - REMOVER ESTES COMENTÁRIOS DESTE CÓDIGO
            Console.WriteLine("# ---------------------------------------");
            Console.WriteLine(content);
            Console.WriteLine("# ---------------------------------------");

            content.Headers.ContentType = contentType;
            return httpClient.PostAsync(url, content);
        }


        public static Task<HttpResponseMessage> PutAsJson<T>(
            this HttpClient httpClient, string url, T data)
        {
            var dataAsString = JsonSerializer.Serialize(data);
            var content = new StringContent(dataAsString);

            // TODO - REMOVER ESTES COMENTÁRIOS DESTE CÓDIGO
            Console.WriteLine("# ---------------------------------------");
            Console.WriteLine(content);
            Console.WriteLine("# ---------------------------------------");

            content.Headers.ContentType = contentType;
            return httpClient.PutAsJson(url, content);
        }
    }
}