using System.Collections.Generic;

namespace CDIAC.Common.Models.Application
{
    public class BaseResponse
    {
        public BaseResponse()
        {
            this.Errors = new List<string>();
        }
        public List<string> Errors { get; set; }
        public Response Response { get; set; }
    }
}
