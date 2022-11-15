using CarBookingData.DataModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBookingData.DTOModels
{
    // This is for the create operations, so PK id is not needed, it will be generated automatically
    public class CreateCarDTO
    {
        [Required]
        [Range(1975, 2075)]
        /*[Range(1975, 2075,ErrorMessage ="Year must be between 1975 & 2075")]*/ //Can add error message explicitely like this.
        public int Year { get; set; }

        [Required]
        [StringLength(15, ErrorMessage = "Must be less than 15 chars.")]
        [Display(Name = "Colour")]
        public string? Name { get; set; }

        [Required]
        [Display(Name = "Plate No")]
        //[MaxLength(12,ErrorMessage ="Must be less than 12 chars.")]
        //[StringLength(maximumLength:12, ErrorMessage = "Must be less than 12 chars.")]
        //[Range(1,5)]
        public string? RegnNo { get; set; }

        [Required]
        public int MakeId { get; set; } // Make ID PK for create scenario

        [Required]
        public int StyleId { get; set; }// Style ID PK for create scenario 

        [Required]
        public int CarModelId { get; set; }// CarModel ID PK for create scenario


        public string? CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
    }

    // This is for all other operations except create.
    // Can have seperate DTOs for each operations, ie one DTO for update all fields, another DTO for updating some specific fields 
    public class CarDTO : CreateCarDTO
    {
        public int Id { get; set; }
        public string? UpdatedBy { get; set; }
        public DateTime UpdatedDate { get; set; }

        public MakeDTO? Make { get; set; } // This will give all the fields defined in the MakeDTO
        public StyleDTO? Style { get; set; } // This will give all the fields defined in the StyleDTO
        public CarModelDTO? CarModel { get; set; } // This will give all the fields defined in the CarModelDTO
    }
}
