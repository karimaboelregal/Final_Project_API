using Models.Models.Enum;

namespace Web_API.Model
{
    public class OrderAPIModel
    {
        public Guid Id { get; set; }    
        public Status Status { get; set; }
    }
}
