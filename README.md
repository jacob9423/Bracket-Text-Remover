# Bracket-Text-Remover
Bracket Text Remover is a simple comannd line tool that removes the brakets and text inside those brackets  
  
EX: `[Something]Hello.txt` would turn into `Hello.txt`  
  
It accepts 3 command line args  
  
1. PATH - Just the path to the file EX: `BracketTextRemover /home/user/Documents/`
2. PWD - Will use the current directory the terminal is in EX: `BracketTextRemover PWD`
3. ?, help, man, and actully anything else will bring up the help page
  
To install run `dotnet tool install -g BracketTextRemover`
