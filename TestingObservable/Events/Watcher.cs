using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TestingObservable.Events {
	public interface IWatcher<T> {
		void OnCompleted(object sender, EventArgs e);
		void OnError(object sender, DataEventArgs<Exception> e);
		void OnNext(object sender, DataEventArgs<T> e);
	}

	public class Watcher<T> : IWatcher<T>, IDisposable {
		IDisposable subscription;

		public void Subscribe(IWatched<T> subject) {
			if (subscription != null) {
				throw new InvalidOperationException("This watcher is already observing a subject!");
			}
			subscription = subject.Subscribe(this);
		}

		public void OnNext(object sender, DataEventArgs<T> e) {
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
