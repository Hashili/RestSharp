using Microsoft.Extensions.Configuration;
using RestSharp;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Xunit.Abstractions;

namespace BestBuyRestAutomation.Tests
{
    public class BaseTest : IDisposable
    {
        ITestOutputHelper output;
        public RestClient client;
        public static string BasePath
        {
            get
            {
                return Directory.GetCurrentDirectory();
            }
        }
        public static IConfigurationRoot TestSettings
        {
            get
            {
                return (new ConfigurationBuilder().AddJsonFile(BaseTest.BasePath + @"\Config\TestSettings.json").Build());
            }
        }

        public BaseTest(ITestOutputHelper output)
        {
            this.output = output;          
            client = new RestClient(TestSettings["baseURL"]);
        }
        public void Dispose()
        {
           
        }
    }
}
