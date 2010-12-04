using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TestingObservable {
	public class Watched : IObservable<string> {
		List<IObserver<string>> watchers = new List<IObserver<string>>();

		public IDisposable Subscribe(IObserver<string> watcher) {
			watchers.Add(watcher);
			return new Unsubscriber(watchers, watcher);
		}

		public void Send(string message) {
			if (message == null) {
				watchers.ForEach(x => x.OnError(new ArgumentNullException("message", "Unable to process null strings")));
				return;
			}

			watchers.ForEach(x => x.OnNext(message));
		}

		public void EndTransmission() {
			watchers.ForEach(x => x.OnCompleted());
		}

		class Unsubscriber : IDisposable {
			private List<IObserver<string>> observers;
			private IObserver<string> observer;

			public Unsubscriber(List<IObserver<string>> observers, IObserver<string> observer) {
				this.observers = observers;
				this.observer = observer;
			}

			public void Dispose() {
				if (observer != null && observers.Contains(observer))
					observers.Remove(observer);
			}
		}
	}
}
