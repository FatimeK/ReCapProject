using Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Business.Constants
{
    public static class Messages
    {
        public static string CarAdded = "Araba Eklendi!";
        public static string CarNameInvalid = "Böyle bir araba bulunmuyor";
        public static string MaintenanceTime = "Sistem bakımda";
        public static string CarsListed = "Arabalar listelendi";
        public static string CustomerAdded = "Müşteri Eklendi!";
        public static string CustomerDeleted = "Müşteri silindi!";
        public static string ImageAdded;
        public static string ImageDeleted;
        public static string ImageUpdated;
        public static string ImagesListed;
        public static string CarImageLimitExceeded;
        public static string UserNotFound = "Kullanıcı bulunamadı.";
        public static string PasswordError = "Parola hatası.";
        public static string SuccessfulLogin = "Başarılı giriş.";
        internal static string UserAdded;
        public static string AuthorizationDenied = "AuthorizationDenie";
    }
}
