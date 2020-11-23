using System.Collections.Generic;

namespace Kebattle.Web.Models.Company
{
    public class StatisticsListViewModel
    {
        public int CompanyId { get; set; }
        public StatisticsListViewModel()
        {
            Statistics = new List<StatisticViewModel>();
        }

        public StatisticsListViewModel(List<DomainModel.Order> statistics)
        {
            Statistics = new List<StatisticViewModel>();
            statistics.ForEach(a => Statistics.Add(new StatisticViewModel(a)));
        }

        public List<StatisticViewModel> Statistics { get; set; }
    }
}