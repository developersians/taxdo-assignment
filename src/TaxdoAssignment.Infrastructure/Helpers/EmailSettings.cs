﻿namespace TaxdoAssignment.Infrastructure;

public class EmailSettings
{
    public string SmtpServer { get; set; } = "smtp.gmail.com";
    public int Port { get; set; } = 587;
    public string Username { get; set; }
    public string Password { get; set; }
    public string FromEmail { get; set; }
    public string FromName { get; set; }
    public bool UseSsl { get; set; } = true;
}
