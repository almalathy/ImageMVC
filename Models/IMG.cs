using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ImageMVC.Models
{
    public class IMG
    {
        [DataType(DataType.Upload)]
        [Display(Name = "UploadFiles")]
        //[Required(ErrorMessage = "Please choose file to upload.")]
        public string file { get; set; }

        public string Search { get; set; }

        public List<string> imgList { get; set; }

    }
}