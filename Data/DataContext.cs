using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProjetoDS.Models;
using ProjetoDS.Models.Enuns;
using Microsoft.EntityFrameworkCore;

namespace ProjetoDS.Data
{
    public class DataContext : DbContext
    {
        //classe para criar bd
        public DataContext (DbContextOptions <DataContext> options) : base (options)
        {
        }

        public DbSet<Tarefas> TB_TAREFAS { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Tarefas>().ToTable("TB_TAREFAS");
            modelBuilder.Entity<Tarefas>().HasData
            (
                new Tarefas() {Id = 1, Nome = "Lavar a Louça", Descrição = "Lavar a louça antes da mãe chegar", Prioridade = Prioridade.Prioridadebaixa, Status = Status.Concluida},
                new Tarefas() {Id = 1, Nome = "Estudar para prova", Descrição = "Estudar c# para proxima prova", Prioridade = Prioridade.PrioridadeAlta, Status = Status.Incompleta},
                new Tarefas() {Id = 1, Nome = "Fazer trabalho escolar", Descrição = "Fazer o trabalho de fisica", Prioridade = Prioridade.Prioridadebaixa, Status = Status.Incompleta},
                new Tarefas() {Id = 1, Nome = "Academia", Descrição = "Ir a academia", Prioridade = Prioridade.Prioridademedia, Status = Status.Concluida},
                new Tarefas() {Id = 1, Nome = "Revisar conteudo passado aula", Descrição = "Revisar conteudo passado na aula de DS", Prioridade = Prioridade.Prioridadebaixa, Status = Status.Concluida}
            );
        }

        protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
        {
            configurationBuilder.Properties<string>().HaveColumnType("varchar").HaveMaxLength(500);
            //cria campos de texto/ muda string para varchar no banco 
        }
        
    }
}