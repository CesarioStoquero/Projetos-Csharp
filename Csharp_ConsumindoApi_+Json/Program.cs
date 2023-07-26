using ScreenSound_04.Modelos;
using System.Text.Json;
using ScreenSound_04.Filtros;

using (HttpClient client = new HttpClient())
{
    try
    {
        string resposta = await client.GetStringAsync("https://guilhermeonrails.github.io/api-csharp-songs/songs.json");
        var musicas = JsonSerializer.Deserialize<List<Musica>>(resposta)!;

        LinqFilter.FiltrarMusicasEmCSharp(musicas);
       // musicas[1].ExibirDetalhesDaMusica();
       // LinqFilter.FiltrarTodosOsGenerosMusicais(musicas);
       // LinqOrder.ExibirListaDeArtistasOrdenados(musicas);
       // LinqFilter.FiltrarArtistasPorGeneroMusical(musicas, "rock");
       // LinqFilter.FiltrarMusicasDeUmArtista(musicas, "U2");

        var musicasPreferidasdoCesario = new MusicasPreferidas("Cesario");
        musicasPreferidasdoCesario.AdicionarMusicasFavoritas(musicas[1]);
        musicasPreferidasdoCesario.AdicionarMusicasFavoritas(musicas[377]);
        musicasPreferidasdoCesario.AdicionarMusicasFavoritas(musicas[4]);
        musicasPreferidasdoCesario.AdicionarMusicasFavoritas(musicas[6]);
        musicasPreferidasdoCesario.AdicionarMusicasFavoritas(musicas[1467]);

        musicasPreferidasdoCesario.ExibirMusicasFavoritas();

        musicasPreferidasdoCesario.GerarArquivoJson();
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Temos um problema: {ex.Message}");
    }
}
