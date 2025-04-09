// When I started learning C#, I encountered LINQ pretty quickly, and fell in love.
// Here i will collect lots of examples, both using linq query syntax and linc method syntax (lambda)

// Linq query syntax vs methods syntax
newList = (from unit in orgUnits select unit).ToList(); //ToList casts IEnumerable to List
newList = orgUnits.Select(unit => unit).ToList(); //unit => unit is the lambda expression
