using System;
using System.IO;
using System.Reflection;
using System.Runtime.InteropServices;
using Excel = Microsoft.Office.Interop.Excel; 


namespace IDS_BASE
{                  
    public partial class Form1 : Form
    {       // Author Callum Du Heaume
            // Title: Intrustion detection project
            // Due 9/05/2022
           
        string[]? src_G;
        double[]? srcCommonality_G;
        string[]? dist_G;
        double[]? distCommonality_G;
        string[]? protocol_G;
        double[]? protocolCommonality_G;
        string[]? srcPort_G;
        double[]? srcPortCommonality_G;
        string[]? distPort_G;
        double[]? distPortCommonality_G;

        public Form1()
        {
            InitializeComponent();
        

        }

        private void RUN_btn_Click(object sender, EventArgs e)
        {

            // Hard Coded for TESTING need to make user changable
            string FilePath = TrainingDataPath_txt.Text;
            Input(FilePath); //Starts the Reading Process
            // Input(@"H:\Visual Studio Solutions\IDS BASE\IDS BASE\bin\Debug\DATA\MixedBefireInfection.xlsx"); // FilePath Goes Here
        }
        private void Analyse_btn_Click(object sender, EventArgs e)
        {

            string FilePath = DataSetPath_txt.Text;
            double[] safetyRating = Analyse(FilePath); // FilePath Goes here
            //double[] safetyRating = Analyse(@"H:\Visual Studio Solutions\IDS BASE\IDS BASE\bin\Debug\DATA\MixedBefireInfection.xlsx"); // FilePath Goes here
        }
        private void TrainData_btn_Click(object sender, EventArgs e)
        { // Opens the File Explorer Dialog And Saves the Selcted File
            openFileDialog1.ShowDialog();
            string FilePath = openFileDialog1.FileName;
            FilePath = FilePath.Substring(0, FilePath.Length);
            TrainingDataPath_txt.Text = FilePath;

        }
        private void MainData_btn_Click(object sender, EventArgs e)
        {// Opens the File Explorer Dialog And Saves the Selcted File
            openFileDialog1.ShowDialog();
            string FilePath = openFileDialog1.FileName;
            FilePath = FilePath.Substring(0, FilePath.Length);
            DataSetPath_txt.Text = FilePath;
        }
        private void Sensitivity_tb_Scroll(object sender, EventArgs e)
        {
            int SensitivityInput = Sensitivity_tb.Value;
            double Sensitivity = (double)SensitivityInput / 10;
            sensitivity_txt.Text = Sensitivity.ToString();
        }

        private void SensitivityTip_pb_Click(object sender, EventArgs e)
        {   // This is a tool Tip for the Sensitivity Settinfg
            MessageBox.Show("This is Used to adjust the Sensitivity of the Model, 1 being the higest Sensitivity, will trigger at allmost everything.\nAnd 0 being the opposite the model will trigger with only the packets with the highest suspicion.\n0.2 is default.", "Sensitivity Value");


        }
        private void TrainingData_pb_Click(object sender, EventArgs e)
        {// Help message for the Traing Data Ammount % 
            MessageBox.Show("This is the % of The Training Data to use for the Traing\nThis may want to be Adjusted with Large data sets for Time\nDefault is 10%","Traing Data Ammount");// Set to .7% for Code testing
        }
        private void dataSet_pb_Click(object sender, EventArgs e)
        {
            MessageBox.Show("This is the % of The Data Set to use for the Analyse phase\nThis may want to be Adjusted with Large data sets for Time\nDefault is 10%", "Data Set Ammount");// Set to .7% for Code testing
        }
        private void dataSetCheck_pb_Click(object sender, EventArgs e)
        {
            MessageBox.Show("This Check will use the same File that was used for Traing, for analysis.\nIt will not use the same Packets, it will start where the traing finished, in that file.\nCannot be used when using 100% of traing file.", "Train Data As Data Set");
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
                 MessageBox.Show("USE Numbers in the sensitivity bettween 1 and 0 \n (0.3) For Example");
                 sensitivity = .2;
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
            sheet = wkb.Sheets[1];
            // gets the used number of used cells
            range = sheet.UsedRange;
            // count of used rows and coloums
            int rowCount = range.Rows.Count;
            int ColoumnsCount = range.Columns.Count;
            //itrate thew every single ROW for a SELECTED Coloum            
            
            string[] data = new string[6];
          
            double Percentage;
            if (DataSetAmmount_txt.Text != string.Empty) // check if they Enterd a Precentage
            {
                try // Check if they enterd a valid Precentage 
                {
                    Percentage = Convert.ToDouble(DataSetAmmount_txt.Text); // Divide the Percentage by 10 * the RowCount to find how many Rows yo use
                    if (Percentage > 100) { MessageBox.Show("Data Set Ammount set to 100%\nCannot be over 100%"); Percentage = 100; }
                }
                catch { Percentage = 2; MessageBox.Show("Please enter Number from 1 to 100, Defaulting to: " + Percentage.ToString()); }
            }
            else
            {
                Percentage = 2;
            }
            double Row_D = Percentage / 100 * rowCount;
            DataSetAmmount_txt.Text = Percentage.ToString();
            int Rows = Convert.ToInt32(Row_D);
            int offSet;

            if (DataSetUsesTraingData_cb.Checked)
            {
                double PercentageofTraing = Convert.ToDouble(TraingDataAmmount_txt.Text);
                offSet = Convert.ToInt32(PercentageofTraing / 100 * rowCount);
                Rows += offSet;
            }
            else
            {
                offSet=1;
            }
            int n = offSet + 500;
            
            MainProgressBar.Maximum = Rows;
            MainProgressBar.Minimum = offSet;
            MainProgressBar.Value = MainProgressBar.Minimum;
            for (int i = offSet; i <= Rows; i++) // using the Seccind set of 8000 ROWS for this PART
                {
                    for (int j = 4; j < 9; j++) // Goto 9 For all relavent Data int the END GOAL
                    {
                        // check if cell has DATA then read it
                        if (range.Cells[i, j] != null && range.Cells[i, j].Text != null)
                        {

                            data[j - 4] = (range.Cells[i, j].Text);

                        }
                    }

                    
                    // Run Through Each Part of the Data Packet againts its Trained NODE
                    double safety = SourceAddressNodeAnalyse(src_G, srcCommonality_G, data[0]);
                    safety_Array[0] = safety;
                    safety = DistAddressNodeAnalyse(dist_G, distCommonality_G, data[1]);
                    safety_Array[1] = safety;
                    safety = ProtocolNodeAnalyse(protocol_G, protocolCommonality_G, data[2]);
                    safety_Array[2] = safety;
                    safety = srcPortNodeAnalyse(protocol_G, protocolCommonality_G, data[3]);
                    safety_Array[3] = safety;
                    safety = distPortNodeAnalyse(protocol_G, protocolCommonality_G, data[4]);
                    safety_Array[4] = safety;

                    
                    double saftyRating = 0;
                    foreach (double commanality in safety_Array)
                    {
                        saftyRating = saftyRating + commanality;

                    }
                    saftyRating = saftyRating / 5; // ideally to be 6 by the END
                    if (saftyRating < sensitivity)
                    {
                     Console.WriteLine("Packet: " + i + " Has Been Flagged With Rating of: " + saftyRating.ToString());
                    resultsDisplay_rtb.Text += "Packet: " + i + " Has Been Flagged With Rating of: " + saftyRating.ToString()+"\n";
                }
                    if (i > n) { Console.WriteLine("Status: " + i.ToString() + "/" + Rows.ToString()); n += 500;MainProgressBar.PerformStep();}

            }

            MainProgressBar.Value = MainProgressBar.Minimum;
            MessageBox.Show("Done", "Completed Analyse");
           
            
            
            
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
            sheet = wkb.Sheets[1];
            // gets the used number of used cells
            range = sheet.UsedRange;
            MainProgressBar.Minimum = 0;
            MainProgressBar.Value = 0;
            string[] Results = scrape(4);
            (src_G, srcCommonality_G) = SourceAddressNodeTraining(Results);
            Results = scrape(5);
            (dist_G, distCommonality_G) = DistAddressNodeTraining(Results);
            Results = scrape(6);
            (protocol_G, protocolCommonality_G) = ProtocolNodeTraining(Results);
            Results = scrape(7);
            (srcPort_G, srcPortCommonality_G) = srcPortNodeTraining(Results);
            Results = scrape(8);
            (distPort_G, distPortCommonality_G) = distPortNodeTraining(Results);
            
            // used to Scrape the Rows out of a single coloum 
            string[] scrape(int coloum) {
                // count of used rows 
                int rowCount = range.Rows.Count;
                double Percentage;
                if (TraingDataAmmount_txt.Text != string.Empty) // check if they Enterd a Precentage
                {
                    try // Check if they enterd a valid Precentage 
                    {   
                        Percentage = Convert.ToDouble(TraingDataAmmount_txt.Text); // Divide the Percentage by 10 * the RowCount to find how many Rows to use
                        if (Percentage > 100) { MessageBox.Show("Training Data Ammount set to 100%\nCannot be over 100%", "Traing Data Ammount"); Percentage = 100; }
                    }
                    catch { Percentage = 2; MessageBox.Show("Please enter Number from 1 to 100, Defaulting to: "+ Percentage.ToString() + "%", "Traing Data Ammount");  }
                }
                else 
                {  
                   Percentage = 2; MessageBox.Show("Please enter Number from 1 to 100, Defaulting to: "+Percentage.ToString()+"%", "Traing Data Ammount");
                }
                double Row_D = Percentage / 100 * rowCount;
                TraingDataAmmount_txt.Text = Percentage.ToString();
                int Rows = Convert.ToInt32(Row_D);  
                // Selets the coloum to Scrape
                //itrate thew every single ROW for a SELECTED Coloum            
                int n = 500;
                List<string> Scrape = new List<string> { };
                MainProgressBar.Maximum = Rows*5;
                MainProgressBar.Minimum = 2;
               
                for (int i = 2; i <= Rows; i++)
                {
                    if (i > n) { Console.WriteLine(i.ToString()); n += 500;MainProgressBar.PerformStep();}  // Progress Tracking for Progress Bar
                    if (range.Cells[i, coloum] != null && range.Cells[i, coloum].Text != null)
                    {

                        Scrape.Add(range.Cells[i, coloum].Text);

                        //TESTING BLOCK
                        // Console.Write(range.Cells[i, 4].Text + "\t");
                        //Console.Write("\r\n");
                        //End
                    }

                }
                Console.WriteLine("copying");
                string[] Results = new string[Scrape.Count];
                Scrape.CopyTo(Results);
                Console.WriteLine("copying Done");
                Scrape.Clear();
                return Results;
            }
            // End Of Scrape
            MainProgressBar.Value = 2;
            MessageBox.Show("Done", "Completed Training");



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
        public (string[], double[]) DistAddressNodeTraining(string[] Destinations)
        {

            List<string> dist = new List<string>();
            List<int> comanality = new List<int>();
            string Sample = string.Empty;
            //Look for duplacats based on sample and count them
            for (int i = 0; i < Destinations.Length; i++)
            {
                if (Destinations[i] != string.Empty)
                {
                    Sample = Destinations[i];
                    int count = 0;
                    for (int j = 0; j < Destinations.Length; j++)
                    {
                        if (Destinations[j] == Sample)
                        {
                            count++;
                            Destinations[j] = string.Empty;
                        }


                    }
                    // reccord the Comanality of those duplcates
                    dist.Add(Sample);
                    comanality.Add(count);
                }
                Sample = string.Empty;
            }
            string[] dist_A = dist.ToArray();
            int[] comanality_A = comanality.ToArray();

            Console.WriteLine(comanality_A.Max().ToString());
            Console.WriteLine(comanality_A.Min().ToString());
            double[] comanality_D = new double[comanality_A.Length];
            for (int i = 0; i < comanality_A.Length; i++)
            {
                comanality_D[i] = (double)comanality_A[i] / (double)comanality_A.Max();
            }
            return (dist_A, comanality_D);

        }
        public double DistAddressNodeAnalyse(string[]? Destinations, double[]? distCommonality, string data)
        {
            for (int i = 0; i < Destinations.Length; i++)
            {
                if (data == Destinations[i])
                {
                    double commonality = distCommonality[i];
                    return commonality;
                }

            }
            return 0;
        }
        public (string[], double[]) ProtocolNodeTraining(string[] Protocols)
        {

            List<string> proto = new List<string>();
            List<int> comanality = new List<int>();
            string Sample = string.Empty;
            //Look for duplacats based on sample and count them
            for (int i = 0; i < Protocols.Length; i++)
            {
                if (Protocols[i] != string.Empty)
                {
                    Sample = Protocols[i];
                    int count = 0;
                    for (int j = 0; j < Protocols.Length; j++)
                    {
                        if (Protocols[j] == Sample)
                        {
                            count++;
                            Protocols[j] = string.Empty;
                        }


                    }
                    // reccord the Comanality of those duplcates
                    proto.Add(Sample);
                    comanality.Add(count);
                }
                Sample = string.Empty;
            }
            string[] proto_A = proto.ToArray();
            int[] comanality_A = comanality.ToArray();

            Console.WriteLine(comanality_A.Max().ToString());
            Console.WriteLine(comanality_A.Min().ToString());
            double[] comanality_D = new double[comanality_A.Length];
            for (int i = 0; i < comanality_A.Length; i++)
            {
                comanality_D[i] = (double)comanality_A[i] / (double)comanality_A.Max();
            }
            return (proto_A, comanality_D);

        }
        public double ProtocolNodeAnalyse(string[]? Protocols, double[]? protoCommonality, string data)
        {
            for (int i = 0; i < Protocols.Length; i++)
            {
                if (data == Protocols[i])
                {
                    double commonality = protoCommonality[i];
                    return commonality;
                }

            }
            return 0;
        }
        public (string[], double[]) srcPortNodeTraining(string[] srcPorts)
        {

            List<string> ports = new List<string>();
            List<int> comanality = new List<int>();
            string Sample = string.Empty;
            //Look for duplacats based on sample and count them
            for (int i = 0; i < srcPorts.Length; i++)
            {
                if (srcPorts[i] != string.Empty)
                {
                    Sample = srcPorts[i];
                    int count = 0;
                    for (int j = 0; j < srcPorts.Length; j++)
                    {
                        if (srcPorts[j] == Sample)
                        {
                            count++;
                            srcPorts[j] = string.Empty;
                        }


                    }
                    // reccord the Comanality of those duplcates
                    ports.Add(Sample);
                    comanality.Add(count);
                }
                Sample = string.Empty;
            }
            string[] ports_A = ports.ToArray();
            int[] comanality_A = comanality.ToArray();

            Console.WriteLine(comanality_A.Max().ToString());
            Console.WriteLine(comanality_A.Min().ToString());
            double[] comanality_D = new double[comanality_A.Length];
            for (int i = 0; i < comanality_A.Length; i++)
            {
                comanality_D[i] = (double)comanality_A[i] / (double)comanality_A.Max();
            }
            return (ports_A, comanality_D);

        }
        public double srcPortNodeAnalyse(string[]? srcPorts, double[]? srcPortCommonality, string data)
        {
            for (int i = 0; i < srcPorts.Length; i++)
            {
                if (data == srcPorts[i])
                {
                    double commonality = srcPortCommonality[i];
                    return commonality;
                }

            }
            return 0;
        }
        public (string[], double[]) distPortNodeTraining(string[] distPorts)
        {

            List<string> ports = new List<string>();
            List<int> comanality = new List<int>();
            string Sample = string.Empty;
            //Look for duplacats based on sample and count them
            for (int i = 0; i < distPorts.Length; i++)
            {
                if (distPorts[i] != string.Empty)
                {
                    Sample = distPorts[i];
                    int count = 0;
                    for (int j = 0; j < distPorts.Length; j++)
                    {
                        if (distPorts[j] == Sample)
                        {
                            count++;
                            distPorts[j] = string.Empty;
                        }


                    }
                    // reccord the Comanality of those duplcates
                    ports.Add(Sample);
                    comanality.Add(count);
                }
                Sample = string.Empty;
            }
            string[] distports_A = ports.ToArray();
            int[] comanality_A = comanality.ToArray();

            Console.WriteLine(comanality_A.Max().ToString());
            Console.WriteLine(comanality_A.Min().ToString());
            double[] comanality_D = new double[comanality_A.Length];
            for (int i = 0; i < comanality_A.Length; i++)
            {
                comanality_D[i] = (double)comanality_A[i] / (double)comanality_A.Max();
            }
            return (distports_A, comanality_D);

        }
        public double distPortNodeAnalyse(string[]? distPorts, double[]? distPortCommonality, string data)
        {
            for (int i = 0; i < distPorts.Length; i++)
            {
                if (data == distPorts[i])
                {
                    double commonality = distPortCommonality[i];
                    return commonality;
                }

            }
            return 0;
        }
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            Application.Exit();
        }

    }
}