using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace EventsVsReactive {
	public partial class MouseWatcherForm : Form {
		public MouseWatcherForm() {
			InitializeComponent();
			this.MouseMove += UpdateLabel;
		}

		public void UpdateLabel(object sender, MouseEventArgs e) {
			if(( e.X % 10 == 0 || e.Y % 10 == 0)
								|| ((e.Button & MouseButtons.Left) == MouseButtons.Left 
									&& (e.Button & MouseButtons.Right) == MouseButtons.Right))
			display.Text = string.Format("X: {0}, Y: {1}, Button: {2}", e.X, e.Y, e.Button);
		}
	}
}
