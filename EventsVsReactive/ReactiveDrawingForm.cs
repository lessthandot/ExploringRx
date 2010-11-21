using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace EventsVsReactive {
	public partial class ReactiveDrawingForm : Form {
		public ReactiveDrawingForm() {
			InitializeComponent();
			var mouseMove = Observable.FromEvent<MouseEventArgs>(this, "MouseMove");
			var mouseDown = Observable.FromEvent<MouseEventArgs>(this, "MouseDown");
			var mouseUp = Observable.FromEvent<MouseEventArgs>(this, "MouseUp");

			var selectedMovementEvents = from pair in mouseMove
						 .SkipUntil(mouseDown)
						 .TakeUntil(mouseUp)
						 .Let(mvmnt => mvmnt.Zip(mvmnt.Skip(1),
							(previous, current) => new {
								current = current.EventArgs.Location,
								previous = previous.EventArgs.Location
							}))
						.Repeat()
				select pair;

			selectedMovementEvents.Subscribe(p => {
				using (var gfx = this.CreateGraphics())
				using (var pen = new Pen(Color.Black, 5F)) {
					gfx.DrawLine(pen, p.previous, p.current);
				}
			});
		}
	}
}
