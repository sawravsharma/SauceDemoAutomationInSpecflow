//using DocumentFormat.OpenXml.Spreadsheet;
//using NPOI.HSSF.UserModel;
//using NPOI.Util;
//using NPOI.XSSF.UserModel;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace SauceDemoAutomationWithSpecflow.StepDefinitions
//{

//    public class BaseClass
//    {
//        public void readExcel(String filePath, String fileName, String sheetName)
//        {
//            string path = @"C:\\Users\\SauravSharma\\source\\repos\\Inherit\\SauceDemoAutomationWithSpecflow\\SauceDemoAutomationWithSpecflow\\BasePagePackage\\SauceDemoUsers.xlsx";
           
//                //Create an object of File class to open xlsx file
//                File file = new File(filePath + "\\" + fileName);
//                //Create an object of FileInputStream class to read excel file
//                FileInputStream inputStream = new FileInputStream(file);
//                Workbook guru99Workbook = null;
//                //Find the file extension by splitting file name in substring  and getting only extension name
//                String fileExtensionName = fileName.substring(fileName.indexOf("."));
//                //Check condition if the file is xlsx file
//                if (fileExtensionName.equals(".xlsx"))
//                {
//                    //If it is xlsx file then create object of XSSFWorkbook class
//                    guru99Workbook = new XSSFWorkbook(inputStream);
//                }
//                //Check condition if the file is xls file
//                else if (fileExtensionName.Equals(".xls"))
//                {
//                    //If it is xls file then create object of HSSFWorkbook class
//                    guru99Workbook = new HSSFWorkbook(inputStream);
//                }
//                //Read sheet inside the workbook by its name
//                Sheet guru99Sheet = guru99Workbook.getSheet(sheetName);
//                //Find number of rows in excel file
//                int rowCount = guru99Sheet.getLastRowNum() - guru99Sheet.getFirstRowNum();
//                //Create a loop over all the rows of excel file to read it
//                for (int i = 0; i < rowCount + 1; i++)
//                {
//                    Row row = guru99Sheet.getRow(i);
//                    //Create a loop to print cell values in a row
//                    for (int j = 0; j < row.getLastCellNum(); j++)
//                    {
//                        //Print Excel data in console
//                        Console.WriteLine(row.getCell(j).getStringCellValue() + "|| ");
//                    }
//                Console.WriteLine();
//                }
//        } 
//                }
//}