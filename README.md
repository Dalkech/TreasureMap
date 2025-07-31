
# TreasureMap

## Inputs and outputs 
Input file is in **ConsoleApp/TreasureMap.Input.txt**.

Output file is in **ConsoleApp/TreasureMap.Output.txt**

## Onion Architecture

The project try to follow the Onion architecture principle.
Separating the differents layers from businness layer.
Offering modularity to the application.

- **ConsoleApp** is the client. Regrouping all kind of parsing and DTO conversion code.
- **Application** Contains the use cases. depending TreasureMap.
- **TreasureMap** is the business, isolated from the other layer
- **Architecture** or Data Lyaer is missing, because we do not save any state in thirdPart data storage service
## Test 

Each Layer is tasted.
With Unit and a UAT Scenario.
