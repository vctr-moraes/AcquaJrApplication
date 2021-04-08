using System.Collections.Generic;
using AcquaJrApplication.Notificacoes;

namespace AcquaJrApplication.Interfaces
{
    public interface INotificador
    {
        bool TemNotificacao();
        List<Notificacao> ObterNotificacoes();
        void Handle(Notificacao notificacao);
    }
}
