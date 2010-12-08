using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using Rhino.Mocks;
using Rhino.Mocks.Constraints;
using Is = Rhino.Mocks.Constraints.Is;

namespace TestingObservable.Events.Tests {
	[TestFixture]
	public class WatchedTest {
		[Test]
		public void Send() {
			var watched = new Watched<string>();

			var onNextCalled = false;

			watched.OnNext += (sender, e) => onNextCalled = true;

			watched.Send("something");

			Assert.IsTrue(onNextCalled);
		}

		[Test]
		public void Send_Multiple_Messages() {
			var watched = new Watched<string>();

			var callCount = 0;

			watched.OnNext += (sender, e) => callCount ++;

			watched.Send("something");
			watched.Send("something else");

			Assert.AreEqual(2, callCount);
		}

		[Test]
		public void Send_Errors_When_String_Is_Null() {
			var watched = new Watched<string>();

			var wasErrorCalled = false;

			watched.OnError += (sender, e) => wasErrorCalled = true;

			watched.Send(null);

			Assert.IsTrue(wasErrorCalled);
		}

		[Test]
		public void EndTransmission() {
			var watched = new Watched<string>();

			var onCompletedCalled = false;

			watched.OnCompleted += (sender, e) => onCompletedCalled = true;

			watched.EndTransmission();

			Assert.IsTrue(onCompletedCalled);
		}
	}
}
