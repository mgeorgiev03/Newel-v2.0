using System.ComponentModel.DataAnnotations;

namespace Newel.Server.Model
{
    public abstract class BaseEntity
    {
        [Key]
        public Guid Id { get; set; }
    }
}
