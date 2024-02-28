using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookStore.Data;
using BookStore.Interfaces;
using BookStore.Models.Book;
using Microsoft.EntityFrameworkCore;

namespace BookStore.Repository
{
    public class BookRepository : IBookRepository
    {
        private readonly BookStoreContext _context;

        public BookRepository(BookStoreContext context)
        {
            _context = context;
        }
        public async Task<List<BookDetailsDto>> GetAllBooks()
        {
            var books = await _context.Books.Select(x => new BookDetailsDto()
            {
                Id = x.Id,
                Name = x.Name,
                Author = x.Author,
                Amount = x.Amount,
                Description = x.Description
            }).ToListAsync();
            return books;
        }
        public async Task<BookDetailsDto> GetBookById(int id)
        {
            var book = await _context.Books.Where(x => x.Id == id)
                                            .Select(x => new BookDetailsDto()
                                            {
                                                 Id = x.Id,
                                                Name = x.Name,
                                                Author = x.Author,
                                                Amount = x.Amount,
                                                Description = x.Description
                                            }).FirstOrDefaultAsync();
            return book;
        }
        public async Task<int> AddBook(AddBookDto model)
        {
            var book = new Book()
            {
                Name = model.Name,
                Author = model.Author,
                Amount = model.Amount,
                Description = model.Description
            };
            _context.Books.Add(book);
            await _context.SaveChangesAsync();
            return book.Id;
        }

        public async Task<bool> UpdateBook(int id, UpdateBookDto model)
        {
            var book = await _context.Books.Where(x => x.Id == id)
                                           .FirstOrDefaultAsync();
            if(book != null)
            {
                book.Name = model.Name;
                book.Author = model.Author;
                book.Amount = model.Amount;
                book.Description = model.Description;
                await _context.SaveChangesAsync();
                return true;
            }
            return false;

        }
        public async Task<bool> RemoveBook(int id)
        {
            var book = await _context.Books.Where(x => x.Id == id)
                                           .FirstOrDefaultAsync();
            if(book != null)
            {
                _context.Books.Remove(book);
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }


    }
}