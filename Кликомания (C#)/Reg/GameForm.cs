using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Reg
{
    public partial class GameForm : Form
    {
        RegistrationForm registrationForm = new RegistrationForm();
        Game g;
        User cur_user;
        public GameForm()
        {
            InitializeComponent();
        }

        private void RegForm_Load(object sender, EventArgs e)
        {
            registrationForm.ShowDialog(); // Отображаем форму авторизации.
            cur_user = registrationForm.current_user;
            nameLabel.Text = "Здравствуйте, " + registrationForm.login + "!";
            g = cur_user.UserGame;
            drawField(g, datagv);
        }

        public void drawField(Game game, DataGridView dgv)
        {
            dgv.ColumnCount = game.field.GetLength(0);
            dgv.RowCount = game.field.GetLength(1);
            for (int i = 0; i < dgv.ColumnCount; i++)
                for (int j = 0; j < dgv.RowCount; j++)
                {
                    dgv[i, j].Value = (int)game.field[i, j];
                    dgv.Columns[i].Width = 30;
                    if (Convert.ToInt32(dgv[i, j].Value) == (int)Game.BlockColors.Red)
                    {
                        dgv[i, j].Style.BackColor = dgv[i, j].Style.ForeColor = dgv[i, j].Style.SelectionBackColor =
                            dgv[i, j].Style.SelectionForeColor = Color.Red;
                    }
                    if (Convert.ToInt32(dgv[i, j].Value) == (int)Game.BlockColors.Yellow)
                    {
                        dgv[i, j].Style.BackColor = dgv[i, j].Style.ForeColor = dgv[i, j].Style.SelectionBackColor =
                            dgv[i, j].Style.SelectionForeColor = Color.Yellow;
                    }
                    if (Convert.ToInt32(dgv[i, j].Value) == (int)Game.BlockColors.Green)
                    {
                        dgv[i, j].Style.BackColor = dgv[i, j].Style.ForeColor = dgv[i, j].Style.SelectionBackColor =
                            dgv[i, j].Style.SelectionForeColor = Color.Green;
                    }
                    if (Convert.ToInt32(dgv[i, j].Value) == (int)Game.BlockColors.None)
                    {
                        dgv[i, j].Style.BackColor = dgv[i, j].Style.ForeColor = dgv[i, j].Style.SelectionBackColor =
                            dgv[i, j].Style.SelectionForeColor = Color.White;
                    }
                }
        }

        private void newgame_btn_Click(object sender, EventArgs e)
        {
            cur_user.NewGame(10, 15);
            g = cur_user.UserGame;
            drawField(g, datagv);
        }

        private double CountScore(int bc)
        {
            if (bc == 0)
                return 0;
            if (bc > 20)
                return 10 * bc;
            double coef = 1 - 10.0 / 19;

            return coef * bc + 10.0/19;
        }

        private void datagv_CellClick(object sender, DataGridViewCellEventArgs e)
        {
			int block_amount = 0;
			if (e.ColumnIndex >= 0 || e.RowIndex >= 0)
				block_amount = g.PlayerTurn(e.ColumnIndex, e.RowIndex);
            cur_user.IncreaseScore(CountScore(block_amount));
            drawField(g, datagv);
            string r = "Ваш результат за текущую игру: " + Math.Round(cur_user.CurrentScore, 0) + "\nГлобальный результат: " + Math.Round(cur_user.GlobalScore, 0) + "\nМаксимальный результат: " + Math.Round(cur_user.MaxScore, 0)/* + "\nКоличество кликов: " + cur_user.ClickCount + "\nМинимальное кол-во кликов: " + cur_user.TopClickCount*/;

			if (g.isWin())
                MessageBox.Show("С победой, " + registrationForm.login + "!" + Environment.NewLine + r);
            else
                if (g.isGameOver)
                MessageBox.Show(registrationForm.login + ", ходов больше нет." + Environment.NewLine + r);
        }

        private void GameForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            registrationForm.WriteAllUsers();
        }
    }
}