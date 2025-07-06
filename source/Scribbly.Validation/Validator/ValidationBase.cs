using System.Linq.Expressions;
using System.Reflection;

namespace Scribbly.Validation;

/// <summary>
/// 
/// </summary>
/// <typeparam name="TData"></typeparam>
public abstract class ValidationBase<TData> : IValidator<TData> where TData : class
{
    private IList<Func<TData, List<ValidationError>>> _valdatorsFuncs = [];

    /// <summary>
    /// 
    /// </summary>
    protected ValidationBase()
    {

    }

    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="TProperty"></typeparam>
    /// <param name="selector"></param>
    /// <returns></returns>
    /// <exception cref="ArgumentException"></exception>
    protected IRuleBuilder RuleFor<TProperty>(Expression<Func<TData, TProperty>> selector)
    {
        if (selector.Body is not MemberExpression { Member: PropertyInfo propertyInfo })
        {
            throw new ArgumentException("The selector must target a property.", nameof(selector));
        }

        return new RuleBuilder();
    }


    /// <inheritdoc />
    public ValidationResult Validate(TData data)
    {
        var results = new List<ValidationError>();

        foreach (var validatorsFunc in _valdatorsFuncs)
        {
            var result = validatorsFunc(data);

            results.AddRange(result);
        }

        return ValidationResult.From(results);
    }
}