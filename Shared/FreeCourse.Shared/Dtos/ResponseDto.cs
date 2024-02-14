using System;
using System.Text.Json.Serialization;

namespace FreeCourse.Shared.Dtos
{
	public class ResponseDto<T>
	{
		public T Data { get; set; }

		[JsonIgnore] //Postmanda dönüş getle veri alınırsa eğer dönüş kodu zaten veriliyor birdaha ayriyetten nesne özelliği olarak ekranda gösterilmesine gerek yok. 
		public int StatusCode { get; private set; }

        [JsonIgnore]
        public bool isSuccessful { get;private  set; }

		public List<string> Errors { get; set; }



		public static ResponseDto<T> Success(T data,int statuscode)
		{


			return new ResponseDto<T> { Data = data, StatusCode = statuscode, isSuccessful = true };
		}

        public static ResponseDto<T> Success(int statuscode)
        {


            return new ResponseDto<T> {Data=default(T),StatusCode = statuscode, isSuccessful = true };
        }

		public static ResponseDto<T> Fail (List<string> errors,int statuscode)
		{
			return new ResponseDto<T>
			{
				Errors = errors,
				StatusCode=statuscode,
				isSuccessful=false
			};
		}

        public static ResponseDto<T> Fail(string error, int statuscode)
        {
			return new ResponseDto<T> { Errors = new List<string> { error},StatusCode=statuscode,isSuccessful=false };
        }
    }
}

