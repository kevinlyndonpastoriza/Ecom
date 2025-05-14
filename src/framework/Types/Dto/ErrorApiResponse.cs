using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Framework.Types.Dto
{
    public class ErrorApiResponse : BaseApiResponse
    {
        /// <summary>
		///     Default constructor
		/// </summary>
		/// <param name="error">Data to return in response</param>
		/// <param name="messages">Messages to include in response</param>
		/// <param name="status">Response status (success or failed)</param>
        public ErrorApiResponse(object error)
            : base(ResponseStatus.Failed)
        {
            Error = error;
        }

        public object Error { get; }
    }
}
