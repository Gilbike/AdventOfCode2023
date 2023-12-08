string[] lines = File.ReadAllLines("input.txt");

int sum = 0;

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
                found = true;
            } else if (rightIndex < line.Length && !char.IsDigit(line[rightIndex]) && line[rightIndex] != '.') {
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
                        found = true;
                    }
                }
                if (!found && l + 1 < lines.Length) {
                    string upperLine = lines[l + 1];
                    int col = leftIndex >= 0 ? leftIndex : leftIndex + 1;
                    while (col <= endIndex && (char.IsDigit(upperLine[col]) || upperLine[col] == '.'))
                    {
                        col++;
                    }
                    if (col <= endIndex)
                    {
                        found = true;
                    }
                }
            }

            if (found)
            {
                string numberRaw = line[c].ToString();
                if (digitStreak > 0)
                {
                    for (int d = 1; d <= digitStreak; d++)
                    {
                        numberRaw += line[c + d].ToString();
                    }
                }
                sum += int.Parse(numberRaw);
            }

            c += digitStreak + 1;
            continue;
        }
        c++;
    }
}

Console.WriteLine(sum);