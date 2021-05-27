using System;
using System.Collections.Generic;

namespace DIO.bank
{
    class Program
    {

        static List<Conta> listaContas = new List<Conta>();
        static void Main(string[] args)
        {
            string opcao = menu();

            while (opcao.ToUpper() != "X")
            {
                switch (opcao)
                {
                    case "1":
                        listarContas();
                        break;

                    case "2":
                        inserirConta();
                        break;

                    case "3":
                        transferir();
                        break;

                    case "4":
                        sacar();
                        break;

                    case "5":
                        depositar();
                        break;

                    case "C":
                        Console.Clear();
                        break;

                    default:
                        Console.WriteLine("Opção inválida, tente novamente");
                        break;
                }
                opcao = menu();
            }

            Console.WriteLine("Obrigado por usar nossos serviços!");

        }

        private static void transferir()
        {
            Console.Write("Digite o número da conta de origem: ");
            int indiceContaOrigem = int.Parse(Console.ReadLine());

            if (!verificaConta(indiceContaOrigem))
            {
                Console.WriteLine("Conta inexistente.");

                return;
            }

            Console.Write("Digite o número da conta de destino: ");
            int indiceContaDestino = int.Parse(Console.ReadLine());

            if (indiceContaOrigem == indiceContaDestino)
            {
                Console.WriteLine("As contas são iguais, tente novamente");

                return;
            }

            if (!verificaConta(indiceContaDestino))
            {
                Console.WriteLine("Conta inexistente.");

                return;
            }

            Console.Write("Digite o valor a ser transferido: ");
            double valorTransferencia = double.Parse(Console.ReadLine().Replace(".", ","));

            if (valorTransferencia <= 0)
            {
                Console.WriteLine("Valor inválido!");

                return;
            }

            try
            {
                listaContas[indiceContaOrigem].Transferir(valorTransferencia, listaContas[indiceContaDestino]);

                Console.WriteLine("Tranferência realizada com sucesso!");
            }
            catch (Exception e)
            {
                Console.WriteLine("Não foi possível realizar a transação.");
                Console.WriteLine($"Erro: {e}");
            }
        }

        private static bool verificaConta(int indice) //Verifica se a conta existe
        {
            //Verifica se a conta existe
            if (indice < 0 || indice > listaContas.Count)
            {
                return false;
            }

            return true;
        }

        private static void depositar()
        {
            Console.WriteLine("Digite o número da conta: ");
            int indiceConta = int.Parse(Console.ReadLine());

            if (!verificaConta(indiceConta))
            {
                Console.WriteLine("Conta inexistente");

                return;
            }

            Console.Write("Digite o valor a ser depositado: ");
            double valorDeposito = double.Parse(Console.ReadLine().Replace(".", ","));

            if (valorDeposito <= 0)
            {
                Console.WriteLine("Valor inválido!");

                return;
            }

            try
            {
                listaContas[indiceConta].Depositar(valorDeposito);

                Console.WriteLine("Depósito efetuado com sucesso!");
            }
            catch (Exception e)
            {
                Console.WriteLine("Não foi possível efetuar o depósito");
                Console.WriteLine($"Erro: {e}");
            }
        }

        private static void sacar()
        {
            Console.WriteLine("Digite o número da conta: ");
            int indiceConta = int.Parse(Console.ReadLine());

            if (!verificaConta(indiceConta))
            {
                Console.WriteLine("Conta inexistente");

                return;
            }

            Console.Write("Digite o valor a ser sacado: ");
            double valorSaque = double.Parse(Console.ReadLine().Replace(".", ","));

            if (valorSaque <= 0)
            {
                Console.WriteLine("Valor inválido!");

                return;
            }

            try
            {
                listaContas[indiceConta].Sacar(valorSaque);

                Console.WriteLine("Saque efetuado com sucesso!");
            }
            catch (Exception e)
            {
                Console.WriteLine("Não foi possível efetuar o saque");
                Console.WriteLine($"Erro: {e}");
            }
        }

        private static void listarContas()
        {
            Console.WriteLine("Lista contas");

            if (listaContas.Count == 0)
            {
                Console.WriteLine("Nenhuma conta cadastrada!");

                return;
            }
            for (int i = 0; i < listaContas.Count; i++)
            {
                Conta conta = listaContas[i];

                Console.Write("#{0} - ", i);
                Console.WriteLine(conta);
            }

        }

        private static void inserirConta()
        {
            Console.WriteLine("Inserir nova conta");

            Console.Write("Digite 1 para Conta Física ou 2 para Conta Jurídica: ");
            int entradaTipoConta = int.Parse(Console.ReadLine());

            //Verifica se o tipo de pessoa existe
            if (entradaTipoConta != 1 && entradaTipoConta != 2)
            {
                Console.WriteLine("Valor inexistente, digite novamente");

                return;
            }

            Console.Write("Digite o nome do cliente: ");
            string entradaNome = Console.ReadLine();

            Console.Write("Digite o saldo inicial: ");
            double entradaSaldo = double.Parse(Console.ReadLine().Replace(".", ","));

            Console.Write("Digite o crédito: ");
            double entradaCredito = double.Parse(Console.ReadLine().Replace(".", ","));

            if (string.IsNullOrEmpty(entradaNome) || double.IsNaN(entradaSaldo) || double.IsNaN(entradaCredito))
            {
                Console.WriteLine("Um ou mais valores inválidos, tente novamente");

                return;
            }

            try
            {
                Conta conta = new Conta(tipoConta: (TipoConta)entradaTipoConta,
                                                            saldo: entradaSaldo,
                                                            credito: entradaCredito,
                                                            nome: entradaNome);

                listaContas.Add(conta);

                Console.WriteLine("Conta cadastrada com sucesso!");
            }
            catch (Exception e)
            {
                Console.WriteLine("Não foi possível adicionar");
                Console.WriteLine($"Erro: {e}");
            }
        }

        public static string menu()
        {
            Console.WriteLine();
            Console.WriteLine("|--------------------------------------|");
            Console.WriteLine("|            Bem-Vindo!                |");
            Console.WriteLine("|  Informe a opção desejada:           |");
            Console.WriteLine("|--------------------------------------|");
            Console.WriteLine();

            Console.WriteLine("1 - Listar contas");
            Console.WriteLine("2 - Inserir nova conta");
            Console.WriteLine("3 - Transferir");
            Console.WriteLine("4 - Sacar");
            Console.WriteLine("5 - Depositar");
            Console.WriteLine("C - Limpar tela");
            Console.WriteLine("X - Sair");

            string opcao = Console.ReadLine().ToUpper();
            Console.WriteLine();

            return opcao;
        }
    }
}
