namespace Library
{
    partial class Final_checkin
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.bookid = new System.Windows.Forms.TextBox();
            this.title = new System.Windows.Forms.TextBox();
            this.cardno = new System.Windows.Forms.TextBox();
            this.branchid = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(164, 51);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Book _ ID";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(164, 79);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Book Title";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(172, 106);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(47, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Card no.";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(164, 132);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(55, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Branch ID";
            // 
            // bookid
            // 
            this.bookid.Location = new System.Drawing.Point(240, 51);
            this.bookid.Name = "bookid";
            this.bookid.Size = new System.Drawing.Size(100, 20);
            this.bookid.TabIndex = 4;
            // 
            // title
            // 
            this.title.Location = new System.Drawing.Point(240, 79);
            this.title.Name = "title";
            this.title.Size = new System.Drawing.Size(100, 20);
            this.title.TabIndex = 5;
            // 
            // cardno
            // 
            this.cardno.Location = new System.Drawing.Point(240, 106);
            this.cardno.Name = "cardno";
            this.cardno.Size = new System.Drawing.Size(100, 20);
            this.cardno.TabIndex = 6;
            // 
            // branchid
            // 
            this.branchid.Location = new System.Drawing.Point(240, 133);
            this.branchid.Name = "branchid";
            this.branchid.Size = new System.Drawing.Size(100, 20);
            this.branchid.TabIndex = 7;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(193, 186);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 8;
            this.button1.Text = "Check IN";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Final_checkin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(486, 281);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.branchid);
            this.Controls.Add(this.cardno);
            this.Controls.Add(this.title);
            this.Controls.Add(this.bookid);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "Final_checkin";
            this.Text = "Final_checkin";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox bookid;
        private System.Windows.Forms.TextBox title;
        private System.Windows.Forms.TextBox cardno;
        private System.Windows.Forms.TextBox branchid;
        private System.Windows.Forms.Button button1;
    }
}