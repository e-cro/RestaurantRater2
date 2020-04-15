using IntroToAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;//added this by ctrl . on HttpClient
using System.Text;
using System.Threading.Tasks;

namespace IntroToAPI
{
    class Program
    {
        static void Main(string[] args)
        {
            HttpClient httpClient = new HttpClient();
            var response = httpClient.GetAsync("https://pokeapi.co/api/v2/pokemon/1").Result;

            if (response.IsSuccessStatusCode)
            {
                //Console.WriteLine(response.Content.ReadAsStringAsync().Result);



                Pokemon pokemonResponse = response.Content.ReadAsAsync<Pokemon>().Result;
                Console.WriteLine(pokemonResponse.name);//name would normally be uppercase but the code in the PokeAPI website had lowercase

                foreach (var ability in pokemonResponse.abilities)
                {
                    Console.WriteLine(ability.ability.name);
                }
            }

            PokeAPIService service = new PokeAPIService();
            Pokemon numberTwo = service.GetPokemonAsync("https://pokeapi.co/api/v2/pokemon/2").Result;
            if (numberTwo != null)
            {
                Console.WriteLine(numberTwo.name);
            }

            //Assigning the type when you call the method
            Pokemon anotherPokemon = service.GetAsync<Pokemon>("https://pokeapi.co/api/v2/pokemon/42").Result;
            var test = service.GetAsync<Move>("https://pokeapi.co/api/v2/pokemon/42").Result;
            Console.WriteLine(anotherPokemon.name);
            //Console.WriteLine(test.move); //it's null

            var listOfPokemon = service.GetAsync<ListOfPokemon>("https://pokeapi.co/api/v2/pokemon").Result;
            foreach(var pokemon in listOfPokemon.results)
            {
                Console.WriteLine(pokemon.name);
            }

            Console.ReadKey();
        }
    }
}
