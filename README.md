# Game Rules

1. A random number between **1 and 100** is shown
2. The player guesses: will the next number be **Higher** or **Lower**?
3. A correct guess earns **1 point**; a wrong guess costs **1 life**
4. The game ends when all **3 lives** are lost

# Phase 1: Folder Structure

- What folders will we need in the project?

# Phase 2: Classes and Interfaces

- What classes, interfaces, and enums will we need?
- Which layer does each one belong to?

# Phase 3: GameService

- What are the possible outcomes of a single guess?
- What should the service expose and what should it be able to do?
- Where and how should we register the service and the pages?

# Phase 4: File-Based Storage

- Instead of keeping the game state in memory, where should it be stored?
- What should the file contain and in what format?
- How does the service read and write the state on each operation?
- Where on the device should the file live?

# Phase 5: StartPage

- What does the player need to do on this page?
- How should we prevent starting the game without a name?
- What needs to happen when the game starts?

# Phase 6: GamePage

- What information does the player need to see?
- How do we handle a guess and what can happen as a result?
- What should change on screen after each guess?

# Phase 7: GameOverPage

- What should the player see when the game ends?
- How do we get back to the start?
