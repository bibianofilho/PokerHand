using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using IQMetrixPoker.Service;
using System.Collections.Generic;

namespace IQmetrixPokerTest
{
    //I used the same examples from PDF file to create the test methods
    [TestClass]
    public class IQMetrixPokerTest
    {
        
        [TestMethod]
        public void  Test1()
        {
            Player playerOne = new Player();
            playerOne.Name = "Joe";
            playerOne.PlayerHand = new Card[]{
                new Card { MyValue= (Card.PlayingCardNominalValue) 8 , MySuit = Card.CardSuit.Spades  },
                new Card { MyValue= (Card.PlayingCardNominalValue)8, MySuit = Card.CardSuit.Diamonds  },
                new Card { MyValue= (Card.PlayingCardNominalValue)14 , MySuit = Card.CardSuit.Diamonds  },
                new Card { MyValue= (Card.PlayingCardNominalValue)12, MySuit = Card.CardSuit.Diamonds  },
                new Card { MyValue= (Card.PlayingCardNominalValue)11, MySuit = Card.CardSuit.Hearts  },
            };

            Player playerTwo = new Player();
            playerTwo.Name = "Bob";
            playerTwo.PlayerHand = new Card[]{
                new Card { MyValue= (Card.PlayingCardNominalValue)14, MySuit = Card.CardSuit.Spades  },
                new Card { MyValue= (Card.PlayingCardNominalValue)12, MySuit = Card.CardSuit.Spades  },
                new Card { MyValue= (Card.PlayingCardNominalValue)8, MySuit = Card.CardSuit.Spades  },
                new Card { MyValue= (Card.PlayingCardNominalValue)6, MySuit = Card.CardSuit.Spades  },
                new Card { MyValue= (Card.PlayingCardNominalValue)4, MySuit = Card.CardSuit.Spades  },
            };

            Player playerThree = new Player();
            playerThree.Name = "Sally";
            playerThree.PlayerHand = new Card[]{
                new Card { MyValue= (Card.PlayingCardNominalValue)4, MySuit = Card.CardSuit.Spades  },
                new Card { MyValue= (Card.PlayingCardNominalValue)4, MySuit = Card.CardSuit.Hearts  },
                new Card { MyValue= (Card.PlayingCardNominalValue)3, MySuit = Card.CardSuit.Hearts  },
                new Card { MyValue= (Card.PlayingCardNominalValue)12, MySuit = Card.CardSuit.Clubs  },
                new Card { MyValue= (Card.PlayingCardNominalValue)8, MySuit = Card.CardSuit.Clubs  },
            };

            List<Player> players = new List<Player>();
            players.Add(playerOne);
            players.Add(playerTwo);
            players.Add(playerThree);


            IQmetrixPokerService iQmetrixPokerService = new IQmetrixPokerService();
            var winners = iQmetrixPokerService.EvaluateWinners(players);
            foreach (var item in winners)
            {
                Console.WriteLine(item.Name);
            }

            var expected = new List<Player>();
            expected.Add(playerOne);

            CollectionAssert.AreEqual(expected, winners);
        }

        [TestMethod]
        public void Test2()
        {
            Player playerOne = new Player();
            playerOne.Name = "Joe";
            playerOne.PlayerHand = new Card[]{
                new Card { MyValue= (Card.PlayingCardNominalValue) 12 , MySuit = Card.CardSuit.Diamonds  },
                new Card { MyValue= (Card.PlayingCardNominalValue)8, MySuit = Card.CardSuit.Diamonds  },
                new Card { MyValue= (Card.PlayingCardNominalValue)13 , MySuit = Card.CardSuit.Diamonds  },
                new Card { MyValue= (Card.PlayingCardNominalValue)7, MySuit = Card.CardSuit.Diamonds  },
                new Card { MyValue= (Card.PlayingCardNominalValue)3, MySuit = Card.CardSuit.Diamonds  },
            };

            Player playerTwo = new Player();
            playerTwo.Name = "Bob";
            playerTwo.PlayerHand = new Card[]{
                new Card { MyValue= (Card.PlayingCardNominalValue)14, MySuit = Card.CardSuit.Spades  },
                new Card { MyValue= (Card.PlayingCardNominalValue)12, MySuit = Card.CardSuit.Spades  },
                new Card { MyValue= (Card.PlayingCardNominalValue)8, MySuit = Card.CardSuit.Spades  },
                new Card { MyValue= (Card.PlayingCardNominalValue)6, MySuit = Card.CardSuit.Spades  },
                new Card { MyValue= (Card.PlayingCardNominalValue)4, MySuit = Card.CardSuit.Spades  },
            };

            Player playerThree = new Player();
            playerThree.Name = "Sally";
            playerThree.PlayerHand = new Card[]{
                new Card { MyValue= (Card.PlayingCardNominalValue)4, MySuit = Card.CardSuit.Spades  },
                new Card { MyValue= (Card.PlayingCardNominalValue)4, MySuit = Card.CardSuit.Hearts  },
                new Card { MyValue= (Card.PlayingCardNominalValue)3, MySuit = Card.CardSuit.Hearts  },
                new Card { MyValue= (Card.PlayingCardNominalValue)12, MySuit = Card.CardSuit.Clubs  },
                new Card { MyValue= (Card.PlayingCardNominalValue)8, MySuit = Card.CardSuit.Clubs  },
            };

            List<Player> players = new List<Player>();
            players.Add(playerOne);
            players.Add(playerTwo);
            players.Add(playerThree);


            IQmetrixPokerService iQmetrixPokerService = new IQmetrixPokerService();
            var winners = iQmetrixPokerService.EvaluateWinners(players);
            foreach (var item in winners)
            {
                Console.WriteLine(item.Name);
            }

            var expected = new List<Player>();
            expected.Add(playerTwo);

            CollectionAssert.AreEqual(expected, winners);
        }

        [TestMethod]
        public void Test3()
        {
            Player playerOne = new Player();
            playerOne.Name = "Joe";
            playerOne.PlayerHand = new Card[]{
                new Card { MyValue= (Card.PlayingCardNominalValue) 3 , MySuit = Card.CardSuit.Hearts  },
                new Card { MyValue= (Card.PlayingCardNominalValue)5, MySuit = Card.CardSuit.Diamonds  },
                new Card { MyValue= (Card.PlayingCardNominalValue)9 , MySuit = Card.CardSuit.Clubs  },
                new Card { MyValue= (Card.PlayingCardNominalValue)9, MySuit = Card.CardSuit.Diamonds  },
                new Card { MyValue= (Card.PlayingCardNominalValue)12, MySuit = Card.CardSuit.Hearts  },
            };

            Player playerTwo = new Player();
            playerTwo.Name = "Jen";
            playerTwo.PlayerHand = new Card[]{
                new Card { MyValue= (Card.PlayingCardNominalValue)5, MySuit = Card.CardSuit.Clubs  },
                new Card { MyValue= (Card.PlayingCardNominalValue)7, MySuit = Card.CardSuit.Diamonds  },
                new Card { MyValue= (Card.PlayingCardNominalValue)9, MySuit = Card.CardSuit.Hearts  },
                new Card { MyValue= (Card.PlayingCardNominalValue)9, MySuit = Card.CardSuit.Spades  },
                new Card { MyValue= (Card.PlayingCardNominalValue)12, MySuit = Card.CardSuit.Spades  },
            };

            Player playerThree = new Player();
            playerThree.Name = "Bob";
            playerThree.PlayerHand = new Card[]{
                new Card { MyValue= (Card.PlayingCardNominalValue)2, MySuit = Card.CardSuit.Hearts  },
                new Card { MyValue= (Card.PlayingCardNominalValue)2, MySuit = Card.CardSuit.Clubs  },
                new Card { MyValue= (Card.PlayingCardNominalValue)5, MySuit = Card.CardSuit.Spades  },
                new Card { MyValue= (Card.PlayingCardNominalValue)10, MySuit = Card.CardSuit.Clubs  },
                new Card { MyValue= (Card.PlayingCardNominalValue)14, MySuit = Card.CardSuit.Hearts  },
            };

            List<Player> players = new List<Player>();
            players.Add(playerOne);
            players.Add(playerTwo);
            players.Add(playerThree);


            IQmetrixPokerService iQmetrixPokerService = new IQmetrixPokerService();
            var winners = iQmetrixPokerService.EvaluateWinners(players);
            foreach (var item in winners)
            {
                Console.WriteLine(item.Name);
            }

            var expected = new List<Player>();
            expected.Add(playerTwo);

            CollectionAssert.AreEqual(expected, winners);
        }

        [TestMethod]
        public void Test4()
        {
            Player playerOne = new Player();
            playerOne.Name = "Joe";
            playerOne.PlayerHand = new Card[]{
                new Card { MyValue= (Card.PlayingCardNominalValue) 2 , MySuit = Card.CardSuit.Hearts  },
                new Card { MyValue= (Card.PlayingCardNominalValue)3, MySuit = Card.CardSuit.Diamonds  },
                new Card { MyValue= (Card.PlayingCardNominalValue)4 , MySuit = Card.CardSuit.Clubs  },
                new Card { MyValue= (Card.PlayingCardNominalValue)5, MySuit = Card.CardSuit.Diamonds  },
                new Card { MyValue= (Card.PlayingCardNominalValue)10, MySuit = Card.CardSuit.Hearts  },
            };

            Player playerTwo = new Player();
            playerTwo.Name = "Jen";
            playerTwo.PlayerHand = new Card[]{
                new Card { MyValue= (Card.PlayingCardNominalValue)5, MySuit = Card.CardSuit.Clubs  },
                new Card { MyValue= (Card.PlayingCardNominalValue)7, MySuit = Card.CardSuit.Diamonds  },
                new Card { MyValue= (Card.PlayingCardNominalValue)8, MySuit = Card.CardSuit.Hearts  },
                new Card { MyValue= (Card.PlayingCardNominalValue)9, MySuit = Card.CardSuit.Spades  },
                new Card { MyValue= (Card.PlayingCardNominalValue)12, MySuit = Card.CardSuit.Diamonds  },
            };

            Player playerThree = new Player();
            playerThree.Name = "Bob";
            playerThree.PlayerHand = new Card[]{
                new Card { MyValue= (Card.PlayingCardNominalValue)2, MySuit = Card.CardSuit.Clubs  },
                new Card { MyValue= (Card.PlayingCardNominalValue)4, MySuit = Card.CardSuit.Diamonds  },
                new Card { MyValue= (Card.PlayingCardNominalValue)5, MySuit = Card.CardSuit.Spades  },
                new Card { MyValue= (Card.PlayingCardNominalValue)10, MySuit = Card.CardSuit.Clubs  },
                new Card { MyValue= (Card.PlayingCardNominalValue)11, MySuit = Card.CardSuit.Hearts  },
            };

            List<Player> players = new List<Player>();
            players.Add(playerOne);
            players.Add(playerTwo);
            players.Add(playerThree);


            IQmetrixPokerService iQmetrixPokerService = new IQmetrixPokerService();
            var winners = iQmetrixPokerService.EvaluateWinners(players);
            foreach (var item in winners)
            {
                Console.WriteLine(item.Name);
            }

            var expected = new List<Player>();
            expected.Add(playerTwo);

            CollectionAssert.AreEqual(expected, winners);
        }


        [TestMethod]
        public void FlushTest()
        {
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
            var winners = iQmetrixPokerService.EvaluateWinners(players);
            foreach (var item in winners)
            {
                Console.WriteLine(item.Name);
            }

            var expected = new List<Player>();
            expected.Add(playerThree);

            CollectionAssert.AreEqual(expected, winners);
        }

        [TestMethod]
        public void OnePairTest()
        {
            Player playerOne = new Player();
            playerOne.Name = "Joe";
            playerOne.PlayerHand = new Card[]{
                new Card { MyValue= Card.PlayingCardNominalValue.Ten, MySuit = Card.CardSuit.Hearts  },
                new Card { MyValue= Card.PlayingCardNominalValue.Ten, MySuit = Card.CardSuit.Diamonds  },
                new Card { MyValue= Card.PlayingCardNominalValue.Eight, MySuit = Card.CardSuit.Clubs  },
                new Card { MyValue= Card.PlayingCardNominalValue.Seven, MySuit = Card.CardSuit.Diamonds  },
                new Card { MyValue= Card.PlayingCardNominalValue.Four, MySuit = Card.CardSuit.Hearts  },
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
                new Card { MyValue= Card.PlayingCardNominalValue.Jack, MySuit = Card.CardSuit.Diamonds  },
            };

            List<Player> players = new List<Player>();
            players.Add(playerOne);
            players.Add(playerTwo);
            players.Add(playerThree);


            IQmetrixPokerService iQmetrixPokerService = new IQmetrixPokerService();
            var winners = iQmetrixPokerService.EvaluateWinners(players);
            foreach (var item in winners)
            {
                Console.WriteLine(item.Name);
            }

            var expected = new List<Player>();
            expected.Add(playerOne);

            CollectionAssert.AreEqual(expected, winners);
        }
    }
}
