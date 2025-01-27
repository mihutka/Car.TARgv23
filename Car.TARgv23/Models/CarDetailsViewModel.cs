namespace Car.TARgv23.Models
{
    public class CarDetailsViewModel
    {
        public Guid Id { get; set; }

        public string? Brand { get; set; }

        public string? Model { get; set; }

        public string? Number { get; set; }

        public int? Mileage { get; set; }

        public bool? TechnicalInspection { get; set; }

        public DateTime? CreatedAt { get; set; }
        public DateTime? ModifiedAt { get; set; }
    }
}
