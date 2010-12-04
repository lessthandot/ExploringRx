using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TestingObservable {
	public class Watched : IObservable<string> {
		List<IObserver<string>> watchers = new List<IObserver<string>>();

		public IDisposable Subscribe(IObserver<string> watcher) {
			watchers.Add(watcher);
			return new Unsubscriber<string>(watchers, watcher);
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
	}
}
