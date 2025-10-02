﻿namespace Domain.Entities;

public class UserConfirm
{
    public long ConfirmerId { get; set; }
    public string Email { get; set; }
    public bool IsConfirmed { get; set; }
    public string ConfirmingCode { get; set; }
    public DateTime ExpiredDate { get; set; }

    public long UserId { get; set; }
    public User User { get; set; }
}
