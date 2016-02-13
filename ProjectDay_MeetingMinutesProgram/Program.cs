using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ProjectDay_MeetingMinutesProgram
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, string> teamMembers = new Dictionary<string, string>();
            teamMembers.Add("Marcus Motherlover", "Administration");
            teamMembers.Add("Herby Trustingham", "Spelling");
            teamMembers.Add("Sugarpie McGee", "Administration");
            teamMembers.Add("Marco Rubio", "Bullshit");
            teamMembers.Add("Carly Fiorina", "Bullshit");
            teamMembers.Add("Helpy Yelperson","Spelling");
            teamMembers.Add("Trash Leggity", "Administration");
            teamMembers.Add("Jorp Plastic", "Spelling");
            teamMembers.Add("Marpy Winkelman", "Bullshit");

            int rerun = 0;
            do
            {
                DisplayMenu();
                string menuInput = Console.ReadLine();
                switch (menuInput)
                {
                    case "1":
                        CreateNewMeeting();
                        rerun=1;                       
                        break;
                    case "2":
                        ViewByTeam(teamMembers);
                        rerun = 1;
                        break;
                    case "3":
                        Console.Clear();
                        Console.WriteLine("\n\n\n\n\n\n{0,50}\n\n\n\n\n\n\n", "GOODBYE!");
                        return;
                    default:
                        rerun=1;
                        Console.WriteLine("Not a valid choice. \nPlease enter the number corresponding to the menu option you have selected.");
                        Console.ReadKey();
                        break;
                }
            }
            while (rerun == 1);          
        }
        static void DisplayMenu()
        {
            Console.Clear();
            Console.WriteLine("------------MEETING MINUTES NOTES-------------\n");
            Console.WriteLine("Choose an option from the Main Menu by number: \n");
            Console.WriteLine("MAIN MENU");
            Console.WriteLine("---------");
            Console.WriteLine("1. Create Meeting");
            Console.WriteLine("2. View Team");
            Console.WriteLine("3. Exit");
        }
        static void ViewByTeam(Dictionary<string, string> teamMembers)
        {
            Console.Clear();
            List<string> teamsList = new List<string>(teamMembers.Values.Distinct());
            //Write teams to console
            int counter = 0;
            foreach (string item in teamsList)
            {
                counter++;
                Console.WriteLine(counter + ". " + item);
            }
            counter++;
            Console.WriteLine(counter +". All Company Members");
            //User input: select team
            Console.WriteLine("Which team would you like to view?");
            string input = Console.ReadLine();
            //Convert user input for use as integer in switch case
            Int16 teamSelected = Convert.ToInt16(input);           
            switch (input)
            {
                case "1":
                case "2":
                case "3":
                    Console.Clear();
                    Console.WriteLine("{0} Team\n", teamsList[teamSelected - 1].ToString());
                    foreach (KeyValuePair<string, string> pair in teamMembers)
                    {
                        if (pair.Value == teamsList[teamSelected - 1].ToString())
                        {
                            Console.WriteLine(pair.Key);
                        }
                    }
                    break;
                case "4":
                    Console.Clear();
                    Console.WriteLine("All Team Members\n");
                    foreach (KeyValuePair<string,string> pair in teamMembers)
                    {
                        Console.WriteLine("{0,-20}  ({1})",pair.Key,pair.Value);
                    }
                    break;

                default: //any input other than a digit...
                    {
                        Console.Clear();
                        Console.WriteLine("Choose a number from the list.\n");
                        ViewByTeam(teamMembers); //restart method
                        break;
                    }
            }
            Console.ReadKey();
            return;
        }
        static List<string> TopicNotes()
        {
            List<string> notes = new List<string>();
            bool addNew = true;
            do
            {
                Console.Clear();
                Console.WriteLine("Topic: ");
                string topic = Console.ReadLine();
                notes.Add("\nTOPIC: " + topic);
                notes.Add("\n");
                notes.Add("NOTES:");
                Console.WriteLine("Write your notes: ");
                while (true)
                {
                    string line = Console.ReadLine();
                    if (line == "")
                        break;

                    notes.Add(line);
                }
                while (true)
                {
                    Console.WriteLine("Would you like to enter notes on another topic? (Enter Y/N): ");
                    string input = Console.ReadLine().ToLower();

                    if (input == "n")
                    {
                        addNew = false;
                        break;
                    }
                    else if (input=="y")
                    {
                        addNew = true;
                        notes.Add("\n");
                        break;
                    }                   
                }             
            }
            while (addNew==true);
            return notes;  
        }
        
        static string MeetingType()
        {
            List<string> meetingTypes = new List<string>() { "Dictionary Entries", "Word Problems", "Word Sorting", "General Word Issue", "New Word Announcement", "Special Topic" };
            Console.WriteLine("MEETING TYPES:");
            for (int i = 0; i < meetingTypes.Count; i++)
            {
                Console.Write((i + 1) + ". "); Console.WriteLine(meetingTypes[i]);
            }
            string input = Console.ReadLine();
            string meetingChoice = "";
            switch (input)
            {

                case "1":
                    meetingChoice = "Dictionary Entries";
                    break;
               case "2":
                    meetingChoice = "Word Problems";
                    break;
                case "3":
                    meetingChoice = "Word Sorting";
                    break;
                case "4":
                    meetingChoice = "General Word Issue";
                    break;
                case "5":
                    meetingChoice = "New Word Announcement";
                    break;
                case "6":
                    meetingChoice = "Special Topic";
                    break;
                default:
                    Console.WriteLine("Enter a number from the menu");
                    MeetingType();
                    break;
            }
          
            return meetingChoice;            
        }
        
        static void CreateNewMeeting()
        {
            Console.Clear();
            Console.WriteLine("Enter Date (MMDDYYY)");
            string meetingDate = Console.ReadLine();
            Console.WriteLine("Who is recording meeting (first last)");
            string meetingRecorder = Console.ReadLine();
            Console.WriteLine("Who is leading the meeting: (first last)");
            string meetingLeader = Console.ReadLine();

            Console.WriteLine("Choose a meeting type:");

            string meetingType=MeetingType();

            List<string> notes = new List<string>(TopicNotes());
            

            string fileName = @"MeetingMinutes" + meetingDate + ".txt";
            StreamWriter sw = new StreamWriter(fileName);

            using (sw)
            {
                sw.WriteLine("Words, Inc");
                sw.WriteLine("One-Two-Three Dictionary Dr.");
                sw.WriteLine("Morewords Falls, OH FourFourOneOneEight");
                sw.WriteLine("-------------------------------------");
                sw.WriteLine("MEETING MINUTES");
                sw.WriteLine("-------------------------------------");

                sw.WriteLine("Meeting Type: " + meetingType);
                sw.WriteLine("Meeting leader: " + meetingLeader);
                sw.WriteLine("Meeting Recorded by: " + meetingRecorder);
                sw.WriteLine("Date: " + meetingDate);
                sw.WriteLine("\n\n");

                
                foreach(string note in notes)
                {
                    if (note == "")
                        sw.WriteLine("\n");
                    sw.WriteLine(note);
                }                      
            }
            Console.Clear();
            Console.WriteLine("Here is a copy of today's Words INC. Meeting Minutes: \n");
            StreamReader sr = new StreamReader(fileName);
            using (sr)
            {
                Console.WriteLine(sr.ReadToEnd()); 
            }
            Console.ReadKey();
            
        }
    }
}
