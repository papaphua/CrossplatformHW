﻿namespace CrossplatformHW.Server.Services.MailService;

public interface IMailService
{
    Task SendEmailAsync(string receiver, string text);
}