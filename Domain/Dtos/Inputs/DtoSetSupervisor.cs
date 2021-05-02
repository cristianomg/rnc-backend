using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Dtos.Inputs
{
    public class DtoSetSupervisor
    {
        public int SetorId { get; set; }
        public string UserEmail { get; set; }
        public int UserId { get; set; }
        public virtual User User { get; set; }
    }
}
