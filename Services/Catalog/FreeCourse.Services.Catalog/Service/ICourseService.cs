using FreeCourse.Services.Catalog.Dtos;
using FreeCourse.Shareds.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FreeCourse.Services.Catalog.Service
{
    public interface ICourseService
    {
        Task<ResponseDto<List<CourseDto>>> GetAllAsync();
        Task<ResponseDto<CourseDto>> GetByIdAsync(string Id);
        Task<ResponseDto<List<CourseDto>>> GetAllByUserIdAsync(string userId);
        Task<ResponseDto<CourseDto>> CreateAsync(CourseCreateDto courseCreate);
        Task<ResponseDto<NoContent>> UpdateAsync(CourseUpdateDto courseUpdate);
        Task<ResponseDto<NoContent>> DeleteAsync(string Id);
    }
}
