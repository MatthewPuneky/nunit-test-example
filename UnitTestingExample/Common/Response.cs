using System.Collections.Generic;

namespace UnitTestExample.Common
{
    public class Response<T>
    {
        public T Data { get; set; }
        public bool IsValid { get; set; } = true;
        public List<ErrorMessage> ErrorMessages { get; set; } = new List<ErrorMessage>();
    }
}