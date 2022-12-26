using Microsoft.VisualBasic;
using System;
using System.Globalization;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace Backend.Models
{
    public class GuestBookModel
    {
        [NotNull]
        public int Id { get; set; }
        [NotNull]
        public string Nama { get; set; }
        [NotNull]
        public string No_Hp { get; set; }
        [NotNull]
        public string Email { get; set; }
        [NotNull]
        public string Alamat { get; set; }
        [NotNull]
        public string Provinsi { get; set; }
        [NotNull]
        public string Kota_Kabupaten { get; set; }
        [NotNull]
        public string Kecamatan { get; set; }
        [NotNull]
        public string Kelurahan { get; set; }
        [NotNull]
        public string Kode_Pos { get; set; }
        [NotNull]
        public DateTime Kehadiran { get; set; }
    }
}
