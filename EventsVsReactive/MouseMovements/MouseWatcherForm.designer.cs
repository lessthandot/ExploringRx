namespace EventsVsReactive {
	partial class MouseWatcherForm {
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing) {
			if (disposing && (components != null)) {
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent() {
			this.display = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// display
			// 
			this.display.AutoSize = true;
			this.display.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.display.Location = new System.Drawing.Point(0, 249);
			this.display.Name = "display";
			this.display.Size = new System.Drawing.Size(47, 13);
			this.display.TabIndex = 0;
			this.display.Text = "No Data";
			// 
			// MouseWatcherForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(284, 262);
			this.Controls.Add(this.display);
			this.Name = "MouseWatcherForm";
			this.Text = "MouseWatcherForm";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label display;
	}
}

