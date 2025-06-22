# oop_pw1_ext_2425
This repository is the base element for the development of Practice 1 for the extraordinary OOP exam session. 
Cover
:
:

Table of contents
1. Introduction
2. Description
3. Class Diagram
4. Problem Faced
5. Conlcusion
6. How to Run

1. Introduction
   Robert Lucero Rodriguez
   This document presents a simulation of a train station that handles the arrival and docking of  passangers and freight trains over time. The simulations advances a tick (15 minutes) and manages different train platforms, this ensures that the docking is handled efficiently.

2. Description
   This project was develps using the object oriented concepts in C#. This simulation is composed of multiple interacting classes to represent trains, platforms, adn the station as a whole.
   
  Key Components:
  Train (abstract): Base class for all trains, with shared attributes like ID, status, arrival time, and type.
PassengerTrain / FreightTrain: Subclasses with additional fields (carriage count, capacity, max weight, freight type).
Platform: Represents a docking area.
Station: Controller that holds the list of platforms and trains. Manages simulation flow.
TrainLoader: Uses the CSV file and loads trains into the system.
Program.cs: Entry point as well as also containing the user interface (CLI).

Key Design Decisions
.Followed modular OOP structure similar to a previous aircraft project for consistency.
.We use try/Parse instead of custom error handler classes, as input complexity was lower that our other project.
.Display and simulation output designed for clarity and simplicity in a terminal.

3.  Class Diagram
![image](https://github.com/user-attachments/assets/a501de1b-23c8-44a2-89a5-68e2b20de5ff)
![image](https://github.com/user-attachments/assets/5ae7749d-627d-40f2-b684-1d8d7eee4f07)
![image](https://github.com/user-attachments/assets/39a55ffc-c082-478a-864c-26cd130ece70)




5. Problem Faced
. Manual input validation: Initially considered reusing eror handler classes but simplified using tryParse.
.Platform assignment logic. Ensured trains dont get  docked if no free platform is available.
Tick sistem: Ensure both platform and train status update syncrhonously every tick.

6. Conclusions
This project reinforced knowledge of:
Inheritance and polymorphism in C#
State based simulation design
File Input Output and exception hadling
Lessons learned include how to effectively structure a project to maximize efficiency.

6.How to Run
Run without debugging, When prompted say whatever real number for platforms, the choose option 1 to load the file train.csv (The path is in a comment junt in case), choose option 2 to start simulation and then after "playing with it" you can choose option 3 to view the current state of the system.

   


  
