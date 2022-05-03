using System;
using System.IO;
using System.Reflection;
using System.Runtime.InteropServices;
using Excel = Microsoft.Office.Interop.Excel; 


namespace IDS_BASE
{
    public partial class Form1 : Form
    {
      
        public Form1()
        {
            InitializeComponent();

           
        }

        private void RUN_btn_Click(object sender, EventArgs e)
        {

            // Hard Coded for TESTING need to may user changable
            Input(@"H:\Visual Studio Solutions\IDS BASE\IDS BASE\bin\Debug\DATA\MixedBefireInfection.xlsx");


        }      

        public void Input(string filePath)
        {// Method for Reading the EXCEL File and providing in to the Next NODE's in the programme
            Console.WriteLine(filePath);

            // Creates the EXCEL Interop for use
            Excel.Application? excel = null;
            Excel.Workbook? wkb = null;
            Excel.Range? range = null;
            Excel.Worksheet? sheet = null;


            // starts the EXCEL Interop
            excel = new Excel.Application();
            // Opens the workbook File
            wkb = excel.Workbooks.Open(filePath);
            //opens the sheet *Need to make the name changable / open sheet [1] by default*
            sheet = wkb.Sheets["MixedBefireInfection"];
            // gets the used number of used cells
            range = sheet.UsedRange;

            string[] Results = scrape(4);

            // used to Scrape the Rows out of a single coloum !!! CAPED AT 15000 rows for testing because of SPEED !!!
            string[] scrape(int coloum) {
                // count of used rows 
                int rowCount = range.Rows.Count;
                ; // Selets the coloum to Scrape
                                //itrate thew every single ROW for a SELECTED Coloum            
                int n = 500;
                List<string> Scrape = new List<string> { };
                for (int i = 1; i <= 15000; i++)
                {
                    if (i > n) { Console.WriteLine(i.ToString()); n += 500; }
                    if (range.Cells[i, coloum] != null && range.Cells[i, coloum].Text != null)
                    {

                        Scrape.Add(range.Cells[i, coloum].Text);

                        //TESTING BLOCK
                        // Console.Write(range.Cells[i, 4].Text + "\t");
                        //Console.Write("\r\n");

                    }

                }
                Console.WriteLine("copying");
                string[] Results = new string[Scrape.Count];
                Scrape.CopyTo(Results);
                Console.WriteLine("copying Done");
                Scrape.Clear();
                return Results;
             }





            //clean excel process
            Console.WriteLine("Done.. Starting clean up");
            GC.Collect();
            GC.WaitForPendingFinalizers();

            //release com objects to fully kill excel process from running in the background
            Marshal.ReleaseComObject(range);
            Marshal.ReleaseComObject(sheet);

            //close and release
            wkb.Close();
            Marshal.ReleaseComObject(wkb);

            //quit and release
            excel.Quit();
            Marshal.ReleaseComObject(excel);
            return;
            

        }
      



    }
}