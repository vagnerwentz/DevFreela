﻿using MediatR;

namespace DevFreela.Application.Commands.UserCommands.CreateUser
{
    public class CreateUserCommand : IRequest<int>
    {
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
        public DateTime Birthdate { get; set; }
    }
}

