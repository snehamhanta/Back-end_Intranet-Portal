using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IntranetPortal.Models
{
    public class YStoriesModel
    {
        [Key]


        public int videoId { get; set; }

        public string videoURL { get; set; }


        [NotMapped]
        public string? videoTitle { get; set; }
    }
}
