using ProjetoPrincipal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IAlunosRepository
    {
        public string Add(Alunos aluno);

        public void UPDate(Alunos aluno, int RA);

        public void Delete(Alunos aluno);

        public Alunos Get(int RA);
    }
}
