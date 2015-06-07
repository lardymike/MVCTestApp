using MVCTestApp.Models;
using Newtonsoft.Json;
using System;
using System.Net;

namespace MVCTestApp.Controllers
{
  public class JsonProxyClient
  {
    public Results GetData(String url) {

      var client = new WebClient();
      var data = client.DownloadString(url);

      Results rawdata = JsonConvert.DeserializeObject<Results>(data);
      
      return rawdata;
    }

    public ChartData GetChartData(Results rawdata)
    {
      ChartData chartdata = new ChartData();

      chartdata.Labels = rawdata[0].Score.Keys;

      return chartdata cd;
    }
  }
}