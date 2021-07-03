﻿using System;

namespace NeutronNetwork.Naughty.Attributes
{
	[AttributeUsage(AttributeTargets.Field, AllowMultiple = true, Inherited = true)]
	public class OnValueChangedAttribute : MetaAttribute
	{
		public string CallbackName { get; private set; }

		public OnValueChangedAttribute(string callbackName)
		{
			CallbackName = callbackName;
		}
	}
}
