﻿using System.Web;
using System.Web.Optimization;

namespace Vidly.Web
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/lib").Include(
                        "~/Scripts/jquery-{version}.js",
                        "~/Scripts/bootstrap.js",
                        "~/Scripts/bootbox.js",
                        "~/Scripts/respond.js",
                        "~/Scripts/datatables/jquery.dataTables.js",
                        "~/Scripts/datatables/dataTables.bootstrap.js",
                        "~/Scripts/datatables/dataTables.bootstrap4.js"
                        ));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at https://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                    "~/Content/bootstrap_flatly.css",
                    "~/Content/site.css",
                    "~/Content/datatables/css/dataTables.bootstrap.css",
                    "~/Content/datatables/css/dataTables.dataTables.bootstrap4.css"));
        }
    }
}
