int red = 12;
int green = 13;
int blue = 14;

string[] lines = File.ReadAllLines("input.txt");

int idSums = 0;

int lowestSums = 0;

foreach (var line in lines)
{
    int gameID = int.Parse(line.Split(':')[0].Replace("Game", "").Trim());
    string[] sets = line.Split(":")[1].Split(';');

    bool possible = true;

    int largestRed = 0;
    int largestGreen = 0;
    int largestBlue = 0;

    foreach (var set in sets)
    {
        string[] bags = set.Split(",");
        foreach (var bag in bags)
        {
            string color = bag.Trim().Split(' ')[1];
            int count = int.Parse(bag.Trim().Split(' ')[0]);

            switch (color)
            {
                case "red":
                    if (count > red) possible = false;
                    if (count > largestRed) largestRed = count;
                    break;
                case "green":
                    if (count > green) possible = false;
                    if (count > largestGreen) largestGreen = count;
                    break;
                case "blue":
                    if (count > blue) possible = false;
                    if (count > largestBlue) largestBlue = count;
                    break;
            }
        }
    }

    if (possible) idSums += gameID;
    lowestSums += largestRed * largestGreen * largestBlue;
}

Console.WriteLine(idSums);
Console.WriteLine(lowestSums);