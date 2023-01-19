namespace ElectricGamesApiV1.Interfaces;

interface IGame
{
    int Id { get; set; }
    string GameName { get; set; } 
     string GameGenre { get; set; }
     string GamePlatform { get; set; } 
     int GamePrice { get; set; }
     int GameReleaseYear {get; set;}
     string GameImage { get; set; } 
}