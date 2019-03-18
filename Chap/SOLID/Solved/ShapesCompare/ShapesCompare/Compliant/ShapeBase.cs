namespace ShapesCompare.Compliant
{
    public abstract class ShapeBase : IShape
    {
        public override string ToString()
        {
            return $"A {GetType().Name} with an area of {Area.Value:F3}";
        }

        public abstract PositiveDouble Area { get; }
    }
}