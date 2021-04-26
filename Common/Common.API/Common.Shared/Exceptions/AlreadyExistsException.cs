using Common.Shared.Resources;

namespace Common.Shared.Exceptions
{
    public class AlreadyExistsException : CustomException
    {
        public AlreadyExistsException(string name, string property, object key)
            : base(string.Format(ErrorMessageResource.AlreadyExistsError, name, property, key))
        {
        }
    }
}
