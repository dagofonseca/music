using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace commons
{
    public class Response<T>
    {
        #region Properties
        public bool Status { get; set; }
        public String Message { get; set; }
        public T Data { get; set; }
        #endregion

        #region Constructors
        public Response(bool status, string message, T data)
        {
            Status = status;
            Message = message;
            Data = data;
        }

        public Response(bool status, T data) 
            : this(status, "There is no message", data) {
        }
        #endregion
    }
}
