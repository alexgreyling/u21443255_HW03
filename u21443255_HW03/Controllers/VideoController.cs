using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;
using u21443255_HW03.Models;

namespace u21443255_HW03.Controllers
{
    public class VideoController : Controller
    {
        // GET: Video
        public ActionResult Videos()
        {
            ViewBag.Message = "Your Videos page.";

            // get filepath
            string[] filepath = Directory.GetFiles(Server.MapPath("~/myMedia/Videos/"));
            //get a list of all images
            List<FileModel> files = new List<FileModel>();
            // return files for images
            foreach (string vidfilePath in filepath)
            {
                files.Add(new FileModel { FileName = Path.GetFileName(vidfilePath) });
            }
            return View(files);
        }

        public FileResult DownloadFile(string fileName)
        {
            // Get the file path
            string filepath = Server.MapPath("~/myMedia/Videos") + fileName;

            byte[] bytes = new byte[5];
            if (Directory.Exists(filepath))
            {
                bytes = System.IO.File.ReadAllBytes(filepath);
            }
            return File(bytes, "application/octet-stream", fileName);
        }

        public ActionResult DeleteFile(string fileName)
        {
            // Get the file path
            string filepath = Server.MapPath("~/myMedia/Videos/") + fileName;
            byte[] bytes = System.IO.File.ReadAllBytes(filepath);

            // Delete the file
            System.IO.File.Delete(filepath);

            return RedirectToAction("Videos");
        }
    }
}