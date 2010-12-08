using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TestingObservable.Events {
	public interface IWatched<T> {
		event EventHandler<DataEventArgs<T>> OnNext;
		event EventHandler<DataEventArgs<Exception>> OnError;
		event EventHandler OnCompleted;
		IDisposable Subscribe(IWatcher<T> watcher);
	}

	public class Watched<T> : IWatched<T> {
		public event EventHandler<DataEventArgs<T>> OnNext;
		public event EventHandler<DataEventArgs<Exception>> OnError;
		public event EventHandler OnCompleted;

		public IDisposable Subscribe(IWatcher<T> watcher) {
			return new Subscription<T>(this, watcher) as IDisposable;
		}
		public void Send(T message) {
			if (message == null)  {
				OnError(this, new DataEventArgs<Exception>(new ArgumentNullException("message", "Unable to process null strings")));
				return;
			}
			OnNext(this, new DataEventArgs<T>(message));
		}

		public void EndTransmission() {
			OnCompleted(this, new EventArgs());
		}
	}
}
