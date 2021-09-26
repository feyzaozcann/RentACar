using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Constants
{
    public static class Messages
    {
        public static string CarAdded = "Araba eklendi";
        public static string CarIdInvalid ="Araba numarası geçersiz";
        public static string MaintenanceTime = "Sistem bakımda";
        public static string CarsListed = "Arabalar listelendi";
        public static string CarsDeleted ="Arabalar silindi";
        public static string CarsUpdated = "Arabalar güncellendi";
        public static string UserAdded = "Kullanıcı eklendi";
        public static string UserDeleted = "Kullanıcı silindi";
        public static string UserUpdated = "Kullanıcı güncellendi";
        public static string RentalAdded = "Kiralık araba eklendi";
        public static string RentalDeleted = "Kiralık araba silindi";
        public static string RentalUpdated = "Kiralık araba güncellendi";
        public static string CustomerAdded = "Müşteri eklendi";
        public static string CustomerDeleted = "Müşteri silindi";
        public static string CustomerUpdated = "Müşteri güncellendi";
        public static string RentDateInvalid = "Kiralama tarihi geçerli değil";
        public static string DailyPriceInvalid = "Günlük fiyatı geçerli değil";
        public static string CarCountofBrandError = "Bir markadan en fazla 10 araba olabilir";
        public static string CarAlreadyExists = "Araba zaten kayıtlı";
    }
}
