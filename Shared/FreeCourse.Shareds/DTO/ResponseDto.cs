using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace FreeCourse.Shareds.DTO
{
    public class ResponseDto<T>
    {
        public T Data { get; set; }
        [JsonIgnore]
        public int StatusCode { get; private set; }
        [JsonIgnore]
        public bool IsSuccess { get; private set; }

        public List<string> Errors { get; set; }

        //Static Factory Method
        //Başarılı ve Geriye data döndüren ResponseDto
        public static ResponseDto<T> Success(T data, int StatusCode)
        {
            return new ResponseDto<T> { Data = data, StatusCode = StatusCode, IsSuccess = true };
        }
        //Başarılı ama geriye data döndürmeyen ResponseDto
        public static ResponseDto<T> Success(int StatusCode)
        {
            return new ResponseDto<T> { Data = default(T), StatusCode = StatusCode, IsSuccess = true };
        }
        //Birden Fazla Hata varsa liste olarak hepsini döndürür
        public static ResponseDto<T> Fail(List<string> errors,int StatusCode)
        {
            return new ResponseDto<T>
            {
                Errors = errors,
                StatusCode = StatusCode,
                IsSuccess = false
            };
        }
        //Tek bir Hata var ise döner
        public static ResponseDto<T> Fail(string Error,int StatusCode)
        {
            return new ResponseDto<T>
            {
                Errors = new List<string> { Error },
                IsSuccess = false,
                StatusCode = StatusCode,
            };
        }

    }
}
