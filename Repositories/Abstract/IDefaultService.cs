using LibraryDapperProject.Dtos;

namespace LibraryDapperProject.Repositories.Abstract
{
    public interface IDefaultService
    {
        Task<List<ResultBookDto>> GetPagedBooksAsync(int page, int pageSize);
    }
}
