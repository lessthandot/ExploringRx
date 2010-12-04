using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using Rhino.Mocks;

namespace TestingObservable.Reactive.Tests {
	[TestFixture]
	public class UnsubscriberTest {
		[Test]
		public void Dispose() {
			var mockery = new MockRepository();
			var observer = mockery.StrictMock<IObserver<string>>();
			var observers = mockery.StrictMock<IList<IObserver<string>>>();
			
			using (mockery.Record()) {
				Expect.Call(observers.Contains(observer)).Return(true);
				Expect.Call(observers.Remove(observer)).Return(true);
			}

			using (mockery.Playback()) {
				var unsubscriber = new Unsubscriber<string>(observers, observer);
				unsubscriber.Dispose();
			}
		}
	}
}
