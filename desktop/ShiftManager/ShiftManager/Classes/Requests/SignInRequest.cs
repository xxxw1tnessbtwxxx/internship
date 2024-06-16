namespace TimeControllerAPI.Classes
{
    public record SignInRequest
    {

        public string Login { get; private set; }
        public string Password { get; private set; }


        public SignInRequest(string Login, string Password)
        {
            this.Login = Login;
            this.Password = Password;
        }
    }
}
