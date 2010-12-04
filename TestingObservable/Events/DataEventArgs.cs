using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TestingObservable.Events {
	public class DataEventArgs<T> : EventArgs {
		public DataEventArgs(T data) : base() {
			this.Data = data;
		}
		public T Data { get; set; }
	}
}
