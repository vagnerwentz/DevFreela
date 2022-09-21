namespace DevFreela.Core.Exceptions
{
    public class EmailAlreadyExistsException : Exception
    {
        public EmailAlreadyExistsException() : base("Email already exists!")
        {
        }
    }
}

