namespace Scribbly.Validation.Converters;

/// <summary>
/// 
/// </summary>
/// <typeparam name="TInput"></typeparam>
/// <typeparam name="TOutput"></typeparam>
public interface ITypeConverter<in TInput, out TOutput>
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    public TOutput Convert(TInput input);
}
