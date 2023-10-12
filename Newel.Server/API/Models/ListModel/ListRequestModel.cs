using System.ComponentModel.DataAnnotations;

namespace API.Models.ListModel
{
    public class ListRequestModel : BaseRequestModel
    {
        [Required]
        public string Name { get; set; }

        public Guid userId { get; set; }
    }
}
