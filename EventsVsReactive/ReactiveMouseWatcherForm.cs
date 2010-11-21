using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace EventsVsReactive {
	public partial class ReactiveMouseWatcherForm : Form {
		public ReactiveMouseWatcherForm() {
			InitializeComponent();
			var mouseMoveEvent = Observable.FromEvent<MouseEventArgs>(this, "MouseMove");

			var selectedMovementEvents = from pos in mouseMoveEvent
						 .Where(x => (x.EventArgs.X % 10 == 0 || x.EventArgs.Y % 10 == 0)
								|| ((x.EventArgs.Button & MouseButtons.Left) == MouseButtons.Left
									&& (x.EventArgs.Button & MouseButtons.Right) == MouseButtons.Right))
						 .Repeat()
						select pos.EventArgs;

			selectedMovementEvents.Subscribe(p => {
				display.Text = string.Format("X: {0}, Y: {1}, Button: {2}", p.X, p.Y, p.Button);
			});
		}
	}
}
