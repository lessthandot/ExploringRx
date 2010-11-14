namespace ClockMaster3000
{
	partial class Clock
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

		#region Component Designer generated code

		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.clockName = new System.Windows.Forms.Label();
			this.time = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// clockName
			// 
			this.clockName.AutoSize = true;
			this.clockName.Location = new System.Drawing.Point(4, 4);
			this.clockName.Name = "clockName";
			this.clockName.Size = new System.Drawing.Size(35, 13);
			this.clockName.TabIndex = 0;
			this.clockName.Text = "label1";
			// 
			// time
			// 
			this.time.AutoSize = true;
			this.time.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.time.Location = new System.Drawing.Point(117, 4);
			this.time.Name = "time";
			this.time.Size = new System.Drawing.Size(98, 13);
			this.time.TabIndex = 1;
			this.time.Text = "Not Responding";
			// 
			// Clock
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.time);
			this.Controls.Add(this.clockName);
			this.Name = "Clock";
			this.Size = new System.Drawing.Size(244, 26);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label clockName;
		private System.Windows.Forms.Label time;
	}
}
