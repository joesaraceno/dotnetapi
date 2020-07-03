using System;
using System.Diagnostics;
using Microsoft.Extensions.Configuration;

namespace CityInfo.Api.Services
{
  public class CloudMailService : IMailService
  {
    private static IConfiguration _configuration;
    public CloudMailService (IConfiguration config)
    {
      _configuration = config ?? throw new ArgumentException(nameof(config));
    }

    public void Send(string subject, string message)
    {
      Debug.WriteLine($"Mail from {_configuration["Logging:MailSettings:MailFromAddress"]} to {_configuration["Logging:MailSettings:MailToAddress"]}, with CloudMailService");
      Debug.WriteLine($"Subject: {subject}");
      Debug.WriteLine($"Subject: {message}");
    }
  }
}