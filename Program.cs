Console.WriteLine("welcome to adveture!");
string name = "";
do
{
    Console.Write("What is your name: ");
    name = Console.ReadLine();
    
    Console.Write($"So {name} is truly your name?");
    string yesOrno = Console.ReadLine().Trim().ToLower();
    if (yesOrno != "yes" && yesOrno != "ok"){
        name = "";
    }
} while (name == "");


class MyProgram {
    string name = "";
    static string Ask(string question) {
        string response;
        do {
            Console.Write(question);
            response = Console.ReadLine().Trim();
        } while (response == "");
        return response;
    }
}
