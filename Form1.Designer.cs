
namespace GeneticSalesman
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.buttonGo = new System.Windows.Forms.Button();
            this.textBoxMain = new System.Windows.Forms.TextBox();
            this.buttonEvolve = new System.Windows.Forms.Button();
            this.textBoxCities = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxPath = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textBoxMutationRate = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.textBoxGenerationsPerClick = new System.Windows.Forms.TextBox();
            this.checkBoxShowWorst = new System.Windows.Forms.CheckBox();
            this.checkBoxShowBestPath = new System.Windows.Forms.CheckBox();
            this.checkBoxShowCities = new System.Windows.Forms.CheckBox();
            this.buttonNewMap = new System.Windows.Forms.Button();
            this.checkBoxClones = new System.Windows.Forms.CheckBox();
            this.checkBoxRandomParents = new System.Windows.Forms.CheckBox();
            this.checkBoxRandomMutation = new System.Windows.Forms.CheckBox();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.statusStripLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripExecutionStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.labelEvolveTime = new System.Windows.Forms.Label();
            this.toolStripStatusLabelEta = new System.Windows.Forms.ToolStripStatusLabel();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::GeneticSalesman.Properties.Resources.white700x700;
            this.pictureBox1.Location = new System.Drawing.Point(12, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(700, 700);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBox1_Paint);
            // 
            // buttonGo
            // 
            this.buttonGo.Location = new System.Drawing.Point(784, 270);
            this.buttonGo.Name = "buttonGo";
            this.buttonGo.Size = new System.Drawing.Size(85, 82);
            this.buttonGo.TabIndex = 1;
            this.buttonGo.Text = "Generate new map";
            this.buttonGo.UseVisualStyleBackColor = true;
            this.buttonGo.Click += new System.EventHandler(this.buttonGo_Click);
            // 
            // textBoxMain
            // 
            this.textBoxMain.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxMain.Location = new System.Drawing.Point(719, 153);
            this.textBoxMain.Multiline = true;
            this.textBoxMain.Name = "textBoxMain";
            this.textBoxMain.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBoxMain.Size = new System.Drawing.Size(613, 586);
            this.textBoxMain.TabIndex = 2;
            // 
            // buttonEvolve
            // 
            this.buttonEvolve.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonEvolve.Location = new System.Drawing.Point(853, 95);
            this.buttonEvolve.Name = "buttonEvolve";
            this.buttonEvolve.Size = new System.Drawing.Size(479, 52);
            this.buttonEvolve.TabIndex = 3;
            this.buttonEvolve.Text = "Evolve";
            this.buttonEvolve.UseVisualStyleBackColor = true;
            this.buttonEvolve.Click += new System.EventHandler(this.buttonEvolve_Click);
            // 
            // textBoxCities
            // 
            this.textBoxCities.Location = new System.Drawing.Point(937, 16);
            this.textBoxCities.Name = "textBoxCities";
            this.textBoxCities.Size = new System.Drawing.Size(82, 22);
            this.textBoxCities.TabIndex = 4;
            this.textBoxCities.Text = "15";
            this.textBoxCities.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(889, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(42, 17);
            this.label1.TabIndex = 5;
            this.label1.Text = "Cities";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(1025, 19);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 17);
            this.label2.TabIndex = 7;
            this.label2.Text = "Paths";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // textBoxPath
            // 
            this.textBoxPath.Location = new System.Drawing.Point(1075, 16);
            this.textBoxPath.Name = "textBoxPath";
            this.textBoxPath.Size = new System.Drawing.Size(62, 22);
            this.textBoxPath.TabIndex = 6;
            this.textBoxPath.Text = "20";
            this.textBoxPath.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(1143, 19);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(91, 17);
            this.label3.TabIndex = 9;
            this.label3.Text = "Mutation rate";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // textBoxMutationRate
            // 
            this.textBoxMutationRate.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxMutationRate.Location = new System.Drawing.Point(1240, 16);
            this.textBoxMutationRate.Name = "textBoxMutationRate";
            this.textBoxMutationRate.Size = new System.Drawing.Size(92, 22);
            this.textBoxMutationRate.TabIndex = 8;
            this.textBoxMutationRate.Text = "3";
            this.textBoxMutationRate.TextChanged += new System.EventHandler(this.textBox3_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(889, 44);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(142, 17);
            this.label4.TabIndex = 11;
            this.label4.Text = "Generations per click";
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // textBoxGenerationsPerClick
            // 
            this.textBoxGenerationsPerClick.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxGenerationsPerClick.Location = new System.Drawing.Point(1037, 44);
            this.textBoxGenerationsPerClick.Name = "textBoxGenerationsPerClick";
            this.textBoxGenerationsPerClick.Size = new System.Drawing.Size(295, 22);
            this.textBoxGenerationsPerClick.TabIndex = 10;
            this.textBoxGenerationsPerClick.Text = "1";
            this.textBoxGenerationsPerClick.TextChanged += new System.EventHandler(this.textBoxGenerationsPerClick_TextChanged);
            // 
            // checkBoxShowWorst
            // 
            this.checkBoxShowWorst.AutoSize = true;
            this.checkBoxShowWorst.Location = new System.Drawing.Point(319, 718);
            this.checkBoxShowWorst.Name = "checkBoxShowWorst";
            this.checkBoxShowWorst.Size = new System.Drawing.Size(133, 21);
            this.checkBoxShowWorst.TabIndex = 12;
            this.checkBoxShowWorst.Text = "Show worst path";
            this.checkBoxShowWorst.UseVisualStyleBackColor = true;
            this.checkBoxShowWorst.CheckedChanged += new System.EventHandler(this.checkBoxShowWorst_CheckedChanged);
            this.checkBoxShowWorst.CheckStateChanged += new System.EventHandler(this.checkBoxShowWorst_CheckStateChanged);
            // 
            // checkBoxShowBestPath
            // 
            this.checkBoxShowBestPath.AutoSize = true;
            this.checkBoxShowBestPath.Checked = true;
            this.checkBoxShowBestPath.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxShowBestPath.Location = new System.Drawing.Point(155, 718);
            this.checkBoxShowBestPath.Name = "checkBoxShowBestPath";
            this.checkBoxShowBestPath.Size = new System.Drawing.Size(127, 21);
            this.checkBoxShowBestPath.TabIndex = 13;
            this.checkBoxShowBestPath.Text = "Show best path";
            this.checkBoxShowBestPath.UseVisualStyleBackColor = true;
            this.checkBoxShowBestPath.CheckedChanged += new System.EventHandler(this.checkBoxShowBestPath_CheckedChanged);
            // 
            // checkBoxShowCities
            // 
            this.checkBoxShowCities.AutoSize = true;
            this.checkBoxShowCities.Checked = true;
            this.checkBoxShowCities.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxShowCities.Location = new System.Drawing.Point(12, 718);
            this.checkBoxShowCities.Name = "checkBoxShowCities";
            this.checkBoxShowCities.Size = new System.Drawing.Size(100, 21);
            this.checkBoxShowCities.TabIndex = 14;
            this.checkBoxShowCities.Text = "Show cities";
            this.checkBoxShowCities.UseVisualStyleBackColor = true;
            this.checkBoxShowCities.CheckedChanged += new System.EventHandler(this.checkBoxShowCities_CheckedChanged);
            // 
            // buttonNewMap
            // 
            this.buttonNewMap.Location = new System.Drawing.Point(718, 95);
            this.buttonNewMap.Name = "buttonNewMap";
            this.buttonNewMap.Size = new System.Drawing.Size(129, 52);
            this.buttonNewMap.TabIndex = 15;
            this.buttonNewMap.Text = "Create new map";
            this.buttonNewMap.UseVisualStyleBackColor = true;
            this.buttonNewMap.Click += new System.EventHandler(this.buttonNewMap_Click);
            // 
            // checkBoxClones
            // 
            this.checkBoxClones.AutoSize = true;
            this.checkBoxClones.Location = new System.Drawing.Point(719, 19);
            this.checkBoxClones.Name = "checkBoxClones";
            this.checkBoxClones.Size = new System.Drawing.Size(100, 21);
            this.checkBoxClones.TabIndex = 16;
            this.checkBoxClones.Text = "Add clones";
            this.checkBoxClones.UseVisualStyleBackColor = true;
            // 
            // checkBoxRandomParents
            // 
            this.checkBoxRandomParents.AutoSize = true;
            this.checkBoxRandomParents.Location = new System.Drawing.Point(719, 44);
            this.checkBoxRandomParents.Name = "checkBoxRandomParents";
            this.checkBoxRandomParents.Size = new System.Drawing.Size(164, 21);
            this.checkBoxRandomParents.TabIndex = 17;
            this.checkBoxRandomParents.Text = "Add Random parents";
            this.checkBoxRandomParents.UseVisualStyleBackColor = true;
            // 
            // checkBoxRandomMutation
            // 
            this.checkBoxRandomMutation.AutoSize = true;
            this.checkBoxRandomMutation.Location = new System.Drawing.Point(719, 68);
            this.checkBoxRandomMutation.Name = "checkBoxRandomMutation";
            this.checkBoxRandomMutation.Size = new System.Drawing.Size(170, 21);
            this.checkBoxRandomMutation.TabIndex = 18;
            this.checkBoxRandomMutation.Text = "Random mutation rate";
            this.checkBoxRandomMutation.UseVisualStyleBackColor = true;
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.statusStripLabel,
            this.toolStripExecutionStatus,
            this.toolStripStatusLabelEta,
            this.toolStripStatusLabel1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 749);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1344, 26);
            this.statusStrip1.TabIndex = 19;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // statusStripLabel
            // 
            this.statusStripLabel.Name = "statusStripLabel";
            this.statusStripLabel.Size = new System.Drawing.Size(0, 20);
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(0, 20);
            this.toolStripStatusLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // toolStripExecutionStatus
            // 
            this.toolStripExecutionStatus.AutoSize = false;
            this.toolStripExecutionStatus.Name = "toolStripExecutionStatus";
            this.toolStripExecutionStatus.Size = new System.Drawing.Size(100, 20);
            // 
            // labelEvolveTime
            // 
            this.labelEvolveTime.AutoSize = true;
            this.labelEvolveTime.Location = new System.Drawing.Point(889, 72);
            this.labelEvolveTime.Name = "labelEvolveTime";
            this.labelEvolveTime.Size = new System.Drawing.Size(169, 17);
            this.labelEvolveTime.TabIndex = 20;
            this.labelEvolveTime.Text = "Estimated time to evolve: ";
            // 
            // toolStripStatusLabelEta
            // 
            this.toolStripStatusLabelEta.AutoSize = false;
            this.toolStripStatusLabelEta.Name = "toolStripStatusLabelEta";
            this.toolStripStatusLabelEta.Size = new System.Drawing.Size(300, 20);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1344, 775);
            this.Controls.Add(this.textBoxGenerationsPerClick);
            this.Controls.Add(this.labelEvolveTime);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.checkBoxRandomMutation);
            this.Controls.Add(this.checkBoxRandomParents);
            this.Controls.Add(this.checkBoxClones);
            this.Controls.Add(this.buttonNewMap);
            this.Controls.Add(this.checkBoxShowCities);
            this.Controls.Add(this.checkBoxShowBestPath);
            this.Controls.Add(this.checkBoxShowWorst);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBoxMutationRate);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBoxPath);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBoxCities);
            this.Controls.Add(this.buttonEvolve);
            this.Controls.Add(this.textBoxMain);
            this.Controls.Add(this.buttonGo);
            this.Controls.Add(this.pictureBox1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Form1_Paint);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button buttonGo;
        private System.Windows.Forms.TextBox textBoxMain;
        private System.Windows.Forms.Button buttonEvolve;
        private System.Windows.Forms.TextBox textBoxCities;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxPath;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBoxMutationRate;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBoxGenerationsPerClick;
        private System.Windows.Forms.CheckBox checkBoxShowWorst;
        private System.Windows.Forms.CheckBox checkBoxShowBestPath;
        private System.Windows.Forms.CheckBox checkBoxShowCities;
        private System.Windows.Forms.Button buttonNewMap;
        private System.Windows.Forms.CheckBox checkBoxClones;
        private System.Windows.Forms.CheckBox checkBoxRandomParents;
        private System.Windows.Forms.CheckBox checkBoxRandomMutation;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel statusStripLabel;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripExecutionStatus;
        private System.Windows.Forms.Label labelEvolveTime;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabelEta;
    }
}

