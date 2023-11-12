using ScreenSound.Menus;
using ScreenSound.Modelos;
using OpenAI_API;

internal class Program
{
    private static void Main(string[] args)
    {

        Menu menu = new Menu();

        Banda ira = new Banda("Ira");
        ira.AdicionarAlbum(new Album("Folk"));
        ira.AdicionarNota(new Avaliacao(10));
        ira.AdicionarNota(new Avaliacao(8));
        ira.AdicionarNota(new Avaliacao(6));

        Banda beatles = new("The Beatles");
        beatles.AdicionarNota(new Avaliacao(10));
        beatles.AdicionarNota(new Avaliacao(6));

        Banda linkinPark = new("Linkin Park");
        linkinPark.AdicionarNota(new Avaliacao(10));
        linkinPark.AdicionarNota(new Avaliacao(10));

        Dictionary<string, Banda> bandasRegistradas = new();
        bandasRegistradas.Add(ira.Nome, ira);
        bandasRegistradas.Add(beatles.Nome, beatles);
        bandasRegistradas.Add(linkinPark.Nome, linkinPark);

        Dictionary<int, Menu> opcoes = new();
        opcoes.Add(1, new MenuRegistrarBanda());
        opcoes.Add(2, new MenuRegistrarAlbum());
        opcoes.Add(3, new MenuMostrarBandas());
        opcoes.Add(4, new MenuAvaliarBanda());
        opcoes.Add(5, new MenuAvaliarAlbum());
        opcoes.Add(6, new MenuExibirDetalhes());
        opcoes.Add(0, new MenuSair());

        void ExibirLogo()
        {
            Console.WriteLine(@"

░██████╗░█████╗░██████╗░███████╗███████╗███╗░░██╗  ░██████╗░█████╗░██╗░░░██╗███╗░░██╗██████╗░
██╔════╝██╔══██╗██╔══██╗██╔════╝██╔════╝████╗░██║  ██╔════╝██╔══██╗██║░░░██║████╗░██║██╔══██╗
╚█████╗░██║░░╚═╝██████╔╝█████╗░░█████╗░░██╔██╗██║  ╚█████╗░██║░░██║██║░░░██║██╔██╗██║██║░░██║
░╚═══██╗██║░░██╗██╔══██╗██╔══╝░░██╔══╝░░██║╚████║  ░╚═══██╗██║░░██║██║░░░██║██║╚████║██║░░██║
██████╔╝╚█████╔╝██║░░██║███████╗███████╗██║░╚███║  ██████╔╝╚█████╔╝╚██████╔╝██║░╚███║██████╔╝
╚═════╝░░╚════╝░╚═╝░░╚═╝╚══════╝╚══════╝╚═╝░░╚══╝  ╚═════╝░░╚════╝░░╚═════╝░╚═╝░░╚══╝╚═════╝░
");
            Console.WriteLine("Boas vindas ao Screen Sound 2.0!");
        }

        void ExibirOpcoesDoMenu()
        {
            ExibirLogo();
            Console.WriteLine("\nDigite 1 para registrar uma banda");
            Console.WriteLine("Digite 2 para registrar o álbum de uma banda");
            Console.WriteLine("Digite 3 para mostrar todas as bandas");
            Console.WriteLine("Digite 4 para avaliar uma banda");
            Console.WriteLine("Digite 5 para Avaliar um Album de uma banda");
            Console.WriteLine("Digite 6 para exibir os detalhes de uma banda");
            Console.WriteLine("Digite 0 para sair");

            Console.Write("\nDigite a sua opção: ");
            int opcaoEscolhida = int.Parse(Console.ReadLine()!);

            if (opcoes.ContainsKey(opcaoEscolhida))
            {
                Menu menuEscolhido = opcoes[opcaoEscolhida];
                menuEscolhido.Executar(bandasRegistradas);
                if (opcaoEscolhida != 0) ExibirOpcoesDoMenu();
            }
            else
                Console.WriteLine("Opção inválida");
        }
        ExibirOpcoesDoMenu();
    }
}