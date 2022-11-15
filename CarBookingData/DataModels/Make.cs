using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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

        public List<Style>? Styles { get; set; }
        public List<Car>? Cars { get; set; }
        public virtual List<CarModel>? CarModels { get; set; }
    }
}
