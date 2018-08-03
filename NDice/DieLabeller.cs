using System;
using System.Collections.Generic;
using System.Text;

namespace NDice
{
	/// <summary>
	/// Labels a Die roll result to a value of type TLabel
	/// </summary>
    public class DieLabeller<TLabel>
    {
		private readonly IDie die = null;
		private readonly IReadOnlyDictionary<int, TLabel> labels = null;
		private readonly bool throwsIfLabelMissing = false;

		public DieLabeller(IDie die, IReadOnlyDictionary<int, TLabel> labels)
			: this(die, labels, throwsIfLabelMissing: false)
		{
		}

		public DieLabeller(IDie die, IReadOnlyDictionary<int, TLabel> labels, bool throwsIfLabelMissing)
		{
			this.die = die ?? throw new ArgumentNullException(nameof(die), "An IDie instance must be supplied.");
			this.labels = labels ?? throw new ArgumentNullException(nameof(labels), "A sequence of labels must be supplied.");
			this.throwsIfLabelMissing = throwsIfLabelMissing;
		}

		/// <summary>
		/// Rolls a new label
		/// </summary>
		public TLabel Roll() 
		{
			int dieRoll = die.Roll();

			if (!labels.TryGetValue(dieRoll, out TLabel correspondingLabel)) {

				if (throwsIfLabelMissing) throw new LabelMissingException($"No label was provided for value {dieRoll}.");

				return default(TLabel);
			}

			return correspondingLabel;
		}
	}
}
