using System;
using System.ComponentModel.DataAnnotations;


namespace Lab6.Models
{
    public class Staffs
    {
        [Key]
        public int Id { get; set; }
        public string FIOStaffs { get; set; }
        public int schedulesId { get; set; }
    }
}
