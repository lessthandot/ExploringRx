using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace EventsVsReactive {
	public partial class DrawingForm : Form {

		MouseEventHandler handler;
		Point? previousMousePosition;

		public DrawingForm() {
			InitializeComponent();

			handler = (sender, e) => {
				if (previousMousePosition.HasValue) {
					using (var gfx = this.CreateGraphics())
					using (var pen = new Pen(Color.Black, 5F)) {
						gfx.DrawLine(pen, previousMousePosition.Value, e.Location);
					}
				}
				previousMousePosition = e.Location;
			};

			this.MouseDown += DrawingForm_MouseDown;
			this.MouseUp += DrawingForm_MouseUp;
		}

		void DrawingForm_MouseUp(object sender, MouseEventArgs e) {
			previousMousePosition = null;
			this.MouseMove -= handler;
		}

		void DrawingForm_MouseDown(object sender, MouseEventArgs e) {
			this.MouseMove += handler;
		}
	}
}
