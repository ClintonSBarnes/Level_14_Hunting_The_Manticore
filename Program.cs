﻿// See https://aka.ms/new-console-template for more information

//establishes variables
int manticoreDistance;
int round = 1;
int cityHealth = 16;
int manticoreHealth = 10;
int cannonDamage = 1;
int rangeGuess = -1;
int turn = 1;

//Player 1 entry of the Manicore's distance from Consolas
Console.WriteLine("Player 1, how far away from the city do you want to station the Manticore?");
manticoreDistance = Convert.ToInt16(Console.ReadLine());

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
    Console.WriteLine("The Manticore has been destroyed! The city of Consolas has been saved!");
}
else
    Console.WriteLine("The city of Consolas has been lost...all hope is gone...you have disappointed everyone...especially your mother.");

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
