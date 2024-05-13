﻿using Rumassa.Domain.Entities.Auth;
using System.Reflection.Metadata;

namespace Rumassa.Domain.Entities;

public class Comment
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public string TelegramLogin { get; set; }
    public string Text { get; set; }
    public Guid? UserId { get; set; }
    public virtual User? User { get; set; }


}