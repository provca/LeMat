# Schrödinger's Cat Quantum Experiment

## Overview
The **Schrödinger's Cat Quantum Experiment** is an interactive console application designed to simulate the famous thought experiment[^1] by physicist Erwin Schrödinger. This project demonstrates key quantum mechanics concepts, such as superposition and wave function collapse, through a simple and engaging program.

## Features
- **Quantum Superposition Simulation**: The cat exists in a superposition of states (alive and dead) until observed.
- **Wave Function Collapse**: Observing the system determines the definitive state of the cat.
- **Probability Fluctuations**: The wave state fluctuates dynamically before observation.
- **Modular Design**: The application is designed to be flexible, allowing for integration with various frontends (e.g., web, console).

## Technologies Used
- **Language**: C#
- **Framework**: .NET
- **Architecture**: SOLID principles

## Project Structure
```
SchroedingersCat/ 
│
├── User/ 
│     └── ConsoleUserInterface.cs
│
└── Program.cs


QuantumCat/ 
│ 
├── Game/ 
│    └── Game.cs 
│
├── Interfaces/ 
│    ├── IProbabilityCalculator.cs 
│    ├── IStartExperiment.cs
│    ├── IStateCollapser.cs
│    └── IUserInterface.cs
│
├── Logic/ 
│    ├── ProbabilityCalculator.cs 
│    ├── StartExperiment.cs 
│    └── StateCollapser.cs 
│
└── Model/ 
     └── QuantumCatModel.cs 
```

## How It Works
1. The experiment begins with the cat in a superposition state.
2. The user can:
   - **Check the Wave State (`S`)**: View the current probability of the cat being alive or dead.
   - **Observe the Cat (`O`)**: Collapse the wave state into a definitive state (alive or dead).
   - **Restart the Experiment**: Reset the system to its initial quantum state.
   - **Quit the Experiment (`Q`)**: Exit the application.
3. The state probabilities fluctuate dynamically until the wave function is collapsed.

## Getting Started
### Prerequisites
- .NET 8.0

### Usage
- **Type `S`**: View the current wave state probabilities.
- **Type `O`**: Observe the system and reveal the cat's definitive state.
- **Type `Q`**: Quit the experiment.

### Example Run
```
Welcome to Schrödinger's Cat Quantum Experiment!
Before observation, the cat exists in superposition (like a wave).
Upon observation, the state collapses to a particle: 'alive' or 'dead'.
Type 'O' (observe) to open the box and collapse the cat's state, or 'S' (state) to view the quantum wave.
Type 'Q' (quit) to leave the experiment.

> S
Wave state: Alive 53.12% | Dead 46.88%.

> O
You observed the system! The cat is: Alive.
The cat has broken its quantum state.
```

## License
This project is licensed under the MIT License. See the LICENSE file for details.

[^1]:[Schrödinger's cat](https://en.wikipedia.org/wiki/Schr%C3%B6dinger%27s_cat)