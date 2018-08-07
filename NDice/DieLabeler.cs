using System;
using System.Collections.Generic;
using System.Text;

namespace NDice
{
	/// <summary>
	/// Labels a Die roll result to a value of type TLabel
	/// </summary>
    public class DieLabeler<TLabel>
    {
		private readonly IDie _die = null;
		private readonly IReadOnlyDictionary<int, TLabel> _labels = null;
		private readonly bool _throwsIfLabelMissing = false;

		public DieLabeler(IDie die, IReadOnlyDictionary<int, TLabel> labels)
			: this(die, labels, throwsIfLabelMissing: false)
		{
		}

		public DieLabeler(IDie die, IReadOnlyDictionary<int, TLabel> labels, bool throwsIfLabelMissing)
		{
			_die = die;
			_labels = labels;
			_throwsIfLabelMissing = throwsIfLabelMissing;
		}

		/// <summary>
		/// Rolls a new label
		/// </summary>
		public TLabel Roll() 
		{
			int dieRoll = _die.Roll();

			if (!_labels.TryGetValue(dieRoll, out TLabel correspondingLabel)) {

				if (_throwsIfLabelMissing) throw new LabelMissingException($"No label was provided for value {dieRoll}.");

				return default(TLabel);
			}

			return correspondingLabel;
		}
	}
}
