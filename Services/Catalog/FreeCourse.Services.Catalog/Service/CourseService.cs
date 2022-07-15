using AutoMapper;
using FreeCourse.Services.Catalog.Dtos;
using FreeCourse.Services.Catalog.Model;
using FreeCourse.Services.Catalog.Settings;
using FreeCourse.Shareds.DTO;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FreeCourse.Services.Catalog.Service
{
    public class CourseService: ICourseService
    {
        private readonly IMongoCollection<Course> _CourseCollection;
        private readonly IMongoCollection<Category> _categoryCollection;
        private readonly IMapper _mapper;

        public CourseService(IMapper mapper, IDatabaseSettings databaseSettings)
        {
            var client = new MongoClient(databaseSettings.ConnectionString);
            var database = client.GetDatabase(databaseSettings.DatabaseName);
            _CourseCollection = database.GetCollection<Course>(databaseSettings.CourseCollectionName);
            _categoryCollection = database.GetCollection<Category>(databaseSettings.CategoryCollectionName);
            _mapper = mapper;
        }
        public async Task<ResponseDto<List<CourseDto>>> GetAllAsync()
        {
            var courses = await _CourseCollection.Find(x => true).ToListAsync();

            if (courses.Any())
            {
                foreach (var item in courses)
                {
                    item.Category = await _categoryCollection.Find<Category>(x => x.Id == item.CategoryId).FirstAsync();
                }
            }
            else
            {
                courses = new List<Course>();
            }
            return ResponseDto<List<CourseDto>>.Success(_mapper.Map<List<CourseDto>>(courses), 200);

        }
        public async Task<ResponseDto<CourseDto>> GetByIdAsync(string Id)
        {
            var course = await _CourseCollection.Find<Course>(x => x.Id == Id).FirstOrDefaultAsync();
            if (course == null)
            {
                return ResponseDto<CourseDto>.Fail("Course Not Found", 404);
            }
            course.Category = await _categoryCollection.Find<Category>(x => x.Id == course.CategoryId).FirstAsync();
            return ResponseDto<CourseDto>.Success(_mapper.Map<CourseDto>(course), 200);
        }
        public async Task<ResponseDto<List<CourseDto>>> GetAllByUserIdAsync(string userId)
        {
            var courses=await _CourseCollection.Find<Course>(x => x.UserId == userId).ToListAsync();
            if (courses.Any())
            {
                foreach (var item in courses)
                {
                    item.Category = await _categoryCollection.Find<Category>(x => x.Id == item.CategoryId).FirstAsync();
                }
            }
            else
            {
                courses = new List<Course>();
            }
            return ResponseDto<List<CourseDto>>.Success(_mapper.Map<List<CourseDto>>(courses), 200);
        }
        public async Task<ResponseDto<CourseDto>> CreateAsync(CourseCreateDto courseCreate)
        {
            var newCourse = _mapper.Map<Course>(courseCreate);
            newCourse.CreatedTime = DateTime.Now;
            await _CourseCollection.InsertOneAsync(newCourse);
            return ResponseDto<CourseDto>.Success(_mapper.Map<CourseDto>(newCourse), 200);
        }
        public async Task<ResponseDto<NoContent>> UpdateAsync(CourseUpdateDto courseUpdate)
        {
            var updateCourse=_mapper.Map<Course>(courseUpdate);
            var result = await _CourseCollection.FindOneAndReplaceAsync(x => x.Id == courseUpdate.Id, updateCourse);
            if (result == null)
            {
                return ResponseDto<NoContent>.Fail("Course Not Found", 404);
            }
            return ResponseDto<NoContent>.Success(204);
        }
        public async Task<ResponseDto<NoContent>> DeleteAsync(string Id)
        {
            var result=await _CourseCollection.DeleteOneAsync(x=>x.Id==Id);
            if (result.DeletedCount > 0)
            {
                return ResponseDto<NoContent>.Success(204);
            }
            return ResponseDto<NoContent>.Fail("Course Not Found", 404);

        }
    }
}
