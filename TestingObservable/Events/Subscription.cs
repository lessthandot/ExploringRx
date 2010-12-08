using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TestingObservable.Events {
	//TODO: this could be equivalent to Unsubscriber in reactive model.  Not sure how valuable it is though
	public class Subscription<T> : IDisposable {
		IWatched<T> subject;
		EventHandler<DataEventArgs<T>> nextHandler;//should really be generic
		EventHandler<DataEventArgs<Exception>> errorHandler;
		EventHandler completeHandler;

		public Subscription(IWatched<T> toWatch, 
			IWatcher<T> watcher) {

			this.nextHandler = new EventHandler<DataEventArgs<T>>(watcher.OnNext);
			this.errorHandler = new EventHandler<DataEventArgs<Exception>>(watcher.OnError);
			this.completeHandler = new EventHandler(watcher.OnCompleted);

			subject = toWatch;

			subject.OnNext += nextHandler;
			subject.OnError += errorHandler;
			subject.OnCompleted += completeHandler;
		}

		public void Dispose() {
			subject.OnNext -= nextHandler;
			subject.OnError -= errorHandler;
			subject.OnCompleted -= completeHandler;
			subject = null;
		}
	}
}
