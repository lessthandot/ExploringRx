using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TestingObservable.Events {
	class Watcher : IDisposable {
		internal EventHandler<DataEventArgs<string>> nextHandler;
		internal EventHandler<DataEventArgs<Exception>> errorHandler;
		internal EventHandler completeHandler;
		IWatched subject;
		SubscriptionManager manager;

		public Watcher() {
			nextHandler = new EventHandler<DataEventArgs<string>>(Subject_OnNext);
			errorHandler = new EventHandler<DataEventArgs<Exception>>(Subject_OnError);
			completeHandler = new EventHandler(Subject_OnCompleted);
		}

		public IDisposable Subscribe(IWatched toWatch) {
			if (subject == null) {//weak attempt to prevent subscribing multiple times to same subject
				subject = toWatch;

				subject.OnNext += nextHandler;
				subject.OnError += errorHandler;
				subject.OnCompleted += completeHandler;

				return (IDisposable)this;
			}
			throw new InvalidOperationException("This watcher is already observing a subject!");
		}

		void Subject_OnNext(object sender, DataEventArgs<string> e) {
			Console.WriteLine(e.Data);
		}

		void Subject_OnError(object sender, DataEventArgs<Exception> e) {
			throw new InvalidOperationException("An error occured in subject of observation", e.Data);
		}

		void Subject_OnCompleted(object sender, EventArgs e) {
			subject.OnNext -= nextHandler;
			subject.OnError -= errorHandler;
			subject.OnCompleted -= completeHandler;
			subject = null;
		}

		public void Dispose() {
			Subject_OnCompleted(null, null);
		}
	}
}
