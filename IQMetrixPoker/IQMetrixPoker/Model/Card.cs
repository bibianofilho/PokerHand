using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IQMetrixPoker.Service
{
    public class Card
    {
        /// <summary>
        /// PokerHands
        /// </summary>
        public enum PokerHands
        {
            OnePair,
            TwoPair,
            ThreeOfKind,
            Straight,
            Flush,
            FullHouse,
            FourOfKind,
            StraightFlush,
            RoyalFlush
        }

        /// <summary>
        /// Playing card suit
        /// </summary>
        public enum CardSuit
        {
            Hearts, Diamonds, Clubs, Spades
        }

        /// <summary>
        /// Card Value/Rank
        /// </summary>
        public enum PlayingCardNominalValue
        {
            Two = 2, Three, Four, Five, Six, Seven, Eight,
            Nine, Ten, Jack, Queen, King, Ace
        }

        public CardSuit  MySuit { get; set; }
        public PlayingCardNominalValue MyValue { get; set; }
    }
}
