int[] daNumbers = new int[] { 5, 3, 1, 1 };
var daSum = daNumbers.Sum();
var daCount = daNumbers.Count();
var daMin = daNumbers.Min();
var daMax = daNumbers.Max();
var daAverage = daNumbers.Average();

// Used in combination with Where
var daOnesFiltered = daNumbers.Where(n => n == 1).ToList().Count();

// The Aggregate method will iterate through the daNumbers array.
// The 'seed' value is set to decimal value 0 (0M), simply the starting value.
// This seed value will be the starting point for our sum
// After iterating through daNumbers array, the Aggregate method will return the final value of sum
var daAggregateExample = daNumbers.Aggregate(0M, (sum, daNumberItem) => sum + daNumberItem);
