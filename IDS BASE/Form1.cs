using System;
using System.IO;
using System.Reflection;
using System.Runtime.InteropServices;
using Excel = Microsoft.Office.Interop.Excel; 


namespace IDS_BASE
{
    public partial class Form1 : Form
    {
        string[]? src_G;
        double[]? srcCommonality_G;
        public Form1()
        {
            InitializeComponent();
        

        }

        private void RUN_btn_Click(object sender, EventArgs e)
        {

            // Hard Coded for TESTING need to make user changable
             Input(@"H:\Visual Studio Solutions\IDS BASE\IDS BASE\bin\Debug\DATA\MixedBefireInfection.xlsx");
        }
        private void Analyse_btn_Click(object sender, EventArgs e)
        {


            double[] safetyRating = Analyse(@"H:\Visual Studio Solutions\IDS BASE\IDS BASE\bin\Debug\DATA\MixedBefireInfection.xlsx");

        }
        public double[] Analyse(string dataSet)
        {
            double sensitivity;
            try
            {
                 sensitivity = Convert.ToDouble(sensitivity_txt.Text);
            }
            catch
            {
                 MessageBox.Show("USE Numbers in the sensitivity bettween 1 and 0 (0.3)");
                 sensitivity = .5;
            }

            double[] safety_Array = new double[6];
            // Creates the EXCEL Interop for use
            Excel.Application? excel = null;
            Excel.Workbook? wkb = null;
            Excel.Range? range = null;
            Excel.Worksheet? sheet = null;
            // starts the EXCEL Interop
            excel = new Excel.Application();
            // Opens the workbook File
            wkb = excel.Workbooks.Open(dataSet);
            //opens the sheet *Need to make the name changable / open sheet [1] by default*
            sheet = wkb.Sheets["MixedBefireInfection"];
            // gets the used number of used cells
            range = sheet.UsedRange;
            // count of used rows and coloums
            int rowCount = range.Rows.Count;
            int ColoumnsCount = range.Columns.Count;
            //itrate thew every single ROW for a SELECTED Coloum            
            int n = 500;
            string[] data = new string[6];
            for (int i = 8000; i <= 16000; i++) // using the Seccind set of 8000 ROWS for this PART 
            {

                for (int j = 4; j < 5; j++) // Goto 9 For all relavent Data int the END GOAL
                {
                       // check if cell has DATA then read it
                    if (range.Cells[i, j] != null && range.Cells[i, j].Text != null)
                    {

                        data[j-4] = (range.Cells[i, j].Text);                      

                    }
                }


                // Run Through Each Part of the Data Packet againts its Trained NODE
                double safety = SourceAddressNodeAnalyse(src_G,srcCommonality_G,data[0]);
                safety_Array[0] = safety;


                double saftyRating=0;
                foreach(double commanality in safety_Array)
                {
                    saftyRating = saftyRating + commanality;
                    
                }
                saftyRating = saftyRating / 1; // Will need to be 6 by the END
                if(saftyRating < sensitivity)
                {
                    Console.WriteLine("Packet: " + i  + " Has Been Flagged With Rating of: " + saftyRating.ToString());
                }

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
            return safety_Array;
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
            (src_G, srcCommonality_G) = SourceAddressNodeTraining(Results);

            // used to Scrape the Rows out of a single coloum !!! CAPED AT 15000 rows for testing because of SPEED !!!
            string[] scrape(int coloum) {
                // count of used rows 
                int rowCount = range.Rows.Count;
                 // Selets the coloum to Scrape
                                //itrate thew every single ROW for a SELECTED Coloum            
                int n = 500;
                List<string> Scrape = new List<string> { };
                for (int i = 2; i <= 8000; i++)
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
        public (string[] , double[]) SourceAddressNodeTraining(string[] Sources)
        { 
              
                List<string> Src = new List<string>();
                List<int> comanality = new List<int>();
                string Sample = string.Empty;
                //Look for duplacats based on sample and count them
                for (int i = 0; i < Sources.Length; i++)
                {  if (Sources[i] != string.Empty)
                    {
                        Sample = Sources[i];
                        int count = 0;
                        for (int j = 0; j < Sources.Length; j++)
                        {
                            if (Sources[j] == Sample)
                            {
                                count++;
                                Sources[j] = string.Empty;
                            }
                           

                        }
                        // reccord the Comanality of those duplcates
                        Src.Add(Sample);
                        comanality.Add(count);
                    }
                    Sample = string.Empty;
                }
                string[] Src_A = Src.ToArray();
                int[] comanality_A = comanality.ToArray();

                Console.WriteLine(comanality_A.Max().ToString());
                Console.WriteLine(comanality_A.Min().ToString());
                double[] comanality_D = new double[comanality_A.Length];
                for (int i = 0; i < comanality_A.Length; i++){
                    comanality_D[i] = (double)comanality_A[i] / (double)comanality_A.Max();                                   
                }
                return (Src_A, comanality_D);

        }
        public double SourceAddressNodeAnalyse(string[]?sources,double[]? srcCommonality,string data)
        {
            for (int i = 0; i < sources.Length; i++) 
            { 
               if (data == sources[i])
                {
                    double commonality = srcCommonality[i];
                    return commonality;
                }   
               
            }                               
            return 0;
        }



    }
}