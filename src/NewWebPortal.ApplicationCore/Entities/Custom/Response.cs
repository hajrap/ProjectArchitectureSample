using System.Collections.Generic;
using System.Net;

namespace NewWebPortal.ApplicationCore.Entities
{
    public class Response<T> where T : class
    {
        /// <summary>
        /// Returns exact HTTP status code
        /// </summary>
        public HttpStatusCode StatusCode { get; set; }

        /// <summary>
        /// Returns success message or error message. 
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// Returns entity after successful insert.
        /// </summary>
        public T Entity { get; set; }

        public List<T> EntityList { get; set; }
    }
}
