public static class Arrays
{
    /// <summary>
    /// This function will produce an array of size 'length' starting with 'number' followed by multiples of 'number'.  For 
    /// example, MultiplesOf(7, 5) will result in: {7, 14, 21, 28, 35}.  Assume that length is a positive
    /// integer greater than 0.
    /// </summary>
    /// <returns>array of doubles that are the multiples of the supplied number</returns>
    public static double[] MultiplesOf(double number, int length)
    {
        // TODO Problem 1 Start
        // Remember: Using comments in your program, write down your process for solving this problem
        // step by step before you write the code. The plan should be clear enough that it could
        // be implemented by another person.
        
        //Step 1.
        //Define a List that will hold the returned multiples, and an array that will be returned since the method is supposed to return an array and not a List.
        List <double> multiples = new List<double>{};
        double [] multiplesArray = {};
        //Step 2. 
        //Limit the function by returning an array with 0, if either number or length is 0 to avoid unnecessary iterations, and conver the List to an Array.
        if (number == 0 || length == 0)
        {
            multiplesArray.Append(0);
            return multiplesArray;
        }
        //Step 3.
        //Create a loop that will iterate by the length parameter.
        //Step 4.
        //Within the loop, multiply the number parameter by the next iteration number until the length number is reached.
        //Step 5.
        //Add the multiple to the multiples array.
        else
        {
            for (int i = 1; i <= length; i++)
            {
                double multiple = number * i;
                multiples.Add(multiple);
            }
        }
        
        //Step 6. 
        //Conver the Dynamic Array (List) to an Array. Return the array.
        multiplesArray = multiples.ToArray();
        return multiplesArray; // replace this return statement with your own
    }

    /// <summary>
    /// Rotate the 'data' to the right by the 'amount'.  For example, if the data is 
    /// List<int>{1, 2, 3, 4, 5, 6, 7, 8, 9} and an amount is 3 then the list after the function runs should be 
    /// List<int>{7, 8, 9, 1, 2, 3, 4, 5, 6}.  The value of amount will be in the range of 1 to data.Count, inclusive.
    ///
    /// Because a list is dynamic, this function will modify the existing data list rather than returning a new list.
    /// </summary>
    public static void RotateListRight(List<int> data, int amount)
    {
        // TODO Problem 2 Start
        // Remember: Using comments in your program, write down your process for solving this problem
        // step by step before you write the code. The plan should be clear enough that it could
        // be implemented by another person.

        //Step 1.
        //Create a new rotatory list and use the GetRange method to create a new List with the selected rotatory data.
        List<int> rotatoryData = data.GetRange(data.Count - amount, amount);
        //Step 2.
        //Use RemoveRange method to delete the data from the selected rotation
        data.RemoveRange(data.Count - amount, amount);
        //Step 3.
        //Use InsertRange method to insert the previously created List at the beginning of the original list. 
        data.InsertRange(0,rotatoryData);
    }
}
