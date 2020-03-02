using System;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Cw1
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            //Console.WriteLine("Hello World!");
            //int tmp1 = 1;
            //double tmp2 = 2.0;
            //var tmp6 = 3;

            //string tmp3 = "ala ma kota";
            //string tmp5 = "i psa";
            //bool tmp4 = true;


            //var path = @"C:\Users\s18445\Desktop\Cw1";

            //Console.WriteLine(path);

            //console.writeline($"{tmp3} {tmp5} {tmp1 + tmp6}");

            //var newperson = new person { firstname = "łukasz" };

            var url = args.Length > 0 ? args[0] : "https://www.pja.edu.pl";

            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync(url))
                { 
                    if (response.IsSuccessStatusCode)
                    {
                        var htmlContent = await response.Content.ReadAsStringAsync();

                        var regex = new Regex("[a-z]+[a-z0-9]*@[a-z0-9]+\\.[a-z]+", RegexOptions.IgnoreCase);

                        var matches = regex.Matches(htmlContent);

                        foreach (var match in matches)
                        {
                            Console.WriteLine(match.ToString());
                        }
                    }
                }
            }


        }
    }
}
