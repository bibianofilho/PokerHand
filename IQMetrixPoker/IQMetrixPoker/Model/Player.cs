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

        private void sortCards()
        {            
            var queryPalyer = from hand in PlayerHand
                              orderby hand.MyValue descending
                              select hand;

            _playerHand = queryPalyer.ToArray();
        }
    }
}
