using BestBuyRestAutomation.Model;
using BestBuyRestAutomation.TestData;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using Xunit.Abstractions;

namespace BestBuyRestAutomation.Tests
{
    public class ProductGETTests:BaseTest
    {
        ITestOutputHelper output;
        RestRequest request;

        public ProductGETTests(ITestOutputHelper output):base(output)
        {
            this.output = output;
            request = new RestRequest("products", Method.GET);
        }

        [Theory]
        [DataProvider("Product")]
        public void ProductFindTests(string productName, string productCode, string productDesc)
        {
            IRestResponse<Products> response = client.Execute<Products>(request);
           
            var name = response.Data.data;

            foreach (Product pro in name)
            {
                output.WriteLine(pro.name);
            }

        }
    }
}
