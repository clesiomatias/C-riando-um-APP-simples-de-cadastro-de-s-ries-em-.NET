using System;
using DIO_Filmess.Classes;
using Dio_series;
using DIO_series.Classes;


namespace DIO_series
{
    class Program
    {
        static SerieRepositorio repositorioS = new SerieRepositorio();
        static FilmesRepositorio repositorioF = new FilmesRepositorio();
        static void Main(string[] args)
        {

            string opcaoUsuario = MenuInicial();
            while (opcaoUsuario.ToUpper() != "X")
            {
                switch (opcaoUsuario)
                {
                    case "1":
                        Console.Clear();
                        LidaSeries();
                        break;
                    case "2":
                        Console.Clear();
                        LidaFilmes();
                        break;
                    case "C":
                        Console.Clear();
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
                opcaoUsuario = MenuInicial();

            }
        }

        private static void LidaFilmes()
        {
            var opcaoUsuario = ObterOpcaoUsuarioFilme();
            while (opcaoUsuario.ToUpper() != "M")
            {
                switch (opcaoUsuario)
                {
                    case "1":
                        ListarFilmes();
                        break;
                    case "2":
                        InserirFilme();
                        break;
                    case "3":
                        AtualizaFilme();
                        break;
                    case "4":
                        ExcluirFilme();
                        break;
                    case "5":
                        VisualizarFilme();
                        break;
                    case "C":
                        Console.Clear();
                        break;
                    case "X":
                        Environment.Exit(0);
                        break;
                    case "M":
                        MenuInicial();
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
                opcaoUsuario = ObterOpcaoUsuarioFilme();

            }
        }

        private static void VisualizarFilme()
        {
            Console.Write("Digite o id do filme: ");
            int indiceFilme = int.Parse(Console.ReadLine());
            var filme = repositorioF.RetornaPorId(indiceFilme);
            Console.WriteLine(filme);
        }

        private static void ExcluirFilme()
        {
            Console.Write("Digite o id do filme: ");
            int indiceFilme = int.Parse(Console.ReadLine());
            repositorioF.Exclui(indiceFilme);
        }

        private static void AtualizaFilme()
        {
            Console.Write("Digite o id do filme: ");
            int indiceFilme = int.Parse(Console.ReadLine());
            foreach (int i in Enum.GetValues(typeof(Genero)))
            {
                Console.WriteLine($"{i} - {Enum.GetName(typeof(Genero), i)}");

            }
            Console.Write("Digite o genero entre as opções acima: ");
            int entradaGenero = int.Parse(Console.ReadLine());
            Console.Write("Digite o título do filme: ");
            string entradaTitulo = Console.ReadLine();
            Console.Write("Digite o ano de lançamento do filme: ");
            int entradaAno = int.Parse(Console.ReadLine());
            Console.Write("Digite a descrição do filme: ");
            string entradaDescricao = Console.ReadLine();
            Filmes atualizaFilme = new Filmes(id: indiceFilme,
                                        genero: (Genero)entradaGenero,
                                        titulo: entradaTitulo,
                                        ano: entradaAno,
                                        descricao: entradaDescricao);
            repositorioF.Atualiza(indiceFilme, atualizaFilme);
        }

        private static void InserirFilme()
        {
            foreach (int i in Enum.GetValues(typeof(Genero)))
            {
                Console.WriteLine($"{i} - {Enum.GetName(typeof(Genero), i)}");

            }
            Console.Write("Digite o genero entre as opções acima: ");
            int entradaGenero = int.Parse(Console.ReadLine());
            Console.Write("Digite o título do filme: ");
            string entradaTitulo = Console.ReadLine();
            Console.Write("Digite o ano de lançamento do filme: ");
            int entradaAno = int.Parse(Console.ReadLine());
            Console.Write("Digite a descrição do filme: ");
            string entradaDescricao = Console.ReadLine();
            Filmes novoFilme = new Filmes(id: repositorioF.ProximoId(),
                                        genero: (Genero)entradaGenero,
                                        titulo: entradaTitulo,
                                        ano: entradaAno,
                                        descricao: entradaDescricao);
            repositorioF.Insere(novoFilme);
        }

        private static void ListarFilmes()
        {
            Console.WriteLine("Listar Filmes");
            var lista = repositorioF.Lista();
            if (lista.Count == 0)
            {
                Console.WriteLine("Nenhum filme cadastrado.");
                return;
            }
            foreach (var filme in lista)
            {
                var excluido = filme.retornaExcluido();
                Console.WriteLine($"#ID {filme.retornaId()}: - {filme.retornaTitulo()}  {(excluido ? "*Excluido*" : "")}");
            }
        }

        private static string MenuInicial()

        {
            Console.Clear();
            Console.WriteLine("DIO Séries e Filmes a seu dispor!!!");
            Console.WriteLine();
            Console.WriteLine("Informe a opção desejada:");

            Console.WriteLine();
            Console.WriteLine("1- Ver ou organizar séries");
            Console.WriteLine("2- Ver ou organizar filmes");
            Console.WriteLine("C- Limpar tela");
            Console.WriteLine("X- Sair");
            Console.WriteLine();

            string opcaoUsuario = Console.ReadLine().ToUpper();
            Console.WriteLine();
            return opcaoUsuario;
        }


        private static void LidaSeries()
        {
            var opcaoUsuario = ObterOpcaoUsuarioSerie();
            while (opcaoUsuario.ToUpper() != "M")
            {
                switch (opcaoUsuario)
                {
                    case "1":
                        ListarSeries();
                        break;
                    case "2":
                        InserirSerie();
                        break;
                    case "3":
                        AtualizaSerie();
                        break;
                    case "4":
                        ExcluirSerie();
                        break;
                    case "5":
                        VisualizarSerie();
                        break;
                    case "C":
                        Console.Clear();
                        break;
                    case "X":
                        Environment.Exit(0);
                        break;
                    case "M":
                        MenuInicial();
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
                opcaoUsuario = ObterOpcaoUsuarioSerie();

            }
        }

        private static void VisualizarSerie()
        {
            Console.Write("Digite o id da série: ");
            int indiceSerie = int.Parse(Console.ReadLine());
            var serie = repositorioS.RetornaPorId(indiceSerie);
            Console.WriteLine(serie);
        }
        private static void ExcluirSerie()
        {
            Console.Write("Digite o id da série: ");
            int indiceSerie = int.Parse(Console.ReadLine());
            repositorioS.Exclui(indiceSerie);
        }

        private static void AtualizaSerie()
        {
            Console.Write("Digite o id da série");
            int indiceSerie = int.Parse(Console.ReadLine());
            foreach (int i in Enum.GetValues(typeof(Genero)))
            {
                Console.WriteLine($"{i} - {Enum.GetName(typeof(Genero), i)}");

            }
            Console.Write("Digite o genero entre as opções acima: ");
            int entradaGenero = int.Parse(Console.ReadLine());
            Console.Write("Digite o título da série: ");
            string entradaTitulo = Console.ReadLine();
            Console.Write("Digite o ano de lançamento da série: ");
            int entradaAno = int.Parse(Console.ReadLine());
            Console.Write("Digite a descrição da série: ");
            string entradaDescricao = Console.ReadLine();
            Serie atualizaSerie = new Serie(id: indiceSerie,
                                        genero: (Genero)entradaGenero,
                                        titulo: entradaTitulo,
                                        ano: entradaAno,
                                        descricao: entradaDescricao);
            repositorioS.Atualiza(indiceSerie, atualizaSerie);

        }

        private static void InserirSerie()
        {
            foreach (int i in Enum.GetValues(typeof(Genero)))
            {
                Console.WriteLine($"{i} - {Enum.GetName(typeof(Genero), i)}");

            }
            Console.Write("Digite o genero entre as opções acima: ");
            int entradaGenero = int.Parse(Console.ReadLine());
            Console.Write("Digite o título da série: ");
            string entradaTitulo = Console.ReadLine();
            Console.Write("Digite o ano de lançamento da série: ");
            int entradaAno = int.Parse(Console.ReadLine());
            Console.Write("Digite a descrição da série: ");
            string entradaDescricao = Console.ReadLine();
            Serie novaSerie = new Serie(id: repositorioS.ProximoId(),
                                        genero: (Genero)entradaGenero,
                                        titulo: entradaTitulo,
                                        ano: entradaAno,
                                        descricao: entradaDescricao);
            repositorioS.Insere(novaSerie);
        }
        private static void ListarSeries()
        {
            Console.WriteLine("Listar Séries");
            var lista = repositorioS.Lista();
            if (lista.Count == 0)
            {
                Console.WriteLine("Nenhuma série cadastrada.");
                return;
            }
            foreach (var serie in lista)
            {
                var excluido = serie.retornaExcluido();
                Console.WriteLine($"#ID {serie.retornaId()}: - {serie.retornaTitulo()}  {(excluido ? "*Excluido*" : "")}");
            }
        }
        private static string ObterOpcaoUsuarioSerie()
        {
            Console.WriteLine("DIO Séries e Filmes a seu dispor!!!");
            Console.WriteLine();
            Console.WriteLine("Informe a opção desejada:");

            Console.WriteLine("1- Listar séries");
            Console.WriteLine("2- Inserir nova série");
            Console.WriteLine("3- Atualizar série");
            Console.WriteLine("4- Excluir série");
            Console.WriteLine("5- Visualizar série");
            Console.WriteLine("C- Limpar tela");
            Console.WriteLine("M- Menu inicial");
            Console.WriteLine("X- Sair");
            Console.WriteLine();

            string opcaoUsuario = Console.ReadLine().ToUpper();
            Console.WriteLine();
            return opcaoUsuario;
        }
        private static string ObterOpcaoUsuarioFilme()
        {
            Console.WriteLine("DIO Séries e Filmes a seu dispor!!!");
            Console.WriteLine();
            Console.WriteLine("Informe a opção desejada:");

            Console.WriteLine("1- Listar filmes");
            Console.WriteLine("2- Inserir nova filme");
            Console.WriteLine("3- Atualizar filme");
            Console.WriteLine("4- Excluir filme");
            Console.WriteLine("5- Visualizar filme");
            Console.WriteLine("C- Limpar tela");
            Console.WriteLine("M- Menu inicial");
            Console.WriteLine("X- Sair");
            Console.WriteLine();

            string opcaoUsuario = Console.ReadLine().ToUpper();
            Console.WriteLine();
            return opcaoUsuario;
        }
    }
}
