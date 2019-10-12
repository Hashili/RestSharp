using RestSharp;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit.Abstractions;

namespace BestBuyRestAutomation.Tests
{
    public class BaseTest : IDisposable
    {
        ITestOutputHelper output;
        public RestClient client;

        public BaseTest(ITestOutputHelper output)
        {
            this.output = output;
            client = new RestClient("http://localhost:3030");
        }
        public void Dispose()
        {
           
        }
    }
}
