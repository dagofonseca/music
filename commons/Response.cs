using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace commons
{
    public class Response
    {
        #region Properties
        public bool Status { get; set; }
        public String Message { get; set; }
        #endregion

        #region Constructors
        public Response(bool status, string message)
        {
            Status = status;
            Message = message;
        }

        public Response(bool status) 
            : this(status, "There is no message") {            
        }
        #endregion
    }
}
