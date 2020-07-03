using System.Diagnostics;
using Microsoft.Extensions.Configuration;

namespace CityInfo.Api.Services
{
  public class LocalMailService : IMailService
  {
    private static IConfiguration _configuration;
    
    public LocalMailService (IConfiguration config)
    {
      _configuration = config;
    }

    public void Send(string subject, string message)
    {
      Debug.WriteLine($"Mail from {_configuration["Logging:MailSettings:MailFromAddress"]} to {_configuration["Logging:MailSettings:MailToAddress"]}, with LocalMailService");
      Debug.WriteLine($"Subject: {subject}");
      Debug.WriteLine($"Subject: {message}");
    }
  }
}