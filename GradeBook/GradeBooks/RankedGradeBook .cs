using GradeBook.Enums;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace GradeBook.GradeBooks
{
    class RankedGradeBook : BaseGradeBook
    {
        public RankedGradeBook(string name, bool isWeighted) : base(name, isWeighted)
        {
            Type = GradeBookType.Ranked;
        }

        public override char GetLetterGrade(double averageGrade)
        {
            if(Students.Count >= 5)
            {
                List<double> grades = new List<double>();
                foreach (Student student in Students)
                {
                    grades.Add(student.AverageGrade);
                }
                grades.Sort();
                grades.Reverse();
                for (int x = 0; x < Students.Count; x++)
                {
                    if(x < Students.Count / 5)
                    {
                        return 'A';
                    }
                    else if (x < Students.Count * 2 / 5)
                    {
                        return 'B';
                    }
                    else if (x < Students.Count * 3 / 5)
                    {
                        return 'C';
                    }
                    else if (x < Students.Count * 4 / 5)
                    {
                        return 'D';
                    }
                    else
                    {
                        return 'F';
                    }
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
    }
}
