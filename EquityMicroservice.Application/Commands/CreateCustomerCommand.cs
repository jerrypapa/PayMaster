using EquityMicroservice.Application.Commands;
using EquityMicroservice.Application.Dtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace EquityMicroservice.Application.Commands
{
    public class CreateCustomerCommand:IRequest<Guid>
    {
        public CustomerDto customerDetails { get; set; }
    }
}


