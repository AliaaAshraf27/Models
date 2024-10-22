namespace MedicalServices.AppMetaData
{
    // Class that defines API routing constants
    public class Router
    {
        public const string Root = "Api/";
        public const string Version = "V1/";
        public const string Rule = Root + Version;
        public static class AccountRouting
        {
            public const string Prefix = Rule + "Account/";
            public const string Register = Prefix + "Register";
        }
    }
}
