using IQMetrixPoker.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IQMetrixPoker.Service
{
    public enum Hand
    {
        Nothing,
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
    
    public class HandEvaluatorService
    {
        //Properties
        private Card[] _cards { get; set; }
        private HandValue _handValue;
        public HandValue HandValue
        {
            get { return _handValue; }
            set { _handValue = value; }
        }
        private Hand _pokerHand;
        public Hand PokerHand
        {
            get
            {
                return this._pokerHand;
            }
            private set
            {
                // Can only set value in this class.
                this._pokerHand = value;
            }
        }
        

        private Player _currentPlayer;
        public Player CurrentPlayer {
            get
            {
                return this._currentPlayer;
            }
            private set
            {
                // Can only set value in this class.
                this._currentPlayer = value;
            }
        }

        //Constructor
        public HandEvaluatorService(Player currentPlayer)
        {
            this.CurrentPlayer = currentPlayer;
            _cards = new Card[5];
            _cards = currentPlayer.PlayerHand;
            _handValue = new HandValue();
        }

        public void EvaluateHand()
        {
            if (Flush())
            { 
                _pokerHand = Hand.Flush;               
                return;
            }
            else if (ThreeOfKind())
            { 
                _pokerHand = Hand.ThreeOfKind;
                return;
            }else if (OnePair())
            {
                _pokerHand = Hand.OnePair;
                return;
            }
             
            _handValue.HighCard = _cards
                                 .OrderByDescending(_ => _.MyValue)
                                 .Select(_ => (int)_.MyValue).ToArray();
            _pokerHand = Hand.Nothing;
        }

        private bool Flush()
        {           
            var result = _cards.GroupBy(card => card.MySuit)
                               .Any(group => group.Count() == 5);

            if (result)
            {
                _handValue.Total = (int)Hand.Flush;                 
                _handValue.HighCard = _cards
                                 .OrderByDescending(_ => _.MyValue)
                                 .Select( c => (int) c.MyValue).ToArray();
            }
            return result;
        }

        private bool ThreeOfKind()
        {
            var result = _cards.GroupBy(g => g.MyValue)
                                 .Where(g => g.Count() == 3)
                                 .Select( c => (int) c.Key).ToArray();
            if (result.Count() > 0)
            {
                _handValue.HighCard = _cards.GroupBy(g => g.MyValue)
                                 .Where(g => g.Count() == 3)
                                 .Select( c => (int) c.Key).ToArray();
                _handValue.Total = (int)Hand.ThreeOfKind;
                return true;
            }

            return false;
        }

        private bool OnePair()
        {
            GetHighestKicker();
            var result = _cards.GroupBy(g => g.MyValue)
                                .Where(g => g.Count() == 2)
                                .Select( c => (int) c.Key).ToArray();
            if (result.Count() > 0)
            {
                _handValue.HighCard = _cards.GroupBy(g => g.MyValue)
                               .Where(g => g.Count() == 2)
                               .Select( c => (int) c.Key).ToArray();
                _handValue.Total = (int)Hand.OnePair;
                return true;
            }
            return false;
        }
         
        public void GetHighestKicker()
        {
            var onePair = _cards.GroupBy(card => card.MyValue)
                                .Where(group => group.Count() >= 2)
                                .Select(g => g.Key).SingleOrDefault();

            var highCard = _cards.Where(c => onePair != c.MyValue)
                                 .OrderByDescending( c => c.MyValue )
                                 .Select(c =>  (int) c.MyValue);
            _handValue.HighestKicker = highCard.ToArray(); 
        }
    }
}
