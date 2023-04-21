using Shapes.Shape;
using Shapes.Enum;
using Xunit;

namespace TestProject.Tests;

public class TriangleTests
{
	[Theory]
	[InlineData(1, 1, 1, TriangleType.Acute)]
	[InlineData(3, 4, 5, TriangleType.Right)]
	[InlineData(0.2, 0.3, 0.47, TriangleType.Obtuse)]
	public void TestTypeWithValidParameters(
		double sideA, double sideB, double sideC, TriangleType expectedType)
	{
		var triangleType = new Triangle(sideA, sideB, sideC).GetTriangleType();
		Assert.Equal(expectedType, triangleType);
	}

	[Theory]
	[InlineData(1, 1, 1, 0.43)]
	[InlineData(64.43, 52.34, 91.3, 1646.98)]
	[InlineData(0.2, 0.3, 0.34, 0.03)]
	public void TestAreaWithValidParameters(
		double sideA, double sideB, double sideC, double expectedArea)
	{
		var area = new Triangle(sideA, sideB, sideC).GetArea();
		Assert.Equal(expectedArea, area, 0.01);
	}

	[Theory]
	[InlineData(1, 1, 1, 3)]
	[InlineData(64.43, 52.34, 91.23, 208)]
	[InlineData(0.23, 0.4, 0.34, 0.97)]
	public void TestPerimeterWithValidParameters(
		double sideA, double sideB, double sideC, double expectedPerimeter)
	{
		var perimeter = new Triangle(sideA, sideB, sideC).GetPerimeter();
		Assert.Equal(expectedPerimeter, perimeter, 0.01);
	}

	[Theory]
	[InlineData(1, 1, 3)]
	[InlineData(1, 1, 2)]
	[InlineData(-5, 3, 4)]
	[InlineData(1, 0, 1)]
	public void TestTriangleConstructor(
		double sideA, double sideB, double sideC)
	{
		Assert.Throws<ArgumentException>(() =>
		{
			var triangle = new Triangle(sideA, sideB, sideC);
		});
	}
}
