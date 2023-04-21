using Shapes.Enum;

namespace Shapes.Shape;

public record Triangle : IShape
{
	public double LargeSide { get; }
	public double MediumSide { get; }
	public double SmallSide { get; }

	public Triangle(double sideA, double sideB, double sideC)
	{
		var arr = new[] { sideA, sideB, sideC };
		if (arr.Any(x => x <= 0))
		{
			throw new ArgumentException("Triangle sides must be positive numbers");
		}

		Array.Sort(arr);

		LargeSide = arr[2];
		MediumSide = arr[1];
		SmallSide = arr[0];

		if (LargeSide >= MediumSide + SmallSide)
		{
			throw new ArgumentException("Invalid triangle");
		}
	}

	public double GetPerimeter() => SmallSide + MediumSide + LargeSide;

	public double GetArea()
	{
		var p = GetPerimeter() / 2;
		return Math.Sqrt(p * (p - LargeSide) * (p - MediumSide) * (p - SmallSide));
	}

	public TriangleType GetTriangleType() =>
		(LargeSide * LargeSide -
		 SmallSide * SmallSide -
		 MediumSide * MediumSide)
			switch
		{
			> Accuracy => TriangleType.Obtuse,
			< Accuracy and > -Accuracy => TriangleType.Right,
			< -Accuracy => TriangleType.Acute,
			_ => throw new ArgumentOutOfRangeException()
		};

	private const double Accuracy = 0.01;
}
