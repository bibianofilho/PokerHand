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
    public struct HandValue
    {
        public int Total { get; set; }
        public int HighCard { get; set; }

    }
    public class HandEvaluatorService
    {
        //Properies
        private Card[] _cards { get; set; }
        private HandValue _handValue;
        public HandValue HandValues
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
        private int[] _highestKicker;
        public int[] HighestKicker
        {
            get
            {
                return this._highestKicker;
            }
            private set
            {
                // Can only set value in this class.
                this._highestKicker = value;
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
            _cards = currentPlayer.PortedPlayerHand;
            _handValue = new HandValue();
        }

        public void EvaluateHand()
        {
            if (Flush())
            {
                _handValue.Total = (int)Hand.Flush;
                _pokerHand = Hand.Flush;
                _handValue.HighCard = (int)_cards.Select(c => c.MyValue) .Max();
                return;
            }
            else if (ThreeOfKind())
            {
                _handValue.Total = (int)Hand.ThreeOfKind;
                _pokerHand = Hand.ThreeOfKind;
                return;
            }else if (OnePair())
            {
                _pokerHand = Hand.OnePair;
                return;
            }

            _handValue.HighCard = (int)_cards[4].MyValue;
            _pokerHand = Hand.Nothing;
        }

        private bool HasThreeOfaKind(Card[] cards)
        {
            var result = cards.GroupBy(card => card.MyValue)
                              .Any(group => group.Count() == 3);
            return result;
        }

        private bool Flush()
        {           
            var result = _cards.GroupBy(card => card.MySuit)
                               .Any(group => group.Count() == 5);
            return result;
        }

        private bool ThreeOfKind()
        {
            if(( _cards[0].MyValue == _cards[1].MyValue  && _cards[0].MyValue == _cards[2].MyValue) ||
              ( _cards[1].MyValue == _cards[2].MyValue && _cards[1].MyValue == _cards[2].MyValue))
            {
                _handValue.Total = (int)_cards[2].MyValue * 3;
                _handValue.HighCard = (int)_cards[4].MyValue;
                return true;
            }else if ( _cards[2].MyValue == _cards[3].MyValue && _cards[2].MyValue == _cards[4].MyValue)
            {
                _handValue.Total = (int)_cards[2].MyValue * 3;
                _handValue.HighCard = (int)_cards[1].MyValue;
                return true;
            }
            return false;
        }

        private bool OnePair()
        {
            GetHighestKicker();
            if (_cards[0].MyValue == _cards[1].MyValue)
            {
                _handValue.Total = (int)_cards[0].MyValue * 2;
                _handValue.HighCard = (int)_cards[4].MyValue * 2;
                return true;
            }else if (_cards[1].MyValue == _cards[2].MyValue)
            {
                _handValue.Total = (int)_cards[1].MyValue * 2;
                _handValue.HighCard = (int)_cards[4].MyValue * 2;
                return true;
            }else if (_cards[2].MyValue == _cards[3].MyValue)
            {
                _handValue.Total = (int)_cards[2].MyValue * 2;
                _handValue.HighCard = (int)_cards[4].MyValue * 2;
                return true;
            }
            else if (_cards[3].MyValue == _cards[4].MyValue)
            {
                _handValue.Total = (int)_cards[3].MyValue * 2;
                _handValue.HighCard = (int)_cards[4].MyValue * 2;
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
                                 .OrderByDescending(_ => _.MyValue )
                                 .Select(_ =>  (int)_.MyValue);
            HighestKicker = highCard.ToArray(); 
        }
    }
}
