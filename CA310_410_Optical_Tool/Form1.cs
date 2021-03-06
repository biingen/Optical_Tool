﻿//Sample Code for CA-SDK
//Copyright (c) 2016 KONICA MINOLTA, INC.

using System;
using System.ComponentModel;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.IO;
using System.Linq;
using NPOI.HSSF.UserModel;
using NPOI.XSSF.UserModel;
using NPOI.SS.UserModel;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.IO.Ports;

namespace CA310_410_Optical_Tool
{

    public partial class Form1 : Form
    {
        delegate void UpdateLableHandler(object lv);
        private CA200SRVRLib.Ca200 objCa200;
        private CA200SRVRLib.Ca objCa;
        private CA200SRVRLib.Probe objProbe;
        private CA200SRVRLib.Memory objMemory;
        private CA200SRVRLib.IProbeInfo objProbeInfo;
        //private ColorSpaceControl.xyControl objxyControl;
        private CaControl.CaControl objCaControl;
        //private ColorSpaceControl.xyControl xyControl;
        private Boolean isMsr;
        long vbObjectError = -2147221504;
        Form2 f2 = null;
        int number = 0;
        SerialPort serialPort2238 = new SerialPort();
        SerialPort serialPortPID = new SerialPort();
        String saveDataFile = null;
        FileStream saveDataFS = null;
        public ISheet sheet;
        public FileStream fileStream;
        public IWorkbook workbook = null; //新建IWorkbook對象 
        public HSSFWorkbook wookbook;
        [DllImport("user32.dll", EntryPoint = "FindWindow", CharSet = CharSet.Auto)]
        private extern static IntPtr FindWindow(string lpClassName, string lpWindowName);
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern int PostMessage(IntPtr hWnd, int msg, IntPtr wParam, IntPtr lParam);
        public const int WM_CLOSE = 0x10;
        public string inifilename_source = "source.ini";
        public string inifilename_mode = "mode.ini";
        public string inifilename_CT = "CT.ini";
        SetupIniIP ini = new SetupIniIP();
        string RS232filepath = System.Environment.CurrentDirectory + @"\" + @"309_Optical.xls";


        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            canTmeasure();
            button_connect.Enabled = false;
            //serialPort.DataReceived += new SerialDataReceivedEventHandler(dataReceived);
            //准备就绪              
            serialPort2238.DtrEnable = true;
            serialPort2238.RtsEnable = true;
            //设置数据读取超时为1秒
            serialPort2238.ReadTimeout = 1000;
            serialPort2238.Close();
            inputsetup(inifilename_source, comboBox_sourcelist);
            inputsetup(inifilename_mode, comboBox_modelist);
            inputsetup(inifilename_CT, comboBox_CTlist);
        }
        private void inputsetup(string ini, ComboBox combo)
        {
            try
            {
                string inipath = Application.StartupPath + @"\\" + ini;
                if (File.Exists(Application.StartupPath + "\\" + ini))
                {
                    StreamReader sr = new StreamReader(inipath, Encoding.Default);
                    while (sr.Peek() > 0)
                    {
                        combo.Items.Add(sr.ReadLine());
                    }
                    sr.Close();
                    //選中combobox第一個
                    //combo.Text = (string)comboBox_sourcelist.Items[0];
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        private void f2_Disposed(object sender, EventArgs e)
        {
            f2 = null; //Disposed 後把 f2 設為 null, 下次要用時再建新的 
        }
        void Form2_FormClosing(object sender, FormClosingEventArgs e)
        {
            //如果是 user 要關掉 form, 改為隱藏 
            if (e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true;
                f2.Hide(); //用隱藏取代關閉, 資源不會釋放, 下次要用直接 Show 就好了 
            }
        }
        private void DisplayError(Exception er)
        {
            String msg;
            msg = "Error from" + er.Source + "\r\n";
            msg += er.Message + "\r\n";
            msg += "HR:" + (er.HResult - vbObjectError).ToString();
            MessageBox.Show(msg);
        }
        private void measure(int time)
        {
            try
            {
                isMsr = true;
                ButtonCancel.Enabled = true;
                ButtonMeasure.Enabled = false;
                ButtonCalZero.Enabled = false;
                for (int i = 1; i <= time; i++)
                {
                    objCa.Measure();
                    LabelLv.Text = objProbe.Lv.ToString("##0.0000");
                    Labelx.Text = objProbe.sx.ToString("0.000000");
                    Labely.Text = objProbe.sy.ToString("0.000000");
                    LabelT.Text = objProbe.T.ToString("####");
                    Labelduv.Text = objProbe.duv.ToString("0.000000");
                    dataGridView1.Rows.Add(number, Labelx.Text, Labely.Text, LabelLv.Text, LabelT.Text, Labelduv.Text,
                        comboBox_sourcelist.Text, comboBox_modelist.Text, comboBox_CTlist.Text);
                    Application.DoEvents();
                    //objxyControl.SetXYGraphData();
                    Thread.Sleep(100);
                    if (isMsr == false)
                    {
                        break;
                    }
                    number++;
                }
                //canmeasure();
            }
            catch (Exception er)
            {
                DisplayError(er);
                Application.Exit();
            }
        }
        private void gammacurve(object lv)
        {
            objCa.Measure();
            if (objProbe.Lv <= Convert.ToDouble(lv))
            {
                MessageBox.Show("LV<" + lv + ", Check the CA-310 or DUT", "Warning");
                goto measureend;
            }
            else
            {
                if (System.IO.File.Exists(textBox_excelname.Text + @"_Gamma.xls"))//檔案是否存在
                {
                }
                else
                {
                    File.Copy(System.Environment.CurrentDirectory + "\\GammaRefTable.xls", System.Environment.CurrentDirectory + @"\" + textBox_excelname.Text + @"_Gamma.xls");
                }
                string filePath = System.Environment.CurrentDirectory + @"\" + textBox_excelname.Text + @"_Gamma.xls";
                //string filePath = System.Environment.CurrentDirectory + "\\GammaRefTable.xls";
                if (checkBox1_Red.Checked == true)
                {
                    dataGridView1.Rows.Clear();
                    number = 0;
                    for (int i = 255; i >= 0; i--)
                    {
                        f2.f_ChangeColor(i, 0, 0);
                        label_colorstep.Text = "Color Step:" + i;
                        label_colorstep.ForeColor = Color.Green;
                        Thread.Sleep(Int32.Parse(textBox_gammadelay.Text));
                        measure(1);
                        if (isMsr == false)
                        {
                            goto measureend;
                        }
                    }
                    gammaexcelNPOI(filePath, dataGridView1, 0);
                }
                if (checkBox2_Green.Checked == true)
                {
                    dataGridView1.Rows.Clear();
                    number = 0;
                    for (int i = 255; i >= 0; i--)
                    {
                        f2.f_ChangeColor(0, i, 0);
                        label_colorstep.Text = "Color Step:" + i;
                        label_colorstep.ForeColor = Color.Green;
                        Thread.Sleep(Int32.Parse(textBox_gammadelay.Text));
                        measure(1);
                        if (isMsr == false)
                        {
                            goto measureend;
                        }
                    }
                    gammaexcelNPOI(filePath, dataGridView1, 1);
                }
                if (checkBox3_Blue.Checked == true)
                {
                    dataGridView1.Rows.Clear();
                    number = 0;
                    for (int i = 255; i >= 0; i--)
                    {
                        f2.f_ChangeColor(0, 0, i);
                        label_colorstep.Text = "Color Step:" + i;
                        label_colorstep.ForeColor = Color.Green;
                        Thread.Sleep(Int32.Parse(textBox_gammadelay.Text));
                        measure(1);
                        if (isMsr == false)
                        {
                            goto measureend;
                        }
                    }
                    gammaexcelNPOI(filePath, dataGridView1, 2);
                }
                if (checkBox4_White.Checked == true)
                {
                    dataGridView1.Rows.Clear();
                    number = 0;
                    for (int i = 255; i >= 0; i--)
                    {
                        f2.f_ChangeColor(i, i, i);
                        label_colorstep.Text = "Color Step:" + i;
                        label_colorstep.ForeColor = Color.Green;
                        Thread.Sleep(Int32.Parse(textBox_gammadelay.Text));
                        measure(1);
                        if (isMsr == false)
                        {
                            goto measureend;
                        }
                    }
                    gammaexcelNPOI(filePath, dataGridView1, 3);
                }
                button_Gamma.Text = "Pattern Start";
            }
        measureend:
            canmeasure();
            label_colorstep.ForeColor = Color.Red;
            label_colorstep.Text = "Test Stop";
            button_Gamma.Text = "Pattern Start";

        }
        private void startgamma(object lv)
        {
            this.Invoke(
            new UpdateLableHandler(gammacurve),
            new object[] { lv });
        }
        private void gammacurve1(object lv)
        {
            objCa.Measure();
            if (objProbe.Lv <= Convert.ToDouble(lv))
            {
                MessageBox.Show("LV<" + lv + ", Check the CA-310 or DUT", "Warning");
                goto measureend;
            }
            else
            {
                string filePath = System.Environment.CurrentDirectory + "\\GammaRefTable.xls";
                if (checkBox1_Red.Checked == true)
                {
                    dataGridView1.Rows.Clear();
                    number = 0;
                    for (int i = 255; i >= 0; i--)
                    {
                        f2.f_ChangeColor(i, 0, 0);
                        label_colorstep.Text = "Color Step:" + i;
                        label_colorstep.ForeColor = Color.Green;
                        Thread.Sleep(Int32.Parse(textBox_gammadelay.Text));
                        measure(1);
                        if (isMsr == false)
                        {
                            goto measureend;
                        }
                    }
                    gammaexcelNPOI(filePath, dataGridView1, 0);
                }
                if (checkBox2_Green.Checked == true)
                {
                    dataGridView1.Rows.Clear();
                    number = 0;
                    for (int i = 255; i >= 0; i--)
                    {
                        f2.f_ChangeColor(0, i, 0);
                        label_colorstep.Text = "Color Step:" + i;
                        label_colorstep.ForeColor = Color.Green;
                        Thread.Sleep(Int32.Parse(textBox_gammadelay.Text));
                        measure(1);
                        if (isMsr == false)
                        {
                            goto measureend;
                        }
                    }
                    gammaexcelNPOI(filePath, dataGridView1, 1);
                }
                if (checkBox3_Blue.Checked == true)
                {
                    dataGridView1.Rows.Clear();
                    number = 0;
                    for (int i = 255; i >= 0; i--)
                    {
                        f2.f_ChangeColor(0, 0, i);
                        label_colorstep.Text = "Color Step:" + i;
                        label_colorstep.ForeColor = Color.Green;
                        Thread.Sleep(Int32.Parse(textBox_gammadelay.Text));
                        measure(1);
                        if (isMsr == false)
                        {
                            goto measureend;
                        }
                    }
                    gammaexcelNPOI(filePath, dataGridView1, 2);
                }
                if (checkBox4_White.Checked == true)
                {
                    dataGridView1.Rows.Clear();
                    number = 0;
                    for (int i = 255; i >= 0; i--)
                    {
                        f2.f_ChangeColor(i, i, i);
                        label_colorstep.Text = "Color Step:" + i;
                        label_colorstep.ForeColor = Color.Green;
                        Thread.Sleep(Int32.Parse(textBox_gammadelay.Text));
                        measure(1);
                        if (isMsr == false)
                        {
                            goto measureend;
                        }
                    }
                    gammaexcelNPOI(filePath, dataGridView1, 3);
                }
                button_Gamma.Text = "Start";
            }
        measureend:
            canmeasure();
            label_colorstep.ForeColor = Color.Red;
            label_colorstep.Text = "Test Stop";
        }
        private void startgamma1(object lv)
        {
            this.Invoke(
            new UpdateLableHandler(gammacurve),
            new object[] { lv });
        }
        private void button_Gamma_Click(object sender, EventArgs e)
        {
            if (button_Gamma.Text == "Pattern Start")
            {
                //按鈕功能變更為取消
                button_Gamma.Text = "Stop";
                ThreadPool.QueueUserWorkItem(new WaitCallback(startgamma1), 0.005);
            }
            else
            {
                //設定取消旗標
                isMsr = false;
                //在完全停止前，停用按鈕
                button_Gamma.Enabled = false;
                button_Gamma.Text = "Pattern Start";
            }

            //Thread gammathread =new Thread( new ParameterizedThreadStart(gammacurve));
            //gammathread.Start(0.005);

            // gammacurve(0.005);
        }
        private void ButtonMeasure_Click(object sender, EventArgs e)
        {
            measure(1);
            canmeasure();
        }
        private void AutoMeasure_Click(object sender, EventArgs e)
        {
            button_AutoMeasure.Enabled = false;
            isMsr = true;
            ButtonCancel.Enabled = true;
            backgroundWorker2.RunWorkerAsync();//移到執行緒執行 
        }
        private void backgroundWorker2_DoWork(object sender, DoWorkEventArgs e)
        {
            for (;;)
            {
                if (backgroundWorker2.CancellationPending == true)
                {
                    e.Cancel = true;
                    break;
                }
                objCa.Measure();
                backgroundWorker2.ReportProgress(1);
                Thread.Sleep(500);
            }


        }
        private void backgroundWorker2_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            button_AutoMeasure.Enabled = false;
            LabelLv.Text = objProbe.Lv.ToString("##0.0000");
            Labelx.Text = objProbe.sx.ToString("0.000000");
            Labely.Text = objProbe.sy.ToString("0.000000");
            LabelT.Text = objProbe.T.ToString("####");
            Labelduv.Text = objProbe.duv.ToString("0.000000");
        }
        private void backgroundWorker2_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            //backgroundWorker2.RunWorkerAsync();//移到執行緒執行 
        }
        private void ButtonCancel_Click(object sender, EventArgs e)
        {
            isMsr = false;
            backgroundWorker2.CancelAsync();
            canmeasure();
        }
        private void ButtonCalZero_Click(object sender, EventArgs e)
        {
            bool calzero_success = false;

            while (calzero_success == false)
            {
                ButtonMeasure.Enabled = false;
                ButtonCalZero.Enabled = false;
                button_AutoMeasure.Enabled = false;
                try
                {
                    objCa.CalZero();
                    calzero_success = true;
                }
                catch (Exception er)
                {
                    DisplayError(er);
                    if (MessageBox.Show("Zero Cal Error\r\n Close program?", "CalZero", MessageBoxButtons.OKCancel) == DialogResult.Cancel)
                    {
                        break;
                    }
                    else
                    {
                        System.Environment.Exit(0);
                    }
                }
            }
            MessageBox.Show("CalZero Finish", "CalZero");
            ButtonMeasure.Enabled = true;
            ButtonCalZero.Enabled = true;
            button_AutoMeasure.Enabled = true;
        }
        private void objCa_ExeCalZero()
        {
            if (MessageBox.Show("CalZero?", "CalZero", MessageBoxButtons.OKCancel) == DialogResult.Cancel)
            {
                return;
            }
            ButtonMeasure.Enabled = false;
            ButtonCalZero.Enabled = false;

            try
            {
                objCa.CalZero();
            }
            catch (Exception er)
            {
                DisplayError(er);
            }

            ButtonMeasure.Enabled = true;
            ButtonCalZero.Enabled = true;
        }
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                objCa.RemoteMode = 0;
                objCa200 = null;
                objCa = null;
                objProbe = null;
                objMemory = null;
                objProbeInfo = null;
                objCaControl = null;
                //objxyControl = null;
            }
            catch (Exception er)
            {
                Application.Exit();
            }
        }
        private void button_clear_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            number = 0;
        }

        private void canmeasure()
        {
            //ButtonCancel.Enabled = false;
            ButtonMeasure.Enabled = true;
            ButtonCalZero.Enabled = true;
            button_gammapattern.Enabled = true;
            button_dsiconnect.Enabled = true;
            button_connect.Enabled = false;
            button_310.Enabled = false;
            button_410.Enabled = false;
            button_Gamma.Enabled = true;
            button_2238gamma.Enabled = true;
            checkBox_LumP1.Enabled = true;
            checkBox_LumP2.Enabled = true;
            checkBox_CTTest.Enabled = true;
            checkBox_Contrast.Enabled = true;
            checkBox_Unifornity.Enabled = true;
            //button_lightSensor.Enabled = true;
            checkBox_ColorGamut.Enabled = true;
            checkBox_Dimming.Enabled = true;
            //button_DynamicContrasRatioTest.Enabled = true;
            button_AutoMeasure.Enabled = true;
            button_StartTestCase.Enabled = true;
        }
        private void canTmeasure()
        {
            ButtonCancel.Enabled = false;
            ButtonMeasure.Enabled = false;
            ButtonCalZero.Enabled = false;
            button_gammapattern.Enabled = false;
            button_dsiconnect.Enabled = false;
            button_connect.Enabled = true;
            button_310.Enabled = true;
            button_410.Enabled = true;
            button_Gamma.Enabled = false;
            button_2238gamma.Enabled = false;
            checkBox_LumP1.Enabled = false;
            checkBox_LumP2.Enabled = false;
            checkBox_CTTest.Enabled = false;
            checkBox_Contrast.Enabled = false;
            checkBox_Unifornity.Enabled = false;
            //button_lightSensor.Enabled = false;
            checkBox_ColorGamut.Enabled = false;
            checkBox_Dimming.Enabled = false;
            //button_DynamicContrasRatioTest.Enabled = false;
            button_AutoMeasure.Enabled = false;
            button_StartTestCase.Enabled = false;
        }
        private void button_SaveCsv_Click(object sender, EventArgs e)
        {

            //string input_date2 = textBox1_CSVname.Text;
            string strValue = string.Empty;
            //CSV 匯出的標題 要先塞一樣的格式字串 充當標題
            strValue = "No,X,Y,Lv,T,duv,R,G,B";
            for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
            {
                for (int j = 0; j < dataGridView1.Rows[i].Cells.Count; j++)
                {
                    if (!string.IsNullOrEmpty(dataGridView1[j, i].Value.ToString()))
                    {
                        if (j > 0)
                            strValue = strValue + "," + dataGridView1[j, i].Value.ToString();
                        else
                        {
                            if (string.IsNullOrEmpty(strValue))
                                strValue = dataGridView1[j, i].Value.ToString();
                            else
                                strValue = strValue + Environment.NewLine + dataGridView1[j, i].Value.ToString();
                        }
                    }
                }
            }
            SaveFileDialog sfd = new SaveFileDialog();
            //設定儲存檔案對話方塊的標題
            sfd.Title = "請選擇要儲存的檔案路徑";
            //初始化儲存目錄，預設exe檔案目錄
            sfd.InitialDirectory = Application.StartupPath;
            //設定儲存檔案的型別
            sfd.Filter = "CSV files (*.csv)|*.csv";
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                //獲得儲存檔案的路徑
                string filePath = sfd.FileName;
                //儲存
                using (FileStream fsWrite = new FileStream(filePath, FileMode.OpenOrCreate, FileAccess.Write))
                {
                    byte[] buffer = Encoding.Default.GetBytes(strValue);
                    fsWrite.Write(buffer, 0, buffer.Length);
                }
            }
        }
        private void button_connect_Click(object sender, EventArgs e)
        {
            try
            {
                objCa200 = new CA200SRVRLib.Ca200();
                objCa200.AutoConnect();

                objCa = objCa200.SingleCa;
                objProbe = objCa.SingleProbe;
                objMemory = objCa.Memory;
                objProbeInfo = (CA200SRVRLib.IProbeInfo)objProbe;
                objCaControl = caControlWrapper1.cacontrolobj;
                objCaControl.Memory = objMemory;
                objCaControl.UpdateCaInfo();
                objCaControl.UpdateMemoryInfo();
                //objxyControl = colorSpaceControlWrapper1.xycontrolobj;
                objCaControl.Probe = objProbe;
                objCaControl.Ca = objCa;
                //objxyControl.Probe = objProbe;
                //objxyControl.Ca = objCa;
                //objxyControl.ClearData();
                objCa.ExeCalZero += new CA200SRVRLib._ICaEvents_ExeCalZeroEventHandler(objCa_ExeCalZero);
                canmeasure();
                label_connect.Text = "Connect Pass";
                label_connect.ForeColor = Color.Green;
            }
            catch (Exception er)
            {
                DisplayError(er);
                label_connect.Text = "Connect Fail";
                label_connect.ForeColor = Color.Red;
            }
        }
        private void button_dsiconnect_Click(object sender, EventArgs e)
        {
            try
            {
                objCa.RemoteMode = 0;
                objCa200 = null;
                objCa = null;
                objProbe = null;
                objMemory = null;
                objProbeInfo = null;
                objCaControl = null;
                //objxyControl = null;
                Thread.Sleep(3000);
                canTmeasure();
                label_connect.Text = "Not Connect";
                label_connect.ForeColor = Color.Red;

            }
            catch (Exception er)
            {
                DisplayError(er);
            }
        }
        private void button_gammapattern_Click(object sender, EventArgs e)
        {
            if (f2 == null)
            {
                f2 = new Form2();
                f2.FormClosing += new FormClosingEventHandler(Form2_FormClosing);
                //如果不想每次 new 新的 Form2, 可加上面那句 
                f2.Disposed += new EventHandler(f2_Disposed);
            }
            f2.Show();
        }
        private void button_410_Click(object sender, EventArgs e)
        {
            try
            {
                runCmd(@"""C:\Program Files (x86)\KONICA MINOLTA\CA-S40\CA-SDK2\x86\lib\CA200Srvr.dll""");
                button_connect.Enabled = true;
                label_mode.Text = "Now select:CA-410";
                label_mode.ForeColor = Color.Green;
            }
            catch (Exception)
            {
                label_mode.Text = "Reselect the instrument";
            }
        }
        private void button_310_Click(object sender, EventArgs e)
        {
            try
            {
                runCmd(@"""C:\Program Files (x86)\KONICAMINOLTA\CA-SDK\SDK\CA200Srvr.dll""");
                button_connect.Enabled = true;
                label_mode.Text = "Now select:CA-310";
                label_mode.ForeColor = Color.Green;
            }
            catch (Exception)
            {
                label_mode.Text = "Reselect the instrument";
            }

        }
        private void runCmd(string cmd)
        {
            using (Process myProcess = new Process())
            {
                //cmd = cmd.Trim().TrimEnd() + "&exit";//說明：不管命令是否成功均執行exit命令，否則當調用ReadToEnd()方法時，會處於假死狀態
                myProcess.StartInfo.FileName = "Regsvr32.exe";
                myProcess.StartInfo.Arguments = cmd;//路徑中不能有空格
                myProcess.StartInfo.UseShellExecute = false;
                myProcess.Start();
                myProcess.WaitForExit();//等待程序執行完退出進程
                myProcess.Close();
            }

        }
        //接收数据
        private void dataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            //textBoxReceive為richtext
            /*
            if (serialPort.IsOpen)
            {
                //MessageBox.Show("sss","OK");
                //输出当前时间
                DateTime dateTimeNow = DateTime.Now;
                //dateTimeNow.GetDateTimeFormats();
                textBoxReceive.Text += string.Format("{0}\r\n", dateTimeNow);
                //dateTimeNow.GetDateTimeFormats('f')[0].ToString() + "\r\n";
                textBoxReceive.ForeColor = Color.Red;    //改变字体的颜色
                    try
                    {
                        String input = serialPort.ReadLine();
                        textBoxReceive.Text += input + "\r\n";
                        // save data to file
                        if (saveDataFS != null)
                        {
                            byte[] info = new UTF8Encoding(true).GetBytes(input + "\r\n");
                            saveDataFS.Write(info, 0, info.Length);
                        }
                    }
                    catch(System.Exception ex)
                    {
                        MessageBox.Show(ex.Message, "波特率請確認");
                        return;
                    }
                    
                    textBoxReceive.SelectionStart = textBoxReceive.Text.Length;
                    textBoxReceive.ScrollToCaret();//滚动到光标处
                    serialPort.DiscardInBuffer(); //清空SerialPort控件的Buffer 
                
            }
            else
            {
                MessageBox.Show("請指定特定串口", "錯誤提示");
            }
            */
        }
        private void button_SearchCOM_Click(object sender, EventArgs e)
        {
            comboBox_com.Text = "";
            comboBox_com.Items.Clear();

            string[] str = SerialPort.GetPortNames();
            if (str == null)
            {
                MessageBox.Show("未偵測到COM Port！", "Error");
                return;
            }

            //添加COM
            foreach (string s in str)
            {
                comboBox_com.Items.Add(s);
            }

            //設置預設COM
            comboBox_com.SelectedIndex = 0;
        }
        private void button_buttonOpenCloseCom_Click(object sender, EventArgs e)
        {
            if (!serialPort2238.IsOpen)//COM若關閉
            {
                try
                {

                    if (comboBox_com.SelectedIndex == -1)
                    {
                        MessageBox.Show("Error: 無效端口,請重新選擇", "Error");
                        return;
                    }
                    string strSerialName = comboBox_com.SelectedItem.ToString();
                    string strBaudRate = "115200";
                    string strDataBit = "8";
                    string strCheckBit = "None";
                    string strStopBit = "1";

                    Int32 iBaudRate = Convert.ToInt32(strBaudRate);
                    Int32 iDataBit = Convert.ToInt32(strDataBit);

                    serialPort2238.PortName = strSerialName;//COM
                    serialPort2238.BaudRate = iBaudRate;//波特率
                    serialPort2238.DataBits = iDataBit;//數據位

                    switch (strStopBit)            //停止位
                    {
                        case "1":
                            serialPort2238.StopBits = StopBits.One;
                            break;
                        case "1.5":
                            serialPort2238.StopBits = StopBits.OnePointFive;
                            break;
                        case "2":
                            serialPort2238.StopBits = StopBits.Two;
                            break;
                        default:
                            MessageBox.Show("Error：停止位參數錯誤!", "Error");
                            break;
                    }
                    switch (strCheckBit)             //校驗位
                    {
                        case "None":
                            serialPort2238.Parity = Parity.None;
                            break;
                        case "Odd":
                            serialPort2238.Parity = Parity.Odd;
                            break;
                        case "Even":
                            serialPort2238.Parity = Parity.Even;
                            break;
                        default:
                            MessageBox.Show("Error：教驗位參數錯誤!", "Error");
                            break;
                    }

                    if (saveDataFile != null)
                    {
                        saveDataFS = File.Create(saveDataFile);
                    }

                    //打開串口
                    serialPort2238.Open();

                    //打開串口後設置變無效
                    comboBox_com.Enabled = false;
                    button_whitepattern.Enabled = true;
                    button_redpattern.Enabled = true;
                    button_greenpattern.Enabled = true;
                    button_bluepattern.Enabled = true;
                    button_blackpattern.Enabled = true;
                    button_9point.Enabled = true;
                    button_buttonOpenCloseCom.Text = "Close COM";
                    label_COMconnect.Text = "Connect Pass";
                    label_COMconnect.ForeColor = Color.Green;

                }
                catch (System.Exception ex)
                {
                    MessageBox.Show("Error:" + ex.Message, "Error");
                    return;
                }
            }
            else //COM處於打開
            {

                serialPort2238.Close();//關閉串口
                //串口关闭时设置有效
                comboBox_com.Enabled = true;
                button_buttonOpenCloseCom.Text = "Open COM";
                label_COMconnect.Text = "No Connect";
                label_COMconnect.ForeColor = Color.Red;
                button_whitepattern.Enabled = false;
                button_redpattern.Enabled = false;
                button_greenpattern.Enabled = false;
                button_bluepattern.Enabled = false;
                button_blackpattern.Enabled = false;
                button_9point.Enabled = false;
                if (saveDataFS != null)
                {
                    saveDataFS.Close(); // 關閉完建
                    saveDataFS = null;//釋放文件句柄
                }

            }
        }
        private void button_whitepattern_Click(object sender, EventArgs e)
        {
            if (!serialPort2238.IsOpen)
            {
                MessageBox.Show("請打開串口", "Error");
                return;
            }
            String strSend = "run ptn 020;";//发送框数据
            serialPort2238.WriteLine(strSend);//发送一行数据
        }
        private void button_blackpattern_Click(object sender, EventArgs e)
        {
            if (!serialPort2238.IsOpen)
            {
                MessageBox.Show("請打開串口", "Error");
                return;
            }
            String strSend = "run ptn 111;";//发送框数据
            serialPort2238.WriteLine(strSend);//发送一行数据
        }
        private void button_redpattern_Click(object sender, EventArgs e)
        {
            if (!serialPort2238.IsOpen)
            {
                MessageBox.Show("請打開串口", "Error");
                return;
            }
            String strSend = "run ptn 021;";//发送框数据
            serialPort2238.WriteLine(strSend);//发送一行数据
        }
        private void button_greenpattern_Click(object sender, EventArgs e)
        {
            if (!serialPort2238.IsOpen)
            {
                MessageBox.Show("請打開串口", "Error");
                return;
            }
            String strSend = "run ptn 022;";//发送框数据
            serialPort2238.WriteLine(strSend);//发送一行数据
        }
        private void button_bluepattern_Click(object sender, EventArgs e)
        {
            if (!serialPort2238.IsOpen)
            {
                MessageBox.Show("請打開串口", "Error");
                return;
            }
            String strSend = "run ptn 023;";//发送框数据
            serialPort2238.WriteLine(strSend);//发送一行数据
        }
        private void button_9point_Click(object sender, EventArgs e)
        {
            if (!serialPort2238.IsOpen)
            {
                MessageBox.Show("請打開串口", "Error");
                return;
            }
            String strSend = "run ptn 1087;";//发送框数据
            serialPort2238.WriteLine(strSend);//发送一行数据
        }
        public void gammaexcelNPOI(string filePath, DataGridView dataGridView, int sheet)
        {
            NPOIExcel writer = new NPOIExcel();
            writer.open(filePath, sheet);
            for (int i = 1; i < dataGridView1.ColumnCount-3; i++)
            {
                for (int j = 0; j < dataGridView1.Rows.Count - 1; j++)
                {
                    writer.SetCell(j + 1, i, dataGridView1.Rows[j].Cells[i].Value.ToString(), NPOI.SS.UserModel.CellType.Numeric);//rowcount,column count 都由0開始      
                }
            }
            writer.SaveClose(filePath);
        }
        private void gammacurve2238(object lv)
        {
            objCa.Measure();
            if (!serialPort2238.IsOpen)
            {
                MessageBox.Show("請打開串口", "Error");
                return;
            }
            if (objProbe.Lv <= Convert.ToDouble(lv))
            {
                MessageBox.Show("LV<" + lv + ", Check the CA-310 or DUT", "Warning");
                goto measureend;
            }
            else
            {
                if (System.IO.File.Exists(textBox_excelname.Text + @"_Gamma.xls"))//檔案是否存在
                {
                }
                else
                {
                    File.Copy(System.Environment.CurrentDirectory + "\\GammaRefTable", System.Environment.CurrentDirectory + @"\" + textBox_excelname.Text + @"_Gamma.xls");
                }
                string filePath = System.Environment.CurrentDirectory + @"\" + textBox_excelname.Text + @"_Gamma.xls";
                //string filePath = System.Environment.CurrentDirectory + "\\GammaRefTable.xls";
                dataGridView1.Rows.Clear();
                number = 0;
                if (checkBox1_Red.Checked == true)
                {
                    String strSend = "run ptn 021;";//发送框数据
                    serialPort2238.WriteLine(strSend);//发送一行数据
                    serialPort2238.WriteLine("func luminance 0 1;");
                    Thread.Sleep(Int32.Parse(textBox_gammadelay.Text));
                    serialPort2238.WriteLine("func luminance 1 0;");
                    Thread.Sleep(Int32.Parse(textBox_gammadelay.Text));
                    dataGridView1.Rows.Clear();
                    for (int i = 255; i >= 0; i--)
                    {
                        serialPort2238.WriteLine("func luminance 3 " + i + ";");
                        Thread.Sleep(Int32.Parse(textBox_gammadelay.Text));
                        label_colorstep.Text = "Color Step:" + i;
                        label_colorstep.ForeColor = Color.Green;
                        Thread.Sleep(Int32.Parse(textBox_gammadelay.Text));
                        measure(1);
                        if (isMsr == false)
                        {
                            goto measureend;
                        }
                    }
                    gammaexcelNPOI(filePath, dataGridView1, 0);
                }
                if (checkBox2_Green.Checked == true)
                {
                    String strSend = "run ptn 022;";//发送框数据
                    serialPort2238.WriteLine(strSend);//发送一行数据
                    serialPort2238.WriteLine("func luminance 0 1;");
                    Thread.Sleep(Int32.Parse(textBox_gammadelay.Text));
                    serialPort2238.WriteLine("func luminance 1 0;");
                    Thread.Sleep(Int32.Parse(textBox_gammadelay.Text));
                    dataGridView1.Rows.Clear();
                    for (int i = 255; i >= 0; i--)
                    {
                        serialPort2238.WriteLine("func luminance 3 " + i + ";");
                        Thread.Sleep(Int32.Parse(textBox_gammadelay.Text));
                        label_colorstep.Text = "Color Step:" + i;
                        label_colorstep.ForeColor = Color.Green;
                        Thread.Sleep(Int32.Parse(textBox_gammadelay.Text));
                        measure(1);
                        if (isMsr == false)
                        {
                            goto measureend;
                        }
                    }
                    gammaexcelNPOI(filePath, dataGridView1, 1);
                }
                if (checkBox3_Blue.Checked == true)
                {
                    String strSend = "run ptn 023;";//发送框数据
                    serialPort2238.WriteLine(strSend);//发送一行数据
                    serialPort2238.WriteLine("func luminance 0 1;");
                    Thread.Sleep(Int32.Parse(textBox_gammadelay.Text));
                    serialPort2238.WriteLine("func luminance 1 0;");
                    Thread.Sleep(Int32.Parse(textBox_gammadelay.Text));
                    dataGridView1.Rows.Clear();
                    for (int i = 255; i >= 0; i--)
                    {
                        serialPort2238.WriteLine("func luminance 3 " + i + ";");
                        Thread.Sleep(Int32.Parse(textBox_gammadelay.Text));
                        label_colorstep.Text = "Color Step:" + i;
                        label_colorstep.ForeColor = Color.Green;
                        Thread.Sleep(Int32.Parse(textBox_gammadelay.Text));
                        measure(1);
                        if (isMsr == false)
                        {
                            goto measureend;
                        }
                    }
                    gammaexcelNPOI(filePath, dataGridView1, 2);
                }
                if (checkBox4_White.Checked == true)
                {
                    String strSend = "run ptn 020;";//发送框数据
                    serialPort2238.WriteLine(strSend);//发送一行数据
                    serialPort2238.WriteLine("func luminance 0 1;");
                    Thread.Sleep(Int32.Parse(textBox_gammadelay.Text));
                    serialPort2238.WriteLine("func luminance 1 0;");
                    Thread.Sleep(Int32.Parse(textBox_gammadelay.Text));
                    dataGridView1.Rows.Clear();
                    for (int i = 255; i >= 0; i--)
                    {
                        serialPort2238.WriteLine("func luminance 3 " + i + ";");
                        Thread.Sleep(Int32.Parse(textBox_gammadelay.Text));
                        label_colorstep.Text = "Color Step:" + i;
                        label_colorstep.ForeColor = Color.Green;
                        Thread.Sleep(Int32.Parse(textBox_gammadelay.Text));
                        measure(1);
                        if (isMsr == false)
                        {
                            goto measureend;
                        }
                    }
                    gammaexcelNPOI(filePath, dataGridView1, 3);
                }
            }
        measureend:
            canmeasure();
            label_colorstep.ForeColor = Color.Red;
            label_colorstep.Text = "Test Stop";
            button_2238gamma.Text = "Chroma Start";

        }
        private void startgamma2238(object lv)
        {
            this.Invoke(
            new UpdateLableHandler(gammacurve2238),
            new object[] { lv });
        }
        private void button_2238gamma_Click(object sender, EventArgs e)
        {
            if (button_2238gamma.Text == "Chroma Start")
            {
                //按鈕功能變更為取消
                button_2238gamma.Text = "Stop";
                ThreadPool.QueueUserWorkItem(new WaitCallback(startgamma2238), 0.005);
            }
            else
            {
                //設定取消旗標
                isMsr = false;
                //在完全停止前，停用按鈕
                button_Gamma.Enabled = false;
                button_Gamma.Text = "Pattern Start";
            }
        }
        private void LumP1()
        {
            //1.1亮度填入表格-1
            canTmeasure();
            dataGridView1.Rows.Clear();
            number = 0;
            checkOriginalfile();
            string filePath = System.Environment.CurrentDirectory + @"\" + textBox_excelname.Text + @".xls";
            int sheet = 0;
            NPOIExcel writer = new NPOIExcel();
            writer.open(filePath, sheet);
            NPOIExcel RS232file = new NPOIExcel();
            RS232file.open(RS232filepath, 1);
            if (!serialPort2238.IsOpen)
            {
                MessageBox.Show("請打開串口", "Error");
                goto finish;
            }
            String strSend = "run ptn 020;";//发送框数据
            serialPort2238.WriteLine(strSend);//发送一行数据
            Thread.Sleep(1000);
            for (int k = 0; k < comboBox_sourcelist.Items.Count; k++)
            {
                comboBox_sourcelist.SelectedIndex = k;
                writer.SetCell(4, 3 + k, comboBox_sourcelist.SelectedItem.ToString(), NPOI.SS.UserModel.CellType.String);//rowcount,column count 都由0開始
                if (serialPortPID.IsOpen)
                {
                    string Source = comboBox_sourcelist.Text;
                    string Sourcecommand = GetToolConfigCell(RS232file.workbook, "Source", Source, "Command");
                    byte[] Sourcecommandbyte = StringToByteArray(Sourcecommand);
                    serialPortPID.Write(Sourcecommandbyte, 0, Sourcecommandbyte.Length);
                    Thread.Sleep(8000);
                }
                else
                {
                    MessageBox.Show(comboBox_sourcelist.SelectedItem.ToString() + ", White Pattern.");
                }
                measure(1);
            }
            for (int j = 0; j < dataGridView1.Rows.Count - 1; j++)
            {
                comboBox_sourcelist.SelectedIndex = j;
                writer.SetCell(j + 3, 4, comboBox_sourcelist.SelectedItem.ToString(), NPOI.SS.UserModel.CellType.Numeric);//rowcount,column count 都由0開始
                writer.SetCell(j + 3, 6, dataGridView1.Rows[j].Cells[3].Value.ToString(), NPOI.SS.UserModel.CellType.Numeric);//rowcount,column count 都由0開始      
            }
        finish:
            writer.SaveClose(filePath);
            canmeasure();
        }
        private void LumP2()
        {
            //1.1亮度填入表格-2
            canTmeasure();
            dataGridView1.Rows.Clear();
            checkOriginalfile();
            string filePath = System.Environment.CurrentDirectory + @"\" + textBox_excelname.Text + @".xls";
            //string filePath = System.Environment.CurrentDirectory + "\\Test_Report_optical.xls";
            int sheet = 0;
            int excelcolumn = 3;//excel直欄
            int excelrow = 20;//excel橫列
            int gridviewrow = 0;
            NPOIExcel writer = new NPOIExcel();
            writer.open(filePath, sheet);
            NPOIExcel RS232file = new NPOIExcel();
            RS232file.open(RS232filepath, 1);
            if (!serialPort2238.IsOpen)
            {
                MessageBox.Show("請打開串口", "Error");
                goto finish;
            }
            String strSend = "run ptn 020;";//发送框数据
            serialPort2238.WriteLine(strSend);//发送一行数据
            Thread.Sleep(1000);
            for (int k = 0; k < comboBox_sourcelist.Items.Count; k++)
            {
                comboBox_sourcelist.SelectedIndex = k;
                if (serialPortPID.IsOpen)
                {
                    string Source = comboBox_sourcelist.Text;
                    string Sourcecommand = GetToolConfigCell(RS232file.workbook, "Source", Source, "Command");
                    byte[] Sourcecommandbyte = StringToByteArray(Sourcecommand);
                    serialPortPID.Write(Sourcecommandbyte, 0, Sourcecommandbyte.Length);
                    Thread.Sleep(8000);
                }
                for (int m = 0; m < comboBox_modelist.Items.Count; m++)
                {
                    comboBox_modelist.SelectedIndex = m;
                    writer.SetCell(17, 3 + 2 * m, comboBox_modelist.SelectedItem.ToString(), NPOI.SS.UserModel.CellType.String);//rowcount,column count 都由0開始
                    writer.SetCell(19 + k, 1, comboBox_sourcelist.SelectedItem.ToString(), NPOI.SS.UserModel.CellType.String);//rowcount,column count 都由0開始
                    if (serialPortPID.IsOpen)
                    {
                        string Mode = comboBox_modelist.Text;
                        string Modecommand = GetToolConfigCell(RS232file.workbook, "PictureMode", Mode, "Command");
                        byte[] Modecommandbyte = StringToByteArray(Modecommand);
                        serialPortPID.Write(Modecommandbyte, 0, Modecommandbyte.Length);
                        Thread.Sleep(1000);
                    }
                    else
                    {
                        MessageBox.Show(comboBox_sourcelist.SelectedItem.ToString() + "," + comboBox_modelist.SelectedItem.ToString() + ", White Pattern.");
                    }
                    measure(1);
                }
            }
            for (int i = 0; i < comboBox_sourcelist.Items.Count; i++)
            {
                for (int j = 0; j < comboBox_modelist.Items.Count; j++)
                {
                    writer.SetCell(i + excelrow - 1, excelcolumn, dataGridView1.Rows[gridviewrow].Cells[3].Value.ToString(), NPOI.SS.UserModel.CellType.Numeric);//rowcount,column count 都由0開始      
                    gridviewrow++;
                    excelcolumn = excelcolumn + 2;
                }
                excelcolumn = 3;
            }
        finish:
            writer.SaveClose(filePath);
            canmeasure();
        }
        private void LumP3()
        {
            //1.1亮度填入表格-3
            canTmeasure();
            dataGridView1.Rows.Clear();
            checkOriginalfile();
            string filePath = System.Environment.CurrentDirectory + @"\" + textBox_excelname.Text + @".xls";
            //string filePath = System.Environment.CurrentDirectory + "\\Test_Report_optical.xls";
            int sheet = 0;
            int excelcolumn = 3;//excel直欄
            int excelrow = 20;//excel橫列
            int gridviewrow = 0;
            NPOIExcel writer = new NPOIExcel();
            writer.open(filePath, sheet);
            NPOIExcel RS232file = new NPOIExcel();
            RS232file.open(RS232filepath, 1);
            if (!serialPort2238.IsOpen)
            {
                MessageBox.Show("請打開串口", "Error");
                goto finish;
            }
            String strSend = "run ptn 020;";//发送框数据
            serialPort2238.WriteLine(strSend);//发送一行数据
            Thread.Sleep(1000);
            for (int k = 0; k < comboBox_sourcelist.Items.Count; k++)
            {
                comboBox_sourcelist.SelectedIndex = k;
                if (serialPortPID.IsOpen)
                {
                    string Source = comboBox_sourcelist.Text;
                    string Sourcecommand = GetToolConfigCell(RS232file.workbook, "Source", Source, "Command");
                    byte[] Sourcecommandbyte = StringToByteArray(Sourcecommand);
                    serialPortPID.Write(Sourcecommandbyte, 0, Sourcecommandbyte.Length);
                    Thread.Sleep(8000);
                }
                for (int m = 0; m < comboBox_modelist.Items.Count; m++)
                {
                    comboBox_modelist.SelectedIndex = m;
                    writer.SetCell(17, 3 + 2 * m, comboBox_modelist.SelectedItem.ToString(), NPOI.SS.UserModel.CellType.String);//rowcount,column count 都由0開始
                    writer.SetCell(19 + k, 1, comboBox_sourcelist.SelectedItem.ToString(), NPOI.SS.UserModel.CellType.String);//rowcount,column count 都由0開始
                    if (serialPortPID.IsOpen)
                    {
                        string Mode = comboBox_modelist.Text;
                        string Modecommand = GetToolConfigCell(RS232file.workbook, "PictureMode", Mode, "Command");
                        byte[] Modecommandbyte = StringToByteArray(Modecommand);
                        serialPortPID.Write(Modecommandbyte, 0, Modecommandbyte.Length);
                        Thread.Sleep(1000);
                    }
                    else
                    {
                        MessageBox.Show(comboBox_sourcelist.SelectedItem.ToString() + "," + comboBox_modelist.SelectedItem.ToString() + ", White Pattern.");
                    }
                    measure(1);
                }
            }
            for (int i = 0; i < comboBox_sourcelist.Items.Count; i++)
            {
                for (int j = 0; j < comboBox_modelist.Items.Count; j++)
                {
                    writer.SetCell(i + excelrow - 1, excelcolumn, dataGridView1.Rows[gridviewrow].Cells[3].Value.ToString(), NPOI.SS.UserModel.CellType.Numeric);//rowcount,column count 都由0開始      
                    gridviewrow++;
                    excelcolumn = excelcolumn + 2;
                }
                excelcolumn = 3;
            }
        finish:
            writer.SaveClose(filePath);
            canmeasure();
        }
        private void CT()
        {
            //1.2 色溫XY填入表格
            canTmeasure();
            dataGridView1.Rows.Clear();
            checkOriginalfile();
            string filePath = System.Environment.CurrentDirectory + @"\" + textBox_excelname.Text + @".xls";
            int sheet = 1;
            int excelcolumnX = 5;//excel直欄
            int excelrowX = 24;//excel橫列
            int excelrowY = 26;//excel橫列
            int excelrowT = 23;
            int gridviewrow = 0;
            NPOIExcel writer = new NPOIExcel();
            writer.open(filePath, sheet);
            if (!serialPort2238.IsOpen)
            {
                MessageBox.Show("請打開串口", "Error");
                goto finish;
            }
            String strSend = "run ptn 020;";//发送框数据
            serialPort2238.WriteLine(strSend);//发送一行数据
            NPOIExcel RS232file = new NPOIExcel();
            RS232file.open(RS232filepath, 1);
            Thread.Sleep(1000);
            for (int k = 0; k < comboBox_sourcelist.Items.Count; k++)
            {
                comboBox_sourcelist.SelectedIndex = k;
                if (serialPortPID.IsOpen)
                {
                    string Source = comboBox_sourcelist.Text;
                    string Sourcecommand = GetToolConfigCell(RS232file.workbook, "Source", Source, "Command");
                    byte[] Sourcecommandbyte = StringToByteArray(Sourcecommand);
                    serialPortPID.Write(Sourcecommandbyte, 0, Sourcecommandbyte.Length);
                    Thread.Sleep(8000);
                }
                for (int m = 0; m < comboBox_CTlist.Items.Count; m++)
                {
                    comboBox_CTlist.SelectedIndex = m;
                    writer.SetCell(2 + m * 2, 1, comboBox_CTlist.SelectedItem.ToString(), NPOI.SS.UserModel.CellType.String);//rowcount,column count 都由0開始
                    writer.SetCell(21, 5 + m, comboBox_CTlist.SelectedItem.ToString(), NPOI.SS.UserModel.CellType.String);//rowcount,column count 都由0開始
                    writer.SetCell(22 + k * 4, 3, comboBox_sourcelist.SelectedItem.ToString(), NPOI.SS.UserModel.CellType.String);//rowcount,column count 都由0開始
                    if (serialPortPID.IsOpen)
                    {
                        string CT = comboBox_CTlist.Text;
                        string CTcommand = GetToolConfigCell(RS232file.workbook, "ColorTemperature", CT, "Command");
                        byte[] CTcommandbyte = StringToByteArray(CTcommand);
                        serialPortPID.Write(CTcommandbyte, 0, CTcommandbyte.Length);
                        Thread.Sleep(1000);
                    }
                    else
                    {
                        MessageBox.Show(comboBox_sourcelist.SelectedItem.ToString() + "," + comboBox_CTlist.SelectedItem.ToString() + ", White Pattern.");
                    }
                    measure(1);
                }
            }
            for (int i = 0; i < comboBox_sourcelist.Items.Count; i++)
            {
                for (int j = 0; j < comboBox_CTlist.Items.Count; j++)
                {
                    writer.SetCell(i + excelrowX - 1, excelcolumnX, dataGridView1.Rows[gridviewrow].Cells[1].Value.ToString(), NPOI.SS.UserModel.CellType.Numeric);//rowcount,column count 都由0開始
                    writer.SetCell(i + excelrowY - 1, excelcolumnX, dataGridView1.Rows[gridviewrow].Cells[2].Value.ToString(), NPOI.SS.UserModel.CellType.Numeric);//rowcount,column count 都由0開始      
                    writer.SetCell(i + excelrowT - 1, excelcolumnX, dataGridView1.Rows[gridviewrow].Cells[4].Value.ToString(), NPOI.SS.UserModel.CellType.Numeric);//rowcount,column count 都由0開始  
                    gridviewrow++;
                    excelcolumnX = excelcolumnX + 1;
                }
                excelrowX = excelrowX + 4;
                excelrowY = excelrowY + 4;
                excelrowT = excelrowT + 4;
                excelcolumnX = 5;
            }
        finish:
            writer.SaveClose(filePath);
            canmeasure();
        }
        private void ContrastRatio()
        {
            canTmeasure();
            contrastratio(020, 4, ", White Pattern.");//白
            contrastratio(111, 2, ", Black Pattern.");//黑
            MessageBox.Show("Test Finish.", "Finish");
            canmeasure();
        }
        private void contrastratio(int ptn, int x, string pattern)
        {
            //ptn為patterngen pattern號, x為打印直排行數,pattern為msg文字
            //1.3
            dataGridView1.Rows.Clear();
            checkOriginalfile();
            string filePath = System.Environment.CurrentDirectory + @"\" + textBox_excelname.Text + @".xls";
            int sheet = 2;
            int excelCTY = 0;
            int gridviewrow = 0;
            NPOIExcel writer = new NPOIExcel();
            writer.open(filePath, sheet);
            NPOIExcel RS232file = new NPOIExcel();
            RS232file.open(RS232filepath, 1);
            if (!serialPort2238.IsOpen)
            {
                MessageBox.Show("請打開串口", "Error");
                goto finish;
            }
            String strSend = "run ptn " + ptn + ";";//发送框数据
            serialPort2238.WriteLine(strSend);//发送一行数据
            Thread.Sleep(1000);
            for (int k = 0; k < comboBox_sourcelist.Items.Count; k++)
            {
                comboBox_sourcelist.SelectedIndex = k;
                if (serialPortPID.IsOpen)
                {
                    string Source = comboBox_sourcelist.Text;
                    string Sourcecommand = GetToolConfigCell(RS232file.workbook, "Source", Source, "Command");
                    byte[] Sourcecommandbyte = StringToByteArray(Sourcecommand);
                    serialPortPID.Write(Sourcecommandbyte, 0, Sourcecommandbyte.Length);
                    Thread.Sleep(8000);
                }
                for (int m = 0; m < comboBox_CTlist.Items.Count; m++)
                {
                    comboBox_CTlist.SelectedIndex = m;
                    writer.SetCell(4 + m + excelCTY, 1, comboBox_CTlist.SelectedItem.ToString(), NPOI.SS.UserModel.CellType.String);//rowcount,column count 都由0開始
                    writer.SetCell(1 + k * 12, 1, comboBox_sourcelist.SelectedItem.ToString(), NPOI.SS.UserModel.CellType.String);//rowcount,column count 都由0開始
                    if (serialPortPID.IsOpen)
                    {
                        string CT = comboBox_CTlist.Text;
                        string CTcommand = GetToolConfigCell(RS232file.workbook, "ColorTemperature", CT, "Command");
                        byte[] CTcommandbyte = StringToByteArray(CTcommand);
                        serialPortPID.Write(CTcommandbyte, 0, CTcommandbyte.Length);
                        Thread.Sleep(1000);
                    }
                    else
                    {
                        MessageBox.Show(comboBox_sourcelist.SelectedItem.ToString() + "," + comboBox_CTlist.SelectedItem.ToString() + pattern);
                    }
                    measure(1);
                }
                excelCTY = excelCTY + 12;
            }
            for (int i = 0; i < comboBox_sourcelist.Items.Count; i++)
            {
                for (int j = 0; j < comboBox_CTlist.Items.Count; j++)
                {
                    writer.SetCell(4 + j + i * 12, x, dataGridView1.Rows[gridviewrow].Cells[3].Value.ToString(), NPOI.SS.UserModel.CellType.Numeric);//rowcount,column count 都由0開始
                    gridviewrow++;
                }
            }
        finish:
            writer.SaveClose(filePath);
        }
        private void Uniformity()
        {
            //1.4 9POINT
            canTmeasure();
            dataGridView1.Rows.Clear();
            number = 0;
            checkOriginalfile();
            string filePath = System.Environment.CurrentDirectory + @"\" + textBox_excelname.Text + @".xls";
            //string filePath = System.Environment.CurrentDirectory + "\\Test_Report_optical.xls";
            int sheet = 3;
            NPOIExcel writer = new NPOIExcel();
            writer.open(filePath, sheet);
            if (!serialPort2238.IsOpen)
            {
                MessageBox.Show("請打開串口", "Error");
                goto finish;
            }
            String strSend = "run ptn 020;";//发送框数据
            serialPort2238.WriteLine(strSend);//发送一行数据
            Thread.Sleep(1500);
            for (int k = 0; k < 9; k++)
            {
                MessageBox.Show("Put CA310/410 to point " + (k + 1) + ", White Pattern.");
                measure(1);
            }
            for (int j = 0; j < dataGridView1.Rows.Count - 1; j++)
            {
                writer.SetCell(8 + j, 3, dataGridView1.Rows[j].Cells[3].Value.ToString(), NPOI.SS.UserModel.CellType.Numeric);//rowcount,column count 都由0開始      
            }
        finish:
            writer.SaveClose(filePath);
            canmeasure();
        }
        private void colorGamut()
        {
            //1.8 color gamut-9POINT
            canTmeasure();
            for (int k = 0; k < comboBox_CTlist.Items.Count; k++)
            {
                comboBox_CTlist.SelectedIndex = k;
                MessageBox.Show("Change color temperature to " + comboBox_CTlist.SelectedItem.ToString());
                colorgamut(k * 30);
            }
            canmeasure();
        }
        private void colorgamut(int CT)
        {
            //1.8 color gamut-9POINT
            dataGridView1.Rows.Clear();
            number = 0;
            checkOriginalfile();
            string filePath = System.Environment.CurrentDirectory + @"\" + textBox_excelname.Text + @".xls";
            //string filePath = System.Environment.CurrentDirectory + "\\Test_Report_optical.xls";
            int sheet = 5;
            NPOIExcel writer = new NPOIExcel();
            writer.open(filePath, sheet);
            if (!serialPort2238.IsOpen)
            {
                MessageBox.Show("請打開串口", "Error");
                goto finish;
            }
            writer.SetCell(1 + CT, 2, "Color Temp @" + comboBox_CTlist.SelectedItem.ToString(), NPOI.SS.UserModel.CellType.String);//rowcount,column count 都由0開始
            for (int i = 0; i < 9; i++)
            {
                MessageBox.Show("Put CA310/410 to point " + (i + 1));
                String strSend = "run ptn 021;";//发送框数据
                serialPort2238.WriteLine(strSend);//发送一行数据
                Thread.Sleep(500);
                //MessageBox.Show("Put CA310/410 to point " + (i + 1) + ", Red Pattern.");
                measure(1);
                strSend = "run ptn 022;";//发送框数据
                serialPort2238.WriteLine(strSend);//发送一行数据
                Thread.Sleep(500);
                //MessageBox.Show("Put CA310/410 to point " + (i + 1) + ", Green Pattern.");
                measure(1);
                strSend = "run ptn 023;";//发送框数据
                serialPort2238.WriteLine(strSend);//发送一行数据
                Thread.Sleep(500);
                //MessageBox.Show("Put CA310/410 to point " + (i + 1) + ", Blue Pattern.");
                measure(1);
                strSend = "run ptn 020;";//发送框数据
                serialPort2238.WriteLine(strSend);//发送一行数据
                Thread.Sleep(500);
                //MessageBox.Show("Put CA310/410 to point " + (i + 1) + ", White Pattern.");
                measure(1);
            }
            int count = 0;
            int excelx = 2;
            for (int j = 0; j < dataGridView1.Rows.Count - 1; j++)
            {
                if (j % 4 == 0 && j > 0)
                {
                    excelx = 2;
                    count++;
                }
                writer.SetCell(4 + count + CT, excelx, dataGridView1.Rows[j].Cells[1].Value.ToString(), NPOI.SS.UserModel.CellType.Numeric);//rowcount,column count 都由0開始      
                writer.SetCell(4 + count + CT, excelx + 1, dataGridView1.Rows[j].Cells[2].Value.ToString(), NPOI.SS.UserModel.CellType.Numeric);//rowcount,column count 都由0開始      
                excelx = excelx + 2;
            }
        finish:
            writer.SaveClose(filePath);
        }
        private void DimmingRange()
        {
            //1.10
            canTmeasure();
            dataGridView1.Rows.Clear();
            number = 0;
            checkOriginalfile();
            string filePath = System.Environment.CurrentDirectory + @"\" + textBox_excelname.Text + @".xls";
            //string filePath = System.Environment.CurrentDirectory + "\\Test_Report_optical.xls";
            int sheet = 6;
            int percent = 0;
            NPOIExcel writer = new NPOIExcel();
            writer.open(filePath, sheet);
            NPOIExcel RS232file = new NPOIExcel();
            RS232file.open(RS232filepath, 1);
            if (!serialPort2238.IsOpen)
            {
                MessageBox.Show("請打開串口", "Error");
                goto finish;
            }
            String strSend = "run ptn 020;";//发送框数据
            serialPort2238.WriteLine(strSend);//发送一行数据
            Thread.Sleep(1000);
            for (int k = 0; k < comboBox_sourcelist.Items.Count; k++)
            {
                comboBox_sourcelist.SelectedIndex = k;
                writer.SetCell(2, 3 + k, comboBox_sourcelist.SelectedItem.ToString(), NPOI.SS.UserModel.CellType.String);//rowcount,column count 都由0開始
                if (serialPortPID.IsOpen)
                {
                    string Source = comboBox_sourcelist.Text;
                    string Sourcecommand = GetToolConfigCell(RS232file.workbook, "Source", Source, "Command");
                    byte[] Sourcecommandbyte = StringToByteArray(Sourcecommand);
                    serialPortPID.Write(Sourcecommandbyte, 0, Sourcecommandbyte.Length);
                    Thread.Sleep(8000);
                }
                for (int i = 0; i < 11; i++)
                {
                    if (i == 0)
                        percent = 0;
                    else
                        percent = i * 10;
                    if (serialPortPID.IsOpen)
                    {
                        string OSDLevel = percent.ToString();
                        string OSDLevelcommand = GetToolConfigCell(RS232file.workbook, "OSDLevel", OSDLevel, "Command");
                        byte[] OSDLevelcommandbyte = StringToByteArray(OSDLevelcommand);
                        serialPortPID.Write(OSDLevelcommandbyte, 0, OSDLevelcommandbyte.Length);
                        Thread.Sleep(1000);
                    }
                    else
                    {
                        MessageBox.Show(comboBox_sourcelist.SelectedItem.ToString() + ", White Pattern, OSD Level " + percent + "%");
                    }
                    measure(1);
                }
            }
            int count = 0;
            int excelx = 3;
            for (int j = 0; j < dataGridView1.Rows.Count - 1; j++)
            {
                if (j % 11 == 0 && j > 0)
                {
                    excelx++;
                    count = 0;
                }
                writer.SetCell(3 + count, excelx, dataGridView1.Rows[j].Cells[3].Value.ToString(), NPOI.SS.UserModel.CellType.Numeric);//rowcount,column count 都由0開始      
                count++;
            }
        finish:
            writer.SaveClose(filePath);
            canmeasure();
        }
        private void DynamicContrasRatio()
        {
            //1.11
            canTmeasure();
            dataGridView1.Rows.Clear();
            number = 0;
            if (System.IO.File.Exists(textBox_excelname.Text + @".xls"))//檔案是否存在
            {
            }
            else
            {
                File.Copy(System.Environment.CurrentDirectory + "\\Test_Report_optical_Original_file", System.Environment.CurrentDirectory + @"\" + textBox_excelname.Text + @".xls");
            }
            string filePath = System.Environment.CurrentDirectory + @"\" + textBox_excelname.Text + @".xls";
            //string filePath = System.Environment.CurrentDirectory + "\\Test_Report_optical.xls";
            int sheet = 7;
            int excelY = 0;
            NPOIExcel writer = new NPOIExcel();
            writer.open(filePath, sheet);
            if (!serialPort2238.IsOpen)
            {
                MessageBox.Show("請打開串口", "Error");
                goto finish;
            }
            for (int k = 0; k < comboBox_sourcelist.Items.Count; k++)
            {
                comboBox_sourcelist.SelectedIndex = k;
                writer.SetCell(2 + k * 3, 4, comboBox_sourcelist.SelectedItem.ToString(), NPOI.SS.UserModel.CellType.String);//rowcount,column count 都由0開始
                String strSend = "run ptn 020;";//发送框数据
                serialPort2238.WriteLine(strSend);//发送一行数据
                MessageBox.Show(comboBox_sourcelist.SelectedItem.ToString() + ", White Pattern.");
                measure(1);
                strSend = "run ptn 111;";//发送框数据
                serialPort2238.WriteLine(strSend);//发送一行数据
                StartKiller();
                MessageBox.Show("Automatically close this window after 10 seconds and measure the black screen.", "Wait 10 second.", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                measure(1);
            }

            for (int j = 0; j < dataGridView1.Rows.Count - 1; j++)
            {
                if (j % 2 == 0 && j > 0)
                {
                    excelY++;
                }
                writer.SetCell(2 + j + excelY, 6, dataGridView1.Rows[j].Cells[3].Value.ToString(), NPOI.SS.UserModel.CellType.Numeric);//rowcount,column count 都由0開始 
            }
        finish:
            writer.SaveClose(filePath);
            canmeasure();
        }
        private void button_StartTestCase_Click(object sender, EventArgs e)
        {
            if (checkBox_LumP1.Checked)
                LumP1();
            if (checkBox_LumP2.Checked)
                LumP2();
            if (checkBox_CTTest.Checked)
                CT();
            if (checkBox_Contrast.Checked)
                ContrastRatio();
            if (checkBox_Unifornity.Checked)
                Uniformity();
            if (checkBox_ColorGamut.Checked)
                colorGamut();
            if (checkBox_Dimming.Checked)
                DimmingRange();
            MessageBox.Show("Test Finish.", "Finish");
        }
        private void timer_Tick(object sender, EventArgs e)
        {
            KillMessageBox();
            //停止Timer
            ((System.Windows.Forms.Timer)sender).Stop();
        }
        private void StartKiller()
        {
            System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer();
            timer.Interval = 10000; //10秒啓動
            timer.Tick += new EventHandler(timer_Tick);
            timer.Start();
        }
        private void KillMessageBox()
        {
            //依MessageBox的標題,找出MessageBox的視窗
            IntPtr ptr = FindWindow(null, "Wait 10 second.");
            if (ptr != IntPtr.Zero)
            {
                //找到則關閉MessageBox視窗
                PostMessage(ptr, WM_CLOSE, IntPtr.Zero, IntPtr.Zero);
            }
        }
        private void button_addSource_Click(object sender, EventArgs e)
        {
            comboboxadd(comboBox_sourcelist, inifilename_source);
        }
        private void button1_Click(object sender, EventArgs e)
        {
            comboboxremove(comboBox_sourcelist, inifilename_source);
        }
        private void button_addmode_Click(object sender, EventArgs e)
        {
            comboboxadd(comboBox_modelist, inifilename_mode);
        }
        private void button_deletemode_Click(object sender, EventArgs e)
        {
            comboboxremove(comboBox_modelist, inifilename_mode);
        }
        private void button_addCT_Click(object sender, EventArgs e)
        {
            comboboxadd(comboBox_CTlist, inifilename_CT);
        }
        private void button_deleteCT_Click(object sender, EventArgs e)
        {
            comboboxremove(comboBox_CTlist, inifilename_CT);
        }
        private void button_Select232File_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Multiselect = true;//該值確定是否可以選擇多個檔案
            dialog.Title = "請選擇資料夾";
            dialog.Filter = "所有檔案(*.*)|*.*";
            if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                RS232filepath = dialog.FileName;
                label15.Text = "Command File:\r\n" + Path.GetFileName(dialog.FileName);
            }
        }
        private void comboboxadd(ComboBox combobox, string file)
        {
            //新增或者選擇combobox選項後,更新combobox選項順序
            if (!combobox.Items.Contains(combobox.Text) && combobox.Text != "")
            {
                combobox.Items.Add(combobox.Text);
            }
            //儲存combobox的選項內容到配置檔案inifilename
            StreamWriter sw = new StreamWriter(file);
            for (int i = 0; i < combobox.Items.Count; i++)
            {
                sw.WriteLine(combobox.Items[i]);
            }
            sw.Close();
        }
        private void comboboxremove(ComboBox combobox, string file)
        {
            //新增或者選擇combobox選項後,更新combobox選項順序
            if (combobox.Items.Contains(combobox.Text))
            {
                combobox.Items.Remove(combobox.Text);
                combobox.Text = null;
            }
            //儲存combobox的選項內容到配置檔案inifilename
            StreamWriter sw = new StreamWriter(file);
            for (int i = 0; i < combobox.Items.Count; i++)
            {
                sw.WriteLine(combobox.Items[i]);
            }
            sw.Close();
        }
        private void button_searchPIDcom_Click(object sender, EventArgs e)
        {
            comboBox_PID.Text = "";
            comboBox_PID.Items.Clear();

            string[] str = SerialPort.GetPortNames();
            if (str == null)
            {
                MessageBox.Show("未偵測到COM Port！", "Error");
                return;
            }

            //添加COM
            foreach (string s in str)
            {
                comboBox_PID.Items.Add(s);
            }

            //設置預設COM
            comboBox_PID.SelectedIndex = 0;
        }
        private void button_conncetPIDcom_Click(object sender, EventArgs e)
        {
            if (!serialPortPID.IsOpen)//COM若關閉
            {
                try
                {

                    if (comboBox_PID.SelectedIndex == -1)
                    {
                        MessageBox.Show("Error: 無效端口,請重新選擇", "Error");
                        return;
                    }
                    string strSerialName = comboBox_PID.SelectedItem.ToString();
                    string strBaudRate = comboBox_PIDBR.SelectedItem.ToString();
                    string strDataBit = comboBox_PIDDataBit.SelectedItem.ToString();
                    string strCheckBit = comboBox_PIDParity.SelectedItem.ToString();
                    string strStopBit = comboBox_StopBit.SelectedItem.ToString();

                    Int32 iBaudRate = Convert.ToInt32(strBaudRate);
                    Int32 iDataBit = Convert.ToInt32(strDataBit);

                    serialPortPID.PortName = strSerialName;//COM
                    serialPortPID.BaudRate = iBaudRate;//波特率
                    serialPortPID.DataBits = iDataBit;//數據位

                    switch (strStopBit)            //停止位
                    {
                        case "1":
                            serialPortPID.StopBits = StopBits.One;
                            break;
                        case "1.5":
                            serialPortPID.StopBits = StopBits.OnePointFive;
                            break;
                        case "2":
                            serialPortPID.StopBits = StopBits.Two;
                            break;
                        default:
                            MessageBox.Show("Error：停止位參數錯誤!", "Error");
                            break;
                    }
                    switch (strCheckBit)             //校驗位
                    {
                        case "None":
                            serialPortPID.Parity = Parity.None;
                            break;
                        case "Odd":
                            serialPortPID.Parity = Parity.Odd;
                            break;
                        case "Even":
                            serialPortPID.Parity = Parity.Even;
                            break;
                        default:
                            MessageBox.Show("Error：教驗位參數錯誤!", "Error");
                            break;
                    }

                    if (saveDataFile != null)
                    {
                        saveDataFS = File.Create(saveDataFile);
                    }

                    //打開串口
                    serialPortPID.Open();

                    //打開串口後設置變無效
                    comboBox_PID.Enabled = false;
                    button_conncetPIDcom.Text = "Close COM";
                    label_PIDconnect.Text = "Connect Pass";
                    label_PIDconnect.ForeColor = Color.Green;
                    comboBox_PIDBR.Enabled = false;
                    comboBox_PIDDataBit.Enabled = false;
                    comboBox_StopBit.Enabled = false;
                    comboBox_PIDParity.Enabled = false;

                }
                catch (System.Exception ex)
                {
                    MessageBox.Show("Error:" + ex.Message, "Error");
                    return;
                }
            }
            else //COM處於打開
            {

                serialPortPID.Close();//關閉串口
                //串口关闭时设置有效
                comboBox_PID.Enabled = true;
                button_conncetPIDcom.Text = "Open COM";
                label_PIDconnect.Text = "No Connect";
                label_PIDconnect.ForeColor = Color.Red;
                comboBox_PIDBR.Enabled = true;
                comboBox_PIDDataBit.Enabled = true;
                comboBox_StopBit.Enabled = true;
                comboBox_PIDParity.Enabled = true;
                if (saveDataFS != null)
                {
                    saveDataFS.Close(); // 關閉完建
                    saveDataFS = null;//釋放文件句柄
                }

            }
        }
        private void checkOriginalfile()
        {
            if (System.IO.File.Exists(textBox_excelname.Text + @".xls"))//檔案是否存在
            {
            }
            else
            {
                File.Copy(System.Environment.CurrentDirectory + "\\Test_Report_optical_Original_file", System.Environment.CurrentDirectory + @"\" + textBox_excelname.Text + @".xls");
            }
        }
        public string GetToolConfigCell(IWorkbook wookbook, string sheetName, string rowName, string columnName)
        {

            ISheet sheet = wookbook.GetSheet(sheetName);

            if (sheet == null)
                return null;
            int rowIndex = -1;
            int colIndex = -1;

            for (int r = 0; r < sheet.PhysicalNumberOfRows; r++)
            {
                IRow row = sheet.GetRow(r);
                if (row == null || row.Cells.Count == 0)
                    continue;
                if (row.Cells[0].CellType == CellType.String && string.Compare(row.Cells[0].StringCellValue, rowName, true) == 0)
                {
                    rowIndex = r;
                    break;
                }
            }
            IRow firstRow = sheet.GetRow(0);
            for (int c = 0; c < firstRow.Cells.Count; c++)
            {
                if (firstRow.Cells[c].CellType == CellType.String && string.Compare(firstRow.Cells[c].StringCellValue, columnName, true) == 0)
                {
                    colIndex = c;
                    break;
                }
            }

            if (rowIndex != -1 && colIndex != -1)
            {
                string cellData = "";
                ICell cell = sheet.GetRow(rowIndex).Cells[colIndex];

                switch (cell.CellType)
                {
                    case CellType.Blank:
                        cellData = "";
                        break;
                    case CellType.Boolean:
                        cellData = Convert.ToString(cell.BooleanCellValue);
                        break;
                    case CellType.Error:
                        cellData = Convert.ToString(cell.ErrorCellValue);
                        break;
                    case CellType.Formula:
                        cellData = Convert.ToString(cell.StringCellValue);
                        break;
                    case CellType.Numeric:
                        cellData = Convert.ToString(cell.NumericCellValue);
                        break;
                    case CellType.String:
                        cellData = Convert.ToString(cell.StringCellValue);
                        break;
                    case CellType.Unknown:
                        cellData = "";
                        break;
                }
                return cellData;
            }
            else
            {
                return null;
            }
        }
        public static byte[] StringToByteArray(String hex)
        {
            hex = hex.Replace(" ", "");
            int NumberChars = hex.Length;
            byte[] bytes = new byte[NumberChars / 2];
            for (int i = 0; i < NumberChars; i += 2)
                bytes[i / 2] = Convert.ToByte(hex.Substring(i, 2), 16);
            return bytes;
        }
        public class NPOIExcel
        {
            public ISheet sheet;
            public FileStream fileStream;
            public IWorkbook workbook = null; //新建IWorkbook對象
            public void open(String fileName, int sheetnumber)
            {
                Boolean excelfileexist;
                do
                {
                    try
                    {

                        fileStream = new FileStream(fileName, FileMode.Open, FileAccess.ReadWrite);
                        if (fileName.IndexOf(".xlsx") > 0) // 2007版本 
                        {
                            workbook = new XSSFWorkbook(fileStream); //xlsx數據讀入workbook 
                        }
                        else if (fileName.IndexOf(".xls") > 0) // 2003版本 
                        {
                            workbook = new HSSFWorkbook(fileStream); //xls數據讀入workbook 
                        }
                        sheet = workbook.GetSheetAt(sheetnumber); //獲取第N個工作表 
                        excelfileexist = true;

                    }
                    catch
                    {
                        MessageBox.Show("Please close Excel file.", "Error");
                        excelfileexist = false;
                    }
                } while (excelfileexist == false);

            }
            public void SetCell(int iRow, int iCol, string value, CellType _celltype)
            {
                HSSFRow row;
                ICell cell = null;
                if (sheet.GetRow(iRow) != null)
                    row = (HSSFRow)sheet.GetRow(iRow);
                else
                {
                    //int ostatniWiersz = sheet.LastRowNum;
                    //row = (HSSFRow)sheet.CreateRow(ostatniWiersz + 1);//這樣會有問題
                    row = (HSSFRow)sheet.CreateRow(iRow);//add row
                }
                if (row != null)
                {
                    cell = row.GetCell(iCol);
                    if (cell == null)
                    {
                        cell = row.CreateCell(iCol, _celltype);//add cell
                    }
                    if (cell != null)
                    {
                        switch (cell.CellType)
                        {
                            case CellType.Numeric:  // 數值格式
                                cell.SetCellValue(double.Parse(value));
                                break;
                            case CellType.Formula:
                                cell.SetCellFormula(value);
                                break;
                            case CellType.String:   // 字串格式
                                cell.SetCellValue(value);
                                break;
                            default:
                                cell.SetCellValue(value);
                                break;
                        }
                        /*cell.SetCellType ( _celltype);//reset type不用reset也可以
                        if (_celltype == CellType.Numeric)
                            cell.SetCellValue(double.Parse(value));
                        else if (_celltype == CellType.Formula)
                            cell.SetCellFormula(value);
                        else
                            cell.SetCellValue(value);
                            */

                    }
                }
            }
            public void Clear(int ifromRow)
            {

                for (int i = (sheet.FirstRowNum + 0); i <= sheet.LastRowNum; i++)   //-- 每一列做迴圈
                {
                    HSSFRow row = (HSSFRow)sheet.GetRow(i);  //--不包含 Excel表頭列的 "其他資料列"

                    if (row != null)
                    {
                        if (i >= ifromRow)
                        {
                            for (int j = row.FirstCellNum; j < row.LastCellNum; j++)   //-- 每一個欄位做迴圈
                            {
                                SetCell(i, j, "", CellType.Blank);
                                //CellType.Blank);不會清空格式化的cell
                                //CellType.Formula);清空格式化的cell,也清不是格式化的
                            }
                        }
                    }
                }
            }
            public void SaveClose(string path)
            {
                FileStream fs = null;
                try
                {
                    sheet.ForceFormulaRecalculation = true;//更新公式的值 
                    fs = new FileStream(path, FileMode.Create);
                    workbook.Write(fs);
                    fs.Close();

                }
                catch (Exception ex)
                {
                    if (fs != null)
                    {
                        fs.Close();
                    }
                    throw ex;
                }
                finally
                {
                    fileStream.Close();
                }
            }

        }
        public class SetupIniIP
        {
            public string path;
            [DllImport("kernel32", CharSet = CharSet.Unicode)]
            private static extern long WritePrivateProfileString(string section,
            string key, string val, string filePath);
            [DllImport("kernel32", CharSet = CharSet.Unicode)]
            private static extern int GetPrivateProfileString(string section,
            string key, string def, StringBuilder retVal,
            int size, string filePath);
            public void IniWriteValue(string Section, string Key, string Value, string inipath)
            {
                WritePrivateProfileString(Section, Key, Value, Application.StartupPath + "\\" + inipath);
            }
            public string IniReadValue(string Section, string Key, string inipath)
            {
                StringBuilder temp = new StringBuilder(255);
                int i = GetPrivateProfileString(Section, Key, "", temp, 255, Application.StartupPath + "\\" + inipath);
                return temp.ToString();
            }
        }
    }
}
