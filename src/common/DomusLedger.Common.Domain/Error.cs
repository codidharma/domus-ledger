﻿namespace DomusLedger.Common.Domain;

public record Error(string Code, string Description, ErrorType ErrorType)
{
    public static Error Failure(string code, string description)
        => new(code, description, ErrorType.Failure);

    public static Error NotFound(string code, string description)
        => new(code, description, ErrorType.NotFound);

    public static Error Conflict(string code, string description)
        => new(code, description, ErrorType.Conflict);

    public static Error InvalidDomain(string code, string description)
        => new(code, description, ErrorType.InvalidDomain);

    public static Error None => new(string.Empty, string.Empty, ErrorType.None);

    public static Error NullValue(string description) => new("Error.NullValue", description, ErrorType.Failure);
}
