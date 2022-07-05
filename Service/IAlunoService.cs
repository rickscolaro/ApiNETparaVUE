using ApiNETparaVUE.Models;

namespace ApiNETparaVUE.Service {
    
    public interface IAlunoService {

        Task<IEnumerable<Aluno>> GetAlunos();

        Task<Aluno> GetAlunoId(int id);

        Task<IEnumerable<Aluno>> GetAlunosByNome(string nome);

        Task CreateAluno(Aluno aluno);

        Task UpdateAluno(Aluno aluno);

        Task DeleteAluno(Aluno aluno);

    }
}