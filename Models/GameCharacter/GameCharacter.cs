using System.ComponentModel.DataAnnotations;
using ElectricGamesApiV1.Interfaces;

namespace ElectricGamesApiV1.Models;


public class GameCharacter: IGameCharacter
{
    [Key]
    public int Id { get; set; }
    public string CharacterName { get; set; } = "";
    public string CharacterGame { get; set; } = "";
    public int CharacterAge { get; set; }
    public string CharacterImage { get; set; } = "";

}