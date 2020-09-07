using Microsoft.AspNetCore.Identity;

namespace AcquaJrApplication.Data
{
    public class User : IdentityUser<int>
    {
        public User() { }

        public string Nome { get; set; }

        public virtual Role Role { get; set; }
    }
}
