# SeaBattle
SeaBattle in your console.

SB 0.1:
* Added classes Renderer, Point, PlayerInput;
* Ready prototype method Render;
* Ready prototype method GetPlayerInput.

SB 0.2:
* Ready GetPlayerInput method;
* Ready Renderer method, but it need design editing;
* Ready prototype method Shot;
* Changed method SetStingsForPoints.

SB 0.3:
* Optimized Point class;
* Fixed mistake with strings in Render method;
* Created Ships class.

SB 0.4:
* Created prototype Preparation() method;
* Created overload method for CoorinatesToPoints();
* Created private ChoosePositions() method.

SB 0.5:
* Created new class WinChecker;
* Created CheckWin() method;
* Created Win() method.

SB 0.6:
* Created attempt to ref Ships[] and Points[,].

SB 0.7:
* Created prototype Ref Ships[] and Points[.].

SB 0.8:
* Created non-ready AI class.

SB 0.85:
* Modified AI Class(added 25% of AIShoot() method).

SB 0.9:
* Ready AI class.

SB 0.91:
* Began creating Main() method;
* Changed Ships class constructor.

SB 0.92:
* Began creating AIPreparation() method.

SB 0.93:
* Ready 70% AIPreparation() method.

SB 0.94:
* Ready 80% AIPreparation() method:
  1) Added creating 3 deckships;
  2) Added checking typeofpoint for ships.

SB 0.95:
* Ready 90% AIPreparation() method:
   
   a) Added creating 4 deckships.
   
SB 0.96:
* Ready AIPreparation() method;
* Corrected Preparation() method's output.

SB 0.97:
* Fixed Ships class constructor;
* Ready 30% Main method(). 

SB 0.98:
* Changed checking of typeofpoint in AIPreparation() method.

SB 0.985:
* Fixed bugs in AI Class;
* Fixed bugs in PlayerInput Class;
* Began editing Renderer class;
* Ready 35% Main method();

SB 0.987:
* Changed realisation Shot() method for reusing;
* Created new Point[,] massive for view player's action;
* Added many comments;
* Ready 40% Main method().

SB 0.99:
* Ready 90% Main method().

SB 0.991:
* Added render methods in AIShot() and GetPlayerInput();
* Changed realisation of overloaded CoordinatesToPoint() method.

SB 0.992:
* Fixed problem with zero valuses;
* Fixed problem with "10" input;
* Added Thread.Sleep() for comfortable game.

SB 0.993:
* Fixed bug with not correct reading input in CoordinatesToPoint(string[] playeranswers).

SB 0.994 "AI CAN GOOD SHOOT":
* Changed and extended system for simulation of AI's knowledge about ships status;
* Added comments for more readable code.

SB 0.995 "1-deck ships - good ships":
* Ready algorithm for creating 1-deck ships;
* Began creating algorithm for creating 2-deck ships.

SB 0.996 "Half 2-deck ships == 1-deck ship => false":
* Ready 50% algorithm for creating 2-deck ships.

SB 0.997 "Аll ingenious is simple":
* Deleted algoritgm for creating ships for new more simply realisation.
