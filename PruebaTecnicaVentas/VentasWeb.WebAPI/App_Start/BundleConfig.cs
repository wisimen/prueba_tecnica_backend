using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;
using System.Web.UI;

namespace VentasWeb.WebAPI
{
    public class BundleConfig
    {
        // Para obtener más información sobre las uniones, visite https://go.microsoft.com/fwlink/?LinkID=303951
        public static void RegisterBundles(BundleCollection bundles)
        {
            RegisterJQueryScriptManager();

            bundles.Add(new ScriptBundle("~/bundles/WebFormsJs").Include(
                            "~/Scripts/WebForms/WebForms.js",
                            "~/Scripts/WebForms/WebUIValidation.js",
                            "~/Scripts/WebForms/MenuStandards.js",
                            "~/Scripts/WebForms/Focus.js",
                            "~/Scripts/WebForms/GridView.js",
                            "~/Scripts/WebForms/DetailsView.js",
                            "~/Scripts/WebForms/TreeView.js",
                            "~/Scripts/WebForms/WebParts.js",
                            "~/Scripts/main.js",
                            "~/Scripts/lib/chart/chart.min.js",
                            "~/Scripts/lib/easing/easing.min.js",
                            "~/Scripts/lib/waypoints/waypoints.min.js",
                            "~/Scripts/lib/owlcarousel/owl.carousel.min.js",
                            "~/Scripts/lib/tempusdominus/js/moment.min.js",
                            "~/Scripts/lib/tempusdominus/js/moment-timezone.min.js",
                            "~/Scripts/lib/tempusdominus/js/tempusdominus-bootstrap-4.min.js"
                            ));
            bundles.Add(new Bundle("~/bundles/master").Include(
                "~/Scripts/jquery-3.7.0.min.js",
                "~/Scripts/lib/chart/chart.min.js",
                "~/Scripts/lib/easing/easing.min.js",
                "~/Scripts/lib/waypoints/waypoints.min.js",
                "~/Scripts/lib/owlcarousel/owl.carousel.min.js",
                "~/Scripts/lib/tempusdominus/js/moment.min.js",
                "~/Scripts/lib/tempusdominus/js/moment-timezone.min.js",
                "~/Scripts/lib/tempusdominus/js/tempusdominus-bootstrap-4.min.js",
                "~/Scripts/custom.js",
                "~/Scripts/main.js"
                ));


            // El orden es muy importante para el funcionamiento de estos archivos ya que tienen dependencias explícitas
            bundles.Add(new ScriptBundle("~/bundles/MsAjaxJs").Include(
                    "~/Scripts/WebForms/MsAjax/MicrosoftAjax.js",
                    "~/Scripts/WebForms/MsAjax/MicrosoftAjaxApplicationServices.js",
                    "~/Scripts/WebForms/MsAjax/MicrosoftAjaxTimer.js",
                    "~/Scripts/WebForms/MsAjax/MicrosoftAjaxWebForms.js"));

            // Use la versión de desarrollo de Modernizr para desarrollar y aprender. Luego, cuando esté listo
            // para la producción, use la herramienta de compilación disponible en https://modernizr.com para seleccionar solo las pruebas que necesite
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                            "~/Scripts/modernizr-*"));

            //BundleTable.EnableOptimizations = true;
        }

        public static void RegisterJQueryScriptManager()
        {
            ScriptManager.ScriptResourceMapping.AddDefinition("jquery",
                new ScriptResourceDefinition
                {
                    Path = "~/scripts/jquery-3.7.0.min.js",
                    DebugPath = "~/scripts/jquery-3.7.0.js",
                    CdnPath = "http://ajax.aspnetcdn.com/ajax/jQuery/jquery-3.7.0.min.js",
                    CdnDebugPath = "http://ajax.aspnetcdn.com/ajax/jQuery/jquery-3.7.0.js"
                });
        }
    }
}