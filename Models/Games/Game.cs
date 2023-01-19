using System.ComponentModel.DataAnnotations;
using ElectricGamesApiV1.Interfaces;

namespace ElectricGamesApiV1.Models;


public class Game: IGame
{
    [Key]
    public int Id { get; set; }
    public string GameName { get; set; } = "";
    public string GameGenre { get; set; } = "";
    public string GamePlatform { get; set; } = "";
    public int GamePrice { get; set; }
    public int GameReleaseYear {get; set;}
    public string GameImage { get; set; } = "";

}