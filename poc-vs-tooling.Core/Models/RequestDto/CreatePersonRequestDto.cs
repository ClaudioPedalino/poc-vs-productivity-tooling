using System;
using System.Collections.Generic;
using System.Text;

namespace poc_vs_tooling.Core.Models.RequestDto
{
    public class CreatePersonRequestDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTimeOffset Birthday { get; set; }
        public string Email { get; set; }
        public string Avatar { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
    }
}
