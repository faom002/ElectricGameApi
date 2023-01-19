namespace ElectricGamesApiV1.Interfaces;

interface IQuizMultipleChoice
{
  int Id { get; set; }
  string Question { get; set; }
  string AnswerOne { get; set; }
  string AnswerTwo { get; set; }
  string AnswerThree { get; set; }
  string AnswerFour { get; set; }
  string CorrectAnswer { get; set; }
}