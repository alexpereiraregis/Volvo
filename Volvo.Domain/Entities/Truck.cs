using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Volvo.Domain.Entities
{
    public class Truck
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Model { get; set; }
        public int YearManufacture { get; set; }
        public int ModelYear { get; set; }
    }
}
