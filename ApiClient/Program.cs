using CacheCow.Client;
using CacheCow.Client.RedisCacheStore;
using System;
using System.Net.Http;

namespace ApiClient
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Getting the Time");
            var client = ClientExtensions.CreateClient(new RedisStore("localhost"));
            client.BaseAddress = new Uri("http://localhost:1337");

            while(true)
            {
                var response = client.GetAsync("/time1").Result;

                Console.WriteLine(response.StatusCode);
                Console.Write(response.Headers.CacheControl.ToString());
                var content = response.Content.ReadAsStringAsync().Result;
                Console.WriteLine(content);
                Console.WriteLine("Hit enter to try again or hit done");
                if(Console.ReadLine() =="done")
                {
                    break;
                }
            }
        }
    }
}
