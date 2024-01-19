namespace SlaSystem.Domain.Primitives;

/// A value object is a type that is defined only by it's values
/// If two value objects has the same value they considered equal
/// They are immutable by design
public abstract class ValueObject : IEquatable<ValueObject>
{
    /// <summary>
    /// This method will define what are the components 
    /// that defines the value object structure.
    /// </summary>
    /// <returns> IEnumerable<object />
    /// </returns>
    public abstract IEnumerable<object> GetAtomicValues();

    public override bool Equals(object? obj) => obj is ValueObject other && ValuesAreEqual(other);

    public override int GetHashCode() =>
        GetAtomicValues()
            .Aggregate(
                default(int),
                HashCode.Combine);


    /// <param name="other"></param>
    /// <returns>
    ///     True if the atomic values of the passed object and the current the same
    ///     With the consideration of the ordering of these values.
    /// </returns>
    private bool ValuesAreEqual(ValueObject other)
    {
        return GetAtomicValues().SequenceEqual(other.GetAtomicValues());
    }

    public bool Equals(ValueObject? other)
    {
        return other is not null && ValuesAreEqual(other);
    }
}
