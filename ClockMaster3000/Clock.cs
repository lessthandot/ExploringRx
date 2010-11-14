using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ClockMaster3000 {
	public partial class Clock : UserControl, IObserver<DateTime> {
		public Clock() {
			InitializeComponent();
		}

		public string City {
			set { clockName.Text = value; }
			get { return clockName.Text; }
		}

		public double Offset { get; set; }

		public void OnCompleted() {
			SetTimeText(time, "Not Responding");
		}

		public void OnNext(DateTime next) {
			string current = next.AddHours(Offset).ToLongTimeString();
			SetTimeText(time, current);
		}

		public void OnError(Exception ex) {
			SetTimeText(time, "Error reaching time service");
		}

		Action<Label, string> setterCallback = (toSet, text) => toSet.Text = text;

		void SetTimeText(Label toSet, string text) {
			if (time.InvokeRequired) {
				this.Invoke(setterCallback, toSet, text);
			}
			else {
				setterCallback(toSet, text);
			}
		}
	}
}
