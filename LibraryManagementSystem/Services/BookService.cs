using LibraryManagementSystem.LibraryManagement.Utlis;
using LibraryManagementSystem.Repositories;

namespace LibraryManagementSystem.Services
{
    public class BookService:IBookService
    {
        private readonly IBookRepository _bookRepository;

        public BookService(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        public async Task<Result<List<TblBook>>> GetAllBooksAsync(CancellationToken cs)
        {
            var books = await _bookRepository.GetAllBooksAsync(cs);
            return Result<List<TblBook>>.Success("Succeed");
        }

        public async Task<Result<TblBook?>> GetBookByIdAsync(int id)
        {
            var book = await _bookRepository.GetBookByIdAsync(id);
            return Result<TblBook?>.Success("Succeed");
        }

        //public async Task<Result<List<TblBook>>> GetAllBooksAsync(CancellationToken cs)
        //{
        //    try
        //    {
        //        var book = await _bookRepository.GetAllBooksAsync(cs); 

        //        if (!book.IsSuccess || book.Data!.Count == 0) 
        //        {
        //            return Result<List<TblBook>>.Fail("No book is found.");
        //        }
        //        else

        //        {
        //            return Result<List<TblBook>>.Success(book.Data);
        //        }
        //    }

        //    catch (Exception ex)
        //    {
        //        return Result<List<TblBook>>.Fail(ex);
        //    }

    }
    }

