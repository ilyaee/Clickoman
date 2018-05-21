using System;
using System.Collections.Generic;
using System.Text;

namespace Reg
{
	[Serializable]
	public class Game
	{
		const int rndConst = 4, rowConst = 14, colConst = 0;

		internal enum BlockColors : int
		{
			None = 0,
			Red = 1,
			Yellow = 2,
			Green = 3
		}

		internal BlockColors[,] field;

		public Game(int n, int m) // конструктор
		{
			newGame(n, m);
		}

		public void newGame(int n, int m)
		{
			field = new BlockColors[n, m];
			Random rnd = new Random();
			for (int i = 0; i < n; i++)
				for (int j = 0; j < m; j++)
				{
					field[i, j] = (BlockColors)rnd.Next(1, rndConst);
				}
		}

		public int PlayerTurn(int col, int row)
		{
				if (field[col, row] == BlockColors.None)
					return 0;
				bool[,] mf = new bool[field.GetLength(0), field.GetLength(1)];
				int score = 0;

				for (int i = 0; i <= col - 1; i++)
					for (int j = 0; j <= row - 1; j++)
						mf[i, j] = false;

				score = MarkField(col, row, ref mf);
				if (score < 2)
					return 0;

				for (int i = 0; i <= field.GetLength(0) - 1; i++) // обнуление помеченных элементов
					for (int j = 0; j <= field.GetLength(1) - 1; j++)
						if (mf[i, j])
							field[i, j] = BlockColors.None;

				for (int i = 0; i < field.GetLength(0); i++)
					BlocksDown(i);

				BlocksLeft();

				return score;
		}

		private void BlocksDown(int col)
		{
			int NoneCount = 0;
			int k = field.GetLength(1) - 1;
			while (true)
			{
				while (k >= 0 && field[col, k] != BlockColors.None)
				{
					k--; // в "к" окажется номер строки в которой первый нулевой элемент
				}
				int startNone = k;
				while (k >= 0 && field[col, k] == BlockColors.None)
				{
					k--; // в "к" окажется номер строки в которой первый ненулевой элемент после череды нулевых
				}
				int stopNone = k;
				if (stopNone == -1)
					return;
				NoneCount = startNone - stopNone;

				for (int i = startNone; i >= NoneCount; i--) // замещение нулевых элементов
				{
					field[col, i] = field[col, i - NoneCount];
				}
				for (int i = 0; i < NoneCount; i++) // обнуляем лишние элементы сверху после переноса
				{
					field[col, i] = BlockColors.None;
				}
				k = startNone;
			}
		}

		/// <summary>
		/// Рекурсивный метод
		/// </summary>
		private int MarkField(int col, int row, ref bool[,] mf) 
																//принимает булевскую матрицу и помечает "true" те соседние элементы, которые подходят под условие
		{
			int sum = 0;
			mf[col, row] = true;

			if ((col + 1) < field.GetLength(0) && !mf[col + 1, row] && field[col + 1, row] == field[col, row])
				sum += MarkField(col + 1, row, ref mf);
			if ((row + 1) < field.GetLength(1) && !mf[col, row + 1] && field[col, row + 1] == field[col, row])
				sum += MarkField(col, row + 1, ref mf);
			if ((col - 1) >= 0 && !mf[col - 1, row] && field[col - 1, row] == field[col, row])
				sum += MarkField(col - 1, row, ref mf);
			if ((row - 1) >= 0 && !mf[col, row - 1] && field[col, row - 1] == field[col, row])
				sum += MarkField(col, row - 1, ref mf);
			return sum + 1;
		}

		private void BlocksLeft()
		{
			int j = field.GetLength(1) - 1;
			int k;

			for (int i = 1; i < field.GetLength(0); i++)
				if (field[i, j] != BlockColors.None)
				{
					k = i;
					while (field[k - 1, j] == 0)
					{
						for (int n = 1; n < field.GetLength(1); n++)
						{
							field[k - 1, n] = field[k, n];
							field[k, n] = BlockColors.None;
						}
						k--;
						if (k < 1)
							break;
					}
				}
		}

		public bool isGameOver
		{
			get
			{
				bool found = false;

				for (int i = 0; i < field.GetLength(0) - 1; i++)
				{
					if (found)
						break;

					for (int j = 0; j < field.GetLength(1); j++)
						if (field[i, j] != BlockColors.None && field[i, j] == field[i + 1, j])
						{
							found = true;
							break;
						}
				}
				if (!found)
					for (int i = 0; i < field.GetLength(0); i++)
					{
						if (found)
							break;
						for (int j = 0; j < field.GetLength(1) - 1; j++)
							if (field[i, j] != BlockColors.None && field[i, j] == field[i, j + 1])
							{
								found = true;
								break;
							}
					}
				return !found;
			}
		}

		public bool isWin()
		{
			if (field[colConst, rowConst] != BlockColors.None)
				return false;
			return true;
		}
	}
}
