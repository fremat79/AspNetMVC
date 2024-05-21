using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Optimization;

namespace DevExtremeMvcApp1 {

    public class BundleConfig {

        public static void RegisterBundles(BundleCollection bundles) {

            var scriptBundle = new Bundle("~/Scripts/bundle");
            var styleBundle = new Bundle("~/Content/bundle");

            // jQuery
            scriptBundle
                .Include("~/Scripts/jquery-3.6.3.js");

            // Bootstrap
            scriptBundle
                .Include("~/Scripts/bootstrap.js");

            // Bootstrap
            styleBundle
                .Include("~/Content/bootstrap.css");

            // Custom site styles
            styleBundle
                .Include("~/Content/Site.css");


            // jquery validation
            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
            "~/Scripts/jquery.validate*",
            "~/Scripts/jquery.validate.unobtrusive*"));


            bundles.Add(scriptBundle);
            bundles.Add(styleBundle);

            // BundleTable.EnableOptimizations = true;
        }
    }
}