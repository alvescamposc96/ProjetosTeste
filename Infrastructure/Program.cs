using Infrastructure.Repository;
using ProjetoPrincipal;
using System;

namespace Infrastructure
{
    class Program
    {
        static void Main(string[] args)
        {
            Alunos aluno = new Alunos() {
                Nome = "Cristiane",
                CPF = "1294447",
                RA = 88888888
            
            };




            AlunosRepository AR = new AlunosRepository();

            //AR.Add(aluno);



            //AR.Delete(aluno);

            // AR.UPDate(aluno, 4922269);

            // AR.Get(88888888);
            var x = AR.Get(88888888);
            
            Console.WriteLine($"Nome: {x.Nome}, CPF:  {x.CPF}, RA:  {x.RA}");

            // AR.Get(aluno);

        }
    }
}
