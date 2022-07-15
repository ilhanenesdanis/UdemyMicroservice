using FreeCourse.Services.Catalog.Dtos;
using FreeCourse.Services.Catalog.Service;
using FreeCourse.Shareds.ControllerBases;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace FreeCourse.Services.Catalog.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CoursesController : CustomBaseController
    {
        private readonly ICourseService _courseService;

        public CoursesController(ICourseService courseService)
        {
            _courseService = courseService;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var response = await _courseService.GetAllAsync();
            return CreateActionResultsInstance(response);
        }
        [Route("/api/[controller]/GetAllByUserId/{UserId}")]
        [HttpGet]
        public async Task<IActionResult> GetAllByUserId(string UserId)
        {
            var response = await _courseService.GetAllByUserIdAsync(UserId);
            return CreateActionResultsInstance(response);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(string id)
        {
            var response = await _courseService.GetByIdAsync(id);
            return CreateActionResultsInstance(response);
        }
        [HttpPost]
        public async Task<IActionResult> Create(CourseCreateDto courseCreate)
        {
            var response = await _courseService.CreateAsync(courseCreate);
            return CreateActionResultsInstance(response);
        }
        [HttpPut]
        public async Task<IActionResult> Update(CourseUpdateDto courseCreate)
        {
            var response = await _courseService.UpdateAsync(courseCreate);
            return CreateActionResultsInstance(response);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            var response = await _courseService.DeleteAsync(id);
            return CreateActionResultsInstance(response);
        }
    }
}
