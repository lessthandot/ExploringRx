using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using Rhino.Mocks;
using Rhino.Mocks.Constraints;
using Is = Rhino.Mocks.Constraints.Is;

namespace TestingObservable.Tests {
	[TestFixture]
	public class WatchedTest {
		[Test]
		public void Send() {
			var mockery = new MockRepository();
			var subscriber = mockery.StrictMock<IObserver<string>>();

			var message = "test message";

			var watched = new Watched();

			using (mockery.Record()) {
				subscriber.OnNext(message);
			}

			using (mockery.Playback())
			using (var unsubscriber = watched.Subscribe(subscriber)) {
				watched.Send(message);
			}
		}

		[Test]
		public void Send_Multiple_Messages() {
			var mockery = new MockRepository();
			var subscriber = mockery.StrictMock<IObserver<string>>();

			var message = "test message";
			var message2 = "another test message";

			var watched = new Watched();

			using (mockery.Record())
			using (mockery.Ordered()) {
				subscriber.OnNext(message);
				subscriber.OnNext(message2);
			}

			using (mockery.Playback())
			using (var unsubscriber = watched.Subscribe(subscriber)) {
				watched.Send(message);
				watched.Send(message2);
			}
		}

		[Test]
		public void Send_Throws_When_String_Is_Null() {
			var mockery = new MockRepository();
			var subscriber = mockery.StrictMock<IObserver<string>>();

			string message = null;

			var watched = new Watched();

			using (mockery.Record()) {
				subscriber.OnError(new InvalidOperationException());
				LastCall.IgnoreArguments();
				LastCall.Constraints(Is.TypeOf(typeof(ArgumentNullException))
					&& Property.Value("Message", "Unable to process null strings\r\nParameter name: message"));
			}

			using (mockery.Playback())
			using (var unsubscriber = watched.Subscribe(subscriber)) {
				watched.Send(message);
			}
		}

		[Test]
		public void EndTransmission() {
			var mockery = new MockRepository();
			var subscriber = mockery.StrictMock<IObserver<string>>();

			string message = null;

			var watched = new Watched();

			using (mockery.Record()) {
				subscriber.OnCompleted();
			}

			using (mockery.Playback())
			using (var unsubscriber = watched.Subscribe(subscriber)) {
				watched.EndTransmission();
			}
		}
	}
}
