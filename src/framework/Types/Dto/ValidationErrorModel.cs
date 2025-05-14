using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Framework.Types.Dto
{
    public class ValidationErrorModel
    {
        public ValidationErrorModel(string field, IEnumerable<string> validationErrors)
        {
            Field = field;
            ValidationErrors = validationErrors;
        }

        public string Field { get; }
        public IEnumerable<string> ValidationErrors { get; }
    }
}
