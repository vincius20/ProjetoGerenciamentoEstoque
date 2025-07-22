using Entities.Enums;
using Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServicesContracts.DTO
{
    public class SellerAddRequest
    {
        [Required(ErrorMessage = "O vendedor tem que ter um nome")]
        [StringLength(100)]
        public string? SellerName { get; set; }

        [Required(ErrorMessage = "O vendedor tem que ter algum email para contato")]
        [EmailAddress(ErrorMessage = "O valor deve ser de um email válido")]
        [DataType(DataType.EmailAddress)]
        [StringLength(255)]
        public string? Email { get; set; }

        [DataType(DataType.PhoneNumber)]
        [StringLength(15, ErrorMessage = "O numero pode ter no maximo 15 digitos")]
        public string? PhoneNumber { get; set; }
        public DateOnly? DateOfBirth { get; set; }

        [Required(ErrorMessage = "O vendedor deve ter um salario base")]
        [Range(0, double.MaxValue, ErrorMessage = "O salario nao pode ter um valor negativo")]
        public double? Salary { get; set; }

        [Required]
        public Status? Status { get; set; }

        public Seller ToSeller()
        {
            return new Seller()
            {
                SellerName = SellerName,
                Email = Email,
                PhoneNumber = PhoneNumber,
                DateOfBirth = DateOfBirth,
                Salary = Salary,
                Status = Status
            };
        }
    }
}
