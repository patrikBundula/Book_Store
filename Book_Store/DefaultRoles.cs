using System.Collections.Immutable;

namespace Book_Store
{
    public class DefaultRoles
    {
        public const string AdminRole = "Admin";
        public const string CustomerRole = "Customer";

        public static readonly ImmutableArray<string> ValidRoles =
            ImmutableArray.Create(AdminRole, CustomerRole);
    }
}
