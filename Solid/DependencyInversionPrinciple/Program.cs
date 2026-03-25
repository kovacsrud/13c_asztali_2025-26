namespace DependencyInversionPrinciple
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("A függőségek megfordításának elve");

            //A magas szintű modulok ne függjenek az alacsony szintű moduloktól. Mindkettő absztrakcióktól függjön
            
            var rosszUserService=new RosszUserService();

            var userService = new JoUserService(new OracleDB());
            userService.UserMentes("Béla");

        }
    }
}
