﻿// Decompiled with JetBrains decompiler
// Type: TseClient.ServerSerive.LastPossibleDevenCompletedEventArgs
// Assembly: TseClient, Version=2.0.16.0, Culture=neutral, PublicKeyToken=null
// MVID: 55DBD486-C597-460B-B54A-EAFCAFB4B891
// Assembly location: D:\Program Files\TseClient 2.0\TseClient.exe

using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;

namespace TseClient.ServerSerive {
	[DesignerCategory("code")]
	[GeneratedCode("System.Web.Services", "4.0.30319.1")]
	[DebuggerStepThrough]
	public class LastPossibleDevenCompletedEventArgs : AsyncCompletedEventArgs {
		private object[] results;

		internal LastPossibleDevenCompletedEventArgs(
			object[] results,
			Exception exception,
			bool cancelled,
			object userState)
			: base(exception, cancelled, userState) {
			this.results = results;
		}

		public string Result {
			get {
				this.RaiseExceptionIfNecessary();
				return (string)this.results[0];
			}
		}
	}
}
