﻿namespace DrWizardry.Models
{
    public class User
    {
        public int UserId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        
        public List<Vocab> Vocabs { get; set; }
    }
}
