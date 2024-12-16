# Monty Hall Problem Simulation

This C# application simulates the Monty Hall problem, a well-known probability puzzle that challenges intuition. It aims to help users understand the counterintuitive advantage of switching doors in this scenario.

## Key Features:

- **Interactive Gameplay:** You'll make choices throughout the simulation, mimicking a real contestant's experience.
- **Statistics Tracking:** The program keeps track of your wins by switching and sticking with your initial choice, helping you visualize the strategy's effectiveness over time.
- **Clear Explanations:** While the simulation provides the experience, you can find a detailed explanation of the Monty Hall problem and its solution online (resources will be provided).

## How to Play:

1. **Welcome Message:** The program will greet you and explain the basic rules of the Monty Hall problem.
2. **Door Selection:** You'll be presented with three doors, one hiding a prize (unknown to you). Choose a door.
3. **Host's Reveal:** The host, knowing which door has the prize, opens one of the remaining doors to reveal it's empty. This creates the key strategic decision.
4. **Switch or Stick? Here's the crucial part:** you now have the option to switch to the remaining unopened door or stick with your initial choice. The program will prompt you for your decision.
5. **Outcome Revealed:** The program opens the final door, revealing the contents and letting you know whether you won the prize.
6. **Round End:** The program will display the outcome and ask if you'd like to play another round.

## Project Structure
```
MontyHallProblem/ 
├── Program.cs
│
└── User/ 
     └── ConsoleUserInterface.cs


ThreeDoors/ 
│ 
├── Game/ 
│    └── Game.cs 
│
├── Interfaces/ 
│     ├── IUserInterface.cs 
│     └── IRandomGenerator.cs
│
├── Logic/ 
│    ├── RandomGenerator.cs 
│    └── StatisticsManager.cs 
│
└── Models/ 
     └── Door.cs 
```

## License
This project is licensed under the MIT License. See LICENSE for details.

## Running the Program:
1. Compile the C# code.
2. Execute the resulting executable file.
3. Follow the on-screen instructions to play the simulation.

## Additional Resources:
- [Monty Hall Problem](https://en.wikipedia.org/wiki/Monty_Hall_problem)
- [Statistics How To](https://www.statisticshowto.com/probability-and-statistics/monty-hall-problem/)