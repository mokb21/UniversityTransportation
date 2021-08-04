using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniversityTransportation.Models
{
    public class DashboardModel
    {
        public BarChartDataModel roomsBarChart { get; set; } = new BarChartDataModel();
    }

    public class BarChartDataModel
    {
        public List<string> labels { get; set; } = new List<string>();
        public List<BarChartDataSetModel> datasets { get; set; } = new List<BarChartDataSetModel>();

    }

    public class BarChartDataSetModel
    {
        public string label { get; set; }
        public string backgroundColor { get; set; }
        public string borderColor { get; set; }
        public List<int> data { get; set; } = new List<int>();
    }
}
