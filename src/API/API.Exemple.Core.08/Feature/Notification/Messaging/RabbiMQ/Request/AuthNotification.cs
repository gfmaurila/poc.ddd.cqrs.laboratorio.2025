﻿namespace API.Exemple.Core._08.Feature.Notification.Messaging.RabbiMQ.Request;

public class AuthNotification
{
    public string AccountSid { get; set; }
    public string AuthToken { get; set; }
    public string From { get; set; }
}