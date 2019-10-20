using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ChartsDashBoardDemo.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult DashBoard()
        {
            return View();
        }
        public ActionResult Chart()
        {
            return View();
        }
        public string GetJson()
        {
            string json = @"{
        type: 'bar',
        data: {
            labels: ['Red', 'Blue', 'Yellow', 'Green', 'Purple', 'Orange'],
            datasets: [{
                label: '# of Votes',
                backgroundColor:
                    [
                    'rgba(255, 99, 132, 0.2)',
                    'rgba(54, 162, 235, 0.2)',
                    'rgba(255, 206, 86, 0.2)',
                    'rgba(75, 192, 192, 0.2)',
                    'rgba(153, 102, 255, 0.2)',
                    'rgba(255, 159, 64, 0.2)'
                    ] 
                ,
                borderColor: [
                    'rgba(255, 99, 132, 1)',
                    'rgba(54, 162, 235, 1)',
                    'rgba(255, 206, 86, 1)',
                    'rgba(75, 192, 192, 1)',
                    'rgba(153, 102, 255, 1)',
                    'rgba(255, 159, 64, 1)'
                ],
                borderWidth: 1
            }
            ]
        },
    }";

            JObject rss = JObject.Parse(json);
            try
            {

                JObject dataChannel = (JObject)rss["data"];
                JArray datasetsChannel = (JArray)dataChannel["datasets"];
                foreach (JObject item in datasetsChannel)
                {
                    item.AddFirst(new JProperty("data", "[12, 19, 3, 5, 2, -3]"));
                }
            }
            catch (Exception ex)
            {

            }
            return rss.ToString().Replace('\"', '\'').Replace("'type':", "type:")
                .Replace("'data':", "data:")
                .Replace("'labels':", "labels:")
                .Replace("'datasets':", "datasets:")
                .Replace("'label':", "label:")
                .Replace("'backgroundColor':", "backgroundColor:")
                .Replace("'borderColor':", "borderColor:")
                .Replace("'borderWidth':", "borderWidth:");
            //return Json(rss, JsonRequestBehavior.AllowGet) ;
        }
        [HttpGet]
        public ActionResult GetDashBoardCharts()
        {
            var Charts = new List<string>();
            Charts.Add("8b34a8a7-3198-4f15-9d7e-b34ec2e6b64a");
            Charts.Add("bfd404fc-c906-4b7d-8565-0ffbe754adb5");
            Charts.Add(Guid.NewGuid().ToString());
            return Json(new { data = Charts }, @"application/json", JsonRequestBehavior.AllowGet);
        }
        [HttpGet]
        public ActionResult GetChartData(string chartGuid)
        {
            if (chartGuid == "8b34a8a7-3198-4f15-9d7e-b34ec2e6b64a")
            {
                Data data = new Data();

                data.labels = new List<string> { "Red", "Blue", "Yellow", "Green", "Purple", "Orange" };

                Dataset dataset = new Dataset();
                dataset.label = "Test Bar Chart";
                dataset.data = new List<int> { 12, 19, 13, 15, 12, 7 };
                dataset.backgroundColor = new List<string> { "rgba(255, 99, 132, 0.2)", "rgba(54, 162, 235, 0.2)", "rgba(255, 206, 86, 0.2)", "rgba(75, 192, 192, 0.2)", "rgba(153, 102, 255, 0.2)", "rgba(255, 159, 64, 0.2)" };
                dataset.borderColor = new List<string> { "rgba(255, 99, 132, 1)", "rgba(54, 162, 235, 1)", "rgba(255, 206, 86, 1)", "rgba(75, 192, 192, 1)", "rgba(153, 102, 255, 1)", "rgba(255, 159, 64, 1)" };

                data.datasets.Add(dataset);


                return Json(new
                {
                    data = data,
                    type = "bar",
                }
                    , @"application/json", JsonRequestBehavior.AllowGet);
            }

            else if(chartGuid == "bfd404fc-c906-4b7d-8565-0ffbe754adb5")
            {
                Data data = new Data();

                data.labels = new List<string> { "January", "February", "March", "April", "May", "June", "July" };

                Dataset dataset = new Dataset();
                dataset.label = "Test Line Chart";
                dataset.data = new List<int> { 0, 10, 5, 2, 20, 30, 45 };
                dataset.backgroundColor = new List<string> { "rgb(255, 99, 132)" };
                dataset.borderColor = new List<string> { "rgb(255, 99, 132)" };

                data.datasets.Add(dataset);


                return Json(new
                {
                    data = data,
                    type = "line",
                }
                    , @"application/json", JsonRequestBehavior.AllowGet);
            }
            else
            {
                Data data = new Data();

                data.labels = new List<string> { "Red", "Blue", "Yellow", "Green", "Purple", "Orange" };

                Dataset dataset = new Dataset();
                dataset.label = "Test Bar Chart";
                dataset.data = new List<int> { 12, 19, 13, 15, 12, 7 };
                dataset.backgroundColor = new List<string> { "rgba(255, 99, 132, 0.2)", "rgba(54, 162, 235, 0.2)", "rgba(255, 206, 86, 0.2)", "rgba(75, 192, 192, 0.2)", "rgba(153, 102, 255, 0.2)", "rgba(255, 159, 64, 0.2)" };
                dataset.borderColor = new List<string> { "rgba(255, 99, 132, 1)", "rgba(54, 162, 235, 1)", "rgba(255, 206, 86, 1)", "rgba(75, 192, 192, 1)", "rgba(153, 102, 255, 1)", "rgba(255, 159, 64, 1)" };

                data.datasets.Add(dataset);


                return Json(new
                {
                    data = data,
                    type = "pie",
                }
                    , @"application/json", JsonRequestBehavior.AllowGet);
            }
        }

    }
    public class Dataset
    {
        public string label { get; set; }
        public IList<int> data = new List<int>();
        public IList<string> backgroundColor { get; set; }
        public IList<string> borderColor { get; set; }        
    }
    public class Data
    {
        public IList<string> labels = new List<string>();
        public IList<Dataset> datasets = new List<Dataset>();
    }


}