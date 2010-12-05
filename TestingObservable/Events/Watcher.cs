using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TestingObservable.Events {
	public interface IWatcher {
		void OnCompleted(object sender, EventArgs e);
		void OnError(object sender, DataEventArgs<Exception> e);
		void OnNext(object sender, DataEventArgs<string> e);
	}

	public class Watcher : IDisposable, TestingObservable.Events.IWatcher {
		IDisposable unsubscriber;

		public void Subscribe(IWatched subject) {
			if (unsubscriber != null) {
				throw new InvalidOperationException("This watcher is already observing a subject!");
			}
			unsubscriber = subject.Subscribe(this);
		}

		public void OnNext(object sender, DataEventArgs<string> e) {
			Console.WriteLine(e.Data);
		}

		public void OnError(object sender, DataEventArgs<Exception> e) {
			throw new InvalidOperationException("An error occured in subject of observation", e.Data);
		}

		public void OnCompleted(object sender, EventArgs e) {
			unsubscriber.Dispose();
		}

		public void Dispose() {
			OnCompleted(null, null);
		}
	}
}
