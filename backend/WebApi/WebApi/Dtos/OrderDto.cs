using WebApi.Models;

namespace WebApi.View_Models
{
    public class OrderDto
    {
        public string UserId { get; set; } = null!;

        public CartItemModel[] CartItems { get; set; } = null!;

        public string Name { get; set; } = null!;

        public string LastName { get; set; } = null!;

        public string PhoneNumber { get; set; } = null!;

        public string Email { get; set; } = null!;

        public string Country { get; set; } = null!;

        public string Region { get; set; } = null!;

        public string City { get; set; } = null!;

        public string Address { get; set; } = null!;

        public string Index { get; set; } = null!;

        public decimal TotalSum { get; set; }
    }
}
