using Microsoft.AspNetCore.Identity;

namespace AcquaJrApplication.Data
{
    public class Role : IdentityRole<int>
    {
        public Role() { }

        public string Tipo { get; set; }
    }
}
