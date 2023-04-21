using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shapes.Enum;
namespace Shapes.Shape;


public record Circle : IShape
{
	public double Radius { get; }

	public Circle(double radius)
	{
		if (radius <= 0)
		{
			throw new ArgumentException("Радиус не может быть меньше нуля");
		}

		Radius = radius;
	}

	public double GetPerimeter() => 2 * Math.PI * Radius;

	public double GetArea() => Math.PI * Radius * Radius;
}
