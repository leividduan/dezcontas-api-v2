namespace DezContas.API.ViewModel;
public record UserViewModel(
    Guid Id,
    string Name,
    string Username,
    string Email,
    bool IsActive,
    DateTime CreatedAt,
    DateTime UpdatedAt
);

public record UserPostViewModel(
    string Name,
    string Username,
    string Email,
    string Password
);

public record UserPutViewModel(
    Guid Id,
    string Name,
    string Username,
    string Password,
    bool IsActive
);

public record UserLoginViewModel(
    string Username,
    string Password
);
