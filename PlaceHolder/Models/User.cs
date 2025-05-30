﻿namespace PlaceHolder.Models
{
    public class User
    {
        public int Id { get; set; }
        public string? Email { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Avatar { get; set; }
        public Support? Support { get; set; }
    }

    public class Support
    {
        public string? Url { get; set; }
    }
}
