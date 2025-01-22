namespace Entities;

public class Account:IEntity
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public string AccountNumber { get; set; }
    public int AccountType { get; set; }
    public decimal Balance { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    
}