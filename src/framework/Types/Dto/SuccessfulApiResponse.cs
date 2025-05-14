using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading.Tasks.Dataflow;

namespace Framework.Types.Dto
{
    /// <summary>
	///     Default DTO response
	/// </summary>
    [Serializable]
    public class SuccessfulApiResponse : BaseApiResponse
    {
        /// <summary>
        ///     Default constructor
        /// </summary>
        /// <param name="data">Data to return in response</param>
        /// <param name="messages">Messages to include in response</param>
        /// <param name="status">Response status (success or failed)</param>
        public SuccessfulApiResponse(
            Object data,
            IEnumerable<MessageModel>? messages = null
        ) : base(ResponseStatus.Success)
        {
            Payload = data;
            Messages = messages;
        }

        public object Payload { get; }
        public IEnumerable<MessageModel>? Messages { get; }
    }
}
