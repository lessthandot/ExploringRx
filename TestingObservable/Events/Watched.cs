using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TestingObservable.Events {
	public interface IWatched {
		event EventHandler<DataEventArgs<string>> OnNext;
		event EventHandler<DataEventArgs<Exception>> OnError;
		event EventHandler OnCompleted;
		IDisposable Subscribe(IWatcher watcher);
	}

	public class Watched : IWatched {
		public event EventHandler<DataEventArgs<string>> OnNext;
		public event EventHandler<DataEventArgs<Exception>> OnError;
		public event EventHandler OnCompleted;

		public IDisposable Subscribe(IWatcher watcher) {
			return new Subscription(this, watcher) as IDisposable;
		}
		public void Send(string message) {
			if (message == null)  {
				OnError(this, new DataEventArgs<Exception>(new ArgumentNullException("message", "Unable to process null strings")));
				return;
			}
			OnNext(this, new DataEventArgs<string>(message));
		}

		public void EndTransmission() {
			OnCompleted(this, new EventArgs());
		}
	}
}
