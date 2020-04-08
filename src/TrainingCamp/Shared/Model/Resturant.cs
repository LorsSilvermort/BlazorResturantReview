
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TrainingCamp.Shared.Model
{
    public class Resturant
    {
        public int ResturantId { get; set; }
        [Required(ErrorMessage = "Du måste ange ett namn")]
        public string Name {get; set;}
        [Phone(ErrorMessage = "Ange ett riktigt telefonnummer")]
        public string Phone { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }
        public string Image { get; set; }
        public List<Review> Reviews { get; set; }
    }
}
