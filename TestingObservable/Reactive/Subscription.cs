using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TestingObservable.Reactive {
	public class Unsubscriber<T> : IDisposable {
		IList<IObserver<T>> observers;
		IObserver<T> observer;

		public Unsubscriber(IList<IObserver<T>> observers, IObserver<T> observer) {
			this.observers = observers;
			this.observer = observer;
		}

		public void Dispose() {
			if (observer != null && observers.Contains(observer))
				observers.Remove(observer);
		}
	}
}
