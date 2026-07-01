using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;

namespace MyTool
{
    public class ExcelUtil
    {
        /// <summary>
        /// 通过读取文件的方式
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns></returns>
        //public static string GetSocketString(string filePath)
        //{
        //    FileStream stream = File.Open(filePath, FileMode.Open, FileAccess.Read);
        //    IExcelDataReader excelReader;

        //    //1. Reading Excel file
        //    if (Path.GetExtension(filePath).ToUpper() == ".XLS")
        //    {
        //        //1.1 Reading from a binary Excel file ('97-2003 format; *.xls)
        //        excelReader = ExcelReaderFactory.CreateBinaryReader(stream);
        //    }
        //    else
        //    {
        //        //1.2 Reading from a OpenXml Excel file (2007 format; *.xlsx)
        //        excelReader = ExcelReaderFactory.CreateOpenXmlReader(stream);
        //    }

        //    //2. DataSet - The result of each spreadsheet will be created in the result.Tables
        //    DataSet result = excelReader.AsDataSet();

        //    //3. DataSet - Create column names from first row
        //    excelReader.IsFirstRowAsColumnNames = false;
        //}

        //public object UploadExcel(IFormFile file)
        //{

        //    try
        //    {
        //        MemoryStream target = new MemoryStream();
        //        file.OpenReadStream().CopyTo(target);
        //        byte[] data = target.ToArray();
        //        Stream stream = new MemoryStream(data);//excel文件转成数据流
        //        var excelReader = ExcelReaderFactory.CreateOpenXmlReader(stream);//流数据转成Excelreader
        //        //Excelreader转成datatable
        //        var dataSet = excelReader.AsDataSet(new ExcelDataSetConfiguration
        //        {
        //            ConfigureDataTable = _ => new ExcelDataTableConfiguration
        //            {
        //                UseHeaderRow = true // Use first row is ColumnName here :D
        //            }
        //        });
        //        if (dataSet.Tables.Count > 0)
        //        {
        //            var dtData = dataSet.Tables[0];

        //        }
        //    }
        //    catch (Exception ex)
        //    {

        //    }

        //}
    }
}
