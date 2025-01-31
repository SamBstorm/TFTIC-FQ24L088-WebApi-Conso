using DemoConsoApi.Models;
using System.Net;
using System.Text;
using System.Text.Json;
using System.Text.Unicode;

namespace DemoConsoApi
{
    internal class Program
    {
        static void Main(string[] args)
        {
            const string API_URI = "https://localhost:7217";

            try
            {
                IEnumerable<Tache> taches = GetAllTache(API_URI, "/api/Tache").Result;
                foreach (Tache tache in taches)
                {
                    Console.WriteLine($"{tache.Id} : {tache.Titre}");
                }
            }
            catch (AggregateException ex)
            {
                try
                {
                    throw ex.InnerException;
                }
                catch (HttpRequestException httpEx)
                {
                    switch (httpEx.StatusCode)
                    {
                        case HttpStatusCode.NotFound:
                            Console.WriteLine($"Route incorrecte vérifier votre URI, la route ou si le server API est allumé");
                            break;
                        case HttpStatusCode.Unauthorized:
                            Console.WriteLine($"Vous n'avez pas l'autorisation, vérifier votre authentification.");
                            break;
                    }
                }
                catch (Newtonsoft.Json.JsonException jsonEx)
                {
                    Console.WriteLine($"L'information n'est pas du type attendu.");
                }
            }

            Console.WriteLine("Voulez-vous ajouter une tâche ?");
            Console.WriteLine("Quelle est le nom de la tâche ?");
            string titre = Console.ReadLine();
            var nouvelleTache = new TachePost() { Titre = titre }; // new {Titre = titre};
            /*string json = JsonSerializer.Serialize(nouvelleTache);
            StringContent content = new StringContent(json, Encoding.UTF8, "application/json");
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(API_URI);
                HttpResponseMessage response = client.PostAsync("/api/Tache", content).Result;
                response.EnsureSuccessStatusCode();
                Console.WriteLine($"La tâche '{titre}' a bien été sauvée!");
            }*/
            try
            {
                AddTache(API_URI, "/api/Tache", nouvelleTache);
                Console.WriteLine($"La tâche '{titre}' a bien été sauvée!");
            }
            catch (AggregateException ex)
            {
                try
                {
                    throw ex.InnerException;
                }
                catch (HttpRequestException httpEx)
                {
                    switch (httpEx.StatusCode)
                    {
                        case HttpStatusCode.NotFound:
                            Console.WriteLine($"Route incorrecte vérifier votre URI, la route ou si le server API est allumé");
                            break;
                        case HttpStatusCode.Unauthorized:
                            Console.WriteLine($"Vous n'avez pas le droit de publier une nouvelle tâche.");
                            break;
                    }
                }

            }
        }

        static async Task<IEnumerable<Tache>> GetAllTache(string api_uri, string route)
        {
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(api_uri);
                HttpResponseMessage response = await client.GetAsync(route);
                response.EnsureSuccessStatusCode();
                /*  Les bonnes pratiques imposent d'utiliser la méthode EnsureSuccessStatusCode car celle-ci retourne une Exception en cas d'échec
                 * if (response.IsSuccessStatusCode)
                {
                    //string content = response.Content.ReadAsStringAsync().Result;
                    //Console.WriteLine(content);
                    //IEnumerable<Tache>? taches = JsonSerializer.Deserialize<IEnumerable<Tache>>(content, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });


                    IEnumerable<Tache> taches = response.Content.ReadAsAsync<IEnumerable<Tache>>().Result;
                    foreach (Tache tache in taches)
                    {
                        Console.WriteLine($"{tache.Id} : {tache.Titre}");
                    }
                }*/
                return await response.Content.ReadAsAsync<IEnumerable<Tache>>();
            }
        }

        static async Task AddTache(string api_uri, string route, TachePost nouvelleTache)
        {
            string json = JsonSerializer.Serialize(nouvelleTache);
            StringContent content = new StringContent(json, Encoding.UTF8, "application/json");
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(api_uri);
                HttpResponseMessage response = await client.PostAsync(route, content);
                response.EnsureSuccessStatusCode();
            }
        }
    }
}
