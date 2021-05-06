using System.Runtime.Serialization.Json;
using System.Text.Json;
using System.Collections.Generic;
using StoreModels;
namespace Data
{
    public class RepoFile : IRepository
    {
        private const string filePath = "Data/Data.json";
        private string jsonString;

        public List<Item> GetItem(){
            return JsonSerializer.Deserialize<List<Item>>(jsonString);
        }
    }
}