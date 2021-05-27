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
                        throw new ArgumentOutOfRangeException();
                }
                opcao = menu();
            }

            Console.WriteLine("Obrigado por usar nossos serviços!");
            Console.ReadLine();

        }

        private static void transferir()
        {
           Console.Write("Digite o número da conta de origem: ");
           int indiceContaOrigem = int.Parse(Console.ReadLine());

           Console.Write("Digite o número da conta de destino: ");
           int indiceContaDestino = int.Parse(Console.ReadLine());

           Console.Write("Digite o valor a ser transferido: ");
           double valorTransferencia = double.Parse(Console.ReadLine());

           listaContas[indiceContaOrigem].Transferir(valorTransferencia, listaContas[indiceContaDestino]);
        }

        private static void depositar()
        {
            Console.WriteLine("Digite o número da conta: ");
            int indiceConta = int.Parse(Console.ReadLine());

            Console.Write("Digite o valor a ser depositado: ");
            double valorDeposito = double.Parse(Console.ReadLine());

            listaContas[indiceConta].Depositar(valorDeposito);
        }

        private static void sacar()
        {
            Console.WriteLine("Digite o número da conta: ");
            int indiceConta = int.Parse(Console.ReadLine());

            Console.Write("Digite o valor a ser sacado: ");
            double valorSaque = double.Parse(Console.ReadLine());

            listaContas[indiceConta].Sacar(valorSaque);
        }

        private static void listarContas()
        {
            Console.WriteLine("Lista contas");

            if(listaContas.Count == 0){
                Console.WriteLine("Nenhuma conta cadastrada!");

                return;
            }
            for(int i=0; i<listaContas.Count; i++){
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

            Console.Write("Digite o nome do cliente: ");
            string entradaNome = Console.ReadLine();

            Console.Write("Digite o saldo inicial:");
            double entradaSaldo = double.Parse(Console.ReadLine());

            Console.Write("Digite o crédito: ");
            double entradaCredito = double.Parse(Console.ReadLine());

            Conta conta = new Conta(tipoConta: (TipoConta) entradaTipoConta, 
                                                        saldo: entradaSaldo, 
                                                        credito: entradaCredito, 
                                                        nome: entradaNome);
            
            listaContas.Add(conta);
        }

        public static string menu()
        {
            Console.WriteLine();
            Console.WriteLine("DIO Bank soluções");
            Console.WriteLine("Informe a opção desejada: ");

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
