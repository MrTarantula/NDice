using System;
using System.Runtime.Serialization;

namespace NDice
{
	[Serializable]
	public class LabelMissingException : Exception
	{
		public LabelMissingException()
		{
		}

		public LabelMissingException(string message) 
			: base(message)
		{
		}

		public LabelMissingException(string message, Exception inner) 
			: base(message, inner)
		{
		}

		protected LabelMissingException(SerializationInfo info, StreamingContext context) 
			: base(info, context)
		{
		}
	}
}