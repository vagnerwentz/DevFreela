namespace DevFreela.Application.ViewModel
{
    public class SignInViewModel
    {
        public SignInViewModel(string email, string token)
        {
            Email = email;
            Token = token;
        }

        public string Email { get; private set; }
        public string Token { get; private set; }
    }
}

