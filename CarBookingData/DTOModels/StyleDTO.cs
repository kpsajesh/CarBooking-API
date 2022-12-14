using CarBookingData.DataModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBookingData.DTOModels
{
    // This is for the create operations, so PK id is not needed, it will be generated automatically
    public class CreateStyleDTO
    {
        [Required]
        public string? Name { get; set; }
        public string? CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
    }

    // This is for all other operations except create.
    // Can have seperate DTOs for each operations, ie one DTO for update all fields, another DTO for updating some specific fields 
    public class StyleDTO : CreateStyleDTO
    {
        public int Id { get; set; }
        public string? UpdatedBy { get; set; }
        public DateTime UpdatedDate { get; set; }

        // these are to fetch the details of other DTO from other DTOs
        //eg: Give all the cars and models based on make
        public List<MakeDTO>? Makes { get; set; }
        public List<CarDTO>? Cars { get; set; }
        public virtual List<CarModelDTO>? CarModels { get; set; }
    }
}
