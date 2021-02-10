using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OnlineStore.DataModels
{
    public class Account
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(32)]
        public string Email { get; set; }

        [Required]
        public Role Role { get; set; }
    }
}