using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using Rhino.Mocks;
using Rhino.Mocks.Constraints;

namespace TestingObservable.Events.Tests {
	[TestFixture]
	public class WatcherTest {
		[Test]
		public void OnError() {
			var watcher = new Watcher();
			var innerMessage = "a message";
			var outerMessage = "An error occured in subject of observation";

			var thrown = Assert.Throws(
				typeof(InvalidOperationException),
				() => watcher.errorHandler(null, new DataEventArgs<Exception>(new BadImageFormatException(innerMessage))));

			Assert.AreEqual(outerMessage, thrown.Message);
			//carries inner exception from subject
			Assert.IsNotNull(thrown.InnerException);
			Assert.IsInstanceOf<BadImageFormatException>(thrown.InnerException);
			Assert.AreEqual(innerMessage, thrown.InnerException.Message);
		}

		[Test]
		public void Subscribe_And_Unsubscribe_On_Complete() {
			var mockery = new MockRepository();
			var subject = mockery.StrictMock<IWatched>();

			var watcher = new Watcher();

			using (mockery.Record()) {
				subject.OnCompleted += watcher.completeHandler;
				subject.OnError += watcher.errorHandler;
				subject.OnNext += watcher.nextHandler;

				subject.OnCompleted -= watcher.completeHandler;
				subject.OnError -= watcher.errorHandler;
				subject.OnNext -= watcher.nextHandler;
			}

			using (mockery.Playback()) {
				watcher.Subscribe(subject);
				watcher.completeHandler(null, null);
			}
		}

		[Test]
		public void Subscribe_Cannot_Subscribe_Twice() {
			var mockery = new MockRepository();
			var subject = mockery.StrictMock<IWatched>();

			var watcher = new Watcher();

			var message = "This watcher is already observing a subject!";

			using (mockery.Record())
			using (mockery.Ordered()) {
				subject.OnNext += watcher.nextHandler;
				subject.OnError += watcher.errorHandler;
				subject.OnCompleted += watcher.completeHandler;
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
