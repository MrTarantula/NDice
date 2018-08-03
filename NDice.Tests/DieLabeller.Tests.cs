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
		public void DieLabeller_LabelsDieRollProperly()
		{
			Dictionary<int, string> labels = new Dictionary<int, string>
			{
				{2, "Two" },
				{3, "Three" }
			};

			Mock<IDie> dieMock = new Mock<IDie>();

			dieMock.Setup(d => d.Roll()).Returns(2);

			DieLabeller<string> labeller = new DieLabeller<string>(dieMock.Object, labels);

			string actualLabel = labeller.Roll();

			Assert.Equal("Two", actualLabel);
		}

		[Fact]
		public void DieLabeller_ReturnsDefaultTLabelValueWhenLabelIsMissing()
		{
			Dictionary<int, string> labels = new Dictionary<int, string>();

			Mock<IDie> dieMock = new Mock<IDie>();

			dieMock.Setup(d => d.Roll()).Returns(1);

			DieLabeller<string> labeller = new DieLabeller<string>(dieMock.Object, labels);

			string actualLabel = labeller.Roll();

			Assert.Equal(default(string), actualLabel);
		}

		[Fact]
		public void DieLabeller_ThrowaWhenLabelIsMissingIfConfigured()
		{
			Dictionary<int, string> labels = new Dictionary<int, string>();

			Mock<IDie> dieMock = new Mock<IDie>();

			dieMock.Setup(d => d.Roll()).Returns(1);

			DieLabeller<string> labeller = new DieLabeller<string>(dieMock.Object, labels, throwsIfLabelMissing: true);

			Func<string> roll = labeller.Roll;

			Assert.Throws<LabelMissingException>(roll);
		}
	}
}
