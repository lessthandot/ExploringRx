using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;

namespace ClockMaster3000 {
	public partial class GlobalClock : Form {
		AtomicClock atomicClock = new AtomicClock();
		System.Threading.Thread backgroundThread;
		bool running;

		public GlobalClock() {
			InitializeComponent();
			foreach (var control in this.Controls) {
				if (control.GetType() == typeof(ClockMaster3000.Clock)) {
					atomicClock.Subscribe(control as IObserver<DateTime>);
				}
			}
			this.FormClosing += OnClosing;
		}

		private void Run_Click(object sender, EventArgs e) {
			if (!running) {
				backgroundThread = new Thread(atomicClock.Run);
				backgroundThread.Start();
				running = true;
			}
		}

		private void Stop_Click(object sender, EventArgs e) {
			StopService();
		}

		void OnClosing(Object sender, FormClosingEventArgs e) {
			StopService();
		}

		void StopService() {
			atomicClock.Complete();
			running = false;
		}
	}
}
