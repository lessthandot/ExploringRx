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
		IDisposable subscription;

		public void Subscribe(IWatched subject) {
			if (subscription != null) {
				throw new InvalidOperationException("This watcher is already observing a subject!");
			}
			subscription = subject.Subscribe(this);
		}

		public void OnNext(object sender, DataEventArgs<string> e) {
			Console.WriteLine(e.Data);
		}

		public void OnError(object sender, DataEventArgs<Exception> e) {
			throw new InvalidOperationException("An error occured in subject of observation", e.Data);
		}

		public void OnCompleted(object sender, EventArgs e) {
			subscription.Dispose();
		}

		public void Dispose() {
			OnCompleted(null, null);
		}
	}
}
