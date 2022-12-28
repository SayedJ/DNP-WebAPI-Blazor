
using Microsoft.EntityFrameworkCore;
using WebApi.Context;
using WebApi.Models;

namespace WebApi.Repositories
{
    public class ChildRepo : IChildRepo
    {
        private readonly ChildrenDBContext context;
        public ChildRepo(ChildrenDBContext context) { this.context = context; }
        public async Task AddNewChild(Child child)
        {
            await context.Children.AddAsync(child);
            context.SaveChanges();

        }

        public async Task<List<Child>> GetChildren()
        {
            return await context.Children.Include(c => c.Toys).ToListAsync();
            
        }

        public async Task AddToy(int id, Toy toy)
        {
            Child? child = await context.Children.Where(c=> c.ID == id).FirstOrDefaultAsync();

            child.Toys = new List<Toy>() {
                new(){Name =  toy.Name,
                Color = toy.Color,
                 Condition = toy.Color,
                 IsFavourite = toy.IsFavourite},
            };

            await context.SaveChangesAsync();

        }

        public async Task<List<int>> GetChildrenIds()
        {
            var children = await context.Children.Select(c => c.ID).ToListAsync();

            return children;
        }

        public async Task RemoveToy(int id)
        {
            var toy = await context.Toys.FindAsync(id);
            if(toy != null)
            {
                context.Toys.Remove(toy);
            }
            await context.SaveChangesAsync();

        }

        public async Task<List<string>> GetChildrenNames()
        {
            var children = await context.Children.Select(c => c.Name).ToListAsync();
            return children;
        }

        public async Task AddToyToOwner(string name, Toy toy)
        {
            var child = await context.Children.Where(c => c.Name== name).FirstOrDefaultAsync();
            child.Toys = new List<Toy>() {
                new(){Name =  toy.Name,
                Color = toy.Color,
                 Condition = toy.Condition,
                 IsFavourite = toy.IsFavourite},
            };
            context.Children.Update(child);
            await context.SaveChangesAsync();
        }
    }
}
