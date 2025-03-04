﻿using LibraryManagementSystem.LibraryManagement.Utlis;
using LibraryManagementSystem.Model;
using LibraryManagementSystem.Models;
using Microsoft.EntityFrameworkCore;

namespace LibraryManagementSystem.Repositories
{
    public class BookRepository : IBookRepository
    {
        private readonly AppDbContext _context;

        public BookRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<TblBook>> GetAllBooksAsync()
        {
            return await _context.TblBooks.Where(x => !x.IsActive).ToListAsync();
        }

        //public async Task<TblBook?> GetBookAsync(int id, CancellationToken cs)
        //{
        //    return await _context.TblBooks.FirstOrDefaultAsync(x => x.BookId == id && !x.IsActive, cs);
        //}

       


    }
}
