using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace ScreenSound.Modelos
{
    internal class Banda : IAvaliavel
    {
        private readonly List<Album> albuns = new List<Album>();
        private readonly List<Avaliacao> notas = new List<Avaliacao>();

        public Banda(string nome)
        {
            Nome = nome;
            Albuns = new ReadOnlyCollection<Album>(albuns);
        }

        public string Nome { get; }
        public double Media
        {
            get
            {
                if (notas.Count == 0) return 0;
                else
                    return notas.Average(n => n.Nota);
            }
        }
        public IReadOnlyCollection<Album> Albuns { get; }
        public string? Resumo { get; set; }

        public void AdicionarAlbum(Album album)
        {
            albuns.Add(album);
        }

        public void AdicionarNota(Avaliacao nota)
        {
            notas.Add(nota);
        }

        public void ExibirDiscografia()
        {
            Console.WriteLine($"Discografia da banda {Nome}");
            foreach (Album album in albuns)
            {
                Console.WriteLine($"Álbum: {album.Nome} ({album.DuracaoTotal})");
            }
            Console.WriteLine();
            Console.WriteLine(Resumo);
        }
    }
}
