namespace NDice
{
	[System.Serializable]
	public class LabelMissingException : System.Exception
	{
		public LabelMissingException()
		{
		}

		public LabelMissingException(string message) 
			: base(message)
		{
		}

		public LabelMissingException(string message, System.Exception inner) 
			: base(message, inner)
		{
		}

		protected LabelMissingException(
		  System.Runtime.Serialization.SerializationInfo info,
		  System.Runtime.Serialization.StreamingContext context) 
			: base(info, context)
		{
		}
	}
}