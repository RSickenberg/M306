namespace Sony_ICF_C717PJ
{
  partial class simulator
  {
    /// <summary>
    /// Variable nécessaire au concepteur.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    /// Nettoyage des ressources utilisées.
    /// </summary>
    /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
    protected override void Dispose(bool disposing)
    {
      if (disposing && (components != null))
      {
        components.Dispose();
      }
      base.Dispose(disposing);
    }

    #region Code généré par le Concepteur Windows Form

    /// <summary>
    /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
    /// le contenu de cette méthode avec l'éditeur de code.
    /// </summary>
    private void InitializeComponent()
    {
      this.groupBox1 = new System.Windows.Forms.GroupBox();
      this.pictureBox1 = new System.Windows.Forms.PictureBox();
      this.groupBox2 = new System.Windows.Forms.GroupBox();
      this.first_hour_unit = new System.Windows.Forms.Label();
      this.pictureBox2 = new System.Windows.Forms.PictureBox();
      this.double_dot_1 = new System.Windows.Forms.Label();
      this.second_hour_unit = new System.Windows.Forms.Label();
      this.groupBox1.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
      this.groupBox2.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
      this.SuspendLayout();
      // 
      // groupBox1
      // 
      this.groupBox1.Controls.Add(this.pictureBox1);
      this.groupBox1.Location = new System.Drawing.Point(35, 36);
      this.groupBox1.Name = "groupBox1";
      this.groupBox1.Size = new System.Drawing.Size(2412, 550);
      this.groupBox1.TabIndex = 0;
      this.groupBox1.TabStop = false;
      this.groupBox1.Text = "Top";
      // 
      // pictureBox1
      // 
      this.pictureBox1.BackgroundImage = global::Sony_ICF_C717PJ.Properties.Resources.top;
      this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
      this.pictureBox1.Location = new System.Drawing.Point(16, 31);
      this.pictureBox1.Name = "pictureBox1";
      this.pictureBox1.Size = new System.Drawing.Size(2380, 488);
      this.pictureBox1.TabIndex = 0;
      this.pictureBox1.TabStop = false;
      // 
      // groupBox2
      // 
      this.groupBox2.Controls.Add(this.second_hour_unit);
      this.groupBox2.Controls.Add(this.double_dot_1);
      this.groupBox2.Controls.Add(this.first_hour_unit);
      this.groupBox2.Controls.Add(this.pictureBox2);
      this.groupBox2.Location = new System.Drawing.Point(35, 660);
      this.groupBox2.Name = "groupBox2";
      this.groupBox2.Size = new System.Drawing.Size(2412, 550);
      this.groupBox2.TabIndex = 1;
      this.groupBox2.TabStop = false;
      this.groupBox2.Text = "Front";
      // 
      // first_hour_unit
      // 
      this.first_hour_unit.BackColor = System.Drawing.Color.White;
      this.first_hour_unit.Font = new System.Drawing.Font("Digital-7", 140F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.first_hour_unit.Location = new System.Drawing.Point(460, 141);
      this.first_hour_unit.Name = "first_hour_unit";
      this.first_hour_unit.Size = new System.Drawing.Size(262, 303);
      this.first_hour_unit.TabIndex = 1;
      this.first_hour_unit.Text = "0";
      this.first_hour_unit.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
      // 
      // pictureBox2
      // 
      this.pictureBox2.BackgroundImage = global::Sony_ICF_C717PJ.Properties.Resources.display_without_numbers;
      this.pictureBox2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
      this.pictureBox2.Location = new System.Drawing.Point(16, 31);
      this.pictureBox2.Name = "pictureBox2";
      this.pictureBox2.Size = new System.Drawing.Size(2380, 488);
      this.pictureBox2.TabIndex = 0;
      this.pictureBox2.TabStop = false;
      // 
      // double_dot_1
      // 
      this.double_dot_1.BackColor = System.Drawing.Color.White;
      this.double_dot_1.Font = new System.Drawing.Font("Digital-7", 100F);
      this.double_dot_1.Location = new System.Drawing.Point(1008, 192);
      this.double_dot_1.Name = "double_dot_1";
      this.double_dot_1.Size = new System.Drawing.Size(124, 197);
      this.double_dot_1.TabIndex = 2;
      this.double_dot_1.Text = ":";
      this.double_dot_1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
      // 
      // second_hour_unit
      // 
      this.second_hour_unit.BackColor = System.Drawing.Color.White;
      this.second_hour_unit.Font = new System.Drawing.Font("Digital-7", 140F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.second_hour_unit.Location = new System.Drawing.Point(745, 139);
      this.second_hour_unit.Name = "second_hour_unit";
      this.second_hour_unit.Size = new System.Drawing.Size(224, 305);
      this.second_hour_unit.TabIndex = 3;
      this.second_hour_unit.Text = "0";
      this.second_hour_unit.TextAlign = System.Drawing.ContentAlignment.TopCenter;
      // 
      // simulator
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.AutoSize = true;
      this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
      this.ClientSize = new System.Drawing.Size(2478, 1340);
      this.Controls.Add(this.groupBox2);
      this.Controls.Add(this.groupBox1);
      this.Margin = new System.Windows.Forms.Padding(6);
      this.Name = "simulator";
      this.Text = "Sony ICF-C717PJ";
      this.groupBox1.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
      this.groupBox2.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.GroupBox groupBox1;
    private System.Windows.Forms.PictureBox pictureBox1;
    private System.Windows.Forms.GroupBox groupBox2;
    private System.Windows.Forms.PictureBox pictureBox2;
    private System.Windows.Forms.Label first_hour_unit;
    private System.Windows.Forms.Label second_hour_unit;
    private System.Windows.Forms.Label double_dot_1;
  }
}

