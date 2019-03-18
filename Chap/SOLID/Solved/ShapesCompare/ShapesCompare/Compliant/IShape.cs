namespace ShapesCompare.Compliant
{
    public interface IShape
    {
        /// <summary>
        /// Contract: will return a positive value.
        /// </summary>
        PositiveDouble Area { get; }
    }
}