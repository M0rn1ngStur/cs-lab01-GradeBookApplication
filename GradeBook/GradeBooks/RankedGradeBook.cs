using GradeBook.Enums;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GradeBook.GradeBooks
{
    public class RankedGradeBook : BaseGradeBook
    {
        public RankedGradeBook(string name, bool isWeighted) : base(name, isWeighted)
        {
            Type = GradeBookType.Ranked;
        }

        public override char GetLetterGrade(double averageGrade)
        {
            if(Students.Count >= 5)
            {
                Dictionary<string, double> partGrades = new Dictionary<string, double>();

                List<double> allGrades = new List<double>();
                partGrades["p1"] = 0;
                partGrades["p2"] = 0;
                partGrades["p3"] = 0;
                partGrades["p4"] = 0;
                foreach (Student student in Students)
                {
                    allGrades.Add(student.AverageGrade);
                }
                allGrades.Sort();
                allGrades.Reverse();
                List<double> temp = new List<double>();
                for (int x = 0; x < allGrades.Count; x++)
                {
                    if (x < allGrades.Count / 5)
                    {
                        temp.Add(allGrades[x]);
                    }
                    else if (x < allGrades.Count * 2 / 5)
                    {
                        if (partGrades["p1"] == 0)
                        {
                            partGrades["p1"] = temp.Min();
                            temp.Clear();
                        }
                        temp.Add(allGrades[x]);
                    }
                    else if (x < allGrades.Count * 3 / 5)
                    {
                        if (partGrades["p2"] == 0)
                        {
                            partGrades["p2"] = temp.Min();
                            temp.Clear();
                        }
                        temp.Add(allGrades[x]);
                    }
                    else if (x < allGrades.Count * 4 / 5)
                    {
                        if (partGrades["p3"] == 0)
                        {
                            partGrades["p3"] = temp.Min();
                            temp.Clear();
                        }
                        temp.Add(allGrades[x]);
                    }
                    else
                    {
                        if (partGrades["p4"] == 0)
                        {
                            partGrades["p4"] = temp.Min();
                            temp.Clear();
                        }
                        break;
                    }
                }
                
                if(averageGrade >= partGrades["p1"])
                {
                    return 'A';
                }
                else if (averageGrade >= partGrades["p2"])
                {
                    return 'B';
                }
                else if (averageGrade >= partGrades["p3"])
                {
                    return 'C';
                }
                else if (averageGrade >= partGrades["p4"])
                {
                    return 'D';
                } 
                else
                {
                    return 'F';
                }
            }
            throw new InvalidOperationException();
        }

        public override void CalculateStatistics()
        {
            if (Students.Count < 5)
            {
                Console.WriteLine("Ranked grading requires at least 5 students.");
            } 
            else
            {
                base.CalculateStatistics();
            }
        }
        public override void CalculateStudentStatistics(string name)
        {
            if (Students.Count < 5)
            {
                Console.WriteLine("Ranked grading requires at least 5 students.");
            }
            else
            {
                base.CalculateStudentStatistics(name);
            }
        }
    }
}
