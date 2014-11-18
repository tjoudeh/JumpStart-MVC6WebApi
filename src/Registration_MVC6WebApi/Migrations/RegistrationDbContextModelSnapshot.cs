using Microsoft.Data.Entity;
using Microsoft.Data.Entity.Metadata;
using Microsoft.Data.Entity.Migrations.Infrastructure;
using Registration_MVC6WebApi.Models;
using System;

namespace Registration_MVC6WebApi.Migrations
{
    [ContextType(typeof(RegistrationDbContext))]
    public class RegistrationDbContextModelSnapshot : ModelSnapshot
    {
        public override IModel Model
        {
            get
            {
                var builder = new BasicModelBuilder();
                
                builder.Entity("Registration_MVC6WebApi.Models.Course", b =>
                    {
                        b.Property<int>("Credits");
                        b.Property<int>("Id")
                            .GenerateValuesOnAdd();
                        b.Property<string>("Name");
                        b.Key("Id");
                    });
                
                return builder.Model;
            }
        }
    }
}