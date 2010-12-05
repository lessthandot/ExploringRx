using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TestingObservable.Events {
	//TODO: this could be equivalent to Unsubscriber in reactive model.  Not sure how valuable it is though
	public class Unsubscriber : IDisposable {
		IWatched subject;
		EventHandler<DataEventArgs<string>> nextHandler;//should really be generic
		EventHandler<DataEventArgs<Exception>> errorHandler;
		EventHandler completeHandler;

		public Unsubscriber(IWatched toWatch, 
			IWatcher watcher) {

			this.nextHandler = new EventHandler<DataEventArgs<string>>(watcher.Subject_OnNext);
			this.errorHandler = new EventHandler<DataEventArgs<Exception>>(watcher.Subject_OnError);
			this.completeHandler = new EventHandler(watcher.Subject_OnCompleted);

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
