using Liki24Api.Models;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Helpers;
using System.Web.Http;
using System.Web.Http.Results;
using System.Web.Mvc;

namespace Liki24Api.Controllers
{
    //[Authorize]
    public class ValuesController : ApiController
    {
        [System.Web.Http.HttpGet]
        public List<DeliveryWindow> Get(DateTime currentDate, int horizon)
        {
            
            var windowsList = GetWindowsList();
            var result = new List<DeliveryWindow> { };
            var listOfDates = new List<DateTime> { };
            bool finishAppropiate;

            for (int i = currentDate.Day; i<= currentDate.Day+horizon; i++)
            {
                listOfDates.Add(new DateTime(currentDate.Year, currentDate.Month, i));
            }
            foreach(var date in listOfDates)
            {
                foreach (var window in windowsList)
                {
                    if (!result.Any(item => item.Id == window.Id)) // check if window is already included
                    {
                        if (window.Type == "urgent")
                        {
                            window.Available = true;
                            result.Add(window);
                        }
                        else
                        {
                            bool startAppropiate = window.Start.Day <= date.Day;
                            if (!startAppropiate) { finishAppropiate = false; }
                            else { finishAppropiate = date.Day <= window.Finish.Day; }
                             
                            if (startAppropiate || finishAppropiate)
                            {
                                if (window.AvailableBefore > currentDate.Hour)
                                {
                                    window.Available = true;
                                }
                                else
                                {
                                    window.Available = false;
                                }
                                result.Add(window);
                            }
                        }
                    }


                }
            }


            return result;
        }
        public List<DeliveryWindow> GetWindowsList()
        {
            var window1 = new DeliveryWindow
            {
                Name = "URGENT",
                Description = "Delivery in 2h",
                Start = new DateTime(2020, 04, 22),
                Finish = new DateTime(2020, 04, 30),
                Price = 200,
                HourStart = 15,
                HouFinish = 17,
                Type = "urgent",
                Id = 1
            };

            var window2 = new DeliveryWindow
            {
                Name = "10:00 - 12:00",
                Description = "Delivery window: 10:00 - 12:00",
                Start = new DateTime(2020, 12, 21),
                Finish = new DateTime(2020, 12, 24),
                HourStart = 10,
                HouFinish = 12,
                Price = 100,
                Type = "regular",
                AvailableBefore = 8,
                Id = 2
            };

            var window3 = new DeliveryWindow
            {
                Name = "12:00 -- 18:00",
                Description = "Доставка 12:00 - 18:00",
                Start = new DateTime(2020, 12, 21),
                Finish = new DateTime(2020, 12, 24),
                Price = 200,
                HourStart = 12,
                HouFinish = 18,
                Type = "regular",
                AvailableBefore = 10,
                Id = 3
            };

            var window4 = new DeliveryWindow
            {
                Name = "14:00 - 18:00",
                Description = "Delivery window: 14:00 - 18:00",
                Start = new DateTime(2020, 12, 25),
                Finish = new DateTime(2020, 12, 25),
                Price = 50,
                HourStart = 14,
                HouFinish = 18,
                Type = "regular",
                AvailableBefore = 12,
                Id = 4

            };
            var window5  = new DeliveryWindow
            {
                Name = "18:00 - 23:00",
                Description = "Delivery window: 18:00 - 23:00",
                Start = new DateTime(2020, 12, 25),
                Finish = new DateTime(2020, 12, 25),
                HourStart = 18,
                HouFinish = 23,
                Price = 100,
                Type = "regular",
                AvailableBefore = 16,
                Id = 5
            };



            var window6 = new DeliveryWindow
            {
                Name = "10:00 -- 18:00",
                Description = "Доставка 10:00 - 18:00",
                Start = new DateTime(2020, 12, 26),
                Finish = new DateTime(2020, 12, 26),
                Price = 200,
                HourStart = 10,
                HouFinish = 18,
                Type = "regular",
                AvailableBefore = 16,
                Id = 6

            };

            var windowsList = new List<DeliveryWindow> { window1, window2, window3, window4, window5, window6 };
            return windowsList;
        }

        // GET api/values/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        [System.Web.Mvc.HttpPost]
        public void Post([FromBody]JObject data)
        {

        }

        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }

    }
}
