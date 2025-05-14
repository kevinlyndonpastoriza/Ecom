using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Framework.Types.Dto
{
    public abstract class BaseApiResponse
    {
        public BaseApiResponse(ResponseStatus status)
        {
            Status = status;
        }

        public ResponseStatus Status { get; }
    }
}
