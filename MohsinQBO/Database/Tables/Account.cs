using System;
using System.ComponentModel.DataAnnotations;

public class Account
{
    [Key]
    public int Id { get; set; }

    [Required]
    public string AccessToken { get; set; } = string.Empty;

    [Required]
    public string RefreshToken { get; set; } = string.Empty;

    [Required]
    public string DatabaseConnectionString { get; set; } = string.Empty;
    public string SyncStatus { get; set; } = string.Empty;

    [Required]
    public string CompanyName { get; set; } = string.Empty;
    public string RealmId { get; set; } = string.Empty;

    public DateTime? LastSyncDate { get; set; }
    public DateTime? CreatedDate { get; set; }
    public DateTime? UpdatedDate { get; set; }

    public bool ConnectionStatus { get; set; }
}
