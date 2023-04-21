using Shapes.Shape;
using Xunit;
namespace TestProject.Tests;
public class CircleTests
{
	[Theory]
	[InlineData(1, 3.14)]
	[InlineData(64.43, 13041.46)]
	[InlineData(0.2, 0.13)]
	public void TestAreaWithValidParams(double radius, double expectedArea)
	{
		var area = new Circle(radius).GetArea();
		Assert.Equal(expectedArea, area, 0.01);
	}

	[Theory]
	[InlineData(1, 6.28)]
	[InlineData(64.43, 404.83)]
	[InlineData(0.2, 1.26)]
	public void TestPerimeterWithValidP(double radius, double expectedPerimeter)
	{
		var perimeter = new Circle(radius).GetPerimeter();
		Assert.Equal(expectedPerimeter, perimeter, 0.01);
	}

	[Theory]
	[InlineData(-1)]
	[InlineData(-178.63)]
	[InlineData(0)]
	public void TestConstructor(double radius)
	{
		Assert.Throws<ArgumentException>(() =>
		{
			var circle = new Circle(radius);
		});
	}
}
