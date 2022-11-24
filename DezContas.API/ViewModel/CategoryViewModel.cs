using DezContas.Domain.Entities;

namespace DezContas.API.ViewModel;
public record CategoryViewModel(
    Guid Id,
    string Name,
    string Description,
    Transaction.Types Type,
    bool IsActive,
    Guid UserId,
    DateTime CreatedAt,
    DateTime UpdatedAt
);

public record CategoryPostViewModel(
    string Name,
    string Description,
    bool IsActive,
    Transaction.Types Type
);

public record CategoryPutViewModel(
    Guid Id,
    string Name,
    string Description,
    bool IsActive,
    Transaction.Types Type
);
