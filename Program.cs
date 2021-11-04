using System;
using System.Collections.Generic;

namespace DIO.Bank
{
    class Program
    {//armazenar em memória as contas
        static List<Conta> listContas = new List<Conta>();
        static void Main(string[] args)
        {
            string opcaoUsuario = ObterOpcaoUsuario();
            
            while (opcaoUsuario.ToUpper() != "X")
            {
                switch (opcaoUsuario)
                {
                    case "1":
                        ListarConta();
                        break;
                    case "2":
                        InserirConta();
                        break;
                    case "3":
                        Transferir();
                        break;
                    case "4":
                        Sacar();
                        break;
                    case "5":
                        Depositar();
                        break;
                    case "C":
                        Console.Clear();
                        break;

                        default:
                        throw new ArgumentOutOfRangeException();
               }
               
                opcaoUsuario = ObterOpcaoUsuario();
            }
            Console.WriteLine("Obrigado");
            Console.ReadLine();
        }

        private static void Transferir()
            {
            Console.Write("Digite o número da conta de origem: ");
            int indiceContaOrigem = int.Parse(Console.ReadLine());

            Console.Write("Digite o número da conta de destino: ");
            int indiceContaDestino = int.Parse(Console.ReadLine());

            Console.Write("Digite o valor a ser transferido: ");
            double valorTransferencia = double.Parse(Console.ReadLine());

            listContas[indiceContaOrigem].Transferir(valorTransferencia, listContas[indiceContaDestino]);
            }

        private static void Depositar()
        {
            {
            Console.Write("Digite o número da conta: ");
            int indiceConta = int.Parse(Console.ReadLine());

            Console.Write("Digite o valor a ser depositado: ");
            double ValorDeposito = double.Parse(Console.ReadLine());

            listContas[indiceConta].Sacar(ValorDeposito);
            }
        }

        private static void Sacar()
        {
            Console.Write("Digite o número da conta: ");
            int indiceConta = int.Parse(Console.ReadLine());

            Console.Write("Digite o valor a ser sacado: ");
            double valorSaque = double.Parse(Console.ReadLine());

            listContas[indiceConta].Sacar(valorSaque);
        }

        private static void InserirConta()
        {
            Console.WriteLine("Inserir nova conta");

             Console.WriteLine("Digite 1 para conta Pessoa Fisica ou 2 para Pessoa Juridica: ");
             int entradaTipoConta = int.Parse(Console.ReadLine());

             Console.WriteLine("Digite o nome do cliente: ");
             string entradaNome = Console.ReadLine();

             Console.WriteLine("Digite 1 o saldo inicial: ");
             double entradaSaldo = double.Parse(Console.ReadLine());

            Console.WriteLine("Digite o crédito: ");
            double entradaCredito = double.Parse(Console.ReadLine());
            //abaixo, criando um objeto chamado novaconta, instanciando da classe, colocando 

            Conta novaConta = new Conta(tipoConta: (TipoConta)entradaTipoConta,//convertendo as entradas de acordo com o enum
            saldo: entradaSaldo, credito: entradaCredito, nome: entradaNome);

            listContas.Add(novaConta);
        }


        private static void ListarConta()
       {
            Console.WriteLine("Listar contas");
            if (listContas.Count == 0)
            {
                Console.WriteLine("Nenhuma conta cadastrada.");
                return;
            }
            for (int i = 0; i < listContas.Count; i++)
            {
                Conta conta = listContas[i];
                Console.Write("#{0} - ", i);
                Console.WriteLine(conta);
            }
        }

        private static string ObterOpcaoUsuario()
        {
            Console.WriteLine();
            Console.WriteLine("DIO bank a sua disposição");
            Console.WriteLine("Informe a opção desejada");

            Console.WriteLine("1 - Listar Contas");
            Console.WriteLine("2 - Inserir nova conta");
            Console.WriteLine("3 - Tranferir");
            Console.WriteLine("4 - Sacar");
            Console.WriteLine("5 - Depositar");
            Console.WriteLine("C - Limpar Tela");
            Console.WriteLine("X - Sair");
            Console.WriteLine();

            string OpcaoUsuario = Console.ReadLine().ToUpper();
            Console.WriteLine();
            return OpcaoUsuario;
        }
    }
}
