using System.Collections;
using System.Collections.Generic;
using Chart.Mvc.ComplexChart;

namespace MVCTestApp.Models
{

  public class RawData
  {
    public string Subject { get; set; }
    public Dictionary<string, double> Score { get; set; }
  }

  public class Results : List<RawData>
  {
    public List<RawData> Result { get; set; }
  }

  public class ChartData
  {
    public IEnumerable<string> Labels { get; set; }

    public IEnumerable<ComplexDataset> Datasets { get; set; }
  }
}