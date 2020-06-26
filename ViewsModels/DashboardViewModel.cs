using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AcquaJrApplication.ViewsModels
{
    public class DashboardViewModel
    {
        #region Projetos

        public int ProjetosAtivos { get; set; }
        public int ProjetosAtarsados { get; set; }
        public int ProjetosConcluidos { get; set; }

        #endregion

        #region Membros

        public int MembrosAtivos { get; set; }
        public int MembrosInAtivos { get; set; }

        #endregion
    }
}
