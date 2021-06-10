using poc_vs_tooling.Core.Models.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace poc_vs_tooling.Core.Models.RequestDto
{
    public class GetPersonRequestDto : GetWithPagination
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public DateTimeOffset? BirthdayFrom { get; set; }
        public DateTimeOffset? BirthdayTo { get; set; }
        public string? Email { get; set; }
        public string? Address { get; set; }
        public string? Phone { get; set; }
    }
}
