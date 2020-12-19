using System;

namespace Lab6.ViewModels
{
    public class ParkingViewModel
    {
        public int Id { get; set; }
        public string TypeParking { get; set; }
        public DateTime Dateentry { get; set; }
        public DateTime Datedeparture { get; set; }
        public string CarsNumber { get; set; }
        public decimal Price { get; set; }
        public string StaffFIO { get; set; }
    }
}
