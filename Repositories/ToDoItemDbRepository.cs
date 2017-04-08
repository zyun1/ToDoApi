using System.Collections.Generic;
using System.Linq;
using ToDoApi.Models;

namespace ToDoApi.Repositories
{
    public class ToDoItemDbRepository : IToDoItemRepository
    {
        readonly ApplicationDbContext _dbContext;

        public ToDoItemDbRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<ToDoItem> FindAll()
        {
            return _dbContext.ToDoItems;
        }

        public void Add(ToDoItem item)
        {
            _dbContext.ToDoItems.Add(item);
            _dbContext.SaveChanges();
        }

        public bool Exists(int id)
        {
            return _dbContext.ToDoItems.Any(item => item.ID == id);
        }

        public ToDoItem FindById(int id)
        {
            return _dbContext.ToDoItems.FirstOrDefault(item => item.ID == id);
        }

        public void Remove(int id)
        {
            var item = this.FindById(id);
            _dbContext.ToDoItems.Remove(item);
            _dbContext.SaveChanges();
        }

        public void Update(ToDoItem item)
        {
            _dbContext.ToDoItems.Update(item);
            _dbContext.SaveChanges();
        }

        public void Save()
        {
            _dbContext.SaveChanges();
        }
    }
}
