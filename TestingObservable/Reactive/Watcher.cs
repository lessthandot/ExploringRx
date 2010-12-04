using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TestingObservable.Reactive {
	public class Watcher : IObserver<string> {
		IDisposable unsubscriber;

		public void Subscribe(IObservable<string> subject) {
			if (unsubscriber == null) {
				unsubscriber = subject.Subscribe(this);
			}
			else {
				throw new InvalidOperationException("This observer is already watching an observable!");
			}
		}

		public void OnNext(string next) {
			Console.WriteLine(next);
		}

		public void OnError(Exception ex) {
			throw new InvalidOperationException("An error occured in subject of observation", ex);
		}

		public void OnCompleted() {
			unsubscriber.Dispose();
		}
	}
}
