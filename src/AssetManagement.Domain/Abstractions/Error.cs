namespace AssetManagement.Domain.Abstractions;



public record Error(string Code, string Name)
{
    public static Error None = new(string.Empty, string.Empty);

    public static Error NullValue = new("Error.NullValue", "Null value was provided");

    public static Error NotFound(string code, string message) =>
        new(code, message);

    public static Error Validation(string code, string message) =>
        new(code, message);
}
