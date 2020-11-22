using System.Collections.Generic;

namespace Kebattle.Web.Models.Order
{
    public class OrdersListViewModel
    {
        public int CompanyId { get; set; }
        public OrdersListViewModel()
        {
            Orders = new List<OrderViewModel>();
        }

        public OrdersListViewModel(List<DomainModel.Order> orders)
        {
            Orders = new List<OrderViewModel>();
            orders.ForEach(a => Orders.Add(new OrderViewModel(a)));
        }

        public List<OrderViewModel> Orders { get; set; }
    }
}