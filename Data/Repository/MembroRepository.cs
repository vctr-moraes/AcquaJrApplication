using System;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using AcquaJrApplication.Interfaces;
using AcquaJrApplication.Models;

namespace AcquaJrApplication.Data.Repository
{
    public class MembroRepository : Repository<Membro>, IMembroRepository
    {
        private readonly IProjetoRepository _projetoRepository;

        public MembroRepository(ApplicationDbContext context, IProjetoRepository projetoRepository) : base(context)
        {
            _projetoRepository = projetoRepository;
        }

        public async Task<Membro> ObterMembro(Guid id)
        {
            return await Db.Membros.AsNoTracking().FirstOrDefaultAsync(m => m.Id == id);
        }

        public List<Membro> ObterMembrosAtivos()
        {
            return Db.Membros.AsNoTracking().Where(m => m.Status == true).OrderBy(m => m.Nome).ToList();
        }

        public List<Membro> ObterMembrosInativos()
        {
            return Db.Membros.AsNoTracking().Where(m => m.Status == false).OrderBy(m => m.Nome).ToList();
        }

        public async Task SalvarMembro(Membro membro)
        {
            await Adicionar(membro);
        }

        public async Task AtualizarMembro(Membro membro)
        {
            await Atualizar(membro);
        }

        public async Task ExcluirMembroAsync(Guid id)
        {
            var membro = await ObterMembro(id);
            var projetos = _projetoRepository.ObterProjetos().ToList();

            //foreach (var item in projetos)
            //{
            //    if (item.Membros.Any(p => p.MembroId == id))
            //    {
            //        DomainException.When(true, "Este membro não pode ser deletado, pois está vinculado a algum projeto.");
            //    }
            //}

            await Remover(membro.Id);
        }
    }
}
