using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace u21443255_HW03.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public ActionResult Homepage()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Homepage(HttpPostedFileBase newfile, string type)
        {
            // Make sure that a file is selected
            if (newfile != null && newfile.ContentLength > 0)
                {
                // if radiobutton documents selected, send files to documents folder
                if (type == "Document")
                {
                    // get the file name
                    string fileName = Path.GetFileName(newfile.FileName);
                    // Get the path you want to place the file in
                    var documentsfilepath = Path.Combine(Server.MapPath("~/myMedia/Documents/"), fileName);
                    //save the file
                    newfile.SaveAs(documentsfilepath);
                }
                 //if radiobutton images selected, send files to images folder
                else if (type == "Image")
                {
                    // get the file name
                    string fileName = Path.GetFileName(newfile.FileName);
                    var imagesfilepath = Path.Combine(Server.MapPath("~/myMedia/Images/"), fileName);
                    newfile.SaveAs(imagesfilepath);
                }
               //  if radiobutton videos selected, send files to videos folder
                else if (type == "Video")
                {
                    // get the file name
                    string fileName = Path.GetFileName(newfile.FileName);
                    var videosfilepath = Path.Combine(Server.MapPath("~/myMedia/Videos/"), fileName);
                    newfile.SaveAs(videosfilepath);
                }
            }
            ViewBag.Message = "File has been uploaded";
            return View();

        }

        public ActionResult AboutMe()
        {
            return View();
        }
    }
}