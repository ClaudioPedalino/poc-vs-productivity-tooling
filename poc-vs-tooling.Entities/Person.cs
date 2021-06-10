using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Text;

namespace poc_vs_tooling.Core.Entities
{
    //[CP] Add Debugger Display Atrribute
    //[DebuggerDisplay("{FirstName} {LastName}")]
    public class Person : AuditableEntity
    {
        [Key]
        public Guid PersonId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTimeOffset Birthday { get; set; }
        public string Email { get; set; }
        public string Avatar { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }

    }
}
