internal class Program
{
    private static void Main(string[] args)
    
    {
        var listOfTodoItems = new List<string>(); // тоже самое, что new string[] {};
        bool appShouldWork = true;
/*Консольное прилоожение, выполняющее несколько команд
add-todo
rm-todo
list-todos
exit
*/
        // дать справку по командам 
        // НАЧАЛО! (while)
        //while(possibleComand.Equals("add-todo", StringComparison.OrdinalIgnoreCase));
        while (appShouldWork)
        {

            var userInput = /*Console.ReadLine();*/ "add-todo позвонить в сервис";
            var stringElements = userInput.Split(' '); // Создает массив, чтобы по нему проверить первый элемент и на основе его понять какую команду вызвать

            if (stringElements.Length == 0)
            {
                Console.WriteLine("Не удалось распознать команду");
                continue;
            }

            // получить первый элемент массива
            var possibleComand = stringElements[0];
            // узнать, является ли он текстом какой-либо команды
            //var commandDefinitions = new Dictionary<string, Func<string>>;
            if (possibleComand.Equals("add-todo", StringComparison.OrdinalIgnoreCase)) // эквивалент
            {
                // если является, то запустить код (метод) соответствующей команды
                // если нет, то выдать "сообщение об ошибке" (любого формата или вида), и вернуться в начало

                var index = AddTodo(listOfTodoItems, userInput[9..]);
                Console.WriteLine($"Дело создано, номер {index}");
                continue;
            }
            //Описать другие команды 
            if (possibleComand.StartsWith("exit"))
            {
                appShouldWork = false;
            }
            Console.WriteLine(userInput);

        }
    }

    static string AddTodo(List<string> listOfTodoItems, string text)
    {
        // найти способ сохранить текст команды (с идентификатором) в памяти
        //
        listOfTodoItems.Add(text);
        var index = listOfTodoItems.IndexOf(text);
        return index.ToString();
    }
}