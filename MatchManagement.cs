using System;
using System.Collections.Generic;
using System.Linq;

public class MatchManagement
{
    private List<MatchDetails> matches;

    public MatchManagement()
    {
        matches = new List<MatchDetails>();
    }

   
    private bool ValidateMatchDetails(MatchDetails match)
    {
        return true;
    }

    public void AddMatch(MatchDetails match)
    {
        if (ValidateMatchDetails(match))
        {
            matches.Add(match);
        }
        else
        {
            Console.WriteLine("Invalid match details. Match not added.");
        }
    }

    public void SortMatches(string criteria, bool ascending)
    {
        switch (criteria.ToLower())
        {
            case "date":
                matches = ascending ? matches.OrderBy(m => m.MatchDateTime).ToList() : matches.OrderByDescending(m => m.MatchDateTime).ToList();
                break;
            case "sport":
                matches = ascending ? matches.OrderBy(m => m.Sport).ToList() : matches.OrderByDescending(m => m.Sport).ToList();
                break;
            case "location":
                matches = ascending ? matches.OrderBy(m => m.Location).ToList() : matches.OrderByDescending(m => m.Location).ToList();
                break;
            default:
                Console.WriteLine("Invalid sorting criteria.");
                break;
        }
    }

    public List<MatchDetails> FilterMatches(string criteria, string value)
    {
        switch (criteria.ToLower())
        {
            case "sport":
                return matches.Where(m => m.Sport.Equals(value, StringComparison.OrdinalIgnoreCase)).ToList();
            case "location":
                return matches.Where(m => m.Location.Equals(value, StringComparison.OrdinalIgnoreCase)).ToList();
            case "daterange":
                DateTime startDate;
                DateTime endDate;
                if (DateTime.TryParse(value.Split('-')[0], out startDate) && DateTime.TryParse(value.Split('-')[1], out endDate))
                {
                    return matches.Where(m => m.MatchDateTime >= startDate && m.MatchDateTime <= endDate).ToList();
                }
                else
                {
                    Console.WriteLine("Invalid date range format. Use format 'yyyy-mm-dd - yyyy-mm-dd'.");
                }
                break;
            default:
                Console.WriteLine("Invalid filtering criteria.");
                break;
        }

        return new List<MatchDetails>();
    }


    public List<MatchDetails> SearchMatches(string keyword)
    {
        return matches.Where(m =>
            m.Sport.Contains(keyword, StringComparison.OrdinalIgnoreCase) ||
            m.HomeTeam.Contains(keyword, StringComparison.OrdinalIgnoreCase) ||
            m.AwayTeam.Contains(keyword, StringComparison.OrdinalIgnoreCase) ||
            m.Location.Contains(keyword, StringComparison.OrdinalIgnoreCase)
        ).ToList();
    }

    public void DisplayAllMatches()
    {
        foreach (var match in matches)
        {
            Console.WriteLine($"Match ID: {match.MatchId}, Sport: {match.Sport}, Date: {match.MatchDateTime}, Location: {match.Location}, Teams: {match.HomeTeam} vs {match.AwayTeam}, Scores: {match.HomeTeamScore} - {match.AwayTeamScore}");
        }
    }

    public void DisplayMatchDetails(int matchId)
    {
        var match = matches.Find(m => m.MatchId == matchId);
        if (match != null)
        {
            Console.WriteLine($"Match ID: {match.MatchId} , Sport: {match.Sport}, Date: {match.MatchDateTime}, Location: {match.Location}, Teams: {match.HomeTeam} vs {match.AwayTeam}, Scores: {match.HomeTeamScore} - {match.AwayTeamScore}");
        }
        else
        {
            Console.WriteLine("Match not found.");
        }
    }

    public void UpdateMatchScore(int matchId, int homeScore, int awayScore)
    {
        var match = matches.Find(m => m.MatchId == matchId);
        if (match != null)
        {
            match.HomeTeamScore = homeScore;
            match.AwayTeamScore = awayScore;
            Console.WriteLine("Scores updated successfully.");
        }
        else
        {
            Console.WriteLine("Match not found.");
        }
    }

    public void RemoveMatch(int matchId)
    {
        var match = matches.Find(m => m.MatchId == matchId);
        if (match != null)
        {
            matches.Remove(match);
            Console.WriteLine("Match removed successfully.");
        }
        else
        {
            Console.WriteLine("Match not found.");
        }
    }
}

