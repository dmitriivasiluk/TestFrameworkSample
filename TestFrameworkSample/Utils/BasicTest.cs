namespace TestFrameworkSample.Utils
{
    public abstract class BasicTest
    {
        public string Username { get; set; }
        public string Password { get; set; }

        public BasicTest()
        {
            Username = ConfigurationManager.GetProperty("username");

            Password = ConfigurationManager.GetProperty("password");
        }
    }
}