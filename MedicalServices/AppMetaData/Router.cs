﻿namespace MedicalServices.AppMetaData
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
            public const string DeleteAccount = Prefix + "DeleteAccount";
        }
        public static class AppointmentRouting
        {
            public const string Prefix = Rule + "Appointment/";
            public const string AddAppointment = Prefix + "AddAppointment";
            public const string RemoveAppointment = Prefix + "Removeppointment";
        }
        public static class DoctorsRouting
        {
            public const string Prefix = Rule + "Doctors/";
            public const string GetList = Prefix + "GetAllDoctors";
            public const string AddFavoriteDR = Prefix + "AddFavoriteDR";
            public const string RemoveFavoriteDR = Prefix + "RemoveFavoriteDR";
            public const string AddDoctor = Prefix + "AddDoctor";
            public const string RemoveDoctor = Prefix + "RemoveDoctor";

        }
        public static class PatientRouting
        {
            public const string Prefix = Rule + "Patient/";
            public const string GetAllPatients = Prefix + "GetAllPatients";
        }
        public static class BookingRouting
        {
            public const string Prefix = Rule + "Booking/";
            public const string GetAvailableSlots = Prefix + "GetAvailableSlots";
            public const string BookAppointment = Prefix + "BookAppointment";
            public const string CancelAppointment = Prefix + "CancelAppointment";
            public const string GetCanceledBookings = Prefix + "GetCanceledBookings";
            public const string AllBooking = Prefix + "AllBookingByPatientId";
            public const string GetCompletedBookingsByDoctor = Prefix + "GetCompletedBookingsByDoctor";
            public const string GetBookingDetails = Prefix + "GetBookingDetails";
            public const string UpdateBooking = Prefix + "UpdateBooking";
            public const string GetAllBookings = Prefix + "GetAllBookings";
        }
        public static class ProfileRouting
        {
            public const string Prefix = Rule + "Profile/";
            public const string GetUser = Prefix + "GetUserProfile";
            public const string GetAdmin = Prefix + "GetAdminProfile";
            public const string UpdateUser = Prefix + "UpdateUserProfile";
            public const string UpdateDr = Prefix + "UpdateDoctorProfile";
            public const string UpdateAdmin = Prefix + "UpdateAdminProfile";

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
            public const string SendMessage = Prefix + "SendMessage";
            public const string GetAllChats = Prefix + "GetAllChats";

        }
        public static class ReviewRouting
        {
            public const string Prefix = Rule + "Review/";
            public const string AddReview = Prefix + "AddReview";
            public const string GetAllReviewsById = Prefix + "GetAllReviewsByDrId";
            public const string GetAllReviews = Prefix + "GetAllReviews";
            public const string DeleteReview = Prefix + "DeleteReview";
        }
        public static class SpecializationRouting
        {
            public const string Prefix = Rule + "Specialization/";
            public const string GetSpecializations = Prefix + "GetAllSpecializations";
            public const string GetDoctorsBySpecializationID = Prefix + "GetDoctorsBySpecializationID";
            public const string AddSpecialization = Prefix + "AddSpecialization";
            public const string RemoveSpecialization = Prefix + "RemoveSpecialization";
        }
        public static class LocationRouting
        {
            public const string Prefix = Rule + "Location/";
            public const string AddOrUpdateLocation = Prefix + "AddOrUpdateLocation";
            public const string NearbyDoctors = Prefix + "NearbyDoctors";

        }
    }
}
