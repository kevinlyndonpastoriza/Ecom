using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Framework.Types.Dto
{
    [Serializable]
    public class MessageModel
    {
        public MessageModel(string id, string detail, SeverityType severity) 
        { 
            Id = id;
            Detail = detail;
            Severity = severity;
        }

        public string Id { get; }
        public string Detail { get; }
        public SeverityType Severity { get; }
    }
}
