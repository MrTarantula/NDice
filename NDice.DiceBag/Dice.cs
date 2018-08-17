using System;
using NDice.Builders;

namespace NDice.DiceBag
{
    public static class Dice
    {
        public static Die D20 => new DieBuilder().WithSides(20);
        public static WeightedDie AverageDie => new WeightedDieBuilder().WithWeights(1, 2, 2, 1).WithLabels("Two", "Three", "Four", "Five");
        public static WeightedDie DoubleDeuce => new WeightedDieBuilder().WithWeights(1, 2, 1, 1, 1).WithLabels("One", "Two", "Three", "Four", "Six");
        public static Die Coin => new DieBuilder().WithSides(2).WithLabels("Heads", "Tails");
    }
}