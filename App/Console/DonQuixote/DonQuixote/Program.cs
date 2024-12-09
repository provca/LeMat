using ChasingWindmillsInLogic.ChasingWindmills;

// Attempt to evaluate the paradox.
try
{
    // Initial call to the DonQuijote method with a depth value of 0.
    bool result = Game.ChasingWindmills(0);

    // Displays the result of the logical statement.
    Console.WriteLine("Is the proposition true? " + result);
}
catch (StackOverflowException)
{
    //Catch a stack overflow exception and display a dramatic message
    Console.WriteLine(
        "Alas! The logic crumbles beneath its own weight." +
        "What is truth, if not a fleeting mirage?"
        );
}

// This is to keep the console open after the execution.
Console.ReadLine();
