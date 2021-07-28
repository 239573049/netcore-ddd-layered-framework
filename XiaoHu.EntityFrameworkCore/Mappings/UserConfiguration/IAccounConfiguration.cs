using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using XiaoHu.Code.Entities.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XiaoHu.EntityFrameworkCore.Mappings.UserConfiguration
{
    public class IAccounConfiguration : EntityConfiguration<Account>
    {
        public override void Configure(EntityTypeBuilder<Account> builder)
        {
            builder.ToTable("Account");
            base.Configure(builder);
        }
    }
}
