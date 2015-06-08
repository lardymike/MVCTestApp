using Chart.Mvc.ComplexChart;
using MVCTestApp.Models;
using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Net;
using System.Linq;

namespace MVCTestApp.Controllers
{
  public class JsonProxyClient
  {
    public string URL { get; private set; }
    public Results RawData {get; private set;}
    public ChartData ParsedData {get; private set;}

    //Private constructor
    private JsonProxyClient(string ApiURL)
    {
      URL = ApiURL;

      var client = new WebClient();
      var data = client.DownloadString(URL);

      this.RawData = JsonConvert.DeserializeObject<Results>(data);

      List<string> labels = new List<string>();
      List<ComplexDataset> datasets = new List<ComplexDataset>();

      foreach (string key in this.RawData[0].Score.Keys)
      {
        labels.Add(key);
      }

      foreach (RawData element in this.RawData)
      {
        datasets.Add(new ComplexDataset
        {
          Data = element.Score.Values.ToList<double>(),
          Label = element.Subject,
          FillColor = "",
          StrokeColor = "",
          PointColor = "",
          PointStrokeColor = "",
          PointHighlightFill = "",
          PointHighlightStroke = "",
        });
      }

      this.ParsedData = new ChartData();
      this.ParsedData.Labels = labels.ToArray();
      this.ParsedData.Datasets = datasets.ToArray();
    }

    //Public factory
    public static JsonProxyClient CreateJsonProxy(string URL)
    {
      return new JsonProxyClient(URL);
    }
  }
}