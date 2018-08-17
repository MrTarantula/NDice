# NDice.Randomizers

This is a metapackage for all official implementations of `IRandomizable`. The default randomizer `SystemRandomizer` is located in `NDice`.

## NDice.Randomizers.RandomOrg

Uses [alexanderkozlenko/random-org](https://github.com/alexanderkozlenko/random-org) to fetch random numbers from the web. Rolls are cached to prevent API calls when possible.

## NDice.Randomizers.SystemCrypto

Uses `System.Security.Cryptography.RNGCryptoServiceProvider` to roll the die.

## NDice.Randomizers.Troschuetz

Uses [pomma89/Troschuetz.Random](https://github.com/pomma89/Troschuetz.Random) to roll the die.
