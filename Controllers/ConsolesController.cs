using ElectricGamesApiV1.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using ElectricGamesApiV1.Context;

namespace ElectricGamesApiV1.Controllers;


[ApiController]
[Route("[controller]")]
public class ConsolesController : ControllerBase
{
  private readonly GameContext context;

  public ConsolesController(GameContext _context) // Dependacy injection 
  {
    context = _context; // context is the portal for accessing the database
  }

  // a method for getting all of the Consoles

  [HttpGet]
  public async Task<ActionResult<List<ConsolesController>>> Get()
  {
    try
    {
      List<Consoles> gameConsoles = await context.Consoles.ToListAsync();
      return Ok(gameConsoles); // returning all game characters with the status code 200 :)
    }
    catch
    {
      return StatusCode(500); // 500 is a generic code status that tells us that something went wrong with the server side and that it implies, the database could not be reached
    }
  }

  // a method for getting console by given {id}
  [HttpGet("{id}")]
  public async Task<ActionResult<Consoles>> GetById(int id)
  {
    Consoles? gc = await context.Consoles.FindAsync(id);

    if (gc != null)
    {
      return Ok(gc); // Status 200 + Cartoon-objektet
    }
    else
    {
      return NotFound(); // Status 404 Not Found
    }
  }


  /* a method for returning console name as a string an the code inspiration was taken from this link.
  https://stackoverflow.com/questions/46753122/select-a-table-column-from-ienumerable-using-linq
  */
  [HttpGet]
  [Route("[action]")] // we need to add route action here, so that we do not cause ambiguity between the get method.
  public async Task<IEnumerable<Consoles>> GetByName(string consoleNameFromDb) // different name fot the method so the url will https://localhost:7XXX/getByTitle/nametypedhere
  {

    List<Consoles> consolesByName = await context.Consoles.ToListAsync();

    if (consolesByName != null)
    {
      return consolesByName.Where(console => console.ConsoleName.Contains(consoleNameFromDb)); // and then we return the gameCharacter
    }
    else
    {
      return (IEnumerable<Consoles>)NotFound();// status 404 not found and the game character in database is not reached
    }

  }

  /*
  a method for returning console with a minimum price and a maximum price
  */
  [HttpGet]
  [Route("[action]")] // we need to add route action here, so that we do not cause ambiguity between the get method.
  public async Task<IEnumerable<Consoles>> GetByPriceRange(int minPrice, int maxPrice) // different name fot the method so the url will https://localhost:7XXX/getByTitle/nametypedhere
  {

    List<Consoles> consolesByPriceRange = await context.Consoles.ToListAsync();

    if (consolesByPriceRange != null)
    {
      return consolesByPriceRange.Where(console => console.ConsolePrice >= minPrice && console.ConsolePrice <= maxPrice); // and then we return the gameCharacter
    }
    else
    {
      return (IEnumerable<Consoles>)NotFound();// status 404 not found and the game character in database is not reached
    }

  }

// a method for posting a console
  [HttpPost]
  [ActionName(nameof(PostConsole))]
  public async Task<ActionResult<Consoles>> PostConsole(Consoles c)
  {
    try
    {
      context.Consoles.Add(c);
      await context.SaveChangesAsync();
      return CreatedAtAction(nameof(GetById), new { id = c.Id }, c);
    }
    catch
    {
      return StatusCode(500); // 500 is a generic code that tells us somethig went wrong and in our case could not connect to the api and from there to the sqlite database
    }
  }


  // method for updating a console

  [HttpPut]
  public IActionResult Put(Consoles editedConsole)
  {
    context.Entry(editedConsole).State = EntityState.Modified;
    context.SaveChanges(); // saves changes to database. 
    return NoContent(); // everything is ok just run further.
  }

// a method for deleting the console by inserting a {id}
  [HttpDelete("{id}")]
  public async Task<IActionResult> Delete(int id)
  {
    try
    {
      Consoles? consoleToDelete = await context.Consoles.FindAsync(id);
      if (consoleToDelete != null)
      {
        context.Consoles.Remove(consoleToDelete);
        await context.SaveChangesAsync();// save changes to the database
        return NoContent();// everything is ok just run further
      }
      else
      {
        return NotFound(); // it makes a  notfoundobject that creates a status code 404 not found
      }
    }
    catch
    {
      return StatusCode(500); // 500 is a generic code that tells us somethig went wrong and in our case could not connect to the api and from there to the sqlite database
    }
  }

}