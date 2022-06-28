// See https://aka.ms/new-console-template for more information

//establishes variables
int manticoreDistance;
int round;
int cityHealth;
int manticoreHealth;
int cannonDamage;
int rangeGuess;
int turn;
string keepPlaying = "Y";


while (keepPlaying == "Y" || keepPlaying == "y")
{

    round = 1;
    cityHealth = 16;
    manticoreHealth = 10;
    cannonDamage = 1;
    rangeGuess = -1;
    turn = 1;
    int playerCountSelection;
    Random random = new Random();

    //select number of players. 
    Console.WriteLine("Will there be (1) or (2) players?");

    //process the player count input
    playerCountSelection = Convert.ToInt16(Console.ReadLine());
    if (playerCountSelection == 1)
    {
        manticoreDistance = random.Next();
        Console.WriteLine("Prepare yourself for defense...");
        
    }
    else
    {
        Console.WriteLine("Player 1, how far away from the city do you want to station the Manticore?");
        //Player 1 entry of the Manicore's distance from Consolas
        manticoreDistance = Convert.ToInt16(Console.ReadLine());
    }

    


    //check that manticoreDistance is within the allowable range.
    while (manticoreDistance > 100 || manticoreDistance < 1)
    {
        Console.WriteLine("That distance is out of range. It must be between 1-100. Please enter a distance between this range.");
        manticoreDistance = Convert.ToInt16(Console.ReadLine());
    }

    Console.WriteLine("Player 2, it is your turn.");
    //play's game as long as there is health available
    while (manticoreHealth > 0 && cityHealth > 0)
    {
        MagicCannon();
        Status();
        GuessEvaluation();
    }

    if (manticoreHealth <= 0)
    {
        Console.WriteLine($"----------------------------------------------------------");
        Console.WriteLine("The Manticore has been destroyed! The city of Consolas has been saved!");
        Console.WriteLine($"----------------------------------------------------------");
    }
    else
        Console.WriteLine($"----------------------------------------------------------");
    Console.WriteLine("The city of Consolas has been lost...all hope is gone...you have disappointed everyone...especially your mother.");
    Console.WriteLine($"----------------------------------------------------------");


    Console.WriteLine("Woudl you like to play again? (Y/N)");
    keepPlaying = Console.ReadLine();

    if (keepPlaying != "y" || keepPlaying != "Y")
    {

    }
    Console.WriteLine("Thank you for your service to Consolas!");
}
Console.ReadKey();

//provides the status and requests player 2's range guess
void Status()
{
    cityHealth--;
    Console.WriteLine($"----------------------------------------------------------");
    Console.Write($"STATUS: Round: {round} City: {cityHealth}/15 Manticore: {manticoreHealth}/10" +
    $"\nThe cannon is expected to deal {cannonDamage} damage this round" +
    $"\nEnter desired cannon range: ");
    rangeGuess = Convert.ToInt16(Console.ReadLine());

}

//evaluates target hit or the necessary adjustements
//also iterates turn in order to share that data with the magic cannon
void GuessEvaluation()
{

    if (rangeGuess < manticoreDistance)
    {
        Console.WriteLine("That round FELL SHORT of the target.");
    }
    else if (rangeGuess > manticoreDistance)
    {
        Console.WriteLine("That round OVERSHOT of the target.");
    }
    else
    {
        Console.WriteLine("That round was a DIRECT HIT!");
        manticoreHealth = manticoreHealth - cannonDamage;

    }
    turn++;
}

//uses the turn to evaluate the power of the cannon
void MagicCannon()
{
    if (turn % 3 == 0 || turn % 5 == 0)
    {
        cannonDamage = 3;
    }
    else if (turn % 3 == 0 && turn % 5 == 0)
    {
        cannonDamage = 10;
    }
    else
    {
        cannonDamage = 1;
    }
}

