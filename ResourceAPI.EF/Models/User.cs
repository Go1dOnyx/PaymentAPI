using System;
using System.Collections.Generic;

namespace ResourceAPI.EF.Models;

public partial class User
{
    public int UserId { get; set; }

    public string Username { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string Password { get; set; } = null!;

    public string FirstName { get; set; } = null!;

    public string? MiddleName { get; set; }

    public string LastName { get; set; } = null!;

    public bool Status { get; set; }

    public User(int userId, string user, string email, string pass, string first, string middle, string last, bool status) 
    {
        UserId = userId;
        Username = user;
        Email = email;
        Password = pass;
        FirstName = first;
        MiddleName = middle;
        LastName = last;
        Status = status;
    }
    public User() { }
}
