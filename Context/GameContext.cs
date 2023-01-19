#nullable disable // disables nullables alternative could be that you initilized with (?)
using Microsoft.EntityFrameworkCore; // if GameContext was in its own folder then we need to import Models classe
using ElectricGamesApiV1.Models;

namespace ElectricGamesApiV1.Context;
public class GameContext : DbContext
{

    //when context is initialized then thats when we can begin to use database
    public GameContext(DbContextOptions<GameContext> options) : base(options){}

    public DbSet<GameCharacter> GameCharacters {get;set;}
    public DbSet<Consoles> Consoles {get;set;}
    public DbSet<Game> Game {get;set;}
    public DbSet<QuizMultipleChoice> QuizMultipleChoice { get; set; }


}
