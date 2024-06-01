namespace BarberFusion.Application.Exceptions
{
    public class UserHasAlreadyAccountException : Exception
    {
        public UserHasAlreadyAccountException(string message) : base(message) { }
    }
}
