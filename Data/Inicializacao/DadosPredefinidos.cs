using AcquaJrApplication.Models;
//using AutoMapper.Configuration;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AcquaJrApplication.Data.Constantes;
using Microsoft.EntityFrameworkCore;

namespace AcquaJrApplication.Data.Inicializacao
{
    public class DadosPredefinidos
    {
        public static void Inicializar(IServiceProvider serviceProvider)
        {
            using (var context = serviceProvider.GetRequiredService<ApplicationDbContext>())
            {
                var userManager = serviceProvider.GetRequiredService <UserManager<User>>();
                var config = serviceProvider.GetRequiredService<IConfiguration>();

                CriarUsuarioAdministrativo(config, userManager);
                context.SaveChanges();
            }
        }

        public static void CriarUsuarioAdministrativo(IConfiguration configuration, UserManager<User> userManager)
        {
            var email = configuration.GetSection(ConstantesConfiguracao.ConfigEmailUsuarioAdministrativo).Value;
            var senha = configuration.GetSection(ConstantesConfiguracao.ConfigSenhaUsuarioAdministrativo).Value;
            var usuario = userManager.Users.IgnoreQueryFilters().FirstOrDefaultAsync(u => u.Email == email).Result;

            if (usuario == null)
            {
                usuario = new User
                {
                    UserName = email,
                    Email = email
                };

                var resultado = userManager.CreateAsync(usuario, senha).Result;
            }
        }
    }
}
