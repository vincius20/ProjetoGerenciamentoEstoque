  using Entities;
using Services.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServicesContracts.DTO
{
    public class SalesRecordAddRequest
    {
        [DataType(DataType.DateTime)]
        public DateTime? Date { get; set; }
        public double? Amount { get; set; }
        //Lembrar de fazer tratamento no metodo AddSalesRecord
        public List<Guid>? Products { get; set; }
        public Guid SellerId { get; set; }

        [Required(ErrorMessage = "Esse campo é obrigatório")]
        public SalesStatus SalesStatus { get; set; }

        public SalesRecord ToSalesRecord()
        {
            return new SalesRecord()
            {
                Date = Date,
                Amount = Amount,
                SellerId = SellerId,
                SalesStatus = SalesStatus
            };
        }
    }
}
