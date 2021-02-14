# LogToDB
# version: Feb 2021

DESCRIPTION
Program takes for input a json file that contains event logs. The json is deserialized and exported to LiteDB database.
File input is realized with a filestream. Data is loaded and processed line by line to allow support of large input files.
Program code is structured to follow Object Oriented programming principle. 

USAGE
To run the program, execute LogToDb.exe <path_to_input_json_file>

For instance:
C:\Temp\LogToDb.exe C:\Temp\input.json

RESULT
Database written to .\LogEntries.db

LOGGING
Program opeartions are logged to .\LogToDb.log
Events related to file and database operations are logged.
The input objects that failed to be exported to database are listed in the log as well.
