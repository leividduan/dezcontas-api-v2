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
  public Guid Id_Account { get; private set; }
  public Guid Id_Category { get; private set; }

  //Relationships
  public Account Account { get; set; }
  public Category Category { get; set; }

  public Transaction()
  {
  }

  public Transaction(string name, string description, int installment, int totalInstallment, bool paid, bool recurring, bool isActive, DateTime date, Guid id_Account, Guid id_Category)
  {
    Name = name;
    Description = description;
    Installment = installment;
    TotalInstallment = totalInstallment;
    Paid = paid;
    Recurring = recurring;
    IsActive = isActive;
    Date = date;
    Id_Account = id_Account;
    Id_Category = id_Category;
  }

  public override bool IsValid()
  {
    return base.IsValid();
  }
}
