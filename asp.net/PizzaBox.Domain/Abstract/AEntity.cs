using System.ComponentModel.DataAnnotations;

namespace PizzaBox.Domain.Abstract
{
    public abstract class AEntity
    {
        [Key]
        public long EntityID { get; set; }
        protected AEntity(){}
    }
}
