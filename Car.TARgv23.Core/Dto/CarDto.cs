using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Car.TARgv23.Core.Dto
{
    public class CarDto
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
