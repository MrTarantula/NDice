# NDice

Dice toolkit for .Net. Included are some novel dice implementations for .Net. 

## Installation

```C#
dotnet add package NDice
// OR
install-Package NDice
```

## How To Use (tl;dr)

```C#
var die = new Die(); // Creates a new six-sided die

int result = die.Roll();
```

## Types of Dice

### `Die`

A fair die. It is not weighted, and as random as `System.Random` can be.

### `WeightedDie`

Die with one or more sides weighted to have a higher probablility of occurrence.

### `GamblersDie`

Weighted die that obeys the [Gambler's Fallacy](https://github.com/xori/gamblers-dice). The weight shifts after each roll, so that the longer a side has not been rolled, the higher its probability of occurrence for the next roll.

### `TappersDie`

A [tapper's die](http://www.dice-play.com/DiceCrooked.htm) behaves like a fair die, until it is tapped. Then it behaves like a weighted die until it is tapped again.

## Examples

Dice can be constructed with a default of six sides, or any number of sides:

```C#
var fairDie = new Die();

var weightedDie = new WeightedDie();

var bigFairDie = new Die(225);
```

> NOTE: Most types of weighted dice constructed with no weights will behave like a fair die

`WeightedDie` and dice derived from it (e.g. `GamblersDie`) can be constructed with weights for each side, using a series of numbers or an array:

```C#
// Six-sided die with side 4 heavily weighted
var luckyFour = new WeightedDie(1, 1, 1, 5, 1, 1);

int probablyFour = luckyFour.Roll();
int alsoProbablyFour = luckyFour.Roll();

// Ten-sided gambler's die, with side 2 heavily weighted
int[] weights = new Int[] { 1, 5, 1, 1, 1, 1, 1, 1, 1, 1 };
var firstRollLikelyTwo = new GamblersDie(weights);

int likelyTwo = firstRollLikelyTwo.Roll();
int likelyAnythingButTwo = firstRollLikelyTwo.Roll();
```

By default a private `System.Random` object is created for each die, but a shared `Random` can be passed as the first parameter for any die:

```C#
var rnd = new Random();

var die0 = new Die(rnd, 8);

var die1 = new WeightedDie(rnd, 1, 1, 1, 7, 1, 1, 1);

var die2 = new GamblersDie(rnd, 20);
```

## Real World Examples

Die | Code
:-: | -
D20<br>![D20](d20.png) | <pre>var d20 = new Die(20);</pre>
[Average Die<br>![Average Die](avg.png)](https://em4miniatures.com/index.php/catalogsearch/result/?q=+average+dice) | <pre>var avgDie = new WeightedDie(1, 2, 2, 1);<br>int[] sides = new int[] { 2, 3, 4, 5 };<br><br>// Roll the die, then get the value<br>avgDie.Roll();<br>int rolledSide = sides[avgDie.Current];
Double Deuce<br>![Double Deuce](double2.png) | <pre>var d2Die = new WeightedDie(1, 2, 1, 1, 1);<br>int[] sides = new int[] { 1, 2, 3, 4, 6 };<br><br>// Roll the die, then get the value<br>d2Die.Roll();<br>int rolledSide = sides[d2Die.Current];

## Future Work

- [ ] More real world examples
- [ ] Percentages/ratios for weight
- [ ] Include common dice like the examples 
- [ ] Built-in labels
- [ ] Fluent die builder
- [ ] Abstraction for randomizer, so other libs/algorithms may be used
- [ ] More dice algorithms! (statisticians/dice enthusiasts needed. PRs welcome)

## Acknowledgements

This wouldn't have been made if not for stumbling upon [xori/gamblers-dice](https://github.com/xori/gamblers-dice).
