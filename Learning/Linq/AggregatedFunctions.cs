int[] daNumbers = new int[] { 5, 3, 1, 1 };
var daSum = daNumbers.Sum();
var daCount = daNumbers.Count();
var daMin = daNumbers.Min();
var daMax = daNumbers.Max();
var daAverage = daNumbers.Average();

// Used in combination with Where
var daOnesFiltered = daNumbers.Where(n => n == 1).ToList().Count();
