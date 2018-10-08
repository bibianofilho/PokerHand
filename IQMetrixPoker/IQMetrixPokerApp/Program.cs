using IQMetrixPoker.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IQMetrixPokerApp
{
    class Program
    {
        static void Main(string[] args)
        {
            //I did not implement the method to generate the cards, to huffle and to give the deck of cards to each player
            //because it was not required in the assignment
            Player playerOne = new Player();
            playerOne.Name = "Joe";
            playerOne.PlayerHand = new Card[]{
                new Card { MyValue= Card.PlayingCardNominalValue.Two, MySuit = Card.CardSuit.Hearts  },
                new Card { MyValue= Card.PlayingCardNominalValue.Three, MySuit = Card.CardSuit.Diamonds  },
                new Card { MyValue= Card.PlayingCardNominalValue.Four, MySuit = Card.CardSuit.Clubs  },
                new Card { MyValue= Card.PlayingCardNominalValue.Five, MySuit = Card.CardSuit.Diamonds  },
                new Card { MyValue= Card.PlayingCardNominalValue.Ten, MySuit = Card.CardSuit.Hearts  },
            };

            Player playerTwo = new Player();
            playerTwo.Name = "Jen";
            playerTwo.PlayerHand = new Card[]{
                new Card { MyValue= Card.PlayingCardNominalValue.Five, MySuit = Card.CardSuit.Clubs  },
                new Card { MyValue= Card.PlayingCardNominalValue.Seven, MySuit = Card.CardSuit.Diamonds  },
                new Card { MyValue= Card.PlayingCardNominalValue.Eight, MySuit = Card.CardSuit.Hearts  },
                new Card { MyValue= Card.PlayingCardNominalValue.Nine, MySuit = Card.CardSuit.Spades  },
                new Card { MyValue= Card.PlayingCardNominalValue.Queen, MySuit = Card.CardSuit.Diamonds  },
            };

            Player playerThree = new Player();
            playerThree.Name = "Bob";
            playerThree.PlayerHand = new Card[]{
                new Card { MyValue= Card.PlayingCardNominalValue.Two, MySuit = Card.CardSuit.Clubs  },
                new Card { MyValue= Card.PlayingCardNominalValue.Four, MySuit = Card.CardSuit.Clubs  },
                new Card { MyValue= Card.PlayingCardNominalValue.Five, MySuit = Card.CardSuit.Clubs  },
                new Card { MyValue= Card.PlayingCardNominalValue.Ten, MySuit = Card.CardSuit.Clubs  },
                new Card { MyValue= Card.PlayingCardNominalValue.Jack, MySuit = Card.CardSuit.Clubs  },
            };

            List<Player> players = new List<Player>();
            players.Add(playerOne);
            players.Add(playerTwo);
            players.Add(playerThree);


            IQmetrixPokerService iQmetrixPokerService = new IQmetrixPokerService();
            var winners  = iQmetrixPokerService.EvaluateWinners(players);
            Console.ReadLine();
        }
    }
}

