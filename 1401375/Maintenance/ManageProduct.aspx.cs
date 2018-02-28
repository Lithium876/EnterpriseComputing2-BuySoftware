using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace _1401375
{
    public partial class ManageProduct : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Unnamed_LoggingOut(object sender, LoginCancelEventArgs e)
        {
            Context.GetOwinContext().Authentication.SignOut(DefaultAuthenticationTypes.ApplicationCookie);
        }

        protected void getAntiMalwareSoftware(object sender, EventArgs e)
        {
            txtCategory.Text = "1";
            _pageHeader.Text = "Anti-Malware Software";
        }

        protected void getBusinessAntivirusSoftware(object sender, EventArgs e)
        {
            txtCategory.Text = "2";
            _pageHeader.Text = "Business Antivirus Software";
        }

        protected void getBackupSoftware(object sender, EventArgs e)
        {
            txtCategory.Text = "3";
            _pageHeader.Text = "Backup Software";
        }

        protected void getDeveloperSoftware(object sender, EventArgs e)
        {
            txtCategory.Text = "4";
            _pageHeader.Text = "Developer Software";
        }

        protected void getDriverSoftware(object sender, EventArgs e)
        {
            txtCategory.Text = "5";
            _pageHeader.Text = "Driver Software";
        }

        protected void getFileTransferSoftware(object sender, EventArgs e)
        {
            txtCategory.Text = "6";
            _pageHeader.Text = "File Transfer Software";
        }

        protected void getMultimediaSoftware(object sender, EventArgs e)
        {
            txtCategory.Text = "7";
            _pageHeader.Text = "Multimedia Software";
        }

        protected void getOfficeNewsSoftware(object sender, EventArgs e)
        {
            txtCategory.Text = "8";
            _pageHeader.Text = "Office News Software";
        }

        protected void getNetworkingSoftware(object sender, EventArgs e)
        {
            txtCategory.Text = "9";
            _pageHeader.Text = "Networking Software";
        }

        protected void getSecuritySoftware(object sender, EventArgs e)
        {
            txtCategory.Text = "10";
            _pageHeader.Text = "Security Software";
        }

        protected void getSystemTuningSoftware(object sender, EventArgs e)
        {
            txtCategory.Text = "11";
            _pageHeader.Text = "System Tuning Software";
        }

        protected void getVPNsSoftware(object sender, EventArgs e)
        {
            txtCategory.Text = "12";
            _pageHeader.Text = "VPN Software";
        }
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            // Read the file and convert it to Byte Array
            string filePath = fuImagePath.PostedFile.FileName;
            string filename = Path.GetFileName(filePath);
            string ext = Path.GetExtension(filename);
            string contenttype = String.Empty;

            //Set the contenttype based on File Extension
            switch (ext)
            {
                case ".jpg":
                    contenttype = "image/jpg";
                    break;

                case ".png":
                    contenttype = "image/png";
                    break;

                case ".gif":
                    contenttype = "image/gif";
                    break;

                case ".jpeg":
                    contenttype = "image/jpeg";
                    break;
            }

            if (contenttype != String.Empty)
            {
                String strConnString = ConfigurationManager.ConnectionStrings["1401375ConnectionString"].ConnectionString;
                SqlConnection con = new SqlConnection(strConnString);
                SqlCommand cmd = new SqlCommand("spSoftware_UploadImage", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                try
                {
                    Stream fs = fuImagePath.PostedFile.InputStream;
                    BinaryReader br = new BinaryReader(fs);
                    Byte[] bytes = br.ReadBytes((Int32)fs.Length);

                    //INSERT IMAGE FILE AND DATA IN DB
                    cmd.Parameters.AddWithValue("@softwareID", Convert.ToInt32(txtSoftwareID.Text));
                    cmd.Parameters.AddWithValue("@softwareImage", bytes);

                    con.Open();
                    int result = cmd.ExecuteNonQuery();
                    con.Close();

                    lblmessage.ForeColor = System.Drawing.Color.Green;
                    lblmessage.Text = "File Uploaded Successfully";
                }
                catch (Exception ex)
                {
                    lblmessage.ForeColor = System.Drawing.Color.Red;
                    lblmessage.Text = "Oops!! Something went wrong";
                    //lblmessage.Text = Convert.ToString(ex);
                }
            }
            else
            {
                lblmessage.ForeColor = System.Drawing.Color.Red;
                lblmessage.Text = "File format not recognised." +
                  " Please select a Image format .png .jpg OR .gif";
            }
            Response.Redirect("ManageProduct.aspx", false);
        }
    }
}