using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using Rhino.Mocks;

namespace TestingObservable.Events.Tests {
	[TestFixture]
	public class UnsubscriberTest {
		[Test]
		public void Dispose() {
			var mockery = new MockRepository();
			var watcher = mockery.StrictMock<IWatcher>();
			var watched = mockery.StrictMock<IWatched>();
			

			using (mockery.Record()) {
				watched.OnNext += new EventHandler<DataEventArgs<string>>(watcher.Subject_OnNext);
				watched.OnError += new EventHandler<DataEventArgs<Exception>>(watcher.Subject_OnError);
				watched.OnCompleted += new EventHandler(watcher.Subject_OnCompleted);

				watched.OnNext -= new EventHandler<DataEventArgs<string>>(watcher.Subject_OnNext);
				watched.OnError -= new EventHandler<DataEventArgs<Exception>>(watcher.Subject_OnError);
				watched.OnCompleted -= new EventHandler(watcher.Subject_OnCompleted);
			}

			using (mockery.Playback()) {
				var unsubscriber = new Unsubscriber(watched, watcher);
				unsubscriber.Dispose();
			}
		}
	}
}
