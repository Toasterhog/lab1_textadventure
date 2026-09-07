Console.WriteLine("welcome to adveture!");

class Program {
    static void Main(string[] args) {...}
    static string Ask(string question) {
        string response;
        do {
            Console.Write(question);
            response = Console.ReadLine().Trim();
        } while (response == "");
        return response;
    }
}