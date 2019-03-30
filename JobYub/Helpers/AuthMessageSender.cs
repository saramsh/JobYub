using Microsoft.Extensions.Configuration;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JobYub.Helpers
{

    public class AuthMessageSender:ISmsSender
    {
        public AuthMessageSender()
        {

           IConfigurationBuilder builder = new ConfigurationBuilder()
         .SetBasePath(System.IO.Directory.GetCurrentDirectory())
         .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);

            IConfigurationRoot configuration = builder.Build();
            // configurationSection.Key => FilePath
            // configurationSection.Value => C:\\temp\\logs\\output.txt
            UserName = configuration.GetSection("AppSettings").GetSection("smsUser").Value;
            Password = configuration.GetSection("AppSettings").GetSection("smsPass").Value;
            From = configuration.GetSection("AppSettings").GetSection("smsNumber").Value;
        }
        private string UserName { get; set; }
        private string Password { get; set; }
        private string From { get; set; }

        

        public Task SendEmailAsync(string email, string subject, string message)
        {
            // Plug in your email service here to send an email.
            return Task.FromResult(0);
        }

        public Task  SendSmsAsync(string number, string message)
        {
            var client = new RestClient("http://rest.payamak-panel.com/api/SendSMS/SendSMS");
            var request = new RestRequest(Method.POST);
            request.AddHeader("content-type", "application/x-www-form-urlencoded");
            request.AddHeader("postman-token", "fcddb5f4-dc58-c7d5-4bf9-9748710f8789");
            request.AddHeader("cache-control", "no-cache");

            request.AddParameter("application/x-www-form-urlencoded", "username="+UserName+"&password="+Password+"&to="+number+"&from="+From+"&text="+message+"&isflash=false", ParameterType.RequestBody);
            IRestResponse response = client.Execute(request);
            return Task.FromResult(0);

        }
    }
}
