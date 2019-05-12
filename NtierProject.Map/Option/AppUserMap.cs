using NtierProject.Core.Map;
using NtierProject.Model.Option;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NtierProject.Map.Option
{
    public class AppUserMap:CoreMap<AppUser>
    {
        public AppUserMap()
        {
            ToTable("dbo.Users");

            Property(x => x.Address).IsOptional();
            Property(x => x.Email).IsOptional();
            Property(x => x.FirstName).IsOptional();
            Property(x => x.LastName).IsOptional();
            Property(x => x.Password).IsOptional();
            Property(x => x.PhoneNumber).IsOptional();
            Property(x => x.Role).IsOptional();
            Property(x => x.UserName).IsOptional();
            Property(x => x.DateTime).IsOptional();
        }
    }
}
