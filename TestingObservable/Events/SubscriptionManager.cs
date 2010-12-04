using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TestingObservable.Events {
	//TODO: this could be equivalent to Unsubscriber in reactive model.  Not sure how valuable it is though
	public class SubscriptionManager : IDisposable {
		IWatched subject;
		EventHandler<DataEventArgs<string>> nextHandler;//should really be generic
		EventHandler<DataEventArgs<Exception>> errorHandler;
		EventHandler completeHandler;

		public SubscriptionManager(IWatched toWatch, 
			Action<object, DataEventArgs<string>> nextAction,
			Action<object, DataEventArgs<Exception>> errorAction,
			Action<object, EventArgs> completeAction) {

			this.nextHandler = new EventHandler<DataEventArgs<string>>(nextAction);
			this.errorHandler = new EventHandler<DataEventArgs<Exception>>(errorAction);
			this.completeHandler = new EventHandler(completeAction);

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
