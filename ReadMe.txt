# LogToDB
# version: Feb 2021
# author : Michal Zaczek
# .exe location .\bin\Debug

DESCRIPTION
Program takes input json file representing event logs. The json data is deserialized and exported to LogEntries.db LiteDB database.
File input is realized with a filestream. Data is loaded and processed line by line to allow support of large input files.
Code is structured to follow Object Oriented programming principle. 

USAGE
To run the program execute LogToDb.exe <path_to_input_json_file>

For instance:
C:\Temp\LogToDB.exe C:\Temp\input.json

RESULT
Database written to .\LogEntries.db