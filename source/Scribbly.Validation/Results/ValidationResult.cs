using System.Collections;

namespace Scribbly.Validation;

/// <summary>
/// 
/// </summary>
public class ValidationResult : IReadOnlyCollection<ValidationError>
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="errors"></param>
    /// <returns></returns>
    public static ValidationResult Failure(IEnumerable<ValidationError> errors) => new ValidationResult(errors);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="errors"></param>
    /// <returns></returns>
    public static ValidationResult From(IEnumerable<ValidationError> errors) => new ValidationResult(errors);

    /// <summary>
    /// 
    /// </summary>
    public static ValidationResult Success => new ValidationResult(Array.Empty<ValidationError>());

    /// <summary>
    /// 
    /// </summary>
    public bool IsValid => !Errors.Any();

    /// <summary>
    /// 
    /// </summary>
    public IReadOnlyCollection<ValidationError> Errors { get; private set; }

    /// <summary>
    /// 
    /// </summary>
    private ValidationResult(IEnumerable<ValidationError> errors)
    {
        Errors = errors.ToList();
    }

    /// <inheritdoc />
    public IEnumerator<ValidationError> GetEnumerator()
    {
        return Errors.GetEnumerator();
    }

    /// <inheritdoc />
    IEnumerator IEnumerable.GetEnumerator()
    {
        return ((IEnumerable)Errors).GetEnumerator();
    }

    /// <inheritdoc />
    public int Count => Errors.Count;
}