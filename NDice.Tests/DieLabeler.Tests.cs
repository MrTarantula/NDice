using System;
using System.Collections.Generic;
using Xunit;
using NDice;
using Moq;

namespace NDice.Tests
{
	[Trait("Category", "DieLabeller")]
	public class DieLabellerTests
	{
		[Fact]
		public void DieLabeler_LabelsDieRollProperly()
		{
			Dictionary<int, string> labels = new Dictionary<int, string>
			{
				{2, "Two" },
				{3, "Three" }
			};

			Mock<IDie> dieMock = new Mock<IDie>();

			dieMock.Setup(d => d.Roll()).Returns(2);

			DieLabeler<string> labeler = new DieLabeler<string>(dieMock.Object, labels);

			string actualLabel = labeler.Roll();

			Assert.Equal("Two", actualLabel);
		}

		[Fact]
		public void DieLabeler_ReturnsDefaultTLabelValueWhenLabelIsMissing()
		{
			Dictionary<int, string> labels = new Dictionary<int, string>();

			Mock<IDie> dieMock = new Mock<IDie>();

			dieMock.Setup(d => d.Roll()).Returns(1);

			DieLabeler<string> labeler = new DieLabeler<string>(dieMock.Object, labels);

			string actualLabel = labeler.Roll();

			Assert.Equal(default(string), actualLabel);
		}

		[Fact]
		public void DieLabeler_ThrowaWhenLabelIsMissingIfConfigured()
		{
			Dictionary<int, string> labels = new Dictionary<int, string>();

			Mock<IDie> dieMock = new Mock<IDie>();

			dieMock.Setup(d => d.Roll()).Returns(1);

			DieLabeler<string> labeler = new DieLabeler<string>(dieMock.Object, labels, throwsIfLabelMissing: true);

			Func<string> roll = labeler.Roll;

			Assert.Throws<LabelMissingException>(roll);
		}
	}
}
