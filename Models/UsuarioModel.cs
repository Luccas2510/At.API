﻿using System;

namespace At.API.Models
{
    public class UsuarioModel
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public DateOnly DataNascimento { get; set;}
    }
}
