using ExcelDataReader;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EAAutoFramework.Helpers
{
    public class ExcelHelpers
    {

        private static List<Datacollection> _dataCol = new List<Datacollection>();

        /// <summary>
        /// Storing all the excel values in to the in-memory collections
        /// </summary>
        /// <param name="fileName"></param>
        public static void PopulateInCollection(string fileName)
        {
            DataTable table = ExcelToDataTable(fileName);

            //Iterate through the rows and coloumns of the table
            for (int row = 1; row <= table.Rows.Count; row++)
            {
                for (int col = 0; col < table.Columns.Count; col++)
                {
                    Datacollection dtTable = new Datacollection()
                    {
                        rowNumber = row,
                        colName = table.Columns[col].ColumnName,
                        colValue = table.Rows[row - 1][col].ToString()
                    };
                    _dataCol.Add(dtTable);
                }
            }
        }

        /// <summary>
        /// Reading all the data from ExcelSheet
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        //private static DataTable ExcelToDataTable(string fileName)
        //{
            //open file and returns as Stream
            //FileStream stream = File.Open(fileName, FileMode.Open, FileAccess.Read);
            //Create open xml reader via ExcelReaderFactory
            //IExcelDataReader excelReader = ExcelReaderFactory.CreateOpenXmlReader(stream); //.xlsx
            //Set the First Row as Column Name
            //excelReader.IsFirstRowAsColumnNames = true;
            //Return as DataSet
            //DataSet result = excelReader.AsDataSet();
            //Get all the Tables
            //DataTableCollection table = result.Tables;
            //Store it in DataTable
            //DataTable resutTable = table["Sheet1"];
            //return
            //return resutTable;
        //}

        public static DataTable ExcelToDataTable(string fileName)
        {
            using(var stream = File.Open(fileName, FileMode.Open, FileAccess.Read))
            {
                using (var reader = ExcelReaderFactory.CreateReader(stream))
                {
                    var result = reader.AsDataSet(new ExcelDataSetConfiguration()
                    {
                        ConfigureDataTable = (data) => new ExcelDataTableConfiguration()
                        {
                            UseHeaderRow = true
                        }
                    });
                    //Get all the Tables
                    DataTableCollection table = result.Tables;
                    //Store it in DataTable
                    DataTable resutTable = table["Sheet1"];
                    //return
                    return resutTable;
                }
            }
        }

        public static string ReadData(int rowNumber, string ColumnName)
        {
            try
            {
                //Retriving Data using LINQ to reduce of iterations
                string data = (from colData in _dataCol
                               where colData.colName == ColumnName && colData.rowNumber == rowNumber
                               select colData.colValue).SingleOrDefault();

                //var datas = dataCol.Where(x => x.colName == && x.rowNumber == rowNumber
                return data.ToString();
            }
            catch (Exception e)
            {
                return null;
            }
        }
    }
    public class Datacollection
    {
        public int rowNumber { get; set; }

        public string colName { get; set; }

        public string colValue { get; set; }
    }

}
