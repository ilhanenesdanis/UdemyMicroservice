using FreeCourse.Services.Catalog.Dtos;
using FreeCourse.Services.Catalog.Model;
using FreeCourse.Shareds.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FreeCourse.Services.Catalog.Service
{
    public interface ICategoryService
    {
        Task<ResponseDto<List<CategoryDto>>> GetAllAsyncCategory();
        Task<ResponseDto<CategoryDto>> CreateAsync(CategoryDto category);
        Task<ResponseDto<CategoryDto>> GetByIdAsync(string Id);
    }
}
