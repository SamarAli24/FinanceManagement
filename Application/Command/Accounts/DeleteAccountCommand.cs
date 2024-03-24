﻿using Domain.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Command.Accounts
{
    public class DeleteAccountCommand : IRequest<int>
    {
        public int Id { get; set; }
    }
}
