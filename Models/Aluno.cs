

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiNETparaVUE.Models {

    [Table("Alunos")]
    public class Aluno {

        [Key]
        public int AlunoId { get; set; }

        public string Nome { get; set; }

        public string Email { get; set; }

        public int Idade { get; set; }


    }
}