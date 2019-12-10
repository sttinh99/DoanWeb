using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TestCase.Models
{
    public class Appointments
    {
        [Key]
        public int Id { get; set; }

        public DateTime AppointmentDate { get; set; }
        [NotMapped]
        public DateTime AppointmentTime { get; set; }
        public string CustomerName { get; set; }
        public string CustomerPhoneNumber { get; set; }
        public string CustomerEmail { get; set; }
        public bool isConfirmed { get; set; }
        public double Recceipt { get; set; } //Thêm 1 trường Recceipt để tính tổng giá tiền của các sản phẩm
    }
}
