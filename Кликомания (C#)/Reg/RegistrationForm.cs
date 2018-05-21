using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

namespace Reg
{
	public partial class RegistrationForm : Form
	{
		//Переменные, которые будут хранить на протяжение работы программы логин и пароль
		public string login = string.Empty;
		public string password = string.Empty;
		private Users user = new Users(); // Экземпляр класса пользователей.

		public User current_user;

		public RegistrationForm()
		{
			InitializeComponent();

			LoadUsers(); // Метод десериализует класс.
		}

		private void LoadUsers()
		{
			try
			{
				FileStream fs = new FileStream("Users.dat", FileMode.Open);
				BinaryFormatter formatter = new BinaryFormatter();
				user = (Users)formatter.Deserialize(fs);
				fs.Close();
			}
			catch
			{
				return;
			}
		}

		private void EnterToForm() // авторизация
		{
			for (int i = 0; i < user.allUsers.Count; i++) // Ищем пользователя и проверяем правильность пароля.
			{
				if (user.allUsers[i].Login == loginTextBox.Text && user.allUsers[i].Pass == passwordTextBox.Text)
				{
					login = user.allUsers[i].Login;
					password = user.allUsers[i].Pass;
					current_user = user.allUsers[i];
					this.Close();

				}
				else if (user.allUsers[i].Login == loginTextBox.Text && passwordTextBox.Text != user.allUsers[i].Pass)
				{
					login = user.allUsers[i].Login;

					MessageBox.Show("Неверный пароль!");
				}
			}

			if (login == "")
			{
				MessageBox.Show("Пользователь " + loginTextBox.Text + " не найден!");
			}
		}

		private void AddUser(out bool ok) // Регистрируем нового пользователя.
		{
			ok = true;
			if (loginTextBox.Text == "" || passwordTextBox.Text == "")
			{
				MessageBox.Show("Не введен логин или пароль!");
				ok = false;
				return;
			}

			for (int i = 0; i < user.allUsers.Count; i++)
				if (loginTextBox.Text == user.allUsers[i].Login)
				{
					MessageBox.Show("Пользователь с таким логином зарегистрирован ранее");
					ok = false;
					return;
				}

			user.allUsers.Add(new User(loginTextBox.Text, passwordTextBox.Text));
			WriteAllUsers();

			login = loginTextBox.Text;

			this.Close();
		}

		public void WriteAllUsers()
		{
			FileStream fs = new FileStream("Users.dat", FileMode.OpenOrCreate, FileAccess.Write);

			BinaryFormatter formatter = new BinaryFormatter();
			formatter.Serialize(fs, user); // Сериализуем класс.

			fs.Close();
		}

		private void exitButton_Click(object sender, EventArgs e)
		{
			Application.Exit(); // Закрываем программу.
		}

		private void regButton_Click(object sender, EventArgs e)
		{
			bool ok;
			AddUser(out ok);
			if (ok)
			{
				MessageBox.Show(login + ", регистрация прошла успешно." + Environment.NewLine + "Приятной игры!");
				EnterToForm();
			}
		}

		private void enterButton_Click(object sender, EventArgs e)
		{
			EnterToForm();
		}

		private void RegistrationForm_FormClosed(object sender, FormClosedEventArgs e)
		{
			if (login == "" | password == "")
				Application.Exit();
		}
	}
}
