using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AcquaJrApplication.Models
{
    public class MembroProjeto : Entity
    {
        public Guid MembroId { get; set; }
        public Guid ProjetoId { get; set; }

        /* EF Relations */
        public Membro Membro { get; set; }
        public Projeto Projeto { get; set; }
    }
}
