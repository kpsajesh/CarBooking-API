using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBookingData.DataModels
{
    public class Car : BaseDomainEntity
    {

        //public int Id { get; set; } //commented as it is inherited from the BaseDomainEntity class

        //double intYear = double.Parse(DateTime.Now.Year.ToString());

        [Required]
        [Range(1975, 2075)]
        /*[Range(1975, 2075,ErrorMessage ="Year must be between 1975 & 2075")]*/ //Can add error message explicitely like this.
        public int Year { get; set; }

        [Required]
        [StringLength(15, ErrorMessage = "Must be less than 15 chars.")]
        [Display(Name = "Colour")]
        public string? Name { get; set; }

        [ForeignKey(nameof(Make))] // DbContext automatically identify this a FK even without this line
        [Required]
        [Display(Name = "Make")]
        public int MakeId { get; set; }        
        
        [ForeignKey(nameof(Style))]
        [Required]
        [Display(Name = "Style")]
        public int StyleId { get; set; }

        [Display(Name = "Plate No")]
        public string RegnNo { get; set; }

        [ForeignKey(nameof(CarModel))]
        [Required]
        [Display(Name = "Model")]
        public int CarModelId { get; set; }

        [NotMapped]
        public virtual Make Make { get; set; } // It is known as the navigation property, which will help to get all columns in the second table like join
        [NotMapped]
        public virtual CarModel CarModel { get; set; } // It can be written without virtual also like public CarModel CarModel { get; set; }
        [NotMapped]
        public virtual Style Style { get; set; }// It is known as the navigation property, which will help to get all columns in the second table like join

        public virtual IList<Style> Styles { get; set; }
        public virtual IList<Make> Makes { get; set; }
        public virtual IList<CarModel> CarModels { get; set; }

    }
}
