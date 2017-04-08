using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using ToDoApi.Models;
using ToDoApi.Repositories;
using ToDoApi.Filters;

namespace ToDoApi.Controllers
{
    [Route("api/[controller]")]
    public class ToDoItemController : Controller
    {
        readonly IToDoItemRepository _toDoItemRepository;

        public ToDoItemController(IToDoItemRepository toDoItemRepository)
        {
            _toDoItemRepository = toDoItemRepository;
        }

        [HttpGet]
        public IEnumerable<ToDoItem> GetAll()
        {
            return _toDoItemRepository.FindAll();
        }

        [HttpGet("{id}", Name = "GetToDo")]
        public IActionResult Get(int id)
        {
            var item = _toDoItemRepository.FindById(id);
            if (item == null)
            {
                return NotFound();
            }
            return new ObjectResult(item);
        }

        [HttpPost]
        [ValidateModel]
        public IActionResult Create([FromBody] ToDoItem item)
        {
            if (item == null)
            {
                return BadRequest();
            }

            _toDoItemRepository.Add(item);

            return CreatedAtRoute("GetToDo", new { id = item.ID }, item);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] ToDoItem item)
        {
            if (item == null || item.ID != id)
            {
                return BadRequest();
            }

            var existingItem = _toDoItemRepository.FindById(id);
            if (existingItem == null)
            {
                return NotFound();
            }

            existingItem.Title = item.Title;
            existingItem.Notes = item.Notes;
            existingItem.IsCompleted = item.IsCompleted;

            _toDoItemRepository.Update(existingItem);

            return new NoContentResult();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var existingItem = _toDoItemRepository.FindById(id);
            if (existingItem == null)
            {
                return NotFound();
            }

            _toDoItemRepository.Remove(id);

            return new NoContentResult();
        }
    }
}
