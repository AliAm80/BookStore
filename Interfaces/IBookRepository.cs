using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookStore.Models.Book;

namespace BookStore.Interfaces
{
    public interface IBookRepository
    {
        Task<List<BookDetailsDto>> GetAllBooks();
        Task<BookDetailsDto> GetBookById(int id);
        Task<int> AddBook(AddBookDto model);
        Task<bool> UpdateBook(int id, UpdateBookDto model);
        Task<bool> RemoveBook(int id);
    }
}