using System;

namespace DIO.Veiculos
{
    class Program
    {
        static VeiculosRepositorio repositorio = new VeiculosRepositorio();
        static void Main(string[] args)
        {
            string opcaoUsuario = ObterOpcaoUsuario();

			while (opcaoUsuario.ToUpper() != "X")
			{
				switch (opcaoUsuario)
				{
					case "1":
						ListarVeiculos();
						break;
					case "2":
						InserirVeiculos();
						break;
					case "3":
						AtualizarVeiculos();
						break;
					case "4":
						ExcluirVeiculos();
						break;
					case "5":
						VisualizarVeiculos();
						break;
					case "C":
						Console.Clear();
						break;

					default:
						throw new ArgumentOutOfRangeException();
				}

				opcaoUsuario = ObterOpcaoUsuario();
			}

			Console.WriteLine("Obrigado por utilizar nossos serviços.");
			Console.ReadLine();
        }

        private static void ExcluirVeiculos()
		{
			Console.Write("Digite o id do veículo: ");
			int indiceVeiculos = int.Parse(Console.ReadLine());

			repositorio.Exclui(indiceVeiculos);
		}

        private static void VisualizarVeiculos()
		{
			Console.Write("Digite o id do veículo: ");
			int indiceVeiculos = int.Parse(Console.ReadLine());

			var Veiculos = repositorio.RetornaPorId(indiceVeiculos);

			Console.WriteLine(Veiculos);
		}

        private static void AtualizarVeiculos()
		{
			Console.Write("Digite o id do veículo: ");
			int indiceVeiculos = int.Parse(Console.ReadLine());

			// https://docs.microsoft.com/pt-br/dotnet/api/system.enum.getvalues?view=netcore-3.1
			// https://docs.microsoft.com/pt-br/dotnet/api/system.enum.getname?view=netcore-3.1
			foreach (int i in Enum.GetValues(typeof(Marca)))
			{
				Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Marca), i));
			}
			Console.Write("Digite a marca entre as opções acima: ");
			int entradaMarca = int.Parse(Console.ReadLine());

			Console.Write("Digite o Título do Veículo: ");
			string entradaTitulo = Console.ReadLine();

			Console.Write("Digite o Ano do Veículo: ");
			int entradaAno = int.Parse(Console.ReadLine());

			Console.Write("Digite a Descrição do Veículo: ");
			string entradaDescricao = Console.ReadLine();

			Veiculos atualizaVeiculos = new Veiculos(id: indiceVeiculos,
										Marca: (Marca)entradaMarca,
										titulo: entradaTitulo,
										ano: entradaAno,
										descricao: entradaDescricao);

			repositorio.Atualiza(indiceVeiculos, atualizaVeiculos);
		}
        private static void ListarVeiculos()
		{
			Console.WriteLine("Listar Veículos");

			var lista = repositorio.Lista();

			if (lista.Count == 0)
			{
				Console.WriteLine("Nenhuma veículo cadastrado.");
				return;
			}

			foreach (var Veiculos in lista)
			{
                var excluido = Veiculos.retornaExcluido();
                
				Console.WriteLine("#ID {0}: - {1} {2}", Veiculos.retornaId(), Veiculos.retornaTitulo(), (excluido ? "*Excluído*" : ""));
			}
		}

        private static void InserirVeiculos()
		{
			Console.WriteLine("Inserir novo veículo");

			// https://docs.microsoft.com/pt-br/dotnet/api/system.enum.getvalues?view=netcore-3.1
			// https://docs.microsoft.com/pt-br/dotnet/api/system.enum.getname?view=netcore-3.1
			foreach (int i in Enum.GetValues(typeof(Marca)))
			{
				Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Marca), i));
			}
			Console.Write("Digite a marca entre as opções acima: ");
			int entradaMarca = int.Parse(Console.ReadLine());

			Console.Write("Digite o Modelo do Veículo: ");
			string entradaTitulo = Console.ReadLine();

			Console.Write("Digite o Ano do veículo: ");
			int entradaAno = int.Parse(Console.ReadLine());

			Console.Write("Digite a Cor do veículo: ");
			string entradaDescricao = Console.ReadLine();

			Veiculos novaVeiculos = new Veiculos(id: repositorio.ProximoId(),
										Marca: (Marca)entradaMarca,
										titulo: entradaTitulo,
										ano: entradaAno,
										descricao: entradaDescricao);

			repositorio.Insere(novaVeiculos);
		}

        private static string ObterOpcaoUsuario()
		{
			Console.WriteLine();
			Console.WriteLine("DIO Veiculos a seu dispor!!!");
			Console.WriteLine("Informe a opção desejada:");

			Console.WriteLine("1- Listar veículos");
			Console.WriteLine("2- Inserir novo veículos");
			Console.WriteLine("3- Atualizar veículos");
			Console.WriteLine("4- Excluir veículo");
			Console.WriteLine("5- Visualizar veículos");
			Console.WriteLine("C- Limpar Tela");
			Console.WriteLine("X- Sair");
			Console.WriteLine();

			string opcaoUsuario = Console.ReadLine().ToUpper();
			Console.WriteLine();
			return opcaoUsuario;
		}
    }
}
