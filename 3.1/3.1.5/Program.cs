using System;
using System.IO;
using System.Net;
using System.Net.Mail;

namespace _3._1._5
{
    class Program
    {
        static void Main(string[] args)
        {
            //FtpWebRequest
            FtpWebRequest ftpWebRequest = (FtpWebRequest)FtpWebRequest.Create("ftp://ftp.debian.org/debian/README.mirrors.txt");///README.mirrors.txt
            ftpWebRequest.Method = WebRequestMethods.Ftp.DownloadFile;
            FtpWebResponse response = (FtpWebResponse)ftpWebRequest.GetResponse();
            Stream stream2 = response.GetResponseStream();

            byte[] tab2 = new byte[2048];
            //stream2.Read(tab2, 0, tab2.Length);
            //Console.WriteLine(System.Text.Encoding.UTF8.GetString(tab2));
            //Console.ReadLine();


            //httWebRequest
            HttpWebRequest httpWebRequest = (HttpWebRequest)HttpWebRequest.Create("http://www.bing.com/");
            httpWebRequest.Method = WebRequestMethods.Http.Get;
            HttpWebResponse httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
            Stream stream = httpResponse.GetResponseStream();

            byte[] tab = new byte[2048];
            stream.Read(tab, 0, tab.Length);

            Console.WriteLine(System.Text.Encoding.UTF8.GetString(tab));
            Console.ReadLine();


            //smtpClient
            SmtpClient client = new SmtpClient("smtp.gmail.com ", 587); //smtp dla konkretnej poczty, port chyba obojętny
            client.EnableSsl = true;
            MailAddress from = new MailAddress("email wysylajacy", "email wysylajacy");
            MailAddress to = new MailAddress("email docelowy", "email docelowy");
            MailMessage message = new MailMessage(from, to);
            message.Body = "Body";
            message.Subject = "Subject";
            NetworkCredential myCreds = new NetworkCredential("email wysylajacy", "password na poczte", "");
            client.Credentials = myCreds;
            try
            {
                client.Send(message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception is:" + ex.ToString());
            }

            SimpleListenerExample(new string[] {new Uri("http://contoso.com:8080/index/").ToString()});

            Console.ReadLine();
        }

        public static void SimpleListenerExample(string[] prefixes)
        {
            if (!HttpListener.IsSupported)
            {
                Console.WriteLine("Windows XP SP2 or Server 2003 is required to use the HttpListener class.");
                return;
            }

            if (prefixes == null || prefixes.Length == 0)
                throw new ArgumentException("prefixes");

            HttpListener listener = new HttpListener();
         
            foreach (string s in prefixes)
            {
                listener.Prefixes.Add(s);
            }

            listener.Start();
            Console.WriteLine("Listening...");

            HttpListenerContext context = listener.GetContext();
            HttpListenerRequest request = context.Request;
            HttpListenerResponse response = context.Response;

            string responseString = "<HTML><BODY> Hello world!</BODY></HTML>";
            byte[] buffer = System.Text.Encoding.UTF8.GetBytes(responseString);

            response.ContentLength64 = buffer.Length;
            System.IO.Stream output = response.OutputStream;
            output.Write(buffer, 0, buffer.Length);
            output.Close();
            listener.Stop();
        }
    }
}