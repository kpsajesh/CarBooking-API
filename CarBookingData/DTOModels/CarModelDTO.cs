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
    public class CarModelDTO : CreateCarModelDTO
    {
        public int Id { get; set; }
        public string? UpdatedBy { get; set; }
        public DateTime UpdatedDate { get; set; }
        public MakeDTO? Make { get; set; } // This will give all the fields defined in the MakeDTO


        // these are to fetch the details of other DTO from other DTOs
        //eg: Give all the cars and Makes based on Carmodel
        public List<StyleDTO>? Styles { get; set; }
        public List<MakeDTO>? Makes { get; set; }
        public List<CarDTO>? Cars { get; set; }
    }
}
