using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OnlineStore.DataModels
{
    public class Role
    {
        [Key]
        public RoleEnum Id { get; set; }

        [Required]
        [MaxLength(16)]
        public string Name { get; set; }
    }
}