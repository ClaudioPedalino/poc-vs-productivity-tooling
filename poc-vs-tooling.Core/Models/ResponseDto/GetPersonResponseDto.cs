using System;
using System.Collections.Generic;
using System.Text;

namespace poc_vs_tooling.Core.Models.ResponseDto
{
    //[DebuggerDisplay("{FirstName} {LastName}")]
    public class GetPersonResponseDto
    {
        public Guid PersonId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Birthday { get; set; }
        public string Email { get; set; }
        public string Avatar { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
    }
}
