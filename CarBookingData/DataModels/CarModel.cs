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
        public Make Make { get; set; }

        public virtual IList<Style> Styles { get; set; }        
        public virtual IList<Make> Makes { get; set; }
        public virtual IList<Car> Cars { get; set; }
    }
}
