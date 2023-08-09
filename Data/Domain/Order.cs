using Core.DomainDrivenDesign;

namespace Data.Domain
{
    public class Order : Entity, IAggregateRoot
    {
        public string BuyerId { get; private set; }
        public DateTime CreatedDate { get; private set; }
        public Address Address { get; private set; }

        private readonly List<OrderItem> _orderItems;
        public IReadOnlyCollection<OrderItem> OrderItems => _orderItems;

        public Order() { }

        public Order(Address address)
        {
            BuyerId = Guid.NewGuid().ToString().Substring(0, 10).ToUpper();
            CreatedDate = DateTime.Now;
            Address = address;
            _orderItems = new List<OrderItem>();
        }

        public void AddOrderItem(string productId, string productName, decimal price)
        {
            var existProduct = _orderItems.Any(x => x.ProductId == productId);
            if (!existProduct)
            {
                var newOrderItem = new OrderItem(productId, productName, price);
                _orderItems.Add(newOrderItem);
            }
        }

        public decimal GetTotalPrice => _orderItems.Sum(x => x.Price);
    }
}