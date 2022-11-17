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
    public class Make : BaseDomainEntity
    {
        //public int Id { get; set; } //commented as it is inherited from the BaseDomainEntity class

        [Required]
        [Display(Name = "Make")]
        public string? Name { get; set; }

        [NotMapped]
        public CarModel CarModel { get; set; }

        public virtual IList<Style> Styles { get; set; }
        public virtual IList<Car> Cars { get; set; }
        public virtual IList<CarModel> CarModels { get; set; }
    }
}
