using Microsoft.AspNetCore.Mvc;
namespace My_PracticeWork.Models
{
    public class Person
    {
        public string Id { get; set; } = "";
        public string Name { get; set; } = "";
        public string Surname { get; set; } = "";
        public string Middle_Name { get; set; } = "";
        public int Birth_Year { get; set; }
        public int Birth_Month { get; set; }
        public int Birth_Day { get; set; }
    }
}
