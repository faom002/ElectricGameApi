using System.ComponentModel.DataAnnotations;
using ElectricGamesApiV1.Interfaces;

namespace ElectricGamesApiV1.Models;


public class Consoles: IConsole
{
    [Key]
    public int Id { get; set; }
    public string ConsoleName { get; set; } = "";
    public int ConsolePrice { get; set; }
    public string ConsoleImage { get; set; } = "";

}