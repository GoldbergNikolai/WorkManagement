using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WorkManagement.Models
{
    public class ResponseViewModel<T>
    {
        public T Data { get; set; }
        public string ErrorDesc { get; set; }
    }
}
