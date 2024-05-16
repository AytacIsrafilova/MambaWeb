using System.ComponentModel.DataAnnotations.Schema;

namespace MambaWeb.Models
{
    public class Team
    {
        public int Id { get; set; }

        public string Fullname { get; set; }
        public string Profession {  get; set; }
        public string? ImgUrl { get; set; }
        public List<Team> teams { get; set; }
        [NotMapped]
        public IFormFile? PhotoFile { get; set; }

    }
}
