namespace ClockMaster3000
{
	partial class GlobalClock
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
			this.Run = new System.Windows.Forms.Button();
			this.Stop = new System.Windows.Forms.Button();
			this.tokyo = new ClockMaster3000.Clock();
			this.tehran = new ClockMaster3000.Clock();
			this.brussels = new ClockMaster3000.Clock();
			this.losangeles = new ClockMaster3000.Clock();
			this.london = new ClockMaster3000.Clock();
			this.newyork = new ClockMaster3000.Clock();
			this.SuspendLayout();
			// 
			// Run
			// 
			this.Run.Location = new System.Drawing.Point(293, 15);
			this.Run.Name = "Run";
			this.Run.Size = new System.Drawing.Size(75, 23);
			this.Run.TabIndex = 1;
			this.Run.Text = "Run";
			this.Run.UseVisualStyleBackColor = true;
			this.Run.Click += new System.EventHandler(this.Run_Click);
			// 
			// Stop
			// 
			this.Stop.Location = new System.Drawing.Point(293, 45);
			this.Stop.Name = "Stop";
			this.Stop.Size = new System.Drawing.Size(75, 23);
			this.Stop.TabIndex = 3;
			this.Stop.Text = "Stop";
			this.Stop.UseVisualStyleBackColor = true;
			this.Stop.Click += new System.EventHandler(this.Stop_Click);
			// 
			// tokyo
			// 
			this.tokyo.City = "Tokyo";
			this.tokyo.Location = new System.Drawing.Point(24, 230);
			this.tokyo.Name = "tokyo";
			this.tokyo.Offset = 9;
			this.tokyo.Size = new System.Drawing.Size(244, 26);
			this.tokyo.TabIndex = 7;
			// 
			// tehran
			// 
			this.tehran.City = "Tehran";
			this.tehran.Location = new System.Drawing.Point(24, 188);
			this.tehran.Name = "tehran";
			this.tehran.Offset = 3.5;
			this.tehran.Size = new System.Drawing.Size(244, 26);
			this.tehran.TabIndex = 6;
			// 
			// brussels
			// 
			this.brussels.City = "Brussels";
			this.brussels.Location = new System.Drawing.Point(24, 142);
			this.brussels.Name = "brussels";
			this.brussels.Offset = 1;
			this.brussels.Size = new System.Drawing.Size(244, 26);
			this.brussels.TabIndex = 5;
			// 
			// losangeles
			// 
			this.losangeles.City = "Los Angeles";
			this.losangeles.Location = new System.Drawing.Point(24, 12);
			this.losangeles.Name = "losangeles";
			this.losangeles.Offset = -8;
			this.losangeles.Size = new System.Drawing.Size(244, 26);
			this.losangeles.TabIndex = 4;
			// 
			// london
			// 
			this.london.City = "London";
			this.london.Location = new System.Drawing.Point(24, 96);
			this.london.Name = "london";
			this.london.Offset = 0;
			this.london.Size = new System.Drawing.Size(244, 26);
			this.london.TabIndex = 2;
			// 
			// newyork
			// 
			this.newyork.City = "New York";
			this.newyork.Location = new System.Drawing.Point(24, 55);
			this.newyork.Name = "newyork";
			this.newyork.Offset = -5;
			this.newyork.Size = new System.Drawing.Size(244, 26);
			this.newyork.TabIndex = 0;
			// 
			// GlobalClock
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
			this.ClientSize = new System.Drawing.Size(405, 294);
			this.Controls.Add(this.tokyo);
			this.Controls.Add(this.tehran);
			this.Controls.Add(this.brussels);
			this.Controls.Add(this.losangeles);
			this.Controls.Add(this.Stop);
			this.Controls.Add(this.london);
			this.Controls.Add(this.Run);
			this.Controls.Add(this.newyork);
			this.Name = "GlobalClock";
			this.Text = "Clockmaster 3000";
			this.ResumeLayout(false);

		}

		#endregion

		private Clock newyork;
		private System.Windows.Forms.Button Run;
		private Clock london;
		private System.Windows.Forms.Button Stop;
		private Clock losangeles;
		private Clock brussels;
		private Clock tehran;
		private Clock tokyo;
	}
}

