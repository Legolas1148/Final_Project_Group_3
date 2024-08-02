namespace TeamWebAPI.Models
{
    public class CollegeProgram
    {
        public int Id { get; set; }
        public string ProgramName { get; set; }
        public string Department { get; set; }
        public string DegreeType { get; set; }
        public int DurationYears { get; set; }
        public string Description { get; set; }
    }
}
