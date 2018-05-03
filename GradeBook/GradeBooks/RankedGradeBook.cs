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
                throw new InvalidOperationException("Ranked grading requires at least five students.");
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





            /*else if (averageGrade >= Students[Students.Count / 5 * 4].AverageGrade)
            {
                return 'A';
            }
            else if (averageGrade >= Students[Students.Count / 5 * 3].AverageGrade)
            {
                return 'B';
            }
            else if (averageGrade >= Students[Students.Count / 5 * 2].AverageGrade)
            {
                return 'C';
            }
            else if (averageGrade >= Students[Students.Count / 5].AverageGrade)
            {
                return 'D';
            }*/

            return 'F';
        }

    }
}
