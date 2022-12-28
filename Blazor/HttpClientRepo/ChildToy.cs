using Blazor.Models;
using System.Net.Http.Json;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Mvc;

namespace Blazor.HttpClientRepo
{
    public class ChildToy : IChildToy
    {
        private readonly HttpClient client;

        public ChildToy(HttpClient client)
        {
            this.client = client;
        }
        [HttpPost]
        public async Task<string> AddNewChild(Child child)
        {
            string result = " ";
            HttpResponseMessage response = await client.PostAsJsonAsync("https://localhost:7247/addChildren", child);
            if(response.IsSuccessStatusCode)
            {
                result = response.StatusCode.ToString();
            }
            return result;
        }
        [HttpPost]
        public async Task<string> AddToy(int id, Toy toy)
        {
            string result = " ";
            HttpResponseMessage response = await client.PostAsJsonAsync($"https://localhost:7247/children/toy/owner/{id}", toy);
            if(response.IsSuccessStatusCode)
            {
                result = response.StatusCode.ToString();
            }
            return result;
        }
        [HttpPut]
        public async Task<string> AddToyToOwner(string name, Toy toy)
        {
            string result = " ";
            HttpResponseMessage response = await client.PutAsJsonAsync($"https://localhost:7247/toy/owner/{name}", toy);
            if (response.IsSuccessStatusCode)
            {
                result = response.StatusCode.ToString();
            }
            return result;
        }

        public async Task<List<string>> GetChidrenNames()
        {
            var response = await client.GetAsync("https://localhost:7247/getChildrenNames");
            var content = await response.Content.ReadAsStringAsync();
            var children = JsonConvert.DeserializeObject<List<string>>(content);
            return children;

        }

        [HttpGet]
        public async Task<List<Child>> GetChildren()
        {
            var response = await client.GetAsync("https://localhost:7247/getAllChildren");
            var content = await response.Content.ReadAsStringAsync();
            var children = JsonConvert.DeserializeObject<List<Child>>(content);
            return children;
        }
        [HttpGet]
        public async Task<List<int>> GetChildrenIDs()
        {
            var response = await client.GetAsync("https://localhost:7247/getIds");
            var content = await response.Content.ReadAsStringAsync();
            var childrenIds = JsonConvert.DeserializeObject<List<int>>(content);
            return childrenIds;
        }
        [HttpDelete]
        public async Task RemoveChild(int id)
        {
            var response = await client.DeleteAsync($"https://localhost:7247/toys/{id}");
        }
    }
}
