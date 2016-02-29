using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace IdentitySample.Models
{
    public class RoleViewModel
    {
        public string Id { get; set; }
        [Required(AllowEmptyStrings = false)]
        [Display(Name = "RoleName")]
        public string Name { get; set; }
    }

    public class EditUserViewModel
    {
        public string Id { get; set; }

        [Required(AllowEmptyStrings = false)]
        [Display(Name = "Email")]
        [EmailAddress]
        public string Email { get; set; }

        // MODIFICAÇÃO INICIADA PAULO 29/02/2016

        public string Endereco { get; set; }

        public string Cidade { get; set; }

        public string Estado { get; set; }

        [Display(Name = "CEP")]
        public string CodigoPostal { get; set; }

        // MODIFICAÇÃO FINALIZADA PAULO 29/02/2016

        public IEnumerable<SelectListItem> RolesList { get; set; }
    }
}