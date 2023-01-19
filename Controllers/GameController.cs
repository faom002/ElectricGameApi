using ElectricGamesApiV1.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using ElectricGamesApiV1.Context;

namespace ElectricGamesApiV1.Controllers;


[ApiController]
[Route("[controller]")]
public class GameController : ControllerBase
{
  private readonly GameContext context;

  public GameController(GameContext _context) // Dependacy injection 
  {
    context = _context; // context is the portal for accessing the database
  }

  [HttpGet]
  public async Task<ActionResult<List<Game>>> Get()
  {
    try
    {
      List<Game> games = await context.Game.ToListAsync();
      return Ok(games); // returning all game characters with the status code 200 :)
    }
    catch
    {
      return StatusCode(500); // 500 is a generic code status that tells us that something went wrong with the server side and that it implies, the database could not be reached
    }
  }


  [HttpGet("{id}")]
  public async Task<ActionResult<Game>> GetById(int id)
  {
    Game? g = await context.Game.FindAsync(id);

    if (g != null)
    {
      return Ok(g); // Status 200 + Cartoon-objektet
    }
    else
    {
      return NotFound(); // Status 404 Ikke Funnet
    }
  }

  // a method for returning by (name) instead of (id)

  [HttpGet]
  [Route("[action]")] // we need to add route action here, so that we do not cause ambiguity between the get method.
  public async Task<IEnumerable<Game>> GetByName(string nameFromDb) // different name fot the method so the url will https://localhost:7XXX/getByTitle/nametypedhere
  {
    List<Game> gameName = await context.Game.ToListAsync();

    if (gameName != null)
    {
      return gameName.Where(name => name.GameName.Contains(nameFromDb)); // and then we return the gameCharacter
    }
    else
    {
      return NotFoundResult();
    }

  }

  private IEnumerable<Game> NotFoundResult()
  {
    throw new NotImplementedException();
  }

  [HttpPost]
  [ActionName(nameof(PostGame))]
  public async Task<ActionResult<Game>> PostGame(Game g)
  {
    try
    {
      context.Game.Add(g);
      await context.SaveChangesAsync();
      return CreatedAtAction(nameof(GetById), new { id = g.Id }, g);
    }
    catch
    {
      return StatusCode(500); // 500 er en generisk status for at noe galt skjedde på serverside; eksempelvis her at Web Api ikke kunne nå databasen.
    }
  }

  [HttpPut]
  public IActionResult Put(Game editedGame)
  {
    context.Entry(editedGame).State = EntityState.Modified;
    context.SaveChanges(); // saves changes to database. 
    return NoContent(); // everything is ok just run further.
  }

 // a method for deleting game character with a given {id}
  [HttpDelete("{id}")]
  public async Task<IActionResult> Delete(int id)
  {
    try
    {
      Game? gameToDelete = await context.Game.FindAsync(id);
      if (gameToDelete != null)  // if character is not null then..
      {
        context.Game.Remove(gameToDelete); // remove the character of your choice
        await context.SaveChangesAsync(); // then save changes to the database
        return NoContent(); // everything is ok
      }
      else
      {
        return NotFound();  // it makes a  notfoundobject that creates a status code 404 not found
      }
    }
    catch
    {
      return StatusCode(500);    // 500 is a generic code that tells us somethig went wrong and in our case could not connect to the api and from there to the sqlite database
    }
  }



}