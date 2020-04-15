using IntroToAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;//brought this in with ctrl. on HttpClient
using System.Text;
using System.Threading.Tasks;

namespace IntroToAPI
{
    public class PokeAPIService
    {
        private readonly HttpClient _httpClient = new HttpClient();

        public async Task<Pokemon> GetPokemonAsync(string url) //async methods return a Task. Used ctrl. to bring in IntroToAPI Models to get <Pokemon> in Task. Pokemon is the type. 
        {
            HttpResponseMessage response = await _httpClient.GetAsync(url);

            if (response.IsSuccessStatusCode)
            {
                Pokemon pokemon = await response.Content.ReadAsAsync<Pokemon>();//the await here is doing what .Result did in Program.cs
                return pokemon;
            }
            return null;
        }

        public async Task<T> GetAsync<T>(string url) //making a generic Task that can take in any type, a general object.
        {
            HttpResponseMessage response = await _httpClient.GetAsync(url);
            if(response.IsSuccessStatusCode)
            {
                return await response.Content.ReadAsAsync<T>();//we're turning whatever type we get from the url into this response
            }
            return default;
        }
    }
}
