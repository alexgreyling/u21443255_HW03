using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;
using System.ComponentModel.DataAnnotations;

namespace u21443255_HW03.Models
{
    //public class FileModelController : Controller
    //{
        // GET: FileModel
      public class FileModel
        {
            [Display(Name = "File Name")]
            public string FileName { get; set; }
        }
    //}
}