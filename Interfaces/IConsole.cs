namespace ElectricGamesApiV1.Interfaces;

interface IConsole
{
  int Id { get; set; }
  string ConsoleName { get; set; } 
  int ConsolePrice { get; set; }
  string ConsoleImage { get; set; }
}