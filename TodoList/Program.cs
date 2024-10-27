using System.Linq.Expressions;
using System.Net.Security;
using System.Runtime.InteropServices.Marshalling;

internal class Program
{
    private static void Main(string[] args)

    {
        var listOfTodoItems = new List<string>(); 
        bool appShouldWork = true;

        Console.WriteLine("Команда \"add-todo\" добавляет дело в лист.\nКоманда \"rm-todo\" удаляет дело из листа.\nКоманда \"list-todos\" вызывает список дел.\nКоманда \"exit\" позволяет выйти из листа дел\n\nВведите действие");
        while (appShouldWork)
        {
            var userInput = Console.ReadLine(); 
            var stringElements = userInput.Split(' '); // Создает массив, чтобы по нему проверить первый элемент и на основе его понять какую команду вызвать

            if (stringElements.Length == 0)
            {
                Console.WriteLine("Не удалось распознать команду");
                continue;
            }

            // получить первый элемент массива
            var possibleComand = stringElements[0];
            if (possibleComand.Equals("list-todos", StringComparison.OrdinalIgnoreCase))
            {
            foreach (var todoItem in listOfTodoItems)
            {
                Console.WriteLine(todoItem);
            }
            continue;
            }
       
            if (possibleComand.Equals("add-todo", StringComparison.OrdinalIgnoreCase)) // эквивалент
            {
                if (string.IsNullOrWhiteSpace(userInput.Substring(8)))
                    Console.WriteLine("Вы не прописали дело, необходимое к добавлению в лист");
                else
                {
                    var infoTodoitems = AddTodo(listOfTodoItems, userInput[9..]);
                    Console.WriteLine(infoTodoitems);
                }
                continue;
            }

            if (possibleComand.Equals("rm-todo", StringComparison.OrdinalIgnoreCase))
            {
                if (string.IsNullOrWhiteSpace(userInput.Substring(7)))
                {
                    Console.WriteLine("Вы не указали какое дело хотели бы удалить из списка");
                    continue;
                }

                if (int.TryParse(stringElements[1], out int itemIndex))
                {
                    var todoItemDeletionResult = RemoveTodoitem(listOfTodoItems, itemIndex);
                    Console.WriteLine(todoItemDeletionResult);
                    continue;
                }
                else
                {
                    Console.WriteLine("Введите целочисленное значение");
                    continue;
                }
            }
            //Описать другие команды 
            if (possibleComand.StartsWith("exit"))

                appShouldWork = false;

            else
                Console.WriteLine("Такой команды не существует");
        }
    }

    static string AddTodo(List<string> listOfTodoItems, string text)
    {
        listOfTodoItems.Add(text);
        var index = listOfTodoItems.IndexOf(text);
        return $"Дело \"{text}\" под номером {index} создано";
    }   

    static string RemoveTodoitem(List<string> listOfTodoItems, int itemIndex)
    {
        if (listOfTodoItems.Count == 0)
        {
            return "В списке нет дел";
        }

        if (itemIndex >= 0 && itemIndex < listOfTodoItems.Count)
        {
            listOfTodoItems.RemoveAt(itemIndex);
            return $"Дело удалено, № {itemIndex}";
        }

        else
            return "Дела под таким номером не существует";

    }
}