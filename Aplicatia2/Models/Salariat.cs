using System.ComponentModel.DataAnnotations;

namespace Aplicatia2.Models
{
    public class Salariat
    {
        //Id, Numele, Prenumele, Salariul

        public int Id { get; set; }
        [Required]
        public string Nume { get; set; }
        [Required]
        public string Prenume { get; set; }
        [Required]
        public decimal Salariu { get; set; }
    }
}
