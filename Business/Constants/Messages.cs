using Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Business.Constants
{
    public static class Messages
    {
        public static string CarDetailUnvalid = "Araba Bilgisi veya Fiyatı minimum değerlerin altında";
        public static string CarAdded = "Araba eklendi";
        public static string CarDeleted = "Araba Silindi";
        public static string CarUpdated = "Araba Güncellendi";
        public static string CarDetailsListed = "Araba Detayları Getirildi";

        public static string CarImagesLimitExceded = "";
        public static string AuthorizationDenied = "Yetkiniz yok";

        public static string UserRegistered = "Kullanıcı Kayıt oldu";
        public static string UserNotFound = "Kullanıcı bulunamadı";
        public static string PasswordError = "Yanlış parola";
        public static string SuccessfulLogin = "Başarılı giriş";
        public static string UserAlreadyExists = "Kullanıcı Zaten kayıtlı";
        public static string AccessTokenCreated = "Access Token oluşturuldu";
    }
}
