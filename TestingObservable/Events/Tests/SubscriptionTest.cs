﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using Rhino.Mocks;

namespace TestingObservable.Events.Tests {
	[TestFixture]
	public class SubscriptionTest {
		[Test]
		public void Construct_Dispose() {
			var mockery = new MockRepository();
			var watcher = mockery.StrictMock<IWatcher<string>>();
			var watched = mockery.StrictMock<IWatched<string>>();
			

			using (mockery.Record()) {
				watched.OnNext += new EventHandler<DataEventArgs<string>>(watcher.OnNext);
				watched.OnError += new EventHandler<DataEventArgs<Exception>>(watcher.OnError);
				watched.OnCompleted += new EventHandler(watcher.OnCompleted);

				watched.OnNext -= new EventHandler<DataEventArgs<string>>(watcher.OnNext);
				watched.OnError -= new EventHandler<DataEventArgs<Exception>>(watcher.OnError);
				watched.OnCompleted -= new EventHandler(watcher.OnCompleted);
			}

			using (mockery.Playback()) {
				var unsubscriber = new Subscription<string>(watched, watcher);
				unsubscriber.Dispose();
			}
		}
	}
}
