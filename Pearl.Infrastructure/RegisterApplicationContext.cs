using Autofac;
using Pearl.Infrastructure.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pearl.Infrastructure
{
    public class RegisterApplicationContext : Module
    {
        public bool IsRegisterDbContext { get; set; }

        public RegisterApplicationContext(bool isRegisterDbContext = true)
        {
            this.IsRegisterDbContext = isRegisterDbContext;
        }

        protected override void Load(ContainerBuilder builder)
        {
            if (IsRegisterDbContext)
            {
                builder.RegisterType<ApplicationContext>().As<IApplicationContext>().InstancePerLifetimeScope();
            }
        }
    }
}
