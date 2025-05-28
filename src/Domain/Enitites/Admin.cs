using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Abstraction;

namespace Domain.Enitites
{
    public class Admin : BaseEntity
    {
        public string Email { get; set; } = default!;
        public string Password { get; set; } = default!;
    }
}
