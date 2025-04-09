public class Node
{
    public int Data { get; set; }
    public Node? Right { get; private set; }
    public Node? Left { get; private set; }

    public Node(int data)
    {
        this.Data = data;
    }

    public void Insert(int value)
    {
        // TODO Start Problem 1
        //Solution: Values have to be greater than or less than to be added. Anything equal to the current value won't be added, thus filtering the unique values.

        if (value < Data) //This line will ensure that only values less than Data will be added.
        {
            // Insert to the left
            if (Left is null)
                Left = new Node(value);
            else
                Left.Insert(value);
        }
        else if (value > Data) //This line will ensure that anything equal to Data won't be added.
        {
            // Insert to the right
            if (Right is null)
                Right = new Node(value);
            else
                Right.Insert(value);
        }
    }

    public bool Contains(int value)
    {
        // TODO Start Problem 2
        //Solution: The value will be compared to the Data of the current recursive call. If it's equal, then true will be returned. From there it checks if it's greater than or less than and returns another recursive call to go one level down or returns false if the Data is null, meaning it ran out of options.

        if (value == Data) //Base case: If the value equals the data in current recursive call. The function will stop.
        {
            return true;
        }


        if (value < Data) //Smaller problem. if the value is greater than or less than the Data, it will traverse
        //the left or right subtree until it finds its equal. 
        //If it runs out of options and there's no pair, false is returned.
        {
            if (Left == null)
                return false;
            
            return Left.Contains(value);
        }

        if (value > Data)
        {
            if (Right == null)
            return false;
            
            return Right.Contains(value);
        }

        return false;
    }

    public int GetHeight()
    {
        // TODO Start Problem 4
        //Solution: Recursively check both left and right subtree and 
        // then compare both results to see which one is higher. Once 
        // the comparison is done, return either result + 1 to get the 
        // height.

        if (this == null) //Base case: If the first call has an empty node, the tree is empty and the height is 0.
        {
            return 0;
        }

        //Smaller problem: traverse both sides adding one per recursive call. Compare both heights and return the highest + 1. 
        var leftHeight = 0;
        if (Left != null)
        {
            leftHeight = Left.GetHeight();
            
        }
        
        var rightHeight = 0;
        if (Right != null)
        {
            rightHeight = Right.GetHeight();
        }

        if (leftHeight <= rightHeight)
        {
            return rightHeight + 1;
        }
        else if (leftHeight >= rightHeight)
        {
            return leftHeight + 1;
        } 
        else {
            return 0;
        }
        
    }
}