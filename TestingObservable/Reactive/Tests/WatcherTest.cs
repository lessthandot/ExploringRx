using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using Rhino.Mocks;

namespace TestingObservable.Reactive.Tests {
	[TestFixture]
	public class WatcherTest {
		[Test]
		public void OnError() {
			var watcher = new Watcher();
			var innerMessage = "a message";
			var outerMessage = "An error occured in subject of observation";

			var thrown = Assert.Throws(
				typeof(InvalidOperationException),
				() => watcher.OnError(new BadImageFormatException(innerMessage)));

			Assert.AreEqual(outerMessage, thrown.Message);
			//carries inner exception from subject
			Assert.IsNotNull(thrown.InnerException);
			Assert.IsInstanceOf<BadImageFormatException>(thrown.InnerException);
			Assert.AreEqual(innerMessage, thrown.InnerException.Message);
		}

		[Test]
		public void Subscribe() {
			var mockery = new MockRepository();
			var subject = mockery.StrictMock<IObservable<string>>();
			var disposable = mockery.StrictMock<IDisposable>();

			var watcher = new Watcher();

			using (mockery.Record()) {
				Expect.Call(subject.Subscribe(watcher)).Return(disposable);
				disposable.Dispose();
			}

			using (mockery.Playback()){
				watcher.Subscribe(subject);
				watcher.OnCompleted();
			}
		}

		[Test]
		public void Subscribe_Cannot_Subscribe_Twice() {
			var mockery = new MockRepository();
			var subject = mockery.StrictMock<IObservable<string>>();
			var disposable = mockery.StrictMock<IDisposable>();

			var watcher = new Watcher();

			var message = "This observer is already watching an observable!";

			using (mockery.Record()) {
				Expect.Call(subject.Subscribe(watcher)).Return(disposable);
			}

			using (mockery.Playback()) {
				watcher.Subscribe(subject);

				var thrown = Assert.Throws(
				typeof(InvalidOperationException),
					() => watcher.Subscribe(subject));

				Assert.AreEqual(message, thrown.Message);
			}
		}
	}
}
