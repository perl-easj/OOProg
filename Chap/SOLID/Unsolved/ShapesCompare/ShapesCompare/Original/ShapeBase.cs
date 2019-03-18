namespace ShapesCompare.Original
{
    /// <summary>
    /// Shape base class, just overrides ToString
    /// </summary>
    public abstract class ShapeBase : IShape
    {
        public override string ToString()
        {
            return $"A {GetType().Name} with an area of {Area:F3}";
        }

        public abstract double Area { get; }
    }
}