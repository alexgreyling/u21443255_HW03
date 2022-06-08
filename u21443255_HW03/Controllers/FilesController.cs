using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;
using u21443255_HW03.Models;

namespace u21443255_HW03.Controllers
{
    public class FilesController : Controller
    {
        // GET: Files
        public ActionResult Files()
        {
            ViewBag.Message = "Your Files page.";
            // Get the file path for all the files we want to display
            string[] imagefilePaths = Directory.GetFiles(Server.MapPath("~/myMedia/Images/"));
            string[] documentsfilePaths = Directory.GetFiles(Server.MapPath("~/myMedia/Documents/"));
            string[] videosfilePaths = Directory.GetFiles(Server.MapPath("~/myMedia/Videos/"));

            List<FileModel> files = new List<FileModel>();

            // return files for images
            foreach (string newimagefilePath in imagefilePaths)
            {
                files.Add(new FileModel { FileName = Path.GetFileName(newimagefilePath) });
            }
            // return files for documents
            foreach (string newdocumentfilePath in documentsfilePaths)
            {
                files.Add(new FileModel { FileName = Path.GetFileName(newdocumentfilePath) });
            }
            // return files for videos
            foreach (string newvideofilePath in videosfilePaths)
            {
                files.Add(new FileModel { FileName = Path.GetFileName(newvideofilePath) });
            }

            return View(files);
        }

        public FileResult DownloadFile(string fileName)
        {
            string documetspath = Server.MapPath("~/myMedia/Documents/") + fileName;
            string imagespath = Server.MapPath("~/myMedia/Images/") + fileName;
            string videospath = Server.MapPath("~/myMedia/Videos/") + fileName;

            var bytes = new byte[10];
            if (Directory.Exists(documetspath))
            {
                bytes = System.IO.File.ReadAllBytes(documetspath);
            }

            if (Directory.Exists(imagespath))
            {
                bytes = System.IO.File.ReadAllBytes(imagespath);
            }

            if (Directory.Exists(videospath))
            {
                bytes = System.IO.File.ReadAllBytes(videospath);
            }

            return File(bytes, "application/octet-stream", fileName);
            
        }

        public ActionResult DeleteFile(string fileName)
        {
            // Get the file paths for each folders and contents
            string documetspath = Server.MapPath("~/myMedia/Documents/") + fileName;
            string imagespath = Server.MapPath("~/myMedia/Images/") + fileName;
            string videospath = Server.MapPath("~/myMedia/Videos/") + fileName;
            var bytes = new byte[10];

            // check if directory exists
            if (Directory.Exists(documetspath))
            {
                bytes = System.IO.File.ReadAllBytes(documetspath);
                
            }

            if (Directory.Exists(imagespath))
            {
                bytes = System.IO.File.ReadAllBytes(imagespath);
                
            }

            if (Directory.Exists(videospath))
            {
                bytes = System.IO.File.ReadAllBytes(videospath);
                
            }
            // Delete the files
            System.IO.File.Delete(documetspath);
            System.IO.File.Delete(imagespath);
            System.IO.File.Delete(videospath);
            return RedirectToAction("Files");
        }
    }
}