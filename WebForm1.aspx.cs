using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ImageMVC
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
           // if(IsPostBack==false)
           // {
                UploadImage();
           // }
            
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (FileUpload1.HasFile)
            {
                string filename = FileUpload1.FileName;
                FileUpload1.PostedFile.SaveAs(Server.MapPath("~/Data/" + filename));

            }
            Response.Redirect("~/Webform1.aspx");
            //UploadImage();
        }

        private void UploadImage()
        { 
            foreach (string strFileName in Directory.GetFiles(Server.MapPath("~/Data/")))
            {
                ImageButton imageButton = new ImageButton();
                FileInfo fileinfo = new FileInfo(strFileName);
                imageButton.ImageUrl = "~/Data/" + fileinfo.Name;
                imageButton.Width = Unit.Pixel(100);
                imageButton.Height = Unit.Pixel(100);
                imageButton.Style.Add("padding", "5px");
                imageButton.Click += new ImageClickEventHandler(imageButton_Click);
                Panel1.Controls.Add(imageButton);
            }
        }
        void imageButton_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("~/WebForm2.aspx?ImageURL=" + ((ImageButton)sender).ImageUrl);
        }

        protected void Button2_Click(object sender, EventArgs e)
        {

        }
    }
}