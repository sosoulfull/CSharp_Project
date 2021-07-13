namespace CSharp_Project.Controllers
{
    public class DataController
    {

        private static Context context;
        
        public DataController(Context DBContext)
        {
            context = DBContext;
        }


        private static string[] groups = {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
        };

        [HttpGet("getallthedata")]
        public IActionResult GetData()
        {
            foreach(string t in groups)
            {
                string[] info = t.Split(",");
                context.Groups.Add(
                    new Team() {
                        Location=info[0],
                        TeamName=info[1],
                        LeagueId=Int32.Parse(info[2])
                    }
                );
            }
            context.SaveChanges();
    }
}