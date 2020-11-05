using System;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using AcquaJrApplication.Data.Constantes;

namespace AcquaJrApplication.Data.Inicializacao
{
    public class DadosPredefinidos
    {
        public static void Inicializar(IServiceProvider serviceProvider)
        {
            using (var context = serviceProvider.GetRequiredService<ApplicationDbContext>())
            {
                var userManager = serviceProvider.GetRequiredService <UserManager<IdentityUser>>();
                var config = serviceProvider.GetRequiredService<IConfiguration>();

                CriarUsuarioAdministrativo(config, userManager);
                context.SaveChanges();
            }
        }

        public static void CriarUsuarioAdministrativo(IConfiguration configuration, UserManager<IdentityUser> userManager)
        {
            var email = configuration.GetSection(ConstantesConfiguracao.ConfigEmailUsuarioAdministrativo).Value;
            var senha = configuration.GetSection(ConstantesConfiguracao.ConfigSenhaUsuarioAdministrativo).Value;
            var usuario = userManager.Users.IgnoreQueryFilters().FirstOrDefaultAsync(u => u.Email == email).Result;

            if (usuario == null)
            {
                usuario = new IdentityUser
                {
                    UserName = email,
                    Email = email,
                    EmailConfirmed = true
                };

                var resultado = userManager.CreateAsync(usuario, senha).Result;
            }
        }
    }
}
