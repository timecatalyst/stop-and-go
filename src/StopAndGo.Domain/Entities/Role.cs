using Microsoft.AspNetCore.Identity;

namespace Nymbus.Domain.Entities
{
    public class Role : IdentityRole<int>
    {
        public Role() { }

        public Role(string roleName)
            : base(roleName) { }
    }
}
