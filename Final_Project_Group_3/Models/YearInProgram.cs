namespace Final_Project_Group_3.Models
{
    public class YearInProgram
    {
        public int Id { get; set; }
        public string YearName { get; set; }
        public int YearNumber { get; set; }
        public string Description { get; set; }
        public bool IsFinalYear { get; set; }
        public DateTime StartDate { get; set; }
    }
}
