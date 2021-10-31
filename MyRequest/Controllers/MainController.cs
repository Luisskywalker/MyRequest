using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Tesseract;
using Capa_Entidad;
using Capa_Negocio;


namespace MyRequest.Controllers
{
    public class MainController : Controller
    {
       
        // GET: Main
        public ActionResult Index()
        {
            ViewBag.Result = false;
            ViewBag.Title = "OCR ASP.NET MVC ";
            return View();
        }

        public ActionResult Consulta()
        {
            return View();
        }

        public JsonResult Lista()
        {
            MainBL Obj = new MainBL();
            return Json(Obj.ShowData(), JsonRequestBehavior.AllowGet);
        }

        public int InsertaDatos(MainCLS oMainCLS)
        {
            MainBL Obj = new MainBL();
            oMainCLS.ImageName = (TempData["namefile"]).ToString(); 
            oMainCLS.ImageText = (TempData["pagetext"]).ToString();
            oMainCLS.DateConverted = DateTime.Now;
            return Obj.InsertaData(oMainCLS);
        }



        public ActionResult Submit(HttpPostedFileBase File1)
        {
            if (File1 == null || File1.ContentLength == 0)
            {
                ViewBag.Result = true;
                ViewBag.res = "File not Found";
                return View("Index");
            }

            using (var Engine = new TesseractEngine(Server.MapPath(@"~/tessdata"), "eng", EngineMode.Default))
            {
                using (var image = new System.Drawing.Bitmap(File1.InputStream))
                {
                    using (var pix = PixConverter.ToPix(image))
                    {
                        using (var page = Engine.Process(pix))
                        {
                            ViewBag.name = File1.FileName;
                            ViewBag.Result = true;
                            ViewBag.res = page.GetText();                           
                            ViewBag.mean = string.Format("{0}p", page.GetMeanConfidence());
                            return View("Index");
                            
                        }
                    }
                }
            }
                
        }
    }
}