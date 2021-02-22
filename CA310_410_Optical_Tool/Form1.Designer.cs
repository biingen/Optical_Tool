﻿namespace CA310_410_Optical_Tool
{
    partial class Form1
    {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージ リソースが破棄される場合 true、破棄されない場合は false です。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            this.ButtonCalZero = new System.Windows.Forms.Button();
            this.ButtonMeasure = new System.Windows.Forms.Button();
            this.ButtonCancel = new System.Windows.Forms.Button();
            this.Labelduv = new System.Windows.Forms.Label();
            this.LabelT = new System.Windows.Forms.Label();
            this.Labely = new System.Windows.Forms.Label();
            this.Labelx = new System.Windows.Forms.Label();
            this.LabelLv = new System.Windows.Forms.Label();
            this.Label5 = new System.Windows.Forms.Label();
            this.Label4 = new System.Windows.Forms.Label();
            this.Label3 = new System.Windows.Forms.Label();
            this.Label2 = new System.Windows.Forms.Label();
            this.Label1 = new System.Windows.Forms.Label();
            this.caControlWrapper1 = new CaControl.CaControlWrapper();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.No = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.x = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.y = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Lv = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.T = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.duv = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.button_clear = new System.Windows.Forms.Button();
            this.checkBox1_Red = new System.Windows.Forms.CheckBox();
            this.checkBox2_Green = new System.Windows.Forms.CheckBox();
            this.checkBox3_Blue = new System.Windows.Forms.CheckBox();
            this.checkBox4_White = new System.Windows.Forms.CheckBox();
            this.groupBox1_gamma = new System.Windows.Forms.GroupBox();
            this.button_2238gamma = new System.Windows.Forms.Button();
            this.label_colorstep = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.textBox_gammadelay = new System.Windows.Forms.TextBox();
            this.button_Gamma = new System.Windows.Forms.Button();
            this.button_gammapattern = new System.Windows.Forms.Button();
            this.button3_SaveCsv = new System.Windows.Forms.Button();
            this.groupBox1_measure = new System.Windows.Forms.GroupBox();
            this.button_connect = new System.Windows.Forms.Button();
            this.button_dsiconnect = new System.Windows.Forms.Button();
            this.button_410 = new System.Windows.Forms.Button();
            this.button_310 = new System.Windows.Forms.Button();
            this.label_mode = new System.Windows.Forms.Label();
            this.label_connect = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.comboBox_com = new System.Windows.Forms.ComboBox();
            this.button_SearchCOM = new System.Windows.Forms.Button();
            this.button_buttonOpenCloseCom = new System.Windows.Forms.Button();
            this.button_whitepattern = new System.Windows.Forms.Button();
            this.button_redpattern = new System.Windows.Forms.Button();
            this.button_greenpattern = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label_COMconnect = new System.Windows.Forms.Label();
            this.button_9point = new System.Windows.Forms.Button();
            this.button_blackpattern = new System.Windows.Forms.Button();
            this.button_bluepattern = new System.Windows.Forms.Button();
            this.button_LuminanceTest = new System.Windows.Forms.Button();
            this.button_LuminanceTest2 = new System.Windows.Forms.Button();
            this.button_ColorTemperature = new System.Windows.Forms.Button();
            this.button_ContrastRatio = new System.Windows.Forms.Button();
            this.button_deleteSource = new System.Windows.Forms.Button();
            this.comboBox_sourcelist = new System.Windows.Forms.ComboBox();
            this.button_addSource = new System.Windows.Forms.Button();
            this.button_addmode = new System.Windows.Forms.Button();
            this.comboBox_modelist = new System.Windows.Forms.ComboBox();
            this.button_deletemode = new System.Windows.Forms.Button();
            this.button_addCT = new System.Windows.Forms.Button();
            this.comboBox_CTlist = new System.Windows.Forms.ComboBox();
            this.button_deleteCT = new System.Windows.Forms.Button();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.button_DynamicContrasRatioTest = new System.Windows.Forms.Button();
            this.button_DimmingRange = new System.Windows.Forms.Button();
            this.button_colorGamut = new System.Windows.Forms.Button();
            this.button_lightSensor = new System.Windows.Forms.Button();
            this.button_Uniformity = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.groupBox1_gamma.SuspendLayout();
            this.groupBox1_measure.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.SuspendLayout();
            // 
            // ButtonCalZero
            // 
            this.ButtonCalZero.Font = new System.Drawing.Font("新細明體", 9F);
            this.ButtonCalZero.Location = new System.Drawing.Point(124, 88);
            this.ButtonCalZero.Name = "ButtonCalZero";
            this.ButtonCalZero.Size = new System.Drawing.Size(75, 23);
            this.ButtonCalZero.TabIndex = 38;
            this.ButtonCalZero.Text = "CalZero";
            this.ButtonCalZero.UseVisualStyleBackColor = true;
            this.ButtonCalZero.Click += new System.EventHandler(this.ButtonCalZero_Click);
            // 
            // ButtonMeasure
            // 
            this.ButtonMeasure.Font = new System.Drawing.Font("新細明體", 9F);
            this.ButtonMeasure.Location = new System.Drawing.Point(124, 19);
            this.ButtonMeasure.Name = "ButtonMeasure";
            this.ButtonMeasure.Size = new System.Drawing.Size(75, 23);
            this.ButtonMeasure.TabIndex = 37;
            this.ButtonMeasure.Text = "Measure";
            this.ButtonMeasure.UseVisualStyleBackColor = true;
            this.ButtonMeasure.Click += new System.EventHandler(this.ButtonMeasure_Click);
            // 
            // ButtonCancel
            // 
            this.ButtonCancel.Font = new System.Drawing.Font("新細明體", 9F);
            this.ButtonCancel.Location = new System.Drawing.Point(124, 53);
            this.ButtonCancel.Name = "ButtonCancel";
            this.ButtonCancel.Size = new System.Drawing.Size(75, 23);
            this.ButtonCancel.TabIndex = 36;
            this.ButtonCancel.Text = "Cancel";
            this.ButtonCancel.UseVisualStyleBackColor = true;
            this.ButtonCancel.Click += new System.EventHandler(this.ButtonCancel_Click);
            // 
            // Labelduv
            // 
            this.Labelduv.AutoSize = true;
            this.Labelduv.Font = new System.Drawing.Font("新細明體", 9F);
            this.Labelduv.Location = new System.Drawing.Point(43, 101);
            this.Labelduv.Name = "Labelduv";
            this.Labelduv.Size = new System.Drawing.Size(38, 12);
            this.Labelduv.TabIndex = 35;
            this.Labelduv.Text = "0.0000";
            // 
            // LabelT
            // 
            this.LabelT.AutoSize = true;
            this.LabelT.Font = new System.Drawing.Font("新細明體", 9F);
            this.LabelT.Location = new System.Drawing.Point(43, 81);
            this.LabelT.Name = "LabelT";
            this.LabelT.Size = new System.Drawing.Size(38, 12);
            this.LabelT.TabIndex = 34;
            this.LabelT.Text = "0.0000";
            // 
            // Labely
            // 
            this.Labely.AutoSize = true;
            this.Labely.Font = new System.Drawing.Font("新細明體", 9F);
            this.Labely.Location = new System.Drawing.Point(43, 39);
            this.Labely.Name = "Labely";
            this.Labely.Size = new System.Drawing.Size(38, 12);
            this.Labely.TabIndex = 33;
            this.Labely.Text = "0.0000";
            // 
            // Labelx
            // 
            this.Labelx.AutoSize = true;
            this.Labelx.Font = new System.Drawing.Font("新細明體", 9F);
            this.Labelx.Location = new System.Drawing.Point(43, 18);
            this.Labelx.Name = "Labelx";
            this.Labelx.Size = new System.Drawing.Size(38, 12);
            this.Labelx.TabIndex = 32;
            this.Labelx.Text = "0.0000";
            // 
            // LabelLv
            // 
            this.LabelLv.AutoSize = true;
            this.LabelLv.Font = new System.Drawing.Font("新細明體", 9F);
            this.LabelLv.Location = new System.Drawing.Point(43, 60);
            this.LabelLv.Name = "LabelLv";
            this.LabelLv.Size = new System.Drawing.Size(38, 12);
            this.LabelLv.TabIndex = 31;
            this.LabelLv.Text = "0.0000";
            // 
            // Label5
            // 
            this.Label5.AutoSize = true;
            this.Label5.Font = new System.Drawing.Font("新細明體", 9F);
            this.Label5.Location = new System.Drawing.Point(8, 101);
            this.Label5.Name = "Label5";
            this.Label5.Size = new System.Drawing.Size(26, 12);
            this.Label5.TabIndex = 30;
            this.Label5.Text = "duv:";
            // 
            // Label4
            // 
            this.Label4.AutoSize = true;
            this.Label4.Font = new System.Drawing.Font("新細明體", 9F);
            this.Label4.Location = new System.Drawing.Point(8, 81);
            this.Label4.Name = "Label4";
            this.Label4.Size = new System.Drawing.Size(15, 12);
            this.Label4.TabIndex = 29;
            this.Label4.Text = "T:";
            // 
            // Label3
            // 
            this.Label3.AutoSize = true;
            this.Label3.Font = new System.Drawing.Font("新細明體", 9F);
            this.Label3.Location = new System.Drawing.Point(8, 39);
            this.Label3.Name = "Label3";
            this.Label3.Size = new System.Drawing.Size(14, 12);
            this.Label3.TabIndex = 28;
            this.Label3.Text = "y:";
            // 
            // Label2
            // 
            this.Label2.AutoSize = true;
            this.Label2.Font = new System.Drawing.Font("新細明體", 9F);
            this.Label2.Location = new System.Drawing.Point(8, 18);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(14, 12);
            this.Label2.TabIndex = 27;
            this.Label2.Text = "x:";
            // 
            // Label1
            // 
            this.Label1.AutoSize = true;
            this.Label1.Font = new System.Drawing.Font("新細明體", 9F);
            this.Label1.Location = new System.Drawing.Point(8, 60);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(21, 12);
            this.Label1.TabIndex = 26;
            this.Label1.Text = "Lv:";
            // 
            // caControlWrapper1
            // 
            this.caControlWrapper1.Location = new System.Drawing.Point(232, 14);
            this.caControlWrapper1.Name = "caControlWrapper1";
            this.caControlWrapper1.Size = new System.Drawing.Size(207, 64);
            this.caControlWrapper1.TabIndex = 40;
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.No,
            this.x,
            this.y,
            this.Lv,
            this.T,
            this.duv});
            this.dataGridView1.Location = new System.Drawing.Point(12, 256);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(427, 177);
            this.dataGridView1.TabIndex = 49;
            // 
            // No
            // 
            this.No.FillWeight = 30F;
            this.No.HeaderText = "No.";
            this.No.Name = "No";
            this.No.Width = 50;
            // 
            // x
            // 
            this.x.FillWeight = 130F;
            this.x.HeaderText = "x";
            this.x.Name = "x";
            this.x.Width = 65;
            // 
            // y
            // 
            this.y.FillWeight = 130F;
            this.y.HeaderText = "y";
            this.y.Name = "y";
            this.y.Width = 65;
            // 
            // Lv
            // 
            this.Lv.FillWeight = 130F;
            this.Lv.HeaderText = "Lv";
            this.Lv.Name = "Lv";
            this.Lv.Width = 65;
            // 
            // T
            // 
            this.T.FillWeight = 130F;
            this.T.HeaderText = "T";
            this.T.Name = "T";
            this.T.Width = 65;
            // 
            // duv
            // 
            this.duv.FillWeight = 130F;
            this.duv.HeaderText = "duv";
            this.duv.Name = "duv";
            this.duv.Width = 65;
            // 
            // button_clear
            // 
            this.button_clear.Location = new System.Drawing.Point(364, 439);
            this.button_clear.Name = "button_clear";
            this.button_clear.Size = new System.Drawing.Size(75, 23);
            this.button_clear.TabIndex = 50;
            this.button_clear.Text = "clear";
            this.button_clear.UseVisualStyleBackColor = true;
            this.button_clear.Click += new System.EventHandler(this.button_clear_Click);
            // 
            // checkBox1_Red
            // 
            this.checkBox1_Red.AutoSize = true;
            this.checkBox1_Red.Font = new System.Drawing.Font("新細明體", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.checkBox1_Red.Location = new System.Drawing.Point(11, 17);
            this.checkBox1_Red.Name = "checkBox1_Red";
            this.checkBox1_Red.Size = new System.Drawing.Size(43, 16);
            this.checkBox1_Red.TabIndex = 53;
            this.checkBox1_Red.Text = "Red";
            this.checkBox1_Red.UseVisualStyleBackColor = true;
            // 
            // checkBox2_Green
            // 
            this.checkBox2_Green.AutoSize = true;
            this.checkBox2_Green.Font = new System.Drawing.Font("新細明體", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.checkBox2_Green.Location = new System.Drawing.Point(11, 38);
            this.checkBox2_Green.Name = "checkBox2_Green";
            this.checkBox2_Green.Size = new System.Drawing.Size(52, 16);
            this.checkBox2_Green.TabIndex = 54;
            this.checkBox2_Green.Text = "Green";
            this.checkBox2_Green.UseVisualStyleBackColor = true;
            // 
            // checkBox3_Blue
            // 
            this.checkBox3_Blue.AutoSize = true;
            this.checkBox3_Blue.Font = new System.Drawing.Font("新細明體", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.checkBox3_Blue.Location = new System.Drawing.Point(11, 60);
            this.checkBox3_Blue.Name = "checkBox3_Blue";
            this.checkBox3_Blue.Size = new System.Drawing.Size(46, 16);
            this.checkBox3_Blue.TabIndex = 55;
            this.checkBox3_Blue.Text = "Blue";
            this.checkBox3_Blue.UseVisualStyleBackColor = true;
            // 
            // checkBox4_White
            // 
            this.checkBox4_White.AutoSize = true;
            this.checkBox4_White.Font = new System.Drawing.Font("新細明體", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.checkBox4_White.Location = new System.Drawing.Point(11, 82);
            this.checkBox4_White.Name = "checkBox4_White";
            this.checkBox4_White.Size = new System.Drawing.Size(52, 16);
            this.checkBox4_White.TabIndex = 56;
            this.checkBox4_White.Text = "White";
            this.checkBox4_White.UseVisualStyleBackColor = true;
            // 
            // groupBox1_gamma
            // 
            this.groupBox1_gamma.Controls.Add(this.button_2238gamma);
            this.groupBox1_gamma.Controls.Add(this.label_colorstep);
            this.groupBox1_gamma.Controls.Add(this.label6);
            this.groupBox1_gamma.Controls.Add(this.textBox_gammadelay);
            this.groupBox1_gamma.Controls.Add(this.button_Gamma);
            this.groupBox1_gamma.Controls.Add(this.button_gammapattern);
            this.groupBox1_gamma.Controls.Add(this.checkBox4_White);
            this.groupBox1_gamma.Controls.Add(this.checkBox3_Blue);
            this.groupBox1_gamma.Controls.Add(this.checkBox1_Red);
            this.groupBox1_gamma.Controls.Add(this.checkBox2_Green);
            this.groupBox1_gamma.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.groupBox1_gamma.Location = new System.Drawing.Point(238, 83);
            this.groupBox1_gamma.Name = "groupBox1_gamma";
            this.groupBox1_gamma.Size = new System.Drawing.Size(201, 167);
            this.groupBox1_gamma.TabIndex = 57;
            this.groupBox1_gamma.TabStop = false;
            this.groupBox1_gamma.Text = "Gamma";
            // 
            // button_2238gamma
            // 
            this.button_2238gamma.Enabled = false;
            this.button_2238gamma.Font = new System.Drawing.Font("新細明體", 9F);
            this.button_2238gamma.Location = new System.Drawing.Point(115, 75);
            this.button_2238gamma.Name = "button_2238gamma";
            this.button_2238gamma.Size = new System.Drawing.Size(75, 23);
            this.button_2238gamma.TabIndex = 83;
            this.button_2238gamma.Text = "Chroma Start";
            this.button_2238gamma.UseVisualStyleBackColor = true;
            this.button_2238gamma.Click += new System.EventHandler(this.button_2238gamma_Click);
            // 
            // label_colorstep
            // 
            this.label_colorstep.AutoSize = true;
            this.label_colorstep.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label_colorstep.Location = new System.Drawing.Point(11, 138);
            this.label_colorstep.Name = "label_colorstep";
            this.label_colorstep.Size = new System.Drawing.Size(66, 16);
            this.label_colorstep.TabIndex = 68;
            this.label_colorstep.Text = "Test Stop";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("新細明體", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label6.Location = new System.Drawing.Point(12, 110);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(80, 12);
            this.label6.TabIndex = 67;
            this.label6.Text = "Delay Time(ms)";
            // 
            // textBox_gammadelay
            // 
            this.textBox_gammadelay.Font = new System.Drawing.Font("新細明體", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.textBox_gammadelay.Location = new System.Drawing.Point(115, 107);
            this.textBox_gammadelay.Name = "textBox_gammadelay";
            this.textBox_gammadelay.Size = new System.Drawing.Size(74, 22);
            this.textBox_gammadelay.TabIndex = 66;
            this.textBox_gammadelay.Text = "300";
            // 
            // button_Gamma
            // 
            this.button_Gamma.Font = new System.Drawing.Font("新細明體", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.button_Gamma.Location = new System.Drawing.Point(115, 46);
            this.button_Gamma.Name = "button_Gamma";
            this.button_Gamma.Size = new System.Drawing.Size(75, 23);
            this.button_Gamma.TabIndex = 65;
            this.button_Gamma.Text = "Pattern Start";
            this.button_Gamma.UseVisualStyleBackColor = true;
            this.button_Gamma.Click += new System.EventHandler(this.button_Gamma_Click);
            // 
            // button_gammapattern
            // 
            this.button_gammapattern.Font = new System.Drawing.Font("新細明體", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.button_gammapattern.Location = new System.Drawing.Point(115, 17);
            this.button_gammapattern.Name = "button_gammapattern";
            this.button_gammapattern.Size = new System.Drawing.Size(75, 23);
            this.button_gammapattern.TabIndex = 57;
            this.button_gammapattern.Text = "Open Pattern";
            this.button_gammapattern.UseVisualStyleBackColor = true;
            this.button_gammapattern.Click += new System.EventHandler(this.button_gammapattern_Click);
            // 
            // button3_SaveCsv
            // 
            this.button3_SaveCsv.Location = new System.Drawing.Point(283, 439);
            this.button3_SaveCsv.Name = "button3_SaveCsv";
            this.button3_SaveCsv.Size = new System.Drawing.Size(75, 23);
            this.button3_SaveCsv.TabIndex = 57;
            this.button3_SaveCsv.Text = "SaveCSV";
            this.button3_SaveCsv.UseVisualStyleBackColor = true;
            this.button3_SaveCsv.Click += new System.EventHandler(this.button_SaveCsv_Click);
            // 
            // groupBox1_measure
            // 
            this.groupBox1_measure.Controls.Add(this.LabelLv);
            this.groupBox1_measure.Controls.Add(this.Label1);
            this.groupBox1_measure.Controls.Add(this.Label2);
            this.groupBox1_measure.Controls.Add(this.Label3);
            this.groupBox1_measure.Controls.Add(this.Label4);
            this.groupBox1_measure.Controls.Add(this.Label5);
            this.groupBox1_measure.Controls.Add(this.Labelx);
            this.groupBox1_measure.Controls.Add(this.Labely);
            this.groupBox1_measure.Controls.Add(this.LabelT);
            this.groupBox1_measure.Controls.Add(this.ButtonCancel);
            this.groupBox1_measure.Controls.Add(this.Labelduv);
            this.groupBox1_measure.Controls.Add(this.ButtonMeasure);
            this.groupBox1_measure.Controls.Add(this.ButtonCalZero);
            this.groupBox1_measure.Font = new System.Drawing.Font("新細明體", 12F);
            this.groupBox1_measure.Location = new System.Drawing.Point(14, 127);
            this.groupBox1_measure.Name = "groupBox1_measure";
            this.groupBox1_measure.Size = new System.Drawing.Size(206, 123);
            this.groupBox1_measure.TabIndex = 61;
            this.groupBox1_measure.TabStop = false;
            this.groupBox1_measure.Text = "Measure";
            // 
            // button_connect
            // 
            this.button_connect.Enabled = false;
            this.button_connect.Location = new System.Drawing.Point(8, 14);
            this.button_connect.Name = "button_connect";
            this.button_connect.Size = new System.Drawing.Size(85, 23);
            this.button_connect.TabIndex = 63;
            this.button_connect.Text = "Connect";
            this.button_connect.UseVisualStyleBackColor = true;
            this.button_connect.Click += new System.EventHandler(this.button_connect_Click);
            // 
            // button_dsiconnect
            // 
            this.button_dsiconnect.Location = new System.Drawing.Point(113, 15);
            this.button_dsiconnect.Name = "button_dsiconnect";
            this.button_dsiconnect.Size = new System.Drawing.Size(85, 23);
            this.button_dsiconnect.TabIndex = 64;
            this.button_dsiconnect.Text = "Disconncet";
            this.button_dsiconnect.UseVisualStyleBackColor = true;
            this.button_dsiconnect.Click += new System.EventHandler(this.button_dsiconnect_Click);
            // 
            // button_410
            // 
            this.button_410.Location = new System.Drawing.Point(113, 13);
            this.button_410.Name = "button_410";
            this.button_410.Size = new System.Drawing.Size(85, 23);
            this.button_410.TabIndex = 65;
            this.button_410.Text = "CA-410";
            this.button_410.UseVisualStyleBackColor = true;
            this.button_410.Click += new System.EventHandler(this.button_410_Click);
            // 
            // button_310
            // 
            this.button_310.Location = new System.Drawing.Point(8, 13);
            this.button_310.Name = "button_310";
            this.button_310.Size = new System.Drawing.Size(85, 23);
            this.button_310.TabIndex = 66;
            this.button_310.Text = "CA-310";
            this.button_310.UseVisualStyleBackColor = true;
            this.button_310.Click += new System.EventHandler(this.button_310_Click);
            // 
            // label_mode
            // 
            this.label_mode.AutoSize = true;
            this.label_mode.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label_mode.Location = new System.Drawing.Point(46, 38);
            this.label_mode.Name = "label_mode";
            this.label_mode.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.label_mode.Size = new System.Drawing.Size(115, 16);
            this.label_mode.TabIndex = 67;
            this.label_mode.Text = "Select instrument";
            this.label_mode.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label_connect
            // 
            this.label_connect.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label_connect.AutoSize = true;
            this.label_connect.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label_connect.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label_connect.Location = new System.Drawing.Point(61, 40);
            this.label_connect.Name = "label_connect";
            this.label_connect.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.label_connect.Size = new System.Drawing.Size(87, 16);
            this.label_connect.TabIndex = 68;
            this.label_connect.Text = "Not Connect";
            this.label_connect.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.button_410);
            this.groupBox1.Controls.Add(this.label_mode);
            this.groupBox1.Controls.Add(this.button_310);
            this.groupBox1.Location = new System.Drawing.Point(14, 1);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(206, 61);
            this.groupBox1.TabIndex = 69;
            this.groupBox1.TabStop = false;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.button_dsiconnect);
            this.groupBox2.Controls.Add(this.label_connect);
            this.groupBox2.Controls.Add(this.button_connect);
            this.groupBox2.Location = new System.Drawing.Point(14, 64);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(206, 61);
            this.groupBox2.TabIndex = 70;
            this.groupBox2.TabStop = false;
            // 
            // comboBox_com
            // 
            this.comboBox_com.Font = new System.Drawing.Font("新細明體", 9F);
            this.comboBox_com.FormattingEnabled = true;
            this.comboBox_com.Location = new System.Drawing.Point(7, 20);
            this.comboBox_com.Name = "comboBox_com";
            this.comboBox_com.Size = new System.Drawing.Size(121, 20);
            this.comboBox_com.TabIndex = 72;
            // 
            // button_SearchCOM
            // 
            this.button_SearchCOM.Font = new System.Drawing.Font("新細明體", 9F);
            this.button_SearchCOM.Location = new System.Drawing.Point(135, 19);
            this.button_SearchCOM.Name = "button_SearchCOM";
            this.button_SearchCOM.Size = new System.Drawing.Size(75, 23);
            this.button_SearchCOM.TabIndex = 74;
            this.button_SearchCOM.Text = "Search COM";
            this.button_SearchCOM.UseVisualStyleBackColor = true;
            this.button_SearchCOM.Click += new System.EventHandler(this.button_SearchCOM_Click);
            // 
            // button_buttonOpenCloseCom
            // 
            this.button_buttonOpenCloseCom.Font = new System.Drawing.Font("新細明體", 9F);
            this.button_buttonOpenCloseCom.Location = new System.Drawing.Point(6, 46);
            this.button_buttonOpenCloseCom.Name = "button_buttonOpenCloseCom";
            this.button_buttonOpenCloseCom.Size = new System.Drawing.Size(97, 23);
            this.button_buttonOpenCloseCom.TabIndex = 76;
            this.button_buttonOpenCloseCom.Text = "Connect COM";
            this.button_buttonOpenCloseCom.UseVisualStyleBackColor = true;
            this.button_buttonOpenCloseCom.Click += new System.EventHandler(this.button_buttonOpenCloseCom_Click);
            // 
            // button_whitepattern
            // 
            this.button_whitepattern.Enabled = false;
            this.button_whitepattern.Font = new System.Drawing.Font("新細明體", 9F);
            this.button_whitepattern.Location = new System.Drawing.Point(6, 78);
            this.button_whitepattern.Name = "button_whitepattern";
            this.button_whitepattern.Size = new System.Drawing.Size(75, 23);
            this.button_whitepattern.TabIndex = 77;
            this.button_whitepattern.Text = "White";
            this.button_whitepattern.UseVisualStyleBackColor = true;
            this.button_whitepattern.Click += new System.EventHandler(this.button_whitepattern_Click);
            // 
            // button_redpattern
            // 
            this.button_redpattern.Enabled = false;
            this.button_redpattern.Font = new System.Drawing.Font("新細明體", 9F);
            this.button_redpattern.Location = new System.Drawing.Point(6, 113);
            this.button_redpattern.Name = "button_redpattern";
            this.button_redpattern.Size = new System.Drawing.Size(75, 23);
            this.button_redpattern.TabIndex = 78;
            this.button_redpattern.Text = "Red";
            this.button_redpattern.UseVisualStyleBackColor = true;
            this.button_redpattern.Click += new System.EventHandler(this.button_redpattern_Click);
            // 
            // button_greenpattern
            // 
            this.button_greenpattern.Enabled = false;
            this.button_greenpattern.Font = new System.Drawing.Font("新細明體", 9F);
            this.button_greenpattern.Location = new System.Drawing.Point(87, 113);
            this.button_greenpattern.Name = "button_greenpattern";
            this.button_greenpattern.Size = new System.Drawing.Size(75, 23);
            this.button_greenpattern.TabIndex = 79;
            this.button_greenpattern.Text = "Green";
            this.button_greenpattern.UseVisualStyleBackColor = true;
            this.button_greenpattern.Click += new System.EventHandler(this.button_greenpattern_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label_COMconnect);
            this.groupBox3.Controls.Add(this.button_9point);
            this.groupBox3.Controls.Add(this.button_blackpattern);
            this.groupBox3.Controls.Add(this.button_bluepattern);
            this.groupBox3.Controls.Add(this.button_buttonOpenCloseCom);
            this.groupBox3.Controls.Add(this.button_greenpattern);
            this.groupBox3.Controls.Add(this.comboBox_com);
            this.groupBox3.Controls.Add(this.button_redpattern);
            this.groupBox3.Controls.Add(this.button_whitepattern);
            this.groupBox3.Controls.Add(this.button_SearchCOM);
            this.groupBox3.Font = new System.Drawing.Font("新細明體", 12F);
            this.groupBox3.Location = new System.Drawing.Point(452, 5);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(257, 151);
            this.groupBox3.TabIndex = 80;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Chroma 2238";
            // 
            // label_COMconnect
            // 
            this.label_COMconnect.AutoSize = true;
            this.label_COMconnect.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label_COMconnect.Location = new System.Drawing.Point(112, 50);
            this.label_COMconnect.Name = "label_COMconnect";
            this.label_COMconnect.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.label_COMconnect.Size = new System.Drawing.Size(123, 16);
            this.label_COMconnect.TabIndex = 68;
            this.label_COMconnect.Text = "Please Open COM";
            this.label_COMconnect.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // button_9point
            // 
            this.button_9point.Enabled = false;
            this.button_9point.Font = new System.Drawing.Font("新細明體", 9F);
            this.button_9point.Location = new System.Drawing.Point(168, 78);
            this.button_9point.Name = "button_9point";
            this.button_9point.Size = new System.Drawing.Size(75, 23);
            this.button_9point.TabIndex = 82;
            this.button_9point.Text = "9_point";
            this.button_9point.UseVisualStyleBackColor = true;
            this.button_9point.Click += new System.EventHandler(this.button_9point_Click);
            // 
            // button_blackpattern
            // 
            this.button_blackpattern.Enabled = false;
            this.button_blackpattern.Font = new System.Drawing.Font("新細明體", 9F);
            this.button_blackpattern.Location = new System.Drawing.Point(87, 78);
            this.button_blackpattern.Name = "button_blackpattern";
            this.button_blackpattern.Size = new System.Drawing.Size(75, 23);
            this.button_blackpattern.TabIndex = 81;
            this.button_blackpattern.Text = "Black";
            this.button_blackpattern.UseVisualStyleBackColor = true;
            this.button_blackpattern.Click += new System.EventHandler(this.button_blackpattern_Click);
            // 
            // button_bluepattern
            // 
            this.button_bluepattern.Enabled = false;
            this.button_bluepattern.Font = new System.Drawing.Font("新細明體", 9F);
            this.button_bluepattern.Location = new System.Drawing.Point(168, 113);
            this.button_bluepattern.Name = "button_bluepattern";
            this.button_bluepattern.Size = new System.Drawing.Size(75, 23);
            this.button_bluepattern.TabIndex = 80;
            this.button_bluepattern.Text = "Blue";
            this.button_bluepattern.UseVisualStyleBackColor = true;
            this.button_bluepattern.Click += new System.EventHandler(this.button_bluepattern_Click);
            // 
            // button_LuminanceTest
            // 
            this.button_LuminanceTest.Font = new System.Drawing.Font("新細明體", 9F);
            this.button_LuminanceTest.Location = new System.Drawing.Point(14, 21);
            this.button_LuminanceTest.Name = "button_LuminanceTest";
            this.button_LuminanceTest.Size = new System.Drawing.Size(89, 23);
            this.button_LuminanceTest.TabIndex = 82;
            this.button_LuminanceTest.Text = "1.1 Lum P1";
            this.button_LuminanceTest.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button_LuminanceTest.UseVisualStyleBackColor = true;
            this.button_LuminanceTest.Click += new System.EventHandler(this.button_LuminanceTest_Click);
            // 
            // button_LuminanceTest2
            // 
            this.button_LuminanceTest2.Font = new System.Drawing.Font("新細明體", 9F);
            this.button_LuminanceTest2.Location = new System.Drawing.Point(14, 53);
            this.button_LuminanceTest2.Name = "button_LuminanceTest2";
            this.button_LuminanceTest2.Size = new System.Drawing.Size(89, 23);
            this.button_LuminanceTest2.TabIndex = 83;
            this.button_LuminanceTest2.Text = "1.1 Lum P2";
            this.button_LuminanceTest2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button_LuminanceTest2.UseVisualStyleBackColor = true;
            this.button_LuminanceTest2.Click += new System.EventHandler(this.button_LuminanceTest2_Click);
            // 
            // button_ColorTemperature
            // 
            this.button_ColorTemperature.Font = new System.Drawing.Font("新細明體", 9F);
            this.button_ColorTemperature.Location = new System.Drawing.Point(14, 84);
            this.button_ColorTemperature.Name = "button_ColorTemperature";
            this.button_ColorTemperature.Size = new System.Drawing.Size(89, 23);
            this.button_ColorTemperature.TabIndex = 86;
            this.button_ColorTemperature.Text = "1.2 C/T Test";
            this.button_ColorTemperature.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button_ColorTemperature.UseVisualStyleBackColor = true;
            this.button_ColorTemperature.Click += new System.EventHandler(this.button_ColorTemperature_Click);
            // 
            // button_ContrastRatio
            // 
            this.button_ContrastRatio.Font = new System.Drawing.Font("新細明體", 9F);
            this.button_ContrastRatio.Location = new System.Drawing.Point(14, 115);
            this.button_ContrastRatio.Name = "button_ContrastRatio";
            this.button_ContrastRatio.Size = new System.Drawing.Size(89, 23);
            this.button_ContrastRatio.TabIndex = 89;
            this.button_ContrastRatio.Text = "1.3 Contrast Ratio Test";
            this.button_ContrastRatio.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button_ContrastRatio.UseVisualStyleBackColor = true;
            this.button_ContrastRatio.Click += new System.EventHandler(this.button_ContrastRatio_Click);
            // 
            // button_deleteSource
            // 
            this.button_deleteSource.Font = new System.Drawing.Font("新細明體", 9F);
            this.button_deleteSource.Location = new System.Drawing.Point(69, 68);
            this.button_deleteSource.Name = "button_deleteSource";
            this.button_deleteSource.Size = new System.Drawing.Size(59, 23);
            this.button_deleteSource.TabIndex = 94;
            this.button_deleteSource.Text = "Delete";
            this.button_deleteSource.UseVisualStyleBackColor = true;
            this.button_deleteSource.Click += new System.EventHandler(this.button1_Click);
            // 
            // comboBox_sourcelist
            // 
            this.comboBox_sourcelist.Font = new System.Drawing.Font("新細明體", 9F);
            this.comboBox_sourcelist.FormattingEnabled = true;
            this.comboBox_sourcelist.Location = new System.Drawing.Point(7, 42);
            this.comboBox_sourcelist.Name = "comboBox_sourcelist";
            this.comboBox_sourcelist.Size = new System.Drawing.Size(121, 20);
            this.comboBox_sourcelist.TabIndex = 97;
            // 
            // button_addSource
            // 
            this.button_addSource.Font = new System.Drawing.Font("新細明體", 9F);
            this.button_addSource.Location = new System.Drawing.Point(8, 68);
            this.button_addSource.Name = "button_addSource";
            this.button_addSource.Size = new System.Drawing.Size(59, 23);
            this.button_addSource.TabIndex = 98;
            this.button_addSource.Text = "Add";
            this.button_addSource.UseVisualStyleBackColor = true;
            this.button_addSource.Click += new System.EventHandler(this.button_addSource_Click);
            // 
            // button_addmode
            // 
            this.button_addmode.Font = new System.Drawing.Font("新細明體", 9F);
            this.button_addmode.Location = new System.Drawing.Point(8, 146);
            this.button_addmode.Name = "button_addmode";
            this.button_addmode.Size = new System.Drawing.Size(59, 23);
            this.button_addmode.TabIndex = 101;
            this.button_addmode.Text = "Add";
            this.button_addmode.UseVisualStyleBackColor = true;
            this.button_addmode.Click += new System.EventHandler(this.button_addmode_Click);
            // 
            // comboBox_modelist
            // 
            this.comboBox_modelist.Font = new System.Drawing.Font("新細明體", 9F);
            this.comboBox_modelist.FormattingEnabled = true;
            this.comboBox_modelist.Location = new System.Drawing.Point(7, 120);
            this.comboBox_modelist.Name = "comboBox_modelist";
            this.comboBox_modelist.Size = new System.Drawing.Size(121, 20);
            this.comboBox_modelist.TabIndex = 100;
            // 
            // button_deletemode
            // 
            this.button_deletemode.Font = new System.Drawing.Font("新細明體", 9F);
            this.button_deletemode.Location = new System.Drawing.Point(69, 146);
            this.button_deletemode.Name = "button_deletemode";
            this.button_deletemode.Size = new System.Drawing.Size(59, 23);
            this.button_deletemode.TabIndex = 99;
            this.button_deletemode.Text = "Delete";
            this.button_deletemode.UseVisualStyleBackColor = true;
            this.button_deletemode.Click += new System.EventHandler(this.button_deletemode_Click);
            // 
            // button_addCT
            // 
            this.button_addCT.Font = new System.Drawing.Font("新細明體", 9F);
            this.button_addCT.Location = new System.Drawing.Point(6, 232);
            this.button_addCT.Name = "button_addCT";
            this.button_addCT.Size = new System.Drawing.Size(59, 23);
            this.button_addCT.TabIndex = 104;
            this.button_addCT.Text = "Add";
            this.button_addCT.UseVisualStyleBackColor = true;
            this.button_addCT.Click += new System.EventHandler(this.button_addCT_Click);
            // 
            // comboBox_CTlist
            // 
            this.comboBox_CTlist.Font = new System.Drawing.Font("新細明體", 9F);
            this.comboBox_CTlist.FormattingEnabled = true;
            this.comboBox_CTlist.Location = new System.Drawing.Point(5, 206);
            this.comboBox_CTlist.Name = "comboBox_CTlist";
            this.comboBox_CTlist.Size = new System.Drawing.Size(121, 20);
            this.comboBox_CTlist.TabIndex = 103;
            // 
            // button_deleteCT
            // 
            this.button_deleteCT.Font = new System.Drawing.Font("新細明體", 9F);
            this.button_deleteCT.Location = new System.Drawing.Point(67, 232);
            this.button_deleteCT.Name = "button_deleteCT";
            this.button_deleteCT.Size = new System.Drawing.Size(59, 23);
            this.button_deleteCT.TabIndex = 102;
            this.button_deleteCT.Text = "Delete";
            this.button_deleteCT.UseVisualStyleBackColor = true;
            this.button_deleteCT.Click += new System.EventHandler(this.button_deleteCT_Click);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.label9);
            this.groupBox4.Controls.Add(this.label8);
            this.groupBox4.Controls.Add(this.label7);
            this.groupBox4.Controls.Add(this.comboBox_sourcelist);
            this.groupBox4.Controls.Add(this.button_addCT);
            this.groupBox4.Controls.Add(this.button_deleteSource);
            this.groupBox4.Controls.Add(this.comboBox_CTlist);
            this.groupBox4.Controls.Add(this.button_addSource);
            this.groupBox4.Controls.Add(this.button_deleteCT);
            this.groupBox4.Controls.Add(this.button_deletemode);
            this.groupBox4.Controls.Add(this.button_addmode);
            this.groupBox4.Controls.Add(this.comboBox_modelist);
            this.groupBox4.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.groupBox4.Location = new System.Drawing.Point(452, 166);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(134, 296);
            this.groupBox4.TabIndex = 105;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Setting";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("新細明體", 9F);
            this.label9.Location = new System.Drawing.Point(6, 189);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(94, 12);
            this.label9.TabIndex = 108;
            this.label9.Text = "Color Temperature";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("新細明體", 9F);
            this.label8.Location = new System.Drawing.Point(6, 105);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(67, 12);
            this.label8.TabIndex = 107;
            this.label8.Text = "Picture Mode";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("新細明體", 9F);
            this.label7.Location = new System.Drawing.Point(6, 27);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(37, 12);
            this.label7.TabIndex = 106;
            this.label7.Text = "Source";
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.button_DynamicContrasRatioTest);
            this.groupBox5.Controls.Add(this.button_DimmingRange);
            this.groupBox5.Controls.Add(this.button_colorGamut);
            this.groupBox5.Controls.Add(this.button_lightSensor);
            this.groupBox5.Controls.Add(this.button_Uniformity);
            this.groupBox5.Controls.Add(this.button_LuminanceTest);
            this.groupBox5.Controls.Add(this.button_LuminanceTest2);
            this.groupBox5.Controls.Add(this.button_ContrastRatio);
            this.groupBox5.Controls.Add(this.button_ColorTemperature);
            this.groupBox5.Font = new System.Drawing.Font("新細明體", 12F);
            this.groupBox5.Location = new System.Drawing.Point(592, 166);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(117, 296);
            this.groupBox5.TabIndex = 106;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Test Case";
            // 
            // button_DynamicContrasRatioTest
            // 
            this.button_DynamicContrasRatioTest.Enabled = false;
            this.button_DynamicContrasRatioTest.Font = new System.Drawing.Font("新細明體", 9F);
            this.button_DynamicContrasRatioTest.Location = new System.Drawing.Point(14, 266);
            this.button_DynamicContrasRatioTest.Name = "button_DynamicContrasRatioTest";
            this.button_DynamicContrasRatioTest.Size = new System.Drawing.Size(89, 23);
            this.button_DynamicContrasRatioTest.TabIndex = 94;
            this.button_DynamicContrasRatioTest.Text = "1.11 DCR Test";
            this.button_DynamicContrasRatioTest.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button_DynamicContrasRatioTest.UseVisualStyleBackColor = true;
            this.button_DynamicContrasRatioTest.Click += new System.EventHandler(this.button_DynamicContrasRatioTest_Click);
            // 
            // button_DimmingRange
            // 
            this.button_DimmingRange.Font = new System.Drawing.Font("新細明體", 9F);
            this.button_DimmingRange.Location = new System.Drawing.Point(14, 237);
            this.button_DimmingRange.Name = "button_DimmingRange";
            this.button_DimmingRange.Size = new System.Drawing.Size(89, 23);
            this.button_DimmingRange.TabIndex = 93;
            this.button_DimmingRange.Text = "1.10 Dimming";
            this.button_DimmingRange.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button_DimmingRange.UseVisualStyleBackColor = true;
            this.button_DimmingRange.Click += new System.EventHandler(this.button_DimmingRange_Click);
            // 
            // button_colorGamut
            // 
            this.button_colorGamut.Font = new System.Drawing.Font("新細明體", 9F);
            this.button_colorGamut.Location = new System.Drawing.Point(14, 208);
            this.button_colorGamut.Name = "button_colorGamut";
            this.button_colorGamut.Size = new System.Drawing.Size(89, 23);
            this.button_colorGamut.TabIndex = 92;
            this.button_colorGamut.Text = "1.8 ColorGamut";
            this.button_colorGamut.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button_colorGamut.UseVisualStyleBackColor = true;
            this.button_colorGamut.Click += new System.EventHandler(this.button_colorGamut_Click);
            // 
            // button_lightSensor
            // 
            this.button_lightSensor.Enabled = false;
            this.button_lightSensor.Font = new System.Drawing.Font("新細明體", 9F);
            this.button_lightSensor.Location = new System.Drawing.Point(14, 177);
            this.button_lightSensor.Name = "button_lightSensor";
            this.button_lightSensor.Size = new System.Drawing.Size(89, 23);
            this.button_lightSensor.TabIndex = 91;
            this.button_lightSensor.Text = "1.7 LightSensor";
            this.button_lightSensor.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button_lightSensor.UseVisualStyleBackColor = true;
            this.button_lightSensor.Click += new System.EventHandler(this.button_lightSensor_Click);
            // 
            // button_Uniformity
            // 
            this.button_Uniformity.Font = new System.Drawing.Font("新細明體", 9F);
            this.button_Uniformity.Location = new System.Drawing.Point(14, 146);
            this.button_Uniformity.Name = "button_Uniformity";
            this.button_Uniformity.Size = new System.Drawing.Size(89, 23);
            this.button_Uniformity.TabIndex = 90;
            this.button_Uniformity.Text = "1.4 Uniformity";
            this.button_Uniformity.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button_Uniformity.UseVisualStyleBackColor = true;
            this.button_Uniformity.Click += new System.EventHandler(this.button_Uniformity_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(715, 468);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox1_measure);
            this.Controls.Add(this.button3_SaveCsv);
            this.Controls.Add(this.groupBox1_gamma);
            this.Controls.Add(this.button_clear);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.caControlWrapper1);
            this.Name = "Form1";
            this.Text = "CA310/410 gamma tool";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.groupBox1_gamma.ResumeLayout(false);
            this.groupBox1_gamma.PerformLayout();
            this.groupBox1_measure.ResumeLayout(false);
            this.groupBox1_measure.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        internal System.Windows.Forms.Button ButtonCalZero;
        internal System.Windows.Forms.Button ButtonMeasure;
        internal System.Windows.Forms.Button ButtonCancel;
        internal System.Windows.Forms.Label Labelduv;
        internal System.Windows.Forms.Label LabelT;
        internal System.Windows.Forms.Label Labely;
        internal System.Windows.Forms.Label Labelx;
        internal System.Windows.Forms.Label LabelLv;
        internal System.Windows.Forms.Label Label5;
        internal System.Windows.Forms.Label Label4;
        internal System.Windows.Forms.Label Label3;
        internal System.Windows.Forms.Label Label2;
        internal System.Windows.Forms.Label Label1;
        private CaControl.CaControlWrapper caControlWrapper1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button button_clear;
        private System.Windows.Forms.CheckBox checkBox1_Red;
        private System.Windows.Forms.CheckBox checkBox2_Green;
        private System.Windows.Forms.CheckBox checkBox3_Blue;
        private System.Windows.Forms.CheckBox checkBox4_White;
        private System.Windows.Forms.GroupBox groupBox1_gamma;
        private System.Windows.Forms.Button button3_SaveCsv;
        private System.Windows.Forms.GroupBox groupBox1_measure;
        private System.Windows.Forms.Button button_gammapattern;
        private System.Windows.Forms.Button button_connect;
        private System.Windows.Forms.Button button_dsiconnect;
        private System.Windows.Forms.Button button_Gamma;
        private System.Windows.Forms.Button button_410;
        private System.Windows.Forms.Button button_310;
        private System.Windows.Forms.Label label_mode;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textBox_gammadelay;
        private System.Windows.Forms.Label label_colorstep;
        private System.Windows.Forms.Label label_connect;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ComboBox comboBox_com;
        private System.Windows.Forms.Button button_SearchCOM;
        private System.Windows.Forms.Button button_buttonOpenCloseCom;
        private System.Windows.Forms.Button button_whitepattern;
        private System.Windows.Forms.Button button_redpattern;
        private System.Windows.Forms.Button button_greenpattern;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button button_blackpattern;
        private System.Windows.Forms.Button button_bluepattern;
        private System.Windows.Forms.Button button_9point;
        private System.Windows.Forms.Label label_COMconnect;
        private System.Windows.Forms.Button button_2238gamma;
        private System.Windows.Forms.Button button_LuminanceTest;
        private System.Windows.Forms.Button button_LuminanceTest2;
        private System.Windows.Forms.Button button_ColorTemperature;
        private System.Windows.Forms.Button button_ContrastRatio;
        private System.Windows.Forms.Button button_deleteSource;
        private System.Windows.Forms.ComboBox comboBox_sourcelist;
        private System.Windows.Forms.Button button_addSource;
        private System.Windows.Forms.Button button_addmode;
        private System.Windows.Forms.ComboBox comboBox_modelist;
        private System.Windows.Forms.Button button_deletemode;
        private System.Windows.Forms.Button button_addCT;
        private System.Windows.Forms.ComboBox comboBox_CTlist;
        private System.Windows.Forms.Button button_deleteCT;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Button button_Uniformity;
        private System.Windows.Forms.Button button_colorGamut;
        private System.Windows.Forms.Button button_lightSensor;
        private System.Windows.Forms.Button button_DynamicContrasRatioTest;
        private System.Windows.Forms.Button button_DimmingRange;
        private System.Windows.Forms.DataGridViewTextBoxColumn No;
        private System.Windows.Forms.DataGridViewTextBoxColumn x;
        private System.Windows.Forms.DataGridViewTextBoxColumn y;
        private System.Windows.Forms.DataGridViewTextBoxColumn Lv;
        private System.Windows.Forms.DataGridViewTextBoxColumn T;
        private System.Windows.Forms.DataGridViewTextBoxColumn duv;
    }
}

