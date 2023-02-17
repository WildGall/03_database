using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03__database
{
    internal class Program
    {
        static void Main(string[] args)
        {
            const int AddPlayer = 1;
            const int RemovePlayer = 2;
            const int BanPlayer = 3;
            const int UnBanPlayer = 4;
            const int DrowBase = 5;
            const int ExitProgram = 6;
            bool isProgramWork = true;
            DataBase dataBase = new DataBase();

            while (isProgramWork)
            {
                Console.WriteLine("Меню:");
                Console.WriteLine($" {AddPlayer} - Добвить игрока.\n {RemovePlayer} - Удалить игрока.\n {BanPlayer} - Забанить Игрока.\n {UnBanPlayer} - Разбанить Игрока.\n {DrowBase} - Вывод игроков.\n {ExitProgram} - Выход из программы.");
                Console.Write("\nВведите номер команды: ");
                int.TryParse(Console.ReadLine(), out int userInput);

                switch (userInput)
                {
                    case AddPlayer:
                        dataBase.AddPlayer();
                        break;
                    case RemovePlayer:
                        dataBase.RemovePlayer();
                        break;
                    case BanPlayer:
                        dataBase.BanPlayer();
                        break;
                    case UnBanPlayer:
                        dataBase.UnBanPlayer();
                        break;
                    case DrowBase:
                        dataBase.DrowBase();
                        break;
                    case ExitProgram:
                        isProgramWork = false;
                        break;
                }
            }
        }
    }

    class Player
    {
        private string _nick;
        private int _level;
        private bool _flag;
        private int _uniqueNumber;

        public Player(int uniqueNumber,string nick, int level, bool flag = false)
        {
            _uniqueNumber = uniqueNumber;
            _nick = nick;
            _level = level;
            _flag = flag;
        }

        public void ShowInfo()
        {
            Console.WriteLine($"Уникальный номер - {_uniqueNumber} Никнейм - {_nick} Уровень - {_level}");
            if (_flag == true)
            {
                Console.WriteLine("Игрок забанен: да\n");
            }
            else if (_flag == false)
            {
                Console.WriteLine("Игрок забанен: нет\n");
            }
        }

        public void Ban()
        {
            if (_flag != true)
            {
                _flag = true;
                ShowInfo();
            }
        }

        public void UnBan()
        {
            if (_flag != false)
            {
                _flag = false;
                ShowInfo();
            }
        }
    }

    class DataBase
    {
        private int _uniquePlayerNumber = 0;
        private List<Player> _players = new List<Player>();            

        public void AddPlayer()
        {
            Console.WriteLine("Введите имя:");
            string nickPlayer = Console.ReadLine();
            Console.WriteLine("Введите уровень: ");
            int.TryParse(Console.ReadLine(), out int levelPlayer);
            _uniquePlayerNumber++;

            Player players = new Player(_uniquePlayerNumber, nickPlayer, levelPlayer);
            _players.Add(players);

            Console.WriteLine("Игрок успешно добавлен");
            Console.Write("Нажмите любую клавишу");
            Console.ReadKey();
            Console.Clear();
        }

        public void RemovePlayer()
        {
            if (_players.Count >= 0)
            {              
                Console.Write("Введите номер игрока, котрого хотите удалить:");
                int.TryParse(Console.ReadLine(), out int uniqueNumber);

                if (uniqueNumber > 0)
                {
                    _players.RemoveAt(uniqueNumber - 1);
                    Console.Write("Игрок удален");
                    Console.ReadKey();
                    Console.Clear();
                }

                else
                {
                    Console.Write("Неверный номер игрока!");
                }
            }
        }

        public void BanPlayer()
        {
            if (_players.Count >= 0)
            {
                Console.Write("Введите номер игрока, котрого хотите забанить:");
                int.TryParse(Console.ReadLine(), out int uniqueNumber);

                if (uniqueNumber > 0)
                {
                    for (int i = 0; i < _players.Count; i++)
                    {
                        _players[uniqueNumber - 1].Ban();
                    }
                    Console.Write("Игрок забанен");
                    Console.ReadKey();
                    Console.Clear();
                }

                else
                {
                    Console.Write("Неверный номер игрока!");
                }
            }
        }

        public void UnBanPlayer()
        {
            if (_players.Count >= 0)
            {
                Console.Write("Введите номер игрока, котрого хотите разбанить:");
                int.TryParse(Console.ReadLine(), out int uniqueNumber);

                if (uniqueNumber >= 0)
                {
                    for (int i = 0; i < _players.Count; i++)
                    {
                        _players[uniqueNumber - 1].UnBan();
                    }
                    Console.Write("Игрок разбанен");
                    Console.ReadKey();
                    Console.Clear();
                }

                else
                {
                    Console.Write("Неверный номер игрока!");
                }
            }                
        }

        public void DrowBase()
        {
            if (_players.Count > 0)
            {
                for (int i = 0; i < _players.Count; i++)
                {
                    _players[i].ShowInfo();
                }
            }

            else
            {
                Console.WriteLine("Данные Отсутвуют");
            }
        }            
    }
}