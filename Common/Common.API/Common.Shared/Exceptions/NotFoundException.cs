using Common.Shared.Resources;

namespace Common.Shared.Exceptions
{
    public class NotFoundException : CustomException
    {
        public NotFoundException(string name, string property, object key)
            : base(string.Format(ErrorMessageResource.NotFoundError, name, property, key))
        {
        }
    }
}
