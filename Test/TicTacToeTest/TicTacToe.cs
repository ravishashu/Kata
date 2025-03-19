using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace TicTacToeTest
{
    [TestClass]
    public class TicTacToe
    {
        public Game Game { get; set; }
        public TicTacToe() 
        { 
            Game = new Game();
        }
        [TestMethod]
        public void AddPlayer_Success()
        {
            Assert.IsTrue(Game.AddPlayer('X', 0));
            Assert.IsFalse(Game.AddPlayer('X', -1));

        }

        [TestMethod]
        public void GetFistPlayer_TestSuccess()
        {
            Game game = new Game();
            game.AddPlayer('X', 0);
            Assert.AreEqual('X', game.GetFistPlayer());
            
        }

        [TestMethod]
        public void GetFistPlayer_TestFail()
        {
            Game game = new Game();
            game.AddPlayer('X', 0);
            Assert.AreNotEqual('O', game.GetFistPlayer());
        }

        [TestMethod]        
        public void InitialGame_Test()
        { 
            Game = new Game();
            Game.BoardEmpty = true;
            Assert.IsTrue(Game.BoardEmpty);
            Game.AddPlayer('X', 0);
            Assert.IsNotNull(Game.GameStart());
            Assert.IsTrue('X'== Game.GameStart().Name);
        }

        [TestMethod]
        public void MarkCell_Test()
        {
            Game game = new Game();
            Assert.IsTrue(game.MarKCell(4, '-') == '-');
        }

        [TestMethod]
        public void CellMarked_TestSuccess()
        {
            Game game = new Game();
            game.BoardEmpty = true;
            game.AddPlayer('X', 0);
            game.AddPlayer('O', 1);
            game.GameStart();
            Assert.IsTrue(game.Marked(6)  == string.Empty);

        }
    }

   public class Players
    {
        public char Name { get; set; }
    }

    public class Game
    {
        public bool BoardEmpty { get; set; }

        public char[] cells ;

        public Players[] Players;
        public Game()
        {
            cells = new char[9];
        }

        public char GetFistPlayer()
        {
            if (Players == null) return 'F';
            return Players[0].Name;
            
        }
        public char GetScoundPlayer()
        {
            if (Players == null) return 'F';
            return Players[1].Name;

        }

        internal bool AddPlayer(char name,int index)
        {
            Players = new Players[2];
            if (index < 0 || index > 1) return false;
            Players[index]=new Players() { Name = name };
            return true;
        }

        public Players GameStart()
        {
            if(!BoardEmpty) return null;
            if (Players == null) return null;
            cells=new char[9];
            for (int i = 0; i < 9; i++)
            {
                cells[i] = Convert.ToChar('-');
            }
            return Players[0];

        }

        public char MarKCell(int index,char mark)
        {
            cells[index] = mark;
            return cells[index];
        }

        public string Marked(int  index)
        {
            if (cells[index] == 'X' || cells[index] == 'O') return "Used";
            if (cells[index].Equals('-')) return string.Empty;
            return "Error";
        }
    }
}
