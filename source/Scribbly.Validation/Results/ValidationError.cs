namespace Scribbly.Validation;

/// <summary>
/// 
/// </summary>
/// <param name="Key"></param>
/// <param name="Issues"></param>
public sealed record ValidationError(string Key, params string[] Issues);

/// <summary>
/// 
/// </summary>
/// <typeparam name="TData"></typeparam>
public interface IValidator<in TData> where TData : class
{
    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public ValidationResult Validate(TData data);
}

/// <summary>
/// 
/// </summary>
/// <typeparam name="TData"></typeparam>
public interface IAsyncValidator<TData> where TData : class
{
    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public Task<ValidationResult> ValidateAsync();
}