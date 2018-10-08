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
            return winners.ToList();
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

        //The method 
        private IEnumerable<Player> GetWinners(IEnumerable<HandEvaluatorService> playerHands)
        {

            var winningGroup = playerHands
                                        .GroupBy(_ => _.HandValues.Total)
                                        .OrderBy(_ => _.Key)
                                        .Last();

            var winners = winningGroup.Select(_ => _.CurrentPlayer).ToArray();

            List<HandEvaluatorService> playerHandsWinners = new List<HandEvaluatorService>() ;

            if (winners.Count() > 1)
            {
                playerHandsWinners = playerHands.Where(p => winners.Any(w => p.CurrentPlayer == w)).ToList();
                var highCard = playerHandsWinners.OrderByDescending(h => h.HandValues.HighCard).Take(1).SingleOrDefault().HandValues.HighCard;
                winners = playerHandsWinners.Where(p => p.HandValues.HighCard == highCard).Select(_ => _.CurrentPlayer).ToArray();
            }

            if (winners.Count() > 1 && playerHands.Take(1).SingleOrDefault().PokerHand == Hand.OnePair)
            {
                List<int> highestKickerTried = new List<int>();
                highestKickerTried.Add(0);
                for (int i = 0; i < 3; i++)
                {
                    var highestKickerTemp = playerHandsWinners.Where(_ => !highestKickerTried.Any(tried => tried == (_.HighestKicker[i]))).Select(p => p.HighestKicker[i]).GroupBy(_ => _).Where( g => g.Count() > 1).Select( _ => _.Key).ToList();
                    if (highestKickerTemp.Count() > 0)
                    {
                        highestKickerTried.Add(highestKickerTemp[0]);
                    }
                    else
                    {
                        winners =  playerHandsWinners.Where(p => p.HighestKicker.Any(h => h == playerHandsWinners.Select(_ => _.HighestKicker[i]).Max())).Select( p => p.CurrentPlayer).ToArray();
                        break;
                    }
                }
            }
            return winners;
        }
        
    }
}
