using Microsoft.AspNetCore.Mvc;
using WebApi.Models;
using WebApi.Repositories;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    public class ChildrenController : ControllerBase {


        private readonly IChildRepo repo;

        public ChildrenController(IChildRepo repo)
        {
            this.repo = repo;
        }

        [HttpPost]
        [Route("/addChildren")]
        public async Task AddNewChild([FromBody]Child child)
        {
            await repo.AddNewChild(child);
        }

        [HttpGet]
        [Route("/getAllChildren")]
        public async Task<List<Child>> AllChildren()
        {
            return await repo.GetChildren();

        }
        [HttpPost]
        [Route("/Toy/owner/{id}")]
        public async Task AddToy(int id, [FromBody]Toy toy)
        {
            await repo.AddToy(id, toy);
        }
        [HttpPut]
        [Route("/Toy/owner/{name}")]
        public async Task AddToyToOwner(string name, [FromBody] Toy toy)
        {
            await repo.AddToyToOwner(name, toy);
        }

        [HttpGet]
        [Route("/getIds")]
        public async Task<List<int>> GetChildrenIDs()
        {
            return await repo.GetChildrenIds();
        }
        [HttpGet]
        [Route("/getChildrenNames")]
        public async Task<List<string>> GetChildrenNames()
        {
            return await repo.GetChildrenNames();
        }
        [HttpDelete]
        [Route("/toys/{toyId}")]
        public async Task RemoveToy(int toyId)
        {
            await repo.RemoveToy(toyId);
        }

    }
}
