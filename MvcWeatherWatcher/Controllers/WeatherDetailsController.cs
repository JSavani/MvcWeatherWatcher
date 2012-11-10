using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcWeatherWatcher.Models;

namespace MvcWeatherWatcher.Controllers
{
    public class WeatherDetailsController : Controller
    {
        private MvcDBConnectionDataContext _DataContext = null;
        protected MvcDBConnectionDataContext DataContext
        {
            get
            {
                if (_DataContext == null)
                    _DataContext = new MvcDBConnectionDataContext();

                // Load Weather info
                var options = new System.Data.Linq.DataLoadOptions();
                options.LoadWith<SensorReading>(p => p.observation_time);
                _DataContext.LoadOptions = options;

                return _DataContext;
            }
        }
        //
        // GET: /WeatherDetails/

        public ActionResult Index()
        {
            var model = this.DataContext.SensorReadings;
            return View(model);
        }

    }
}
