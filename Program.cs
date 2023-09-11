namespace Match_Details_Management_System
{
    internal class Program
    {
        static void Main()
        {
            MatchManagement matchManagement = new MatchManagement();

            // Add at least 6 MatchDetails objects
            matchManagement.AddMatch(new MatchDetails { MatchId = 1, Sport = "Soccer", MatchDateTime = DateTime.Parse("2023-09-07 14:00"), Location = "Stadium A", HomeTeam = "Team A", AwayTeam = "Team B", HomeTeamScore = 0, AwayTeamScore = 0 });
            matchManagement.AddMatch(new MatchDetails { MatchId = 2, Sport = "Cricket", MatchDateTime = DateTime.Parse("2023-10-23 16:00"), Location = "Wankhed", HomeTeam = "Team CSK", AwayTeam = "Team RCB", HomeTeamScore = 60, AwayTeamScore = 90 });
            matchManagement.AddMatch(new MatchDetails { MatchId = 3, Sport = "BasketBall", MatchDateTime = DateTime.Parse("2023-11-07 14:00"), Location = "Arena A", HomeTeam = "Los Angeles Lakers", AwayTeam = "Golden State Warriors", HomeTeamScore = 60, AwayTeamScore = 80 });
            matchManagement.AddMatch(new MatchDetails { MatchId = 4, Sport = "Tennis", MatchDateTime = DateTime.Parse("2023-12-07 14:00"), Location = "Court 1", HomeTeam = "Team A", AwayTeam = "Team B", HomeTeamScore = 4, AwayTeamScore = 2 });
            matchManagement.AddMatch(new MatchDetails { MatchId = 5, Sport = "Cricket", MatchDateTime = DateTime.Parse("2023-01-07 14:00"), Location = "Wankhede", HomeTeam = "Team MI", AwayTeam = "Team KKR", HomeTeamScore = 2, AwayTeamScore = 3 });

            // Add more matches here...

            bool continueRunning = true;

            while (continueRunning)
            {
                Console.WriteLine("\n**************************************************MATCH DETAILS********************************************");
                Console.WriteLine("(1) Display All Matches");
                Console.WriteLine("(2) Enter Match Details");
                Console.WriteLine("(3) Update Match Score");
                Console.WriteLine("(4) Remove Match");
                Console.WriteLine("(5) Sort Matches");
                Console.WriteLine("(6) Filter Matches");
                Console.WriteLine("(7) Search Matches");
                Console.WriteLine("(8) Exit");

                int choice;
                if (int.TryParse(Console.ReadLine(), out choice))
                {
                    switch (choice)
                    {
                        case 1:
                            matchManagement.DisplayAllMatches();
                            break;
                        case 2:
                            Console.Write("Enter Match ID: ");
                            int matchId = int.Parse(Console.ReadLine());
                            matchManagement.DisplayMatchDetails(matchId);
                            Console.WriteLine("Match ID entered successfully")
                            break;
                        case 3:
                            Console.Write("Enter Match ID: ");
                            int id = int.Parse(Console.ReadLine());
                            Console.Write("Enter Home Team Score: ");
                            int homeScore = int.Parse(Console.ReadLine());
                            Console.Write("Enter Away Team Score: ");
                            int awayScore = int.Parse(Console.ReadLine());
                            matchManagement.UpdateMatchScore(id, homeScore, awayScore);
                            Console.WriteLine("Updated Successfully")
                            break;
                        case 4:
                            Console.Write("Enter Match ID: ");
                            int removeId = int.Parse(Console.ReadLine());
                            matchManagement.RemoveMatch(removeId);
                            Console.WriteLine("Removed Successfully")
                            break;
                        case 5:
                            Console.WriteLine("Sort by: (date/sport/location)");
                            string criteria = Console.ReadLine();
                            Console.WriteLine("Ascending? (true/false)");
                            bool ascending = bool.Parse(Console.ReadLine());
                            matchManagement.SortMatches(criteria, ascending);
                            matchManagement.DisplayAllMatches();
                            Console.WriteLine("Sorted Successfully")
                            break;
                        case 6:
                            Console.WriteLine("Filter by: (sport/location/daterange)");
                            string filterCriteria = Console.ReadLine();
                            Console.WriteLine("Enter value: ");
                            string value = Console.ReadLine();
                            List<MatchDetails> filteredMatches = matchManagement.FilterMatches(filterCriteria, value);
                            Console.WriteLine("\nFiltered Matches:");
                            foreach (var match in filteredMatches)
                            {
                                Console.WriteLine($"Match ID: {match.MatchId}, Sport: {match.Sport}, Date: {match.MatchDateTime}, Location: {match.Location}, Teams: {match.HomeTeam} vs {match.AwayTeam}, Scores: {match.HomeTeamScore} - {match.AwayTeamScore}");
                            }
                            Console.WriteLine("Filtered Successfully")
                            break;
                        case 7:
                            Console.WriteLine("Search for: ");
                            string keyword = Console.ReadLine();
                            List<MatchDetails> searchedMatches = matchManagement.SearchMatches(keyword);
                            Console.WriteLine("\nSearched Matches:");
                            foreach (var match in searchedMatches)
                            {
                                Console.WriteLine($"Match ID: {match.MatchId}, Sport: {match.Sport}, Date: {match.MatchDateTime}, Location: {match.Location}, Teams: {match.HomeTeam} vs {match.AwayTeam}, Scores: {match.HomeTeamScore} - {match.AwayTeamScore}");
                            }
                            Console.WriteLine("Searched Successfully")
                            break;
                        case 0:
                            continueRunning = false;
                            break;
                        default:
                            Console.WriteLine("PLEASE TRY AGAIN :(");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("PLEASE ENTER VALID NUMBER :<");
                }
            }
        }
    }
}