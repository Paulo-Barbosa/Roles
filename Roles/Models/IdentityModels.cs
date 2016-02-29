using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;

namespace IdentitySample.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }


        // MODIFICAÇÃO INICIADA PAULO 29/02/2016

        public string Endereco { get; set; }

        public string Cidade { get; set; }

        public string Estado { get; set; }

        [Display(Name = "CEP")]
        public string CodigoPostal { get; set; }

        public string DisplayEndereco
        {
            get
            {
                string dpsEndereco = string.IsNullOrWhiteSpace(this.Endereco) ? "" : this.Endereco;

                string dpsCidade = string.IsNullOrWhiteSpace(this.Cidade) ? "" : this.Cidade;

                string dpsEstado = string.IsNullOrWhiteSpace(this.Estado) ? "" : this.Estado;

                string dpsCodigoPostal = string.IsNullOrWhiteSpace(this.CodigoPostal) ? "" : this.CodigoPostal;

                return string.Format("{0} {1} {2} {3}", dpsEndereco, dpsCidade, dpsEstado, dpsCodigoPostal);
            }
        }

        // MODIFICAÇÃO FINALIZADA PAULO 29/02/2016
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        static ApplicationDbContext()
        {
            // Set the database intializer which is run once during application start
            // This seeds the database with admin user credentials and admin role
            Database.SetInitializer<ApplicationDbContext>(new ApplicationDbInitializer());
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }
}