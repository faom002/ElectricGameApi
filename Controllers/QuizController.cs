using ElectricGamesApiV1.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using ElectricGamesApiV1.Context;

namespace ElectricGamesApiV1.Controllers;

[ApiController]
[Route("[controller]")]
public class QuizController : ControllerBase
{

    private readonly GameContext context;


    public QuizController(GameContext _context) // Dependacy injection 
    {
        context = _context; // context is the portal for accessing the database
    }

  


    

       [HttpGet]
    public async Task<ActionResult<List<QuizMultipleChoice>>> Get()
    {

       //will update the database
        try
        {
            List<QuizMultipleChoice> quizQuestions = await context.QuizMultipleChoice.ToListAsync();
            return Ok(quizQuestions); // returning all game characters with the status code 200 :)
        }
        catch
        {
            return StatusCode(500); // 500 is a generic code status that tells us that something went wrong with the server side and that it implies, the database could not be reached
        }
    }
}