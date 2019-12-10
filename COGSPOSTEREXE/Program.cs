/*
 * Created by SharpDevelop.
 * User: stu
 * Date: 2019-11-27
 * Time: 19:41
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace COGSPOSTEREXE
{
	class Program
	{
		public static void Main(string[] args)
		{
			string username;
			string password;
			string fromid,toid;
			COGSLoginer loginer=new COGSLoginer();
			Console.Write("网址：");
			loginer.cogsurl=Console.ReadLine();
			Console.Write("用户名：");
			username=Console.ReadLine();
			Console.Write("密码：");
			password=Console.ReadLine();
			Console.Write("发件人ID（并不一定要真实ID，可以是其他人）：");
			fromid=Console.ReadLine();
			loginer.username=username;
			loginer.password=password;
			loginer.fromid=fromid;
			loginer.login();
			Console.Write("收件人id：");
		    toid=Console.ReadLine();
			Console.Write("标题：");
			string title=Console.ReadLine();
			Console.Write("内容：");
			string text=Console.ReadLine();
			Console.Write("发送次数：");
			int times=int.Parse(Console.ReadLine());
			for(int i=1;i<=times;i++){
				loginer.postMail(text,title,toid);
			}
			loginer.logout();
			Console.Write("Press any key to continue . . . ");
			Console.ReadKey(true);
		}
	}
}