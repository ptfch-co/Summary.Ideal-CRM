namespace Summary.IdealCrm
{
    using Core.Security.Permissions;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;


    public class Permissions : IPermissionProvider
    {
        internal static Permission ManageIdealCrmSettings =
            new Permission(nameof(ManageIdealCrmSettings), "Manage Ideal CRM Settings");

        public Task<IEnumerable<Permission>> GetPermissionsAsync()
        {
            return Task.FromResult(new[] { ManageIdealCrmSettings }.AsEnumerable());
        }

        public IEnumerable<PermissionStereotype> GetDefaultStereotypes()
        {
            return new[]
            {
                new PermissionStereotype
                {
                    Name = "Administrator",
                    Permissions = new []{ ManageIdealCrmSettings }
                }
            };
        }
    }
}