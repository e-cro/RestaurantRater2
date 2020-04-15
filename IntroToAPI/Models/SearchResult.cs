using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntroToAPI.Models
{
    public class SearchResult<T>//Type T is a generic type. We're not using this class in the PokeApi because it turns out that website doesn't have a search function. There was a search function in SWAPI, that this lesson plan was based on.
    {
        public int Count { get; set; }
        public List<T> Results { get; set; } = new List<T>();
    }
}
