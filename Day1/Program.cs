using System.Text.RegularExpressions;

string[] lines = File.ReadAllLines("input.txt");

int sum = 0;
foreach (string line in lines)
{
    int firstIndex = 0;
    int secondIndex = line.Length - 1;

    while (firstIndex < line.Length && !int.TryParse(line[firstIndex].ToString(), out _))
    {
        firstIndex++;
    }

    while (secondIndex > 0 && !int.TryParse(line[secondIndex].ToString(), out _))
    {
        secondIndex--;
    }

    string twoDigits = line[firstIndex].ToString() + line[secondIndex].ToString();
    sum += int.Parse(twoDigits);
}

Console.WriteLine(sum);