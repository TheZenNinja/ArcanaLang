- # Concept
	- A functional programming language that has a magical flair

# Important Ideas
 - Has two separate syntax denotated by file extensions
	 - Standard (no magical keywords)
	 - Arcane (magical keywords)
- Also have a way to render out to a magical diagram

# Technical Notes
- program it in lua
	- either convert to lua or compile it to binary?
- ## Syntax
	- ### Variables
		- `let`: static var
		- `var`: dynamic variable
	- ### Functions
		- starts with `func` keyword
		- ends with `return null` 
			- if its at the end of a function, it will auto `return null`
	- ### Imports
		- Have a `std` library for cmd line and useful programming
			- reading files
			- console input/output
		- have a `arc` library for making spells for games
			- contains data types for 
				- `entity`
				- `position`
				- `element`
				- etc
- ## Syntactic Sugar
	- shorthand function syntax for single line length functions
# Diagram Ideas
- ### Functions
	- represented as a circle
	- line connects to where its called
- ## Variable Representation
	- unique icons for each datatype
	- lines connecting to where its used
	- ### Numbers
		- #### Byte
			- represented as a 3x3 grid of dots/squares
			- ??? center dot/color represents if its positive or negative? (signed/unsigned number)
			- the circle of 8 dots are binary representation of the number
		- #### Float/Int
			- only 64 bit numbers
			- represented by an 8x8 grid
			- ??? if its positive/negative it changes color/icon?

# Other Ideas
- Create a custom language server
- Create a custom VSCode plugin

- [ ] custom obsidian plugin that turns a `- ?` into  a question mark bullet point