using Blazor.Models;

namespace Blazor.HttpClientRepo
{
    public interface IChildToy
    {


        Task<string> AddNewChild(Child child);
        Task RemoveChild(int id);
        Task<string> AddToy(int id, Toy toy);

        Task<List<int>> GetChildrenIDs();

        Task<List<Child>> GetChildren();
        Task<List<string>> GetChidrenNames();
        Task<string> AddToyToOwner(string name, Toy toy);


    }
}
