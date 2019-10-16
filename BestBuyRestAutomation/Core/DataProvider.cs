using BestBuyRestAutomation.Tests;
using Microsoft.Extensions.Configuration;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;
using Xunit.Sdk;

namespace BestBuyRestAutomation.TestData
{
    public class DataProvider : DataAttribute
    {
        private string sheetName;
        private string excelFilePath;
        public DataProvider(string sheetName,string excelFilePath)
        {
            this.sheetName = sheetName;
            this.excelFilePath = excelFilePath;
        }

        public DataProvider(string sheetName)
        {
            this.sheetName = sheetName;
            this.excelFilePath = BaseTest.BasePath + @"\TestData\"+BaseTest.TestSettings["testdataexcel_file"];
        }


        public override IEnumerable<object[]> GetData(MethodInfo testMethod)
        {
            FileStream file = new FileStream(excelFilePath, FileMode.Open, FileAccess.Read);
            XSSFWorkbook xcelWb = new XSSFWorkbook(file);
            ISheet sheet = xcelWb.GetSheet(sheetName);
            int col = sheet.GetRow(1).LastCellNum;
            int row = sheet.LastRowNum;
            
            for (int i = 1; i <= row; i++)
            {
                string[] data = new string[col];

                for (int j = 0; j < col; j++)
                {
                    string cellType = null;
                    string cellValue = null;

                    try
                    {
                        cellType = sheet.GetRow(i).GetCell(j).CellType.ToString();
                    }
                    catch { }

                    switch (cellType)
                    {
                        case "String":
                            cellValue = sheet.GetRow(i).GetCell(j).StringCellValue;
                            break;

                        case "Numeric":
                            cellValue = sheet.GetRow(i).GetCell(j).NumericCellValue.ToString();
                            break;
                        default:
                            cellValue = "";
                            break;
                    }

                    data[j] = cellValue;                   
                }
                yield return data;
            }
        }
    }
}
