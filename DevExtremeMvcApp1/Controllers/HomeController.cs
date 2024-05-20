using DevExtreme.AspNet.Mvc;
using DevExtremeMvcApp1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DevExtremeMvcApp1.Controllers {
    public class HomeController : Controller {
        public ActionResult Index(VMPeso vm) {
            
            VMPeso _vm  = vm ?? new VMPeso();
            _vm.Peso = vm?.Peso ?? 100.123m;

            System.Diagnostics.Debug.WriteLine("Index");
            return View(vm);

        }

        public ActionResult Load(VMPeso vm)
        {
            return RedirectToAction("Index",vm);
        }
    }
}