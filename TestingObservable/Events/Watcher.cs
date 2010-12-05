using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TestingObservable.Events {
	public interface IWatcher {
		void Subject_OnCompleted(object sender, EventArgs e);
		void Subject_OnError(object sender, DataEventArgs<Exception> e);
		void Subject_OnNext(object sender, DataEventArgs<string> e);
	}

	public class Watcher : IDisposable, TestingObservable.Events.IWatcher {
		internal EventHandler<DataEventArgs<string>> nextHandler;
		internal EventHandler<DataEventArgs<Exception>> errorHandler;
		internal EventHandler completeHandler;
		IWatched subject;
		IDisposable unsubscriber;

		public Watcher() {
			nextHandler = new EventHandler<DataEventArgs<string>>(Subject_OnNext);
			errorHandler = new EventHandler<DataEventArgs<Exception>>(Subject_OnError);
			completeHandler = new EventHandler(Subject_OnCompleted);
		}

		public void Subscribe(IWatched subject) {
			if (unsubscriber != null) {
				throw new InvalidOperationException("This watcher is already observing a subject!");
			}
			unsubscriber = subject.Subscribe(this);
		}

		public void Subject_OnNext(object sender, DataEventArgs<string> e) {
			Console.WriteLine(e.Data);
		}

		public void Subject_OnError(object sender, DataEventArgs<Exception> e) {
			throw new InvalidOperationException("An error occured in subject of observation", e.Data);
		}

		public void Subject_OnCompleted(object sender, EventArgs e) {
			unsubscriber.Dispose();
		}

		public void Dispose() {
			Subject_OnCompleted(null, null);
		}
	}
}
