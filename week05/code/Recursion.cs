using System.Collections;
using System.Runtime.CompilerServices;
using System.Threading.Tasks.Dataflow;
using System.Diagnostics;

public static class Recursion
{
    /// <summary>
    /// #############
    /// # Problem 1 #
    /// #############
    /// Using recursion, find the sum of 1^2 + 2^2 + 3^2 + ... + n^2
    /// and return it.  Remember to both express the solution 
    /// in terms of recursive call on a smaller problem and 
    /// to identify a base case (terminating case).  If the value of
    /// n <= 0, just return 0.   A loop should not be used.
    /// </summary>
    public static int SumSquaresRecursive(int n)
    {
        // TODO Start Problem 1
        if (n <= 0) // Base case, once the recursive call reaches 0 it will stop.
        {
            return 0;
        }
        var operationResult = n * n + SumSquaresRecursive(n-1); // This operation will elevate n to square and then substract 1 from n. This is the recursive call.
        return operationResult; //Once the base case is reached the sum of all the numbers from 0 to n is returned. 
    }

    /// <summary>
    /// #############
    /// # Problem 2 #
    /// #############
    /// Using recursion, insert permutations of length
    /// 'size' from a list of 'letters' into the results list.  This function
    /// should assume that each letter is unique (i.e. the 
    /// function does not need to find unique permutations).
    ///
    /// In mathematics, we can calculate the number of permutations
    /// using the formula: len(letters)! / (len(letters) - size)!
    ///
    /// For example, if letters was [A,B,C] and size was 2 then
    /// the following would the contents of the results array after the function ran: AB, AC, BA, BC, CA, CB (might be in 
    /// a different order).
    ///
    /// You can assume that the size specified is always valid (between 1 
    /// and the length of the letters list).
    /// </summary>
    
    public static void PermutationsChoose(List<string> results, string letters, int size, string word = "")
    {
        // TODO Start Problem 2
        if (word.Length == size) //Base case, once the word has reached the requested size, the recursion will stop and add the word to results.
        {
            results.Add(word);
            return;
        }

        for (int i = 0; i < letters.Length ; i++)
        {
            var nonUsedLetters = letters.Remove(i, 1);
            PermutationsChoose(results, nonUsedLetters, size, word + letters[i]); //The recursive call uses a loop to go through the letters and create a new word with the found permutations.
        }
        
    }

    private static int getFactorial(int n)
    {
        if (n <= 1) //Base case
        {
            return 1;
        }
        return n * getFactorial(n-1); //Recursive call
    }

    /// <summary>
    /// #############
    /// # Problem 3 #
    /// #############
    /// Imagine that there was a staircase with 's' stairs.  
    /// We want to count how many ways there are to climb 
    /// the stairs.  If the person could only climb one 
    /// stair at a time, then the total would be just one.  
    /// However, if the person could choose to climb either 
    /// one, two, or three stairs at a time (in any order), 
    /// then the total possibilities become much more 
    /// complicated.  If there were just three stairs,
    /// the possible ways to climb would be four as follows:
    ///
    ///     1 step, 1 step, 1 step
    ///     1 step, 2 step
    ///     2 step, 1 step
    ///     3 step
    ///
    /// With just one step to go, the ways to get
    /// to the top of 's' stairs is to either:
    ///
    /// - take a single step from the second to last step, 
    /// - take a double step from the third to last step, 
    /// - take a triple step from the fourth to last step
    ///
    /// We don't need to think about scenarios like taking two 
    /// single steps from the third to last step because this
    /// is already part of the first scenario (taking a single
    /// step from the second to last step).
    ///
    /// These final leaps give us a sum:
    ///
    /// CountWaysToClimb(s) = CountWaysToClimb(s-1) + 
    ///                       CountWaysToClimb(s-2) +
    ///                       CountWaysToClimb(s-3)
    ///
    /// To run this function for larger values of 's', you will need
    /// to update this function to use memoization.  The parameter
    /// 'remember' has already been added as an input parameter to 
    /// the function for you to complete this task.
    /// </summary>
    public static decimal CountWaysToClimb(int s, Dictionary<int, decimal>? remember = null)
    {
        if (remember == null) //If the function is called for the first time, initiate the dictionary.
            remember = new Dictionary<int, decimal>();
        // Base Cases
        if (s == 0)
            return 0;
        if (s == 1)
            return 1;
        if (s == 2)
            return 2;
        if (s == 3)
            return 4;
        
        // TODO Start Problem 3
        if (remember.ContainsKey(s)) // If this has been solved before, return that value.
            return remember[s];
        // Solve using recursion
        decimal ways = CountWaysToClimb(s - 1, remember) + CountWaysToClimb(s - 2, remember) + CountWaysToClimb(s - 3, remember);
        remember[s] = ways; //Add the way to the remember dictionary to know that it has been already found.
        return ways;
    }

    /// <summary>
    /// #############
    /// # Problem 4 #
    /// #############
    /// A binary string is a string consisting of just 1's and 0's.  For example, 1010111 is 
    /// a binary string.  If we introduce a wildcard symbol * into the string, we can say that 
    /// this is now a pattern for multiple binary strings.  For example, 101*1 could be used 
    /// to represent 10101 and 10111.  A pattern can have more than one * wildcard.  For example, 
    /// 1**1 would result in 4 different binary strings: 1001, 1011, 1101, and 1111.
    ///	
    /// Using recursion, insert all possible binary strings for a given pattern into the results list.  You might find 
    /// some of the string functions like IndexOf and [..X] / [X..] to be useful in solving this problem.
    /// </summary>
    public static void WildcardBinary(string pattern, List<string> results, int nextPosition = 0)
    {


        if (!pattern.Contains('*')) //Base case, once wildcards have been replaced with the possible values, 
        // they're added to the results list
        {
            results.Add(pattern);
            return;
        }


        for (int i = nextPosition; i < pattern.Length; i++) //A for loop goes through each character and replaces it with a 0 or 1.
        {
            if (pattern[i] == '*')
            {
                char[] pattern0 = pattern.ToCharArray();
                char[] pattern1 = pattern.ToCharArray();

                pattern0[i] = '0';
                pattern1[i] = '1';

                string pattern0String = new string(pattern0);
                string pattern1String = new string (pattern1);

                WildcardBinary(pattern0String, results, i + 1); //A recusive call replaces the previous pattern with the new pattern 
                // and adds 1 to go to the next position in the for loop.
                WildcardBinary(pattern1String, results, i + 1); //The recursive call is repeated here to replace the values with both 1 and 0.

                return;

            }
        }


        

    }

    /// <summary>
    /// Use recursion to insert all paths that start at (0,0) and end at the
    /// 'end' square into the results list.
    /// </summary>
    public static void SolveMaze(List<string> results, Maze maze, int x = 0, int y = 0, List<ValueTuple<int, int>>? currPath = null)
    {
        // If this is the first time running the function, then we need
        // to initialize the currPath list.
        if (currPath == null) {
            currPath = new List<ValueTuple<int, int>>();
        }
        
        // currPath.Add((1,2)); // Use this syntax to add to the current path

        // TODO Start Problem 5
        // ADD CODE HERE

        // results.Add(currPath.AsString()); // Use this to add your path to the results array keeping track of complete maze solutions when you find the solution.
    }
}