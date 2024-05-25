using Autofac;
using System.Linq;

namespace FlexiSchools.Application
{
    public class RegisterHandler : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            System.Reflection.Assembly assembly = System.Reflection.Assembly.GetExecutingAssembly();

            builder.RegisterAssemblyTypes(assembly)
                .Where(x => x.Name.EndsWith("Query"))
                .AsImplementedInterfaces()
                .InstancePerLifetimeScope();

            builder.RegisterAssemblyTypes(assembly)
               .Where(x => x.Name.EndsWith("Command"))
               .AsImplementedInterfaces()
               .InstancePerLifetimeScope();
        }
    }
}
