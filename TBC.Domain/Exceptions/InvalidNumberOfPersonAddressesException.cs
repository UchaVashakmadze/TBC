using Common.Shared.Exceptions;

namespace TBC.Domain.Exceptions
{
    public class InvalidNumberOfPersonAddressesException : CustomException
    {
        public InvalidNumberOfPersonAddressesException() : base("Invalid Number of Person Addresses")
        {

        }
    }
}
