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
            public const string Login = Prefix + "Login";
        }
        public static class DoctorsRouting
        {
            public const string Prefix = Rule + "Doctors/";
            public const string GetList = Prefix + "GetAllDoctors";
        }
        public static class BookingRouting
        {
            public const string Prefix = Rule + "Booking/";
            public const string GetAvailableSlots = Prefix + "GetAvailableSlots";
            public const string BookAppointment = Prefix + "BookAppointment";
            public const string CancelAppointment = Prefix + "CancelAppointment";
            public const string GetAllBooking = Prefix + "GetAllBooking";
        }
        public static class ProfileRouting
        {
            public const string Prefix = Rule + "Profile/";
            public const string GetUser = Prefix + "GetUserProfile";
            public const string UpdateUser = Prefix + "UpdateUserProfile";
        }
        public static class NotificationRouting
        {
            public const string Prefix = Rule + "Notification/";
            public const string GetNotification = Prefix + "GetNotification";
        }
        public static class ChatRouting
        {
            public const string Prefix = Rule + "Chat/";
            public const string GetMessage = Prefix + "GetMessage";
            public const string SaveMessage = Prefix + "SaveMessage";
            public const string GetAllChats = Prefix + "GetAllChats";

        }
    }
}
