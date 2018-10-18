using IQMetrixPoker.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

///@author: Manoel Filho (bibianofilho@gmail.com)
///@date: 2018, October 8 
///<summary>
///This classes implements a method (in C#) which evaluates who are the winner(s) among several 5 card poker
///hands. Note for this project that you only need to implement a subset of the regular poker hands:
///• Flush
///• Three of a Kind
///• One Pair
///• High Card
///</summary>

namespace IQMetrixPoker.Service
{
    public class IQmetrixPokerService
    {
        public List<Player>  EvaluateWinners(List<Player> players)
        {
            List<HandEvaluatorService> playerHands = new List<HandEvaluatorService>();

            foreach (var item in players)
            {               
                Console.WriteLine("\r\n" + item.Name);
                playerHands.Add(new HandEvaluatorService(item));
                PrintCardColored(item.PlayerHand);
            }

            foreach (var item in playerHands)
            {
                item.EvaluateHand();
            }

            var winners = GetWinners(playerHands);
            Console.WriteLine("");
            Console.WriteLine(winners.Count() == 1 ? "  So the winner is:" : "  So the winners are:");
            Console.WriteLine("");
            foreach (var item in winners)
            {
                Console.WriteLine(item.Name);
            }
            return winners;
        }

        private void PrintCardColored(Card[] cards)
        {
            foreach (var card in cards)
            {
                var foreground = Console.ForegroundColor;
                var background = Console.BackgroundColor;

                Console.BackgroundColor = ConsoleColor.White;
                Console.ForegroundColor =
                    card.MySuit == Card.CardSuit.Clubs || card.MySuit == Card.CardSuit.Spades
                        ? ConsoleColor.Black
                        : ConsoleColor.Red;

                Console.Write(card.MyValue + card.MySuit.ToString());

                Console.ForegroundColor = foreground;
                Console.BackgroundColor = background;
                Console.Write(" ");
            }
        }

        //The method Return Winners
        private List<Player> GetWinners(List<HandEvaluatorService> handEvaluators)
        {
            var winners = GetHighestHandWinner(handEvaluators);
            winners = GetHighestCardHandWinner(winners, handEvaluators);
            winners = GetHighestKickerWinner(winners, handEvaluators);
            return winners.ToList();
        }
        
        private List<Player> GetHighestHandWinner(List<HandEvaluatorService> handEvaluators)
        {
            var winningGroup = handEvaluators
                                       .GroupBy( h => h.HandValues.Total)
                                       .OrderBy( h => h.Key)
                                       .Last();

            var winners = winningGroup.Select( h => h.CurrentPlayer).ToList();
            return winners;
        }

        private List<Player> GetHighestCardHandWinner(List<Player> winners, List<HandEvaluatorService> handEvaluators)
        {
            if (winners.Count() > 1)
            {
                var playerHandsWinners = handEvaluators.Where(p => winners.Any(w => p.CurrentPlayer == w)).ToList();
                for (int i = 0; i < playerHandsWinners[0].HandValues.HighCard.Count(); i++)
                {
                    var highCard = playerHandsWinners.Select(_ => _.HandValues.HighCard[i]).Max();
                    playerHandsWinners = playerHandsWinners.Where(p => p.HandValues.HighCard.Any(ph => ph == highCard)).ToList();
                    if (playerHandsWinners.Count() == 1)
                    {
                        break;
                    }
                }
               winners = playerHandsWinners.Select(w => w.CurrentPlayer).ToList();
            }
            return winners;
        }

        private List<Player> GetHighestKickerWinner(List<Player> winners, List<HandEvaluatorService> handEvaluators)
        {
            if (winners.Count() > 1 && handEvaluators.Take(1).SingleOrDefault().PokerHand == Hand.OnePair)
            {
                var playerHandsWinners = handEvaluators.Where(p => winners.Any(w => p.CurrentPlayer == w)).ToList();
                List<int> highestKickerTried = new List<int>();
                for (int i = 0; i < 3; i++)
                {
                    var highestKickerTemp = playerHandsWinners.Where( p => !highestKickerTried.Any(tried => tried == (p.HighestKicker[i])))
                        .Select(p => p.HighestKicker[i])
                        .GroupBy(p => p)
                        .Where(g => g.Count() > 1)
                        .Select( p => p.Key).ToList();
                    if (highestKickerTemp.Count() > 0)
                    {
                        highestKickerTried.Add(highestKickerTemp[0]);
                    }
                    else
                    {
                        winners = playerHandsWinners.Where(p => p.HighestKicker.Any(h => h == playerHandsWinners.Select( hk => hk.HighestKicker[i]).Max()))
                                                    .Select(p => p.CurrentPlayer).ToList();
                        break;
                    }
                }
            }
            return winners;
        }
    }
}
