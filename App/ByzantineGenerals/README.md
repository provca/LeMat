# Byzantine Generals Game
This is a strategy-based simulation game inspired by the Byzantine Generals' Problem[^1]. The game allows a king to interact with his generals, persuade them to either remain loyal or become traitors, and make decisions that impact the course of battle. The game involves a series of rounds where the king must manage loyalty, respect, and betrayal within his army.

## Game Overview
In the game, the player takes on the role of the King, who must issue commands to his generals. The main goal is to maintain loyalty within the army while dealing with traitors. The player can either try to convert traitors into loyal generals or cause loyalty to falter among the loyal ones. The game's mechanics revolve around making decisions and influencing the generals' loyalty through persuasion and interaction.

## Technologies Used
- **Language**: C#
- **Framework**: .NET
- **Architecture**: SOLID principles

### Features
- **General Types**: Each general has a loyalty (loyal or traitor) and a respect value, which can be influenced by the king's decisions.
- **Persuasion Rounds**: The king interacts with each general and can attempt to convert them from traitor to loyal or vice versa.
- **Rounds and Decisions**: The game is divided into rounds, where the king makes decisions to either continue or stop the round, depending on his strategy.
- **Statistics Tracking**: After each round, the statistics of loyalty and betrayal are displayed, along with individual general stats.

### Project Structure
```
ByzantineGenerals/ 
│
├── User/ 
│     └── ConsoleUserInterface.cs
│
└── Program.cs


QuantumCat/ 
│ 
├── Factories/ 
│    └── GameFactory.cs 
│
├── Play/ 
│    └── Game.cs 
│
├── Interfaces/ 
│    ├── Players/
│    │    ├── IGeneral.cs
│    │    └── IKing.cs 
│    │
│    ├── IRounds.cs 
│    ├── IStatistics.cs
│    └── IUserInterface.cs
│
├── Logic/ 
│    ├── Utilities/
│    │    ├── InputHelper.cs
│    │    └── RandomHelper.cs 
│    │
│    ├── Rounds.cs 
│    └── Statistics.cs
│
└── Models/ 
     ├── General.cs 
     └── King.cs 
```

## How It Works

1. **Initial Decision**: The game begins by asking the King to make an initial decision: attack or retreat. The King must choose between two options:
   - **A** for Attack
   - **R** for Retreat

2. **Persuasion Rounds**: The game proceeds with persuasion rounds. In each round, the King interacts with his generals and makes decisions about how to influence their loyalty:
   - **Neutralize differences** between loyal and traitor generals.
   - **Convert traitors to loyal generals**.
   - **Turn loyal generals into traitors**.

3. **Statistics**: After each round, the game shows a summary of the current loyalty and betrayal statistics, both overall and for each general.

4. **End of Round**: After the first round, the King is prompted to continue to the second round or stop and finalize the decision. If the King chooses to stop, a conspiracy event may occur, which could change the dynamics of the game.

5. **Continuing to the Next Round**: If the King decides to continue to the second round, the game proceeds with the next phase of persuasion, where the King can further influence the generals' loyalty. The generals' positions may evolve, and new dynamics can emerge. This round offers another opportunity to sway the loyalty of the generals, either to strengthen the King's command or risk more betrayal.

## Classes and Methods

### `King`
The King class is responsible for issuing commands and interacting with the generals. The king can perform the following actions:
- **GetInitialDecision**: Prompts the King to choose between attacking or retreating.
- **ExecuteRounds**: Executes two main rounds of interaction with generals.
- **ExecutePersuasionRound**: Executes a round of persuasion where the King tries to influence the generals' loyalty.

### `General`
Each general has attributes that define their loyalty and respect:
- **IsHonest**: Indicates whether the general is loyal or a traitor.
- **Respect**: A value representing the general's respect for the King.
- **ChangeLoyalty**: A method to change a general's loyalty and adjust their respect.

### `Statistics`
This class is responsible for tracking and displaying statistics about the generals and their loyalty:
- **DisplayInitialStatistics**: Displays the initial statistics about the generals' loyalty.
- **DisplayGeneralStatistics**: Displays the statistics for each general.
- **DisplayFinalStatistics**: Displays the final statistics after the rounds are completed.

### Persuasion Mechanism
The king can influence generals using different methods:
- **Neutralize differences**: Attempt to unite loyal and traitor generals.
- **Convert traitors**: Try to convert traitors into loyal generals. Beware, the loyal general may rethink his loyalty.
- **Turn loyals into traitors**: Attempt to reduce loyalty among loyal generals.

## Getting Started
### Prerequisites
- .NET 8.0 or higher

### Usage
- **Type `A`**: for Attack.
- **Type `R`**: for Retreat.
```
Initial Statistics:
Loyal: 2 (50,00%)
Traitor: 2 (50,00%)
Welcome to the Byzantine Generals' Council.
You are the King. Decide whether to attack or retreat.
Beware: some generals may be traitors!

What is your initial order? (attack (A)/retreat (R))
> A
```
- **Type a number**: Select the action to say to each general. Each selection will provide you with the general's response.
```
Round 1:

Interacting with General A...
Choose an action:
1. War is not won solely on the battlefield, but also in the hearts of men.
2. The art of governance is balancing mercy with severity.
3. The Byzantine Empire never died; it merely changed form.
> 2

...
```
- **Type `C` or `S`**: Choose whether to continue persuading generals or check if the conspiracy will be executed.
```
End of Round Statistics:
General A - Loyalty: Traitor, Respect: 2
General B - Loyalty: Traitor, Respect: 2
General C - Loyalty: Traitor, Respect: 2
General D - Loyalty: Loyal, Respect: 1
Do you want to proceed to the next round or stop and finalize? (continue (C)/stop (S))
> C

...

Interacting with General C...
Choose an action:
1. War is not won solely on the battlefield, but also in the hearts of men.
2. The art of governance is balancing mercy with severity.
3. The Byzantine Empire never died; it merely changed form.
> 3
General C: "A king who destroys his country is not a king, but an executioner."

...
...
...

End of Round Statistics:
General A - Loyalty: Loyal, Respect: 3
General B - Loyalty: Loyal, Respect: 3
General C - Loyalty: Loyal, Respect: 3
General D - Loyalty: Loyal, Respect: 3

Final Statistics:
Loyal: 4 (100,00%)
Traitor: 0 (0,00%)
General A - Loyalty: Loyal, Respect: 3
General B - Loyalty: Loyal, Respect: 3
General C - Loyalty: Loyal, Respect: 3
General D - Loyalty: Loyal, Respect: 3
```

### License
This project is licensed under the MIT License - see the LICENSE file for details.

[^1]:[Byzantine fault](https://en.wikipedia.org/wiki/Byzantine_fault)