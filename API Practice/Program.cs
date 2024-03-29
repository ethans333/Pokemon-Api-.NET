using System;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Serialization;


// Pokemon p = new Pokemon(123, "Pikachu", new List<string>(), 33);

namespace API_Practice
{
    class Program
    {
        static async Task Main(string[] args)
        {
            int n = 5;

            for (int i = 1; i < n+1; i++)
            {
                await GetPokemon(i);
            }
        }

        public static async Task GetPokemon(int id)
        {
            // Define base url of api.
            string baseUrl = $"https://pokeapi.co/api/v2/pokemon/{id}";
       
            HttpClient client = new HttpClient();

            // Call get request to fetch data from api.
            HttpResponseMessage response = await client.GetAsync(baseUrl);

            // Extract body from response.
            string body = await response.Content.ReadAsStringAsync();

            // Parse body into json object.
            JObject obj = JObject.Parse(body);

            Pokemon p = new Pokemon(obj["id"].Value<int>(), obj["name"].Value<string>(), GetMoves(obj["moves"].Value<JArray>()), obj["weight"].Value<int>(), obj["height"].Value<int>());

            p.print();
        }

        public static List<string> GetMoves(JArray moves)
        {

            List<string> strMoves = new List<string>();

            foreach (JObject move in moves) {
                strMoves.Add(move["move"]["name"].Value<string>());
            }

            return strMoves;
        }
    }
}
