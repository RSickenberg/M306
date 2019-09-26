namespace Sony_ICF_C717PJ
{
  partial class Main
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
      this.groupBox1 = new System.Windows.Forms.GroupBox();
      this.Front = new System.Windows.Forms.GroupBox();
      this.label1 = new System.Windows.Forms.Label();
      this.pictureBox2 = new System.Windows.Forms.PictureBox();
      this.pictureBox1 = new System.Windows.Forms.PictureBox();
      this.groupBox1.SuspendLayout();
      this.Front.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
      this.SuspendLayout();
      // 
      // groupBox1
      // 
      this.groupBox1.Controls.Add(this.pictureBox1);
      this.groupBox1.Location = new System.Drawing.Point(28, 25);
      this.groupBox1.Margin = new System.Windows.Forms.Padding(2);
      this.groupBox1.Name = "groupBox1";
      this.groupBox1.Padding = new System.Windows.Forms.Padding(2);
      this.groupBox1.Size = new System.Drawing.Size(1168, 262);
      this.groupBox1.TabIndex = 1;
      this.groupBox1.TabStop = false;
      this.groupBox1.Text = "Top";
      // 
      // Front
      // 
      this.Front.Controls.Add(this.label1);
      this.Front.Controls.Add(this.pictureBox2);
      this.Front.Location = new System.Drawing.Point(28, 352);
      this.Front.Name = "Front";
      this.Front.Size = new System.Drawing.Size(1168, 293);
      this.Front.TabIndex = 2;
      this.Front.TabStop = false;
      this.Front.Text = "groupBox2";
      // 
      // label1
      // 
      this.label1.BackColor = System.Drawing.Color.White;
      this.label1.Font = new System.Drawing.Font("Lucida Console", 80F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.label1.ForeColor = System.Drawing.Color.Black;
      this.label1.Location = new System.Drawing.Point(234, 85);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(100, 154);
      this.label1.TabIndex = 1;
      this.label1.Text = "1";
      this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
      // 
      // pictureBox2
      // 
      this.pictureBox2.BackgroundImage = global::Sony_ICF_C717PJ.Properties.Resources.display;
      this.pictureBox2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
      this.pictureBox2.Location = new System.Drawing.Point(15, 19);
      this.pictureBox2.Name = "pictureBox2";
      this.pictureBox2.Size = new System.Drawing.Size(1144, 262);
      this.pictureBox2.TabIndex = 0;
      this.pictureBox2.TabStop = false;
      // 
      // pictureBox1
      // 
      this.pictureBox1.BackgroundImage = global::Sony_ICF_C717PJ.Properties.Resources.top;
      this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
      this.pictureBox1.Location = new System.Drawing.Point(15, 24);
      this.pictureBox1.Margin = new System.Windows.Forms.Padding(2);
      this.pictureBox1.Name = "pictureBox1";
      this.pictureBox1.Size = new System.Drawing.Size(1144, 229);
      this.pictureBox1.TabIndex = 0;
      this.pictureBox1.TabStop = false;
      // 
      // Main
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.AutoSize = true;
      this.ClientSize = new System.Drawing.Size(1260, 657);
      this.Controls.Add(this.Front);
      this.Controls.Add(this.groupBox1);
      this.Margin = new System.Windows.Forms.Padding(2);
      this.Name = "Main";
      this.Text = "Sony ICF-C717PJ EU";
      this.groupBox1.ResumeLayout(false);
      this.Front.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.PictureBox pictureBox1;
    private System.Windows.Forms.GroupBox groupBox1;
    private System.Windows.Forms.GroupBox Front;
    private System.Windows.Forms.PictureBox pictureBox2;
    private System.Windows.Forms.Label label1;
  }
}