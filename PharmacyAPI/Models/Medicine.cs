using PharmacyAPI.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PharmacyAPI
{
    public class Medicine
    {
        public int Id { get; set; }
        [Required]
        [StringLength(15, ErrorMessage ="Maximum 15 karakter olmalıdır.")]
        public string Name { get; set; }
        [Required]
        public string Company { get; set; }
        [Required]
        [Range(1,50)] // Tek seferde maksimum 50 ilacın stoklanmasına izin veriliyor.
        public int UnitsInStock { get; set; }
        [Required]
        public decimal UnitPrice { get; set; }
        [Required]
        [ExperitionDateValidation] // Son kullanma tarihi geçmiş mi diye kontrol ediliyor.
        public DateTime ExpirationDate { get; set; }
        public string Details { get; set; }
        
    }
}
