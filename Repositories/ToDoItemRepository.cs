using System.Collections.Generic;
using System.Linq;
using ToDoApi.Models;

namespace ToDoApi.Repositories
{
    public class ToDoItemRepository : IToDoItemRepository
    {
        List<ToDoItem> _toDoList = new List<ToDoItem>();

        public IEnumerable<ToDoItem> FindAll()
        {
            return _toDoList;
        }

        public void Add(ToDoItem item)
        {
            _toDoList.Add(item);
        }

        public bool Exists(int id)
        {
            return _toDoList.Any(item => item.ID == id);
        }

        public ToDoItem FindById(int id)
        {
            return _toDoList.FirstOrDefault(item => item.ID == id);
        }

        public void Remove(int id)
        {
            var item = this.FindById(id);
            _toDoList.Remove(item);
        }

        public void Update(ToDoItem item)
        {
            var existingItem = this.FindById(item.ID);
            var index = _toDoList.IndexOf(existingItem);

            _toDoList.RemoveAt(index);
            _toDoList.Insert(index, item);
        }

        public void Save()
        {
            // 何もしない
        }
    }
}