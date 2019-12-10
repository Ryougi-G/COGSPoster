/*
 * Created by SharpDevelop.
 * User: stu
 * Date: 2019-11-27
 * Time: 19:42
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Net;
using System.IO;
using System.Text;
using System.Web;

namespace COGSPOSTEREXE
{
	/// <summary>
	/// Description of COGSLoginer.
	/// </summary>
	public class COGSLoginer
	{
		public string username;
		public string password;
		public string cogsurl;
		public string fromid;
		CookieContainer container=new CookieContainer();
		public COGSLoginer()
		{
			
		}
        public string URLencode(string s)
        {
            return HttpUtility.UrlEncode(s);
        }
		public void login(){
			string loginword="";
			loginword="username="+username+"&password="+password;
			HttpWebRequest request=(HttpWebRequest)WebRequest.Create("http://"+cogsurl+"/cogs/user/dologin.php"+"?"+loginword);
			request.CookieContainer=container;
			request.Method="POST";
			request.KeepAlive=true;
			request.Timeout=30*1000;
			/*
			byte[] b=Encoding.UTF8.GetBytes(loginword);
			request.ContentLength=b.Length;
			request.GetRequestStream().Write(b,0,b.Length);
			*/
			HttpWebResponse re=(HttpWebResponse)request.GetResponse();
			StreamReader reader=new StreamReader(re.GetResponseStream());
			string s=reader.ReadToEnd();
			File.WriteAllText("index.html",s);
 		}
		public void logout(){
			HttpWebRequest request= (HttpWebRequest)WebRequest.Create("http://" +cogsurl+"/cogs/user/dologout.php");
			request.CookieContainer=container;
			request.Method="GET";
			request.KeepAlive=true;
			request.Timeout=30*1000;
			HttpWebResponse re=(HttpWebResponse)request.GetResponse();
			var reader=new StreamReader(re.GetResponseStream());
			string s=reader.ReadToEnd();
			File.WriteAllText("index3.html",s);
 		}
		public void postMail(string text,string title,string toid){
			string posttext="fromid="+fromid+"&title="+ URLencode(title)+ "&toid="+toid+"&msg="+URLencode(text);
			HttpWebRequest request= (HttpWebRequest)WebRequest.Create("http://" +cogsurl+"/cogs/mail/send.php");
			request.CookieContainer=container;
			request.Method="POST";
			request.KeepAlive=true;
			request.Timeout=300*1000;
			request.ContentType = "application/x-www-form-urlencoded";
            //			WebProxy pro=new WebProxy("127.0.0.1",8080);
            //			request.Proxy=pro;
           
            byte[] b=Encoding.ASCII.GetBytes(posttext);
			request.ContentLength=b.Length;
			request.GetRequestStream().Write(b,0,b.Length);
			
			HttpWebResponse re=(HttpWebResponse)request.GetResponse();
			StreamReader reader=new StreamReader(re.GetResponseStream());
			string s=reader.ReadToEnd();
			File.WriteAllText("index2.html",s);
		}
	}
}
