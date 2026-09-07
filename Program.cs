Console.WriteLine("welcome to adveture!");


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

