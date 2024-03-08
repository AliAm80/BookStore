using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookStore.Interfaces;
using BookStore.Models.Book;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace BookStore.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class BooksController : ControllerBase
    {
        private readonly IBookRepository _bookRepository;

        public BooksController(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }
        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> GetAllBooks()
        {
            var books = await _bookRepository.GetAllBooks();
            if (books.Count == 0)
                return NotFound("Not Found :(");
            return Ok(books);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetBookById(int id)
        {
            var book = await _bookRepository.GetBookById(id);
            if (book == null)
                return NotFound("Not Found :(");
            return Ok(book);
        }

        [HttpPost]
        public async Task<IActionResult> AddBook([FromBody] AddBookDto model)
        {
            var id = await _bookRepository.AddBook(model);
            return Ok(id);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateBook([FromBody] UpdateBookDto model, int id)
        {
            var result = await _bookRepository.UpdateBook(id, model);
            if (!result)
                return BadRequest("The Book does not exist!");
            return Ok(result);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> RemoveBook(int id)
        {
            var result = await _bookRepository.RemoveBook(id);
            if (!result)
                return BadRequest("The Book does not exist!");
            return Ok(result);
        }


    }
}
