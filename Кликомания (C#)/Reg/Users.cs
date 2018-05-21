using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.Serialization.Formatters.Binary;

namespace Reg
{
	[Serializable]
	public class Users // Класс, который хранит регистрационные данные.
	{
		public List<User> allUsers = new List<User>();
	}

	[Serializable]
	public class User
	{
		//private string login;
		//private string pass;
		//private double globalscore;
		//private double currentscore;
		//private double maxscore;
		//private Game usergame;

		public Game UserGame;
		
		public string Login;

		public string Pass;

		public double GlobalScore;

		public double CurrentScore;

		public double MaxScore;



		public User(string login, string password) //конструктор
		{
			Login = login;
			Pass = password;
			GlobalScore = 0;
			CurrentScore = 0;
			MaxScore = 0;
			NewGame(10, 15);
		}

		public void NewGame(int col, int row)
		{
			UserGame = new Game(col, row);
			CurrentScore = 0;
		}

		public void IncreaseScore(double ds)
		{
			CurrentScore += ds;
			GlobalScore += ds;
			if (CurrentScore > MaxScore)
				MaxScore = CurrentScore;
		}
	}
}
