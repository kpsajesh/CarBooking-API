using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace CarBookingData.DataModels
{
    public class CarModel : BaseDomainEntity
    {
        [Required]
        [Display(Name = "Car Model")]
        public string? Name { get; set; }

        [ForeignKey(nameof(Make))]
        public int MakeId { get; set; }


        [NotMapped]
        public virtual Make Make { get; set; }
        
        public List<Style> Styles { get; set; }        
        public List<Make> Makes { get; set; }
        public List<Car> Cars { get; set; }
    }
}
