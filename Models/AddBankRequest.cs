using System.ComponentModel.DataAnnotations;

namespace WebApplication5.Models
//save the input : and send to the server btwn client and server 
{
    public class AddBankRequest : IValidatableObject
    {

        [Required]
        public string LocationName { get; set; }
        [Url]
        public string LocationURL { get; set; }
        [Required]
        public string Branchmanger { get; set; }

        //custom validation balance : kd ,+ 50kd and rules on the vali 
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (LocationName.StartsWith("N"))
            {
                 yield return new ValidationResult("Name can not start with N");

            }
        }
    } 
    
}
