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
    // This is for the CatrModel basic record
    public class CarModelDTO
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Car Model")]
        public string? Name { get; set; }

        // these are to fetch the details of other DTO from other DTOs
        //eg: Give all the cars and Makes based on Carmodel
        public virtual IList<StyleDTO>? Styles { get; set; }
        public virtual IList<MakeDTO>? Makes { get; set; }
        public virtual IList<CarDTO>? Cars { get; set; }
    }

    //This is with all information of carModel record
    public class CarModelAllInfoDTO : CarModelDTO
    {
        public string? CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string? UpdatedBy { get; set; }
        public DateTime UpdatedDate { get; set; }
    }
    // This is for the create operations, so PK id is not needed, it will be generated automatically
    public class CreateCarModelDTO
    {
        [Required]
        [Display(Name = "Car Model")]
        public string? Name { get; set; }
        public string? CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }

        [Required]
        public int MakeId { get; set; }// We need to pass only the PK of Make ID for create scenario
    }

    // This is for all other operations except create.
    // Can have seperate DTOs for each operations, ie one DTO for update all fields, another DTO for updating some specific fields 
    
    public class CarModelUpdateDTO
    {
        public int Id { get; set; }
        [Required]
        [Display(Name = "Car Model")]
        public string? Name { get; set; }
        [Required]
        public int MakeId { get; set; }// We need to pass only the PK of Make ID for create scenario
        public string? UpdatedBy { get; set; }
        public DateTime UpdatedDate { get; set; }
    }

}
