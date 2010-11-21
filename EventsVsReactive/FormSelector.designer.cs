namespace EventsVsReactive {
	partial class FormSelector {
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
			this.openTraditionalMouseMove = new System.Windows.Forms.Button();
			this.openReactiveMouseMove = new System.Windows.Forms.Button();
			this.openReactiveDraw = new System.Windows.Forms.Button();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.openTraditionalDrawer = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// openTraditionalMouseMove
			// 
			this.openTraditionalMouseMove.Location = new System.Drawing.Point(86, 67);
			this.openTraditionalMouseMove.Name = "openTraditionalMouseMove";
			this.openTraditionalMouseMove.Size = new System.Drawing.Size(75, 23);
			this.openTraditionalMouseMove.TabIndex = 0;
			this.openTraditionalMouseMove.Text = "Open";
			this.openTraditionalMouseMove.UseVisualStyleBackColor = true;
			this.openTraditionalMouseMove.Click += new System.EventHandler(this.openTraditionalMouseMove_Click);
			// 
			// openReactiveMouseMove
			// 
			this.openReactiveMouseMove.Location = new System.Drawing.Point(183, 67);
			this.openReactiveMouseMove.Name = "openReactiveMouseMove";
			this.openReactiveMouseMove.Size = new System.Drawing.Size(75, 23);
			this.openReactiveMouseMove.TabIndex = 1;
			this.openReactiveMouseMove.Text = "Open";
			this.openReactiveMouseMove.UseVisualStyleBackColor = true;
			this.openReactiveMouseMove.Click += new System.EventHandler(this.openReactiveMouseMove_Click);
			// 
			// openReactiveDraw
			// 
			this.openReactiveDraw.Location = new System.Drawing.Point(183, 96);
			this.openReactiveDraw.Name = "openReactiveDraw";
			this.openReactiveDraw.Size = new System.Drawing.Size(75, 23);
			this.openReactiveDraw.TabIndex = 2;
			this.openReactiveDraw.Text = "Open";
			this.openReactiveDraw.UseVisualStyleBackColor = true;
			this.openReactiveDraw.Click += new System.EventHandler(this.openReactiveDrawer_Click);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(5, 67);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(66, 13);
			this.label1.TabIndex = 3;
			this.label1.Text = "MouseMove";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(5, 101);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(32, 13);
			this.label2.TabIndex = 4;
			this.label2.Text = "Draw";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(180, 37);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(50, 13);
			this.label3.TabIndex = 5;
			this.label3.Text = "Reactive";
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(83, 37);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(92, 13);
			this.label4.TabIndex = 6;
			this.label4.Text = "Traditional Events";
			// 
			// openTraditionalDrawer
			// 
			this.openTraditionalDrawer.Location = new System.Drawing.Point(86, 96);
			this.openTraditionalDrawer.Name = "openTraditionalDrawer";
			this.openTraditionalDrawer.Size = new System.Drawing.Size(75, 23);
			this.openTraditionalDrawer.TabIndex = 7;
			this.openTraditionalDrawer.Text = "Open";
			this.openTraditionalDrawer.UseVisualStyleBackColor = true;
			this.openTraditionalDrawer.Click += new System.EventHandler(this.openTraditionalDrawer_Click);
			// 
			// FormSelector
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(284, 262);
			this.Controls.Add(this.openTraditionalDrawer);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.openReactiveDraw);
			this.Controls.Add(this.openReactiveMouseMove);
			this.Controls.Add(this.openTraditionalMouseMove);
			this.Name = "FormSelector";
			this.Text = "FormSelector";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button openTraditionalMouseMove;
		private System.Windows.Forms.Button openReactiveMouseMove;
		private System.Windows.Forms.Button openReactiveDraw;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Button openTraditionalDrawer;
	}
}