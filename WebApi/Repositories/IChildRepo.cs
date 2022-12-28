using WebApi.Models;

namespace WebApi.Repositories
{
    public interface IChildRepo
    {

        Task AddNewChild(Child child);
        Task<List<Child>> GetChildren();

        Task AddToy(int id, Toy toy);
        Task AddToyToOwner(string name, Toy toy);

        Task<List<int>> GetChildrenIds();
        Task<List<string>> GetChildrenNames();

        Task RemoveToy(int id);
    }
}
