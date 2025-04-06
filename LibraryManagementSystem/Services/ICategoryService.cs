namespace LibraryManagementSystem.Services
{
    public interface ICategoryService
    {
        Task<Result<List<TblCategory>>> GetCategoryAsync(CancellationToken cs);
        Task<Result<TblCategory>> GetCategoryByIdAsync(int id);
    }
}
