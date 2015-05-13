using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Net;
using System.Text;

namespace wget
{
	class Program
	{
		static void Main(string[] args)
		{
			if (args.Length < 1)
				Console.WriteLine("Please enter the url");
			else
			{
				try
				{
					string url = args[0];
					string fileName = "";

					if (args.Length == 2)
						fileName = args[1];
					using (WebClient client = new WebClient())
					{
						string response = Encoding.Default.GetString(client.UploadValues(url, "POST", new NameValueCollection {}));
						if (string.IsNullOrEmpty(fileName))
							Console.WriteLine(response);
						else
						{
							using (StreamWriter writetext = new StreamWriter(fileName))
							{
								writetext.Write(response);
								writetext.Close();
							}
						}
					}
				}
				catch (Exception ex)
				{
					Console.WriteLine(ex.Message);
				}
			}
		}
	}
}
