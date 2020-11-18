using System.Collections.Generic;

namespace Kebattle.Web.Models.Order
{
    public class OrdersListViewModel
    {
        public OrdersListViewModel()
        {
            Orders = new List<DomainModel.Order>();
        }

        public OrdersListViewModel(List<DomainModel.Order> orders)
        {
            Orders = orders;
        }

        public List<DomainModel.Order> Orders { get; set; }
    }
}