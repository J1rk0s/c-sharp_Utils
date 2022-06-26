# c-sharp_Utils
* Some c# utils
* PS: Sorry for my english

## Usage
1. Download dll in bin/release
2. Add a reference to the dll in your project
3. Import it 
4. Start using it

## Methods 
1. ReverseString method
    * Reverses input string and returns it
    * It is a extension method and to use it write:
    * ```[name] = [name].ReverseString();```
2. Input
    * Adds a python like input
    * To use it type:
    * ```[data type] [name] = Input<[Data type]>([prompt txt]);```
3. Capitalize
    * This one is self explanatory
    * Capitalizes a string
    * This is also an extension method
    * To use it write:
    * ```[name] = [name].Capitalize();```
4. QuadraticEquationDiscriminant
    * This method calculates discriminant from quadratic equation
    * To use it write:
    * ```int [name] = QuadraticEquationDiscriminant([int a], [int b], [int c]);```
5. BinarySearch
    * This a binary search algorithm
    * To use it write:
    * ```int [name] = BinarySearch([array a], [name of number to be found in array]);```
6. EuclidAlgo
   * This is a euclid algorithm
7. MultiplyAllInArray
    * This one is also self explanatory
    * It is also an extension method
    * It multiplies all numbers an a given array
8. RegexExpressions
    * This is a struct of some usefull regex expressions
9. Similar
    * This is an extension method
    * Returns similar strings from inputed text
    * To use:
    * ```string[] [variable name] = [string name].Similar();```
10. RemoveDuplicates
    * Extension method
    * Removes duplicates from List or Array
    * To use:
    * ```[list or array name] = [list or array name].RemoveDuplicates();```
11. LinearSearchAlgo
    * Performs linear search on given array
    * To use:
    * ```int? [name] = LinearSearchAlgo([array name], [target number]);```
12. ReverseInt
    * Same as ReverseString but this one reverses ints
    * Extension method
    * To use:
    * ```int [name] = [name of int variable].ReverseInt();```
13. SpongebobCase
    * Makes spongebob case
    * Example: input = "Hello"
    * Output: "HeLlO"
    * To use:
    * ```string [name] = SpongebobCase([some string]);```
14. GetAddressOfIntArray
    * Returns IntPtr of given int array
    * To use:
    * ```IntPtr [name] = GetAddressOfIntArray([name of int array]);```
