using ElectricGamesApiV1.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using ElectricGamesApiV1.Context;

namespace ElectricGamesApiV1.Controllers;


[ApiController]
[Route("[controller]")]
public class GameCharacterController : ControllerBase
{
  private readonly GameContext context;

  public GameCharacterController(GameContext _context) // Dependacy injection 
  {
    context = _context; // context is the portal for accessing the database
  }


  [HttpGet]
  public async Task<ActionResult<List<GameCharacter>>> Get()
  {
    try
    {
      List<GameCharacter> gameCharacters = await context.GameCharacters.ToListAsync(); // converting to a list 
      return Ok(gameCharacters); // returning all game characters with the status code 200 :)
    }
    catch
    {
      return StatusCode(500); // 500 is a generic code status that tells us that something went wrong with the server side and that it implies, the database could not be reached
    }
  }

  // a method for returning by (name) instead of (id)

  [HttpGet("{id}")]
  public async Task<ActionResult<GameCharacter>> GetById(int id)
  {
    GameCharacter? gc = await context.GameCharacters.FindAsync(id);

    if (gc != null)
    {
      return Ok(gc); // Status 200 + Cartoon-objektet
    }
    else
    {
      return NotFound(); // Status 404 Ikke Funnet
    }
  }

  /* a method for returning game character name as a string and the code inspiration was taken from this link.
  https://stackoverflow.com/questions/46753122/select-a-table-column-from-ienumerable-using-linq
  */

  [HttpGet]
  [Route("[action]")] // we need to add route action here, so that we do not cause ambiguity between the get method.
  public async Task<IEnumerable<GameCharacter>> GetByName(string characterName) // different name fot the method so the url will https://localhost:7XXX/getByTitle/nametypedhere
  {


    List<GameCharacter> gameCharacterByName = await context.GameCharacters.ToListAsync();

    if (gameCharacterByName != null)
    {
      return gameCharacterByName.Where(character => character.CharacterName.Contains(characterName)); // and then we return the gameCharacter
    }
    else
    {
      return NotFoundResult();// status 404 not found and the game character in database is not reached
    }

  }

  private IEnumerable<GameCharacter> NotFoundResult()
  {
    throw new NotImplementedException();
  }


  // a mtehod for posting a game character
  [HttpPost]
  [ActionName(nameof(PostCharacter))]
  public async Task<ActionResult<GameCharacter>> PostCharacter(GameCharacter gc)
  {
    try
    {
      context.GameCharacters.Add(gc);
      await context.SaveChangesAsync();
      return CreatedAtAction(nameof(GetById), new { id = gc.Id }, gc);
    }
    catch
    {
      return StatusCode(500); // 500 is a generic code that tells us somethig went wrong and in our case could not connect to the api and from there to the sqlite database
    }
  }
  // a method for updating gamecharacter  
  [HttpPut]
  public IActionResult Put(GameCharacter editedGameCharacter)
  {
    context.Entry(editedGameCharacter).State = EntityState.Modified;
    context.SaveChanges(); // saves changes to database. 
    return NoContent(); // everything is ok just run further.
  }

  // a method for deleting game character with a given {id}
  [HttpDelete("{id}")]
  public async Task<IActionResult> Delete(int id)
  {
    try
    {
      GameCharacter? characterToDelete = await context.GameCharacters.FindAsync(id);
      if (characterToDelete != null) // if character is not null then..
      {
        context.GameCharacters.Remove(characterToDelete);// remove the character of your choice
        await context.SaveChangesAsync();// then save changes to the database
        return NoContent();// everything is ok
      }
      else
      {
        return NotFound(); // it makes a  notfoundobject that creates a status code 404 not found
      }
    }
    catch
    {
      return StatusCode(500);// 500 is a generic code that tells us somethig went wrong and in our case could not connect to the api and from there to the sqlite database
    }
  }
}