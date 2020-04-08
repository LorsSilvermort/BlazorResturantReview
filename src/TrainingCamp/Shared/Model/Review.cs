using System;
using TrainingCamp.Shared.Model;

using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace TrainingCamp.Shared.Model
{
    public class Review
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Du måste ange datum")]
        public DateTime Date { get; set; } = DateTime.Now.ToLocalTime();
        [Required(ErrorMessage = "Du måste ange en kort kommentar")]
        [RegularExpression(@"^[a-zåäöA-ZÅÄÖ0-9 ., '\s-]*$", ErrorMessage = "En kommentar kan endast innehålla bokstäver och tecken")]
        [StringLength(80, MinimumLength = 3, ErrorMessage = "Max 80 tecken och minst 3")]
        public string Comment { get; set; }
        public string Image { get; set; }


        [Required(ErrorMessage = "Du måste ange betyg")]
        [Range(1,5)]
        public int Grade { get; set; } = 1;

       
        public int ResturantId { get; set; }
        [JsonIgnore]
        public Resturant Resturant { get; set; }
    }
}
