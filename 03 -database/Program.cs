using System;
using System.Collections.Generic;

namespace _03__database
{
    internal class Program
    {
        static void Main(string[] args)
        {
            const int CommandAddPlayer = 1;
            const int CommandRemovePlayer = 2;
            const int CommandBanPlayer = 3;
            const int CommandUnbanPlayer = 4;
            const int CommandShowBase = 5;
            const int CommandExitProgram = 6;

            bool isProgramWork = true;
            DataBase dataBase = new DataBase();

            while (isProgramWork)
            {
                Console.WriteLine("Меню:");
                Console.WriteLine($" {CommandAddPlayer} - Добвить игрока.\n {CommandRemovePlayer} - Удалить игрока.\n {CommandBanPlayer} - Забанить Игрока.\n {CommandUnbanPlayer} - Разбанить Игрока.\n {CommandShowBase} - Вывод игроков.\n {CommandExitProgram} - Выход из программы.");
                Console.Write("\nВведите номер команды: ");
                int.TryParse(Console.ReadLine(), out int userInput);

                switch (userInput)
                {
                    case CommandAddPlayer:
                        dataBase.AddPlayer();
                        break;

                    case CommandRemovePlayer:
                        dataBase.RemovePlayer();
                        break;

                    case CommandBanPlayer:
                        dataBase.BanPlayer();
                        break;

                    case CommandUnbanPlayer:
                        dataBase.UnbanPlayer();
                        break;

                    case CommandShowBase:
                        dataBase.ShowBase();
                        break;

                    case CommandExitProgram:
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
        private bool _isBanned;
        private int _uniqueNumber;

        public Player(int uniqueNumber,string nick, int level, bool flag = false)
        {
            _uniqueNumber = uniqueNumber;
            _nick = nick;
            _level = level;
            _isBanned = flag;
        }

        public void ShowInfo()
        {
            Console.WriteLine($"Уникальный номер - {_uniqueNumber} Никнейм - {_nick} Уровень - {_level}");

            if (_isBanned == true)
            {
                Console.WriteLine("Игрок забанен: да\n");
            }
            else if (_isBanned == false)
            {
                Console.WriteLine("Игрок забанен: нет\n");
            }
        }

        public void Ban()
        {
            if (_isBanned != true)
            {
                _isBanned = true;
                ShowInfo();
            }
        }

        public void Unban()
        {
            if (_isBanned != false)
            {
                _isBanned = false;
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

        private bool TryGetPlayer(out Player player)
        {
            if (_players.Count > 0)
            {
                Console.Write("Введите номер игрока:");
                int.TryParse(Console.ReadLine(), out int numberPlayer);

                if (numberPlayer > 0 && numberPlayer < _players.Count)
                {
                    player = _players[numberPlayer - 1];
                    return true;
                }        
                else
                {
                    Console.Write("Не верный номер игрока");
                    player = null;
                    return false;
                }
            }
            else
            {
                Console.Write("Нет игроков в базе");
                player = null;
                return false;
            }                      
        }               

        public void RemovePlayer()
        {
            TryGetPlayer(out Player player);
            _players.Remove(player);
            Console.Write("Игрок удален");
            Console.ReadKey();
            Console.Clear();
        }
       
        public void BanPlayer()
        {
            TryGetPlayer(out Player player);
            player.Ban();
            Console.Write("Игрок забанен");
            Console.ReadKey();
            Console.Clear();            
        }

        public void UnbanPlayer()
        {
            TryGetPlayer(out Player player);
            player.Unban();           
            Console.Write("Игрок разбанен");
            Console.ReadKey();
            Console.Clear();                           
        }

        public void ShowBase()
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
