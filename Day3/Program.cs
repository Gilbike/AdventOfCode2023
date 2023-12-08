string[] lines = File.ReadAllLines("input.txt");

int sum = 0;

Dictionary<string, List<int>> gears = new Dictionary<string, List<int>>();

for (int l = 0; l < lines.Length; l++) {
    string line = lines[l];
    int c = 0;
    while (c < line.Length)
    {
        int digitStreak = 0;
        char character = line[c];
        if (char.IsDigit(character)) {
            while (c + digitStreak + 1 < line.Length && char.IsDigit(line[c + digitStreak + 1])) {
                digitStreak++;
            }

            int leftIndex = c - 1;
            int rightIndex = c + digitStreak + 1;

            bool found = false;

            if (leftIndex >= 0 && !char.IsDigit(line[leftIndex]) && line[leftIndex] != '.') {
                if (line[leftIndex] == '*') AddToGears(l, leftIndex, GetNumberFromChars(line, c, digitStreak));
                found = true;
            } else if (rightIndex < line.Length && !char.IsDigit(line[rightIndex]) && line[rightIndex] != '.') {
                if (line[rightIndex] == '*') AddToGears(l, rightIndex, GetNumberFromChars(line, c, digitStreak));
                found = true;
            } else {
                int endIndex = rightIndex < line.Length ? rightIndex : rightIndex - 1;
                if (l > 0) {
                    string upperLine = lines[l - 1];
                    int col = leftIndex >= 0 ? leftIndex : leftIndex + 1;
                    while (col <= endIndex && (char.IsDigit(upperLine[col]) || upperLine[col] == '.')) {
                        col++;
                    }
                    if (col <= endIndex) {
                        if (upperLine[col] == '*') AddToGears(l - 1, col, GetNumberFromChars(line, c, digitStreak));
                        found = true;
                    }
                }
                if (!found && l + 1 < lines.Length) {
                    string lowerLine = lines[l + 1];
                    int col = leftIndex >= 0 ? leftIndex : leftIndex + 1;
                    while (col <= endIndex && (char.IsDigit(lowerLine[col]) || lowerLine[col] == '.'))
                    {
                        col++;
                    }
                    if (col <= endIndex)
                    {
                        if (lowerLine[col] == '*') AddToGears(l + 1, col, GetNumberFromChars(line, c, digitStreak));
                        found = true;
                    }
                }
            }

            if (found) sum += GetNumberFromChars(line, c, digitStreak);

            c += digitStreak + 1;
            continue;
        }
        c++;
    }
}

int gearSum = 0;
List<List<int>> selectedGears = gears.Where(x => x.Value.Count == 2).ToDictionary(x => x.Key, x => x.Value).Values.ToList();
foreach (var gear in selectedGears)
{
    gearSum += gear[0] * gear[1];
}

Console.WriteLine(sum);
Console.WriteLine(gearSum);

int GetNumberFromChars(string line, int start, int streak)
{
    string numberRaw = line[start].ToString();
    if (streak > 0)
    {
        for (int d = 1; d <= streak; d++)
        {
            numberRaw += line[start + d].ToString();
        }
    }
    return int.Parse(numberRaw);
}

void AddToGears(int row, int col, int number)
{
    string key = $"{row}-{col}";
    if (gears.ContainsKey(key)) {
        gears[key].Add(number);
    } else {
        gears[key] = new List<int> { number };
    }
}
