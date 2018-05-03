using GradeBook.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace GradeBook.GradeBooks
{
    public class RankedGradeBook : BaseGradeBook
    {
        public RankedGradeBook(string name) : base(name)
        {
            Type = GradeBookType.Ranked;
        }

        public override char GetLetterGrade(double averageGrade)
        {
            double[] avgGrades = new double[Students.Count];

            for (int i = 0; i < Students.Count; i++)
            {
                avgGrades[i] = Students[i].AverageGrade;
            }

            Array.Sort(avgGrades);
                
            if (Students.Count < 5)
            {
               // throw new InvalidOperationException("Ranked grading requires at least five students.");
            }
            else if (averageGrade >= avgGrades[Students.Count / 5 * 4])
            {
                return 'A';
            }
            else if (averageGrade >= avgGrades[Students.Count / 5 * 3])
            {
                return 'B';
            }
            else if (averageGrade >= avgGrades[Students.Count / 5 * 2])
            {
                return 'C';
            }
            else if (averageGrade >= avgGrades[Students.Count / 5])
            {
                return 'D';
            }

            return 'F';
        }

        public override void CalculateStatistics()
        {
            if (Students.Count < 5)
            {
                Console.WriteLine("Ranked grading requires at least 5 students with grades in order to properly calculate a student's overall grade.");
                return;
            }

            base.CalculateStatistics();
        }

    }
}
