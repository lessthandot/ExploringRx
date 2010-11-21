using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace EventsVsReactive {
	public partial class FormSelector : Form {
		public FormSelector() {
			InitializeComponent();
		}

		private void openTraditionalMouseMove_Click(object sender, EventArgs e) {
			new MouseWatcherForm().ShowDialog();
		}

		private void openReactiveMouseMove_Click(object sender, EventArgs e) {
			new ReactiveMouseWatcherForm().ShowDialog();
		}

		private void openReactiveDrawer_Click(object sender, EventArgs e) {
			new ReactiveDrawingForm().ShowDialog();
		}

		private void openTraditionalDrawer_Click(object sender, EventArgs e) {
			using (var form = new DrawingForm()) {
				form.ShowDialog();
			}
		}
	}
}
