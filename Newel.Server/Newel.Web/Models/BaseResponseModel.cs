using System.ComponentModel.DataAnnotations;

namespace Newel.Web.Models
{
    public class BaseResponseModel
    {
        [Key]
        public Guid Id { get; set; }
    }
}
