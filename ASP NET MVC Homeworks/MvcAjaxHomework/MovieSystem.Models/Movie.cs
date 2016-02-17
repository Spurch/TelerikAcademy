using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieSystem.Models
{
    public class Movie
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Year { get; set; }

        [Required]
        public string Director { get; set; }

        public Actor LeadingMale { get; set; }

        public Actor LeadingFemale { get; set; }
    }
}
