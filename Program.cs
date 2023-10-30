using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Create_DB_Academy
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //List<string> list_names = ReadNamesFromFile();

            //List<string> list_surnames = ReadSurnamesFromFile();

            //CreateTeachersTable(list_names, list_surnames);

            //CreateTable_GroupsLectures();

            CreateTable_Schedules();

        }

        public static void CreateTable_Schedules()
        {
            Random rnd = new Random();
            string file_TableSchedules = "C:\\Users\\Maksim\\source\\repos\\Create_DB_Academy\\Table_Schedules.txt";
            int Weeks = 52;
            int DayOfWeek = 5;
            int Class = 3;
            int LectureRoom = 15;
            int LectureId = 1;
            int number = 0;

            using (StreamWriter writer = new StreamWriter(file_TableSchedules, true))
            {

                for (int i = 1; i <= Weeks; i++)
                {
                    for (int j = 1; j <= DayOfWeek; j++)
                    {
                        Class = rnd.Next(3) + 1; 
                        for (int k = 1; k <= Class; k++)
                        {
                            int[] numberOfLectureId = new int[15];
                            for (int m = 0; m <  numberOfLectureId.Length; m++)
                            {
                                number = rnd.Next(20) + 1;
                                for (int n = 0; n < m; n++)
                                {
                                    if (number == numberOfLectureId[n])
                                    {
                                        m--;
                                        continue;
                                    }
                                }
                                numberOfLectureId[m] = number;
                            }

                            for (int l = 1; l <= LectureRoom; l++)
                            {
                                LectureId = numberOfLectureId[l-1];
                                // INSERT INTO [TopAcademy].[dbo].[Schedules](Class, [DayOfWeek], [Week], LectureId, LectureRoomId) VALUES()
                                writer.WriteLine("INSERT INTO [TopAcademy].[dbo].[Schedules](Class, [DayOfWeek], [Week], LectureId, LectureRoomId) VALUES(" 
                                    + k + ", " + j + ", " + i + ", " + LectureId + ", " + l  + ")");

                            }
                        }
                    }
                }
            }

        }

        public static void CreateTable_GroupsLectures()
        {
            Random rnd = new Random();
            string file_groupsLectures = "C:\\Users\\Maksim\\source\\repos\\Create_DB_Academy\\table_GroupsLecturs_Completion.txt";
            using (StreamWriter writer = new StreamWriter(file_groupsLectures, true))
            {
                for (int GroupId = 1; GroupId <= 9; GroupId++)
                {
                    int firstLectureId = rnd.Next(10) + 1;
                    for (int LectureId = firstLectureId; LectureId <= firstLectureId + 10; LectureId++)
                    {
                        {
                            writer.WriteLine("INSERT INTO [TopAcademy].[dbo].[GroupsLectures](GroupId, LectureId) VALUES(" + GroupId + ", " + LectureId +")");

                        }
                    }
                }
            }
        }

        public static void CreateTeachersTable(List<string> list_names, List<string> list_surnames)
        {
            Random rnd = new Random();
            UnicodeEncoding unicode = new UnicodeEncoding();
            string teachers_table = "C:\\Users\\Maksim\\source\\repos\\Create_DB_Academy\\teachers_table.txt";
            using (StreamWriter writer = new StreamWriter(teachers_table, true, unicode))
            {
                for (int i = 0; i < 20; i++)
                {
                    //INSERT INTO [Academy].[dbo].[Curators]([Name], Surname) VALUES('Александр', 'Суворов')

                    writer.WriteLine("INSERT INTO [TopAcademy].[dbo].[Teachers]([Name], Surname) VALUES('" + 
                        list_names[rnd.Next(list_names.Count - 1)] + "', '" + list_surnames[rnd.Next(list_surnames.Count - 1)] + "')");

                }
            }
        }

        public static List<string> ReadSurnamesFromFile()
        {
            List<string> list_surnames = new List<string>();
            string surnames_file_path = "C:\\Users\\Maksim\\source\\repos\\Create_DB_Academy\\russian_surnames_Unicode.csv";
            UnicodeEncoding unicode = new UnicodeEncoding();
            using (StreamReader reader = new StreamReader(surnames_file_path, unicode))
            {
                bool first = true;
                while (!reader.EndOfStream)
                {

                    string s = reader.ReadLine();
                    if (first)
                    {
                        first = false;
                        continue;
                    }
                    int index_1 = 0;
                    int index_2 = 0;
                    bool exit = false;
                    for (int i = 0; i < s.Length; i++)
                    {
                        if (s[i] == ';')
                        {
                            index_1 = i;
                            for (int j = index_1 + 1; j < s.Length; j++)
                            {
                                if (s[j] == ';')
                                {
                                    index_2 = j;
                                    exit = true;
                                    break;
                                }
                            }
                        }
                        if (exit) break;
                    }
                    string name = s.Substring(index_1 + 1, index_2 - index_1 - 1);
                    list_surnames.Add(name);

                }

            }
            return list_surnames;
        }


        public static List<string> ReadNamesFromFile()
        {
            string names_file_path = "C:\\Users\\Maksim\\source\\repos\\Create_DB_Academy\\russian_names_ANSI.csv";
            List<string> names = new List<string>();

            using (StreamReader reader = new StreamReader(names_file_path, Encoding.GetEncoding("windows-1251")))
            {
                bool first = true;
                while (!reader.EndOfStream)
                {

                    string s = reader.ReadLine();
                    if (first)
                    {
                        first = false;
                        continue;
                    }
                    int index_1 = 0;
                    int index_2 = 0;
                    bool exit = false;
                    for (int i = 0; i < s.Length; i++)
                    {
                        if (s[i] == ';')
                        {
                            index_1 = i;
                            for (int j = index_1 + 1; j < s.Length; j++)
                            {
                                if (s[j] == ';')
                                {
                                    index_2 = j;
                                    exit = true;
                                    break;
                                }
                            }
                        }
                        if (exit) break;
                    }
                    string name = s.Substring(index_1 + 1, index_2 - index_1 - 1);
                    names.Add(name);

                }

            }
            return names;
        }


        public static void Completion_by_groups()
        {
            Random rnd = new Random();

            string file_db = "C:\\Users\\Maksim\\source\\repos\\Create_DB_Academy\\file_db.txt";
            using (FileStream fstream = new FileStream(file_db, FileMode.OpenOrCreate, FileAccess.Write))
            {

            }

            int Id = 94;
            int firstIdInGroup;
            for (int GroupId = 10; GroupId <= 60; GroupId++)
            {
                int numberOfStudents = rnd.Next(11) + 5;
                int limit = numberOfStudents + Id;
                firstIdInGroup = Id;
                for (Id = firstIdInGroup; Id < limit; Id++)
                {
                    using (StreamWriter writer = new StreamWriter(file_db, true))
                    {
                        writer.WriteLine("INSERT INTO[Academy].[dbo].[Students](Id, GroupId) VALUES(" + Id + ", "+ GroupId + ")");
                    }
                }
                using (StreamWriter writer = new StreamWriter(file_db, true))
                {
                    writer.WriteLine("----------------------------------------------------------------------------------");
                }
            }
        }

    }
}
