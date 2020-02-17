using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.IO;
namespace Morlok
{    
    public class FtpWrapper
    {
        public string ftp_server = "";
        public string ftp_port = "";
        public string ftp_user = "";
        public string ftp_pass = "";
        public FtpWebRequest ftp_request;

        public FtpWrapper()
        {
        }

        public bool IsConnection()
        {
            ftp_request = (FtpWebRequest)WebRequest.Create(new Uri(string.Format("ftp://{0}:{1}/{2}",ftp_server,ftp_port,"check.txt")));
            ftp_request.Credentials = new NetworkCredential(ftp_user, ftp_pass);
            
            try
            {
                FtpWebResponse response = (FtpWebResponse)ftp_request.GetResponse();
                response.Close();
            }
            catch(Exception e)
            {
                return false;
            }

            return true;
        }

        public void Delete(string filename)
        {
            try
            {
                ftp_request = (FtpWebRequest)WebRequest.Create(new Uri(string.Format("ftp://{0}:{1}/{2}", ftp_server, ftp_port, filename)));
                ftp_request.Method = WebRequestMethods.Ftp.DeleteFile;
                ftp_request.Credentials = new NetworkCredential(ftp_user, ftp_pass);
                FtpWebResponse response = (FtpWebResponse)ftp_request.GetResponse();
                response.Close();
            }
            catch (Exception ex)
            {
                
            }
        }

        public byte[] DownLoad(string filename)
        {
            byte[] result = null;
            try
            {
                WebClient request = new WebClient();
                request.Credentials = new NetworkCredential(ftp_user, ftp_pass);
                result = request.DownloadData(string.Format("ftp://{0}:{1}/{2}", ftp_server, ftp_port, filename));                
            }
            catch(Exception ex)
            {
                return null;
            }
            return result;
        }

        public bool Upload(string filename, string fullname)
        {
            try
            {
                ftp_request = (FtpWebRequest)WebRequest.Create(new Uri(string.Format("ftp://{0}:{1}/{2}", ftp_server, ftp_port, filename)));
                ftp_request.Credentials = new NetworkCredential(ftp_user, ftp_pass);
                ftp_request.Method = WebRequestMethods.Ftp.UploadFile;

                byte[] fileContents = File.ReadAllBytes(fullname);

                ftp_request.ContentLength = fileContents.Length;

                using (Stream requestStream = ftp_request.GetRequestStream())
                {
                    requestStream.Write(fileContents, 0, fileContents.Length);
                }

                using (FtpWebResponse response = (FtpWebResponse)ftp_request.GetResponse())
                {
                    response.Close();
                    return true;
                }                    
            }
            catch(Exception ex)
            {
                return false;
            }
        }

    }

}
