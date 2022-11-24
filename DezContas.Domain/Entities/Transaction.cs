using DezContas.Domain.Entities.Validators;

namespace DezContas.Domain.Entities;

public class Transaction : Entity
{
  public enum Types
  {
    Expense = 1,
    Income = 2,
    Transference = 3,
  }

  public string Name { get; private set; }
  public string Description { get; private set; }
  public int Installment { get; private set; }
  public int TotalInstallment { get; private set; }
  public bool Paid { get; private set; }
  public bool Recurring { get; private set; }
  public bool IsActive { get; private set; }
  public DateTime Date { get; private set; }
  public Guid AccountId { get; private set; }
  public Guid CategoryId { get; private set; }

  //Relationships
  public Account Account { get; set; }
  public Category Category { get; set; }

  public Transaction()
  {
  }

  public Transaction(string name, string description, int installment, int totalInstallment, bool paid, bool recurring, bool isActive, DateTime date, Guid accountId, Guid categoryId)
  {
    Name = name;
    Description = description;
    Installment = installment;
    TotalInstallment = totalInstallment;
    Paid = paid;
    Recurring = recurring;
    IsActive = isActive;
    Date = date;
    AccountId = accountId;
    CategoryId = categoryId;
  }

  public override bool IsValid()
  {
    ValidationResult = new TransactionValidator().Validate(this);
    return ValidationResult.IsValid;
  }
}
