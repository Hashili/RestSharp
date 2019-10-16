using BestBuyRestAutomation.TestData;
using Microsoft.Extensions.Configuration;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Xunit;
using Xunit.Abstractions;

namespace BestBuyRestAutomation.Tests
{
    public class UnitTester
    {
        ITestOutputHelper output;
        public UnitTester(ITestOutputHelper output)
        {
            this.output = output;
        }
       
    }
}
