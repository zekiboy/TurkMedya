using System;
namespace TurkMedya.Entity
{
	public class Root
	{
        //json veriyi karşılayacağımız kapsayıcı sınıf
        public int ErrorCode { get; set; }
        public string ErrorMessage { get; set; }
        public List<Data> Data { get; set; }
    }
}

