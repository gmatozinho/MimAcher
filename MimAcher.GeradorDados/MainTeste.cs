using MimAcher.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MimAcher.GeradorDados
{
    class MainTeste
    {
        static void Main(string[] args)
        {
            DiretorGeradores diretor = new DiretorGeradores();

            Participante participante = (Participante)diretor.GerarParticipante();
            Nac nac = (Nac)diretor.GerarNac();

            Console.WriteLine("Nome: " + participante.Nome);
            Console.WriteLine("Email: " + participante.Email);
            Console.WriteLine("Senha: " + participante.Senha);
            Console.WriteLine("Nascimento: " +participante.Nascimento);
            Console.WriteLine("Telefone: " + participante.Telefone);
            Console.WriteLine("Aprender: " + participante.Aprender);
            Console.WriteLine("Ensinar: " + participante.Ensinar);
            Console.WriteLine("Hobbies: " + participante.Hobbies);

            Console.WriteLine("-----------------------------------------------------------------");

            Console.WriteLine("Nome representante: " + nac.NomeRepresentante);
            Console.WriteLine("Email: " + nac.Email);
            Console.WriteLine("Senha: " + nac.Senha);
            Console.WriteLine("Telefone: " + nac.Telefone);
        }
    }
}
