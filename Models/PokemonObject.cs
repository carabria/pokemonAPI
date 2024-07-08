using System;
using System.Collections.Generic;
using System.Globalization;

namespace Pokemon_CLI.Models
{
    public class PokemonObject
    {
        public int Count {get; set;}
        public string Next {get; set;}
        public object Previous {get; set;}
        public Result[] Results {get; set;}
    }

    public class Result
    {
        public string Name {get; set;}
        public string Url {get; set;}
    }
}
