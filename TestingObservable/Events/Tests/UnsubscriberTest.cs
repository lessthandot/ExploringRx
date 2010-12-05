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
				watched.OnNext += new EventHandler<DataEventArgs<string>>(watcher.OnNext);
				watched.OnError += new EventHandler<DataEventArgs<Exception>>(watcher.OnError);
				watched.OnCompleted += new EventHandler(watcher.OnCompleted);

				watched.OnNext -= new EventHandler<DataEventArgs<string>>(watcher.OnNext);
				watched.OnError -= new EventHandler<DataEventArgs<Exception>>(watcher.OnError);
				watched.OnCompleted -= new EventHandler(watcher.OnCompleted);
			}

			using (mockery.Playback()) {
				var unsubscriber = new Unsubscriber(watched, watcher);
				unsubscriber.Dispose();
			}
		}
	}
}
