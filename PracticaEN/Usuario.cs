using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticaEN
{
    public class Usuario
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "El Id de Rol es requerido")]
        [ForeignKey("Rol")]
        [Display(Name = "Rol Id")]
        public int RolId { get; set; }

        [Required(ErrorMessage = "El Nombre es requerido")]
        [MaxLength(50, ErrorMessage = "El largo maximo son 50 caracteres")]
        public string Nombre { get; set; }

        public string Apellido { get; set; }

        [Required(ErrorMessage = "El Correo es requerido")]
        [MaxLength(50, ErrorMessage = "El largo maximo son 50 caracteres")]
        public string Correo { get; set; }

        [Required(ErrorMessage = "El Password es requerido")]
        [MaxLength(50, ErrorMessage = "El largo maximo son 50 caracteres")]
        public string Password { get; set; }

        [Required(ErrorMessage = "El Rol es requerido")]
        [MaxLength(50, ErrorMessage = "El largo maximo son 50 caracteres")]
        public Rol Rol { get; set; }
        [NotMapped]
        public int top_aux { get; set; }
    }
}
