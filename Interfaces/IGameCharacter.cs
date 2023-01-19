namespace ElectricGamesApiV1.Interfaces;

interface IGameCharacter
{
  int Id { get; set; }
  string CharacterName { get; set; } 
  string CharacterGame { get; set; } 
  int CharacterAge { get; set; }
  string CharacterImage { get; set; } 
}