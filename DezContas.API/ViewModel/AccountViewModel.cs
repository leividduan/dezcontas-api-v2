using DezContas.Domain.Entities;

namespace DezContas.API.ViewModel;
public record AccountViewModel(
    Guid Id,
    string Name,
    string Description,
    bool IsDefault,
    bool IsActive,
    Account.Types Type,
    Guid UserId,
    DateTime CreatedAt,
    DateTime UpdatedAt
);

public record AccountPostViewModel(
    string Name,
    string Description,
    bool IsDefault,
    bool IsActive,
    Account.Types Type
);

public record AccountPutViewModel(
    Guid Id,
    string Name,
    string Description,
    bool IsDefault,
    bool IsActive,
    Account.Types Type
);
