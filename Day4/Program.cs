string[] lines = File.ReadAllLines("input.txt");

int sum = 0;

foreach (var line in lines)
{
    string[] separated = line.Split(':');
    int gameID = int.Parse(separated[0].Split("Card ")[1]);
    string[] cardSides = separated[1].Split("|");

    Dictionary<int, bool> matching = new Dictionary<int, bool>();

    string winningNumbers = cardSides[0];
    string guessedNumbers = cardSides[1] + " ";
    for (int i = 1; i < winningNumbers.Length; i += 3)
    {
        string number = $"{winningNumbers[i]}{winningNumbers[i + 1]}{winningNumbers[i + 2]}".Trim();
        matching.Add(int.Parse(number), false);
    }

    for (int i = 1; i < guessedNumbers.Length; i += 3)
    {
        string number = $"{guessedNumbers[i]}{guessedNumbers[i + 1]}{guessedNumbers[i + 2]}".Trim();
        int parsed = int.Parse(number);
        if (matching.ContainsKey(parsed)) matching[parsed] = true;
    }

    int multiplication = matching.Where(x => x.Value).Count();
    int value = multiplication > 0 ? 1 : 0;
    for (int m = 0; m < multiplication - 1; m++) value = value * 2;

    Console.WriteLine(multiplication + " " + value);

    sum += value;
}

Console.WriteLine(sum);