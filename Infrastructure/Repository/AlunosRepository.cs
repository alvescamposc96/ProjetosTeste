using Domain;
using Microsoft.Extensions.Configuration;
using ProjetoPrincipal;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repository
{
    class AlunosRepository : IAlunosRepository
    {
        public string Add(Alunos aluno)
        {
         
         var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json",optional: false)
                .Build();


           var sqlconnectionstring = config.GetSection("Conexao").Value;

            using (SqlConnection conexao = new SqlConnection(sqlconnectionstring))
            {
                string inserir = "insert into Alunos (Nome, CPF , RA) Values(@Nome, @CPF, @RA)";

                SqlCommand command = new SqlCommand(inserir, conexao);
                command.Parameters.AddWithValue("@Nome", aluno.Nome);
                command.Parameters.AddWithValue("@CPF", aluno.CPF);
                command.Parameters.AddWithValue("@RA", aluno.RA);

                conexao.Open();
                SqlDataReader reader = command.ExecuteReader();

                conexao.Close();
            }

                Console.WriteLine(sqlconnectionstring);

            return "Aluno adicionado";
        } 

        public void Delete(Alunos aluno)
        {
            var config = new ConfigurationBuilder()
                   .SetBasePath(Directory.GetCurrentDirectory())
                   .AddJsonFile("appsettings.json", optional: false)
                   .Build();


            var sqlconnectionstring = config.GetSection("Conexao").Value;

            using (SqlConnection conexao = new SqlConnection(sqlconnectionstring))
            {
                string delete = "delete from Alunos where RA = @RA";
                SqlCommand command = new SqlCommand(delete, conexao);
                command.Parameters.AddWithValue("@RA", aluno.RA);

                conexao.Open();
                SqlDataReader reader = command.ExecuteReader();

                conexao.Close();
            }

            }

        public void UPDate(Alunos aluno, int RA)
        {

            var config = new ConfigurationBuilder()
                  .SetBasePath(Directory.GetCurrentDirectory())
                  .AddJsonFile("appsettings.json", optional: false)
                  .Build();


            var sqlconnectionstring = config.GetSection("Conexao").Value;

            using (SqlConnection conexao = new SqlConnection(sqlconnectionstring))
            {
                string update = "update Alunos set Nome = @Nome, CPF = @CPF, RA = @RA where RA = @RAup";
                SqlCommand command = new SqlCommand(update, conexao);
                command.Parameters.AddWithValue("@RA", aluno.RA);
                command.Parameters.AddWithValue("@Nome", aluno.Nome);
                command.Parameters.AddWithValue("@CPF", aluno.CPF);
                command.Parameters.AddWithValue("@RAup", RA);

                conexao.Open();
                SqlDataReader reader = command.ExecuteReader();

                conexao.Close();
            }
        }

        public Alunos Get(int RA)
        {

            var config = new ConfigurationBuilder()
                  .SetBasePath(Directory.GetCurrentDirectory())
                  .AddJsonFile("appsettings.json", optional: false)
                  .Build();


            var sqlconnectionstring = config.GetSection("Conexao").Value;
           
            Alunos alunos = new Alunos();

            using (SqlConnection conexao = new SqlConnection(sqlconnectionstring))
            {
                 string select = "select * from Alunos where RA = @RAParam";
               // string select = "select * from Alunos";
                SqlCommand command = new SqlCommand(select, conexao);
                command.Parameters.AddWithValue("@RAParam", RA);


                conexao.Open();


           
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    //Console.WriteLine(String.Format("{0}, {1}, {2}",
                       // reader[0], reader[1], reader [2]));
                    
                    
                    alunos.Nome = String.Format("{0}",reader[0]);
                    alunos.CPF = String.Format("{0}", reader[1]);
                    alunos.RA = Convert.ToInt32( reader[2]);
                }

                conexao.Close();
            }
           return alunos;
        }   
            }
}
