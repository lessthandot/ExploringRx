using System;
using System.Collections.Generic;

namespace ClockMaster3000 {
	class AtomicClock : IObservable<DateTime> {
		IList<IObserver<DateTime>> observers = new List<IObserver<DateTime>>();
		volatile bool keepRunning;

		public IDisposable Subscribe(IObserver<DateTime> observer) {
			observers.Add(observer);
			return observer as IDisposable;
		}

		public void Complete() {
			keepRunning = false;
			foreach (var observer in observers) {
				observer.OnCompleted();
			}
		}

		public void Run() {
			keepRunning = true;
			while (observers.Count > 0 && keepRunning) {
				SendTime();
			}
		}

		void SendTime() {
			foreach (var observer in observers) {
				observer.OnNext(DateTime.UtcNow);
			}
			System.Threading.Thread.Sleep(1000);
		}
	}
}
