using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Media; //WINDOWSの音を使用

namespace RawData_processer
{
    public partial class Form1 : Form
    {

        string rawdata_filename;
        Int32 time_col;
        Int32 line_datastart; // index (zero means first line of file)
        Int32 line_dataend;
        Int32 total_datanum;
        double rawdata_starttime;
        double rawdata_endtime;
        double sampling_rate;

        public Form1()
        {
            InitializeComponent();
        }

        //ドラッグされたものを判断し、受け入れるかどうかを決定。
        private void Form1_DragEnter(object sender, DragEventArgs e)
        {
            // ファイルのドラッグアンドドロップのみを受け付けるようにしています。
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                // ドロップされたファイルは、アプリケーション側に内容がコピーされるものとします。
                e.Effect = DragDropEffects.Copy;
            }

        }

        //File reading by Drag & Drop (Analysis prior to main analysis)
        private void Form1_DragDrop(object sender, DragEventArgs e)
        {
            Int32 i, j;
            Double[,] buffer = new Double[Constants.MAX_DATACOL, Constants.DATA_SEGMENT];
            Double[] last_buffer = new Double[Constants.MAX_DATACOL];


            //Roughly read the file for estimation.
            Int32 Row_count = 0;
            Int32 Col_count = 0;
            Int32 data_colnum = 0;

            Boolean header_read = true;

            TargetCbox.Items.Clear();
            textBox1.Clear();

            ///Get filename.
            foreach (String filename in (string[])e.Data.GetData(DataFormats.FileDrop))
            {
                rawdata_filename = filename;

                using (StreamReader sr = new StreamReader(filename, System.Text.Encoding.Default))
                {
                    string stResult = string.Empty;
                    string stTemp = string.Empty;
                    string stBuffer = string.Empty;
                    string[] stArrayData = new string[Constants.MAX_DATACOL];

                    double d;

                    i = 0;
                    while (sr.Peek() >= 0)
                    {
                        //Read a line
                        stBuffer = sr.ReadLine();
                        //set derimeter
                        stArrayData = stBuffer.Split(',');

                        //Read the Header.////////////////////////////////////////////////

                        if (header_read)
                        {
                            Boolean flag = true;
                            data_colnum = 0;
                            foreach (string stData in stArrayData)
                            {
                                if (!Double.TryParse(stData, out d) && !stData.Equals(string.Empty))
                                {
                                    flag = false;
                                }
                                else if (Double.TryParse(stData, out d) && !stData.Equals(string.Empty))
                                {
                                    data_colnum++;
                                }
                            }
                            if (flag) // if there is only numbers, Enter the sampling mode
                            {
                                //move to data capturing.
                                header_read = false;
                                //save.
                                line_datastart = i;
                                Row_count = 0;
                            }
                            else
                            {
                                stTemp = " # " + stBuffer + "\r\n";
                                textBox1.AppendText(stTemp);
                            }
                        }
                        //Read the DATA.////////////////////////////////////////////////
                        if (!header_read)
                        {
                            if (Row_count < Constants.DATA_SEGMENT)
                            {
                                //このプログラムにおいては、最初に読み込んだ際、100個めまでは、データを表示する。しかしそのあとは読み飛ばすのみ。 
                                Col_count = 0;
                                foreach (string stData in stArrayData)
                                {
                                    if (!stData.Equals(string.Empty))
                                    {
                                        if (Double.TryParse(stData, out d))
                                        {
                                            last_buffer[Col_count] = Double.Parse(stData);
                                            buffer[Col_count, Row_count] = Double.Parse(stData);
                                            Col_count++;
                                        }
                                        else
                                        {
                                            line_dataend = i;
                                            break;// this could be the end of the data.
                                        }
                                    }
                                }
                            }
                            else
                            {
                                Col_count = 0;
                                foreach (string stData in stArrayData)
                                {
                                    if (!Double.TryParse(stData, out d) && !stData.Equals(string.Empty))
                                    {
                                        line_dataend = i;
                                        break;
                                    }
                                    else if (!stData.Equals(string.Empty))
                                    {
                                        //keep last buffer to know the measurement period.
                                        last_buffer[Col_count] = Double.Parse(stData);
                                        Col_count++;
                                    }
                                }

                            }
                            Row_count++; //counter only for data area
                        }
                        i++; //line counter for entire file

                    }

                    if (line_dataend == 0)
                    {
                        line_dataend = i - 2;
                    }

                    total_datanum = Row_count;
                    sr.Close();

                    // Show first 100line for review.
                    for (j = 0; j < Constants.DATA_SEGMENT && j < total_datanum; j++)
                    {
                        stTemp = String.Empty;
                        for (i = 0; i < data_colnum; i++)
                        {
                            stTemp += String.Format("[{0:e}]", buffer[i, j]);
                            if (i < data_colnum - 1) stTemp += ",";
                        }
                        stTemp += "\r\n";
                        textBox1.AppendText(stTemp);
                    }

                    //Auto detection of time column. (not implemented yet)
                    /*
                        Boolean[] col_udcheck = new Boolean[Constants.MAX_DATACOL];
                        for (i = 0; i < Constants.MAX_DATACOL; i++)
                        {
                          col_udcheck[i] = false;
                        }
                     
                     */

                    //For most of wave file, first col is represent time.
                    time_col = 0;

                    rawdata_starttime = buffer[time_col, 0];
                    rawdata_endtime = last_buffer[time_col];
                    sampling_rate = (total_datanum - 1) / Math.Abs(rawdata_endtime - rawdata_starttime);

                    //Update Forms accoding to the analysis
                    for (i = 0; i < data_colnum; i++)
                    {
                        if (i == time_col) stTemp = "Time";
                        else stTemp = String.Format("wave{0}", i);
                        TargetCbox.Items.Add(stTemp);
                        TargetCbox.SelectedIndex = i;
                    }

                    TargetCbox.Refresh();

                    InfoTbox.Text = "File load complete. (" + System.IO.Path.GetFileName(rawdata_filename) + ")\r\n";
                    InfoTbox.Text += String.Format("Data num:{0:d}\r\n", total_datanum);
                    InfoTbox.Text += String.Format("Data start end :{0:e} [s]\r\n", rawdata_starttime);
                    InfoTbox.Text += String.Format("Data end end :{0:e} [s]\r\n", rawdata_endtime);
                    InfoTbox.Text += String.Format("Data start line :{0}\r\n", line_datastart);
                    InfoTbox.Text += String.Format("Data end line:{0}\r\n", line_dataend);
                    InfoTbox.Text += String.Format("Sampling rate :{0:e} [Hz]\r\n", sampling_rate);

                    Int32 splitnum, pindex;
                    Double tindex;

                    splitnum = 32; //default value
                    pindex = (Int32)(total_datanum / splitnum);
                    tindex = Math.Abs(rawdata_endtime - rawdata_starttime) / splitnum;

                    Trim_Start.Enabled = true;
                    SystemSounds.Beep.Play();
                }//using stream
            }//foreach
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            CompressTbox.Text = String.Format("{0}", trackBar1.Value);
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            int d;

            if (int.TryParse(CompressTbox.Text, out d))
            {
                if (d >= 0 && d <= 100)
                {
                    trackBar1.Value = d;
                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void Trim_Start_Click(object sender, EventArgs e)
        {
            int i,j,k;
            // 読み込んだ結果をすべて格納するための変数を宣言する
            Double[,] buffer = new Double[Constants.MAX_DATACOL, Constants.DATA_SEGMENT];
            Double[,] res_buffer = new Double[Constants.MAX_DATACOL, Constants.DATA_SEGMENT];

            int col_num = 0;

            string stResult = string.Empty;
            string stTemp = string.Empty;
            string stBuffer = string.Empty;
            string[] stArrayData = new string[Constants.MAX_DATACOL];

            Double d;
            Int32 Col_count;
            Int32 Row_count;

            //time cropping 用データ
            double starttime = rawdata_starttime;
            double endtime = rawdata_endtime;

            //表示系の調整
            progressBar1.Minimum = 0;
            progressBar1.Maximum = line_dataend;
            progressBar1.Value = 0;

            //ファイルパスから、ディレクトリを抽出。
            string out_filename = System.IO.Path.GetDirectoryName(rawdata_filename);
            out_filename += "\\" + System.IO.Path.GetFileNameWithoutExtension(rawdata_filename) + "_trimed.csv";
            StreamWriter sw = new StreamWriter(out_filename, false, System.Text.Encoding.Default);

            //入力パラメータのエラー処理
            if (CHKBOX_simple.Checked)
            {
                if (int.Parse(SkipcolTbox.Text) <= 0 || int.Parse(SkipcolTbox.Text) >= Constants.DATA_SEGMENT)
                {
                    MessageBox.Show("Incorrect column interval!!",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                    SkipcolTbox.Text = "10";
                    return;
                }
            }
            if (RDPDecimation.Checked)
            {
                if (TargetCbox.SelectedIndex == time_col)
                {
                    MessageBox.Show("You can not use time column as a target!!!",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                    return;
                }
            }
            if (cropbytime_cBox.Checked)
            {
                if (!double.TryParse(Starttime_tBox.Text, out starttime) || !double.TryParse(Endtime_tBox.Text, out endtime))
                {
                    MessageBox.Show("Incorrect Period!!!",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                    Starttime_tBox.Text = String.Format("{0:e}", rawdata_starttime);
                    Endtime_tBox.Text = String.Format("{0:e}", rawdata_endtime);
                    return;
                }
                else
                {
                    starttime = double.Parse(Starttime_tBox.Text);
                    endtime = double.Parse(Endtime_tBox.Text);
                }
            }

            // Any action when file is already exist.
            using (StreamReader sr = new StreamReader(rawdata_filename, System.Text.Encoding.Default))
            {
                //Adding header
                sw.WriteLine("## Trimmed by Makihata Trimmer");

                i = 0;
                Row_count = 0;
                while (sr.Peek() >= 0)
                {
                    //file read
                    stBuffer = sr.ReadLine();
                    //set derimeter
                    stArrayData = stBuffer.Split(',');

                    if (i < line_datastart)
                    {
                        sw.WriteLine("# " + stBuffer);

                    }
                    //read and contain the data into wave_buf.
                    else if (i >= line_datastart && i < line_dataend)
                    {
                        Col_count = 0;
                        foreach (string stData in stArrayData)
                        {
                            if (!stData.Equals(string.Empty))
                            {
                                if (Double.TryParse(stData, out d))
                                {
                                    buffer[Col_count,Row_count] = Double.Parse(stData);
                                    Col_count++;
                                    col_num = Col_count;
                                }
                                else
                                {
                                    break;// this could be the end of the data.
                                }
                            }
                        }
                        Row_count++;
                    }

                    if (Row_count % Constants.DATA_SEGMENT == 0 && i > line_datastart)
                    {
                        //ある時間領域のデータのみを取り出す
                        if (cropbytime_cBox.Checked)
                        {
                            for (j = 0; j < Constants.DATA_SEGMENT; j = j + 1)
                            {
                                if (buffer[time_col, j] > starttime && buffer[time_col, j] <= endtime)
                                {
                                    string sTemp = string.Empty;
                                    for (k = 0; k < col_num; k++)
                                    {
                                        if (k == 0) sTemp += String.Format("{0:e}",buffer[k, j]);
                                        else sTemp += "," + String.Format("{0:e}", buffer[k, j]);
                                    }
                                    sTemp += "\r\n";
                                    sw.Write(sTemp);
                                }
                            }

                        }

                        //単純に間引く。(特定の行数ごとにデータをサンプリングする。
                        else if (CHKBOX_simple.Checked)
                        {
                            for (j = 0; j < Constants.DATA_SEGMENT; j = j + int.Parse(SkipcolTbox.Text))
                            {
                                string sTemp = string.Empty;
                                for (k = 0; k < col_num; k++)
                                {
                                    if (k == 0) sTemp += String.Format("{0:e}",buffer[k, j]);
                                    else sTemp += "," + String.Format("{0:e}", buffer[k, j]);
                                }
                                sTemp += "\r\n";
                                sw.Write(sTemp);
                            }
                        }

                        //Ramer-Douglas-Peuckerアルゴリズム（地形の簡略化や、時系列データの表示に使われる間引き法）
                        else if (RDPDecimation.Checked)
                        {

                            //Double[,] res_buffer = new Double[Constants.MAX_DATACOL, Constants.DATA_SEGMENT];

                            WAVEDATA[] rawpoints = new WAVEDATA[Constants.DATA_SEGMENT];
                            WAVEDATA[] results;

                            for (j = 0; j < Constants.DATA_SEGMENT; j++)
                            {
                                rawpoints[j] = new WAVEDATA();
                                rawpoints[j].data = buffer[TargetCbox.SelectedIndex, j];
                                rawpoints[j].time = buffer[time_col, j];
                            }

                            if (Epsilon_mode.Checked)
                            {
                                results = RDP(rawpoints, Double.Parse(EpsilonTbox.Text));
                            }
                            else
                            {
                                int target_length = (int)(Constants.DATA_SEGMENT * int.Parse(CompressTbox.Text) / 100);
                                Double start_eps = 0;
                                Double end_eps = 1;
                                do
                                {
                                    results = RDP(rawpoints, (end_eps + start_eps) / 2);

                                    if (results.Length > target_length)
                                    {
                                        start_eps = (end_eps + start_eps) / 2;
                                    }
                                    else
                                    {
                                        end_eps = (end_eps + start_eps) / 2;

                                    }
                                } while (Math.Abs(target_length - results.Length) > 20);

                            }
                            for (j = 0; j < results.Length - 1; j++)
                            {
                                sw.WriteLine(String.Format("{0:e},{1:e}", results[j].time, results[j].data));
                            }

                        }

                        //reset for next time.
                        Row_count = 0;
                    }

                    //進行状況を更新。
                    if (i < line_dataend) progressBar1.Value = i;
                    else progressBar1.Value = line_dataend;
                    progressBar1.Refresh();

                    i++;

                } //while
            }//using(sr)
            sw.Close();
            progressBar1.Value = 0;
            progressBar1.Refresh();

            MessageBox.Show("Trimming finished",
                   "Info",
                   MessageBoxButtons.OK,
                   MessageBoxIcon.Information);

            textBox1.Text = "";


        }

     public class WAVEDATA
     {
            public Double time;
            public Double data;
     }

/*
things to be updated.
1. This function is designed only for time and data.(have to crop all column)
*/


     private static WAVEDATA[] RDP(WAVEDATA[] PointList, Double epsilon)
     {
         Int32 index = 0;
         Int32 i;
         double d;
         double dmax = 0;
         WAVEDATA[] Result1, Result2;
         WAVEDATA[] result;

         for (i = 1; i < PointList.Length - 1; i++)
         {
             d = PerpendicularDistance(PointList[0], PointList[PointList.Length - 1], PointList[i]);
             if (d > dmax)
             {
                 index = i;
                 dmax = d;
             }
         }

         if (dmax > epsilon)
         {
             WAVEDATA[] TmpList1 = new WAVEDATA[index + 1];
             WAVEDATA[] TmpList2 = new WAVEDATA[PointList.Length - index];
             Array.Copy(PointList, 0, TmpList1, 0, index + 1);
             Array.Copy(PointList, index , TmpList2, 0, PointList.Length - index);
             Result1 = RDP(TmpList1, epsilon);
             Result2 = RDP(TmpList2, epsilon);

             result = new WAVEDATA[Result1.Length + Result2.Length -1];
             Array.Copy(Result1, 0, result, 0, Result1.Length - 1);
             Array.Copy(Result2, 0, result, Result1.Length - 1, Result2.Length);
         }
         else
         {
             result = new WAVEDATA[2];
             result[0] = PointList[0];
             result[1] = PointList[PointList.Length - 1];
         }

         return(result);
     }

     private static double PerpendicularDistance(WAVEDATA p1, WAVEDATA p2, WAVEDATA p)
     {

         double result;
         double slope;
         double intercept;

         if (p1.time == p2.time)
         {
             result = Math.Abs(p.time - p1.time);
         }
         else
         {
             slope = (p2.data - p1.data) / (p2.time - p1.time);
             intercept = p1.data - (slope * p1.time);
             result = Math.Abs(slope * p.time - p.data + intercept) / Math.Sqrt(Math.Pow(slope, 2) + 1);
         }
         return result;
         
     }

     private void Epsilon_mode_CheckedChanged(object sender, EventArgs e)
     {
         //trackBar1.Enabled = false;
         EpsilonTbox.Enabled = Epsilon_mode.Checked;
     }

     private void Compress_mode_CheckedChanged(object sender, EventArgs e)
     {
         trackBar1.Enabled = Compress_mode.Checked;
         CompressTbox.Enabled = Compress_mode.Checked;
     }

     private void RDPDecimation_CheckedChanged(object sender, EventArgs e)
     {
         Panel_RDP.Enabled = RDPDecimation.Checked;
     }

     private void cropbytime_cBox_CheckedChanged(object sender, EventArgs e)
     {
         Panel_Timecrop.Enabled = cropbytime_cBox.Checked;
     }

     private void CHKBOX_simple_CheckedChanged(object sender, EventArgs e)
     {
         Panel_decimate.Enabled = CHKBOX_simple.Checked;
     }

        private void StatisticsBTN_Click(object sender, EventArgs e)
        {

        }
    }


    static class Constants
    {
        public const int MAX_DATACOL = 5;
        public const int DATA_SEGMENT = 1000;
    }

}
