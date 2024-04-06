using System;
using System.Text.Json.Serialization;

namespace FreeCourse.Shared.Dtos
{
	public class Response<T>
	{
		public T Data { get; set; }

		[JsonIgnore] //Postmanda dönüş getle veri alınırsa eğer dönüş kodu zaten veriliyor birdaha ayriyetten nesne özelliği olarak ekranda gösterilmesine gerek yok. 
		public int StatusCode { get; private set; }

        [JsonIgnore]
        public bool isSuccessful { get;private  set; }

		public List<string> Errors { get; set; }



		public static Response<T> Success(T data,int statuscode)
		{


			return new Response<T> { Data = data, StatusCode = statuscode, isSuccessful = true };
		}

        public static Response<T> Success(int statuscode)
        {


            return new Response<T> {Data=default(T),StatusCode = statuscode, isSuccessful = true };
        }

		public static Response<T> Fail (List<string> errors,int statuscode)
		{
			return new Response<T>
			{
				Errors = errors,
				StatusCode=statuscode,
				isSuccessful=false
			};
		}

        public static Response<T> Fail(string error, int statuscode)
        {
			return new Response<T> { Errors = new List<string> { error},StatusCode=statuscode,isSuccessful=false };
        }
    }
}

