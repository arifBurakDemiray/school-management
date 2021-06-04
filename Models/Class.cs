
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SchoolManagement.API.Models
{
    public class Class : AbstractEntity
    {
        public int Order { get; set; }

        public string OrderAppendix { get; set; }

        [ForeignKey("School")]
        public int SchoolId { get; set; }
        public School School { get; set; }

    }
}