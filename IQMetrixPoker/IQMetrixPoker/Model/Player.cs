using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IQMetrixPoker.Service
{
    public class Player
    {
        public string Name { get; set; }

        private Card[] _playerHand;
        public Card[] PlayerHand {
            get {
                return this._playerHand;
            }
            set {
                this._playerHand = value;
                sortCards();
            }
        }

        private Card[] sortedPlayerHand;
        public Card[] PortedPlayerHand
        {
            get
            {
                return this.sortedPlayerHand;
            }
            private set
            {
                this.sortedPlayerHand = value;
            }
        }

        private void sortCards()
        {
            sortedPlayerHand = new Card[5];
            var queryPalyer = from hand in PlayerHand
                              orderby hand.MyValue
                              select hand;

            sortedPlayerHand = queryPalyer.ToArray();
        }
    }
}
