using Microsoft.VisualStudio.TestTools.UnitTesting;

// TODO Problem 2 - Write and run test cases and fix the code to match requirements.

[TestClass]
public class PriorityQueueTests
{
    [TestMethod]
    // Scenario: The Enqueue function shall add an item with its data and priority to the back of the queue 
    // Expected Result: (baptism, confirmation, endowment, sealing)
    // Defect(s) Found: 
    public void TestPriorityQueue_Enqueue()
    {
        var baptism = new PriorityItem("baptism", 4);
        var confirmation = new PriorityItem("confirmation",3);
        var endowment = new PriorityItem("endowment", 2);
        var sealing = new PriorityItem("sealing", 1);

        PriorityItem[] expectedResult = [baptism, confirmation, endowment, sealing];

        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue(baptism.Value, baptism.Priority);
        priorityQueue.Enqueue(confirmation.Value, confirmation.Priority);
        priorityQueue.Enqueue(endowment.Value, endowment.Priority);
        priorityQueue.Enqueue(sealing.Value, sealing.Priority);

        Assert.AreEqual(expectedResult[3].Value, sealing.Value);
    }

    [TestMethod]
     // Scenario: The Dequeue function shall remove the item with the highest priority 
    // Expected Result: baptism
    // Defect(s) Found: 
    public void TestPriorityQueue_Dequeue()
    {
        var baptism = new PriorityItem("baptism", 4);
        var confirmation = new PriorityItem("confirmation",2);
        var endowment = new PriorityItem("endowment", 1);
        var sealing = new PriorityItem("sealing", 3);

        string expectedResult = "baptism";

        var priorityQueue = new PriorityQueue();
        
        priorityQueue.Enqueue(baptism.Value, baptism.Priority);
        priorityQueue.Enqueue(confirmation.Value, confirmation.Priority);
        priorityQueue.Enqueue(endowment.Value, endowment.Priority);
        priorityQueue.Enqueue(sealing.Value, sealing.Priority);

        var highestPriority = priorityQueue.Dequeue();

        Assert.AreEqual(expectedResult, highestPriority);
        
    }

    [TestMethod]
     // Scenario: The Dequeue function shall remove the item with the highest priority, when there is more than one item with the same priority, the one closest to the front of the queue shall be removed.
    // Expected Result: faith
    // Defect(s) Found: The comparison that determined the highest priority, was causing the next highest item to take precedence over previously entered items. Modified the comparison from an "=>" to a ">" so the already enqueued items would not be ignored.
    public void TestPriorityQueue_DequeueFrontFirst()
    {
        var faith = new PriorityItem("faith", 5);
        var repentance = new PriorityItem("repentance", 5);
        var baptism = new PriorityItem("baptism", 4);
        var confirmation = new PriorityItem("confirmation",2);
        var endowment = new PriorityItem("endowment", 1);
        var sealing = new PriorityItem("sealing", 3);

        string expectedResult = "faith";

        var priorityQueue = new PriorityQueue();
        
        priorityQueue.Enqueue(faith.Value, faith.Priority);
        priorityQueue.Enqueue(repentance.Value, repentance.Priority);
        priorityQueue.Enqueue(baptism.Value, baptism.Priority);
        priorityQueue.Enqueue(confirmation.Value, confirmation.Priority);
        priorityQueue.Enqueue(endowment.Value, endowment.Priority);
        priorityQueue.Enqueue(sealing.Value, sealing.Priority);

        var highestPriority = priorityQueue.Dequeue();

        Assert.AreEqual(expectedResult, highestPriority);
        
    }

    [TestMethod]
     // Scenario: The Dequeue function shall throw an expection  if the queue is empty
    // Expected Result: InvalidOperationException with message "The queue is empty."
    // Defect(s) Found: 
    public void TestPriorityQueue_emptyQueue()
    {

        var priorityQueue = new PriorityQueue();

        try
        {
            priorityQueue.Dequeue();
            Assert.Fail("Exception Thrown");
        }
        catch (InvalidOperationException e)
        {
            Assert.AreEqual("The queue is empty.", e.Message);
        }
        
    }

}