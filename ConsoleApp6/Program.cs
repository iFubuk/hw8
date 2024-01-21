using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ConsoleApp6
{
    internal class Program
    {
        static void Dictionary_Method()
        {
            Dictionary<string, int> search_results = new Dictionary<string, int>();
            string text, word;

            Console.WriteLine("Введите текст:");
            text = Console.ReadLine();
            Console.WriteLine("Введите искомое слово:");
            word = Console.ReadLine();

            Regex regex = new Regex(word);
            MatchCollection matches = regex.Matches(text);
            if (matches.Count == 0)
            {
                Console.WriteLine("Совпадений не найдено");
            }

            search_results.Add(word, matches.Count);

            foreach (var result in search_results)
            {
                Console.WriteLine($"Слово: {result.Key}  Количество вхождений: {result.Value}");
            }
        }
        static void List_Method()
        {
            static void List_Output(List<string> tasks) 
            {
                Console.WriteLine("\tВаш список задач");
                for (int i = 0; i < tasks.Count; i++)
                {
                    Console.WriteLine($"{i + 1}. {tasks[i]}");
                }
            }

            List<string> tasks = new List<string>();

            while (true)
            {
                Console.WriteLine("\n1. Посмотреть список задач\n2. Добавить задачу в список\n3. Удалить задачу из списка\n4. Пометить задачу как выполненную\n5. Выход из программы");
                string command = Console.ReadLine();
                Console.Clear();

                switch (command.Trim(' '))
                {
                    case "1":
                        if (tasks.Count() == 0) { Console.WriteLine("Список пуст!\n"); }

                        else
                        {
                            List_Output(tasks);
                        }

                        break;

                    case "2":
                        Console.WriteLine("Введите новую задачу");

                        tasks.Add(Console.ReadLine());
                        Console.Clear();

                        break;

                    case "3":
                        List_Output(tasks);

                        Console.WriteLine("Введите номер задачи которую вы хотите удалить:");

                        try
                        {
                            tasks.RemoveAt(Convert.ToInt32(Console.ReadLine()) - 1);
                            Console.Clear();
                        }

                        catch
                        {
                            Console.Clear();
                            Console.WriteLine("Ошибка! Введите корректное значение\n");
                        }

                        break;

                    case "4":
                        List_Output(tasks);

                        Console.WriteLine("Введите номер выполненной задачи:");

                        int index = Convert.ToInt32(Console.ReadLine()) - 1;
                        tasks[index] = tasks[index].Insert(tasks[index].Length, "  [ВЫПОЛНЕННО]");
                        Console.Clear();

                        break;

                    case "5":
                        return;

                    default:
                        Console.WriteLine("Ошибка! Введите корректное значение\n");

                        break;
                }
            }
        }
        static void Queue_Method()
        {
            Queue<string> patients = new Queue<string>();
            while (true)
            {
                Console.WriteLine("\n1. Посмотреть следующего в очереди\n2. Добавить пациента в очередь\n3. Продвинуть очередь\n4. Выход из программы");
                string command = Console.ReadLine();
                Console.Clear();

                switch (command.Trim(' '))
                {
                    case "1":
                        bool peek_attempt = patients.TryPeek(out var next_patient);
                        if (!peek_attempt) { Console.WriteLine("Очередь пуста!\n"); }
                        else
                        {
                            Console.WriteLine($"Пациент {next_patient} вышел из очереди\n");
                        }

                        break;

                    case "2":
                        Console.WriteLine("Введите имя пациента которого хотите добавить в очередь");

                        patients.Enqueue(Console.ReadLine());
                        Console.Clear();

                        break;

                    case "3":
                        bool deQ_attempt = patients.TryDequeue(out var next_to_leave_patient);
                        if (!deQ_attempt) { Console.WriteLine("Очередь пуста!\n"); }
                        else { Console.WriteLine($"Пациент {next_to_leave_patient} вышел из очереди\n"); }

                        break;

                    case "4":
                        return;

                    default:
                        Console.WriteLine("Ошибка! Введите корректное значение\n");

                        break;
                }
            }
        }
        static void HashSet_Method()
        {
            HashSet<string> films = new HashSet<string>();
            List<string> watched = new List<string>();
            while (true)
            {
                Console.WriteLine("\n1. Посмотреть список фильмов\n2. Добавить фильм в каталог\n3. Добавить фильм в список просмотренных\n4. Выход из программы");
                string command = Console.ReadLine();
                Console.Clear();

                switch (command.Trim(' '))
                {
                    case "1":
                        foreach(string film in films)
                        {
                            Console.WriteLine(film);
                        }
                        break;

                    case "2":
                        Console.WriteLine("Введите название нового фильма");

                        films.Add(Console.ReadLine());
                        Console.Clear();

                        break;

                    case "3":
                        Console.WriteLine("Введите название просмотренного фильма");
                        string new_watched = Console.ReadLine();
                        Console.Clear();
                        if (films.Contains(new_watched))
                            {
                                watched.Add(new_watched);
                            }
                        else
                        {
                            Console.WriteLine("Нет такого фильма");
                        }
                        break;

                    case "4":
                        return;

                    default:
                        Console.WriteLine("Ошибка! Введите корректное значение\n");

                        break;
                }
            }
        }
        static void Main(string[] args)
        {
            //Dictionary_Method();
            //List_Method();
            //Queue_Method();
            HashSet_Method();
        }
    }
}
