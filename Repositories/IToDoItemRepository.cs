using System.Collections.Generic;
using ToDoApi.Models;

namespace ToDoApi.Repositories
{
    public interface IToDoItemRepository
    {
        bool Exists(int id);
        IEnumerable<ToDoItem> FindAll();
        ToDoItem FindById(int id);
        void Add(ToDoItem item);
        void Update(ToDoItem item);
        void Remove(int id);
        void Save();
    }
}