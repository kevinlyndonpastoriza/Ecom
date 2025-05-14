using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Framework.Types.Dto
{
    public class ModelValidationErrorResponse : BaseApiResponse
    {
        /// <summary>
        ///     Default constructor
        /// </summary>
        /// <param name="validation">Validation information to return in response</param>
        public ModelValidationErrorResponse(IEnumerable<ValidationErrorModel> validation)
            : base(ResponseStatus.Failed) 
        {
            Validation = validation;
        }

        public IEnumerable<ValidationErrorModel> Validation { get; }
    }
}
