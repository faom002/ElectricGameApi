using System.ComponentModel.DataAnnotations;
using ElectricGamesApiV1.Interfaces;


namespace ElectricGamesApiV1.Models;


public class QuizMultipleChoice : IQuizMultipleChoice
{
    [Key]
    public int Id { get; set; }
    public string Question { get; set; } = "";
    public string AnswerOne { get; set; } = "";
    public string AnswerTwo { get; set; } = "";
    public string AnswerThree { get; set; } = "";
    public string AnswerFour { get; set; } = "";
    public string CorrectAnswer { get; set; } = "";
  
}