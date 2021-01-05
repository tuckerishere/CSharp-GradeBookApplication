using GradeBook.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GradeBook.GradeBooks
{
    public class RankedGradeBook : BaseGradeBook
    {
        public GradeBookType Type { get; set; }
        public RankedGradeBook(string name) : base(name)
        {
            Type = GradeBookType.Ranked;
        }
        public override char GetLetterGrade(double averageGrade)
        {
            if (Students.Count < 5)
            {
                throw new InvalidOperationException();
            }

            var percentageOfClass = (int)Math.Ceiling(Students.Count * 0.2);
            var grades = Students.OrderByDescending(score => score.AverageGrade).Select(score => score.AverageGrade).ToList();

            if(averageGrade >= grades[percentageOfClass - 1])
            {
                return 'A';
            }
            if (averageGrade >= grades[(percentageOfClass * 2) - 1])
            {
                return 'B';
            }
            if(averageGrade >= grades[(percentageOfClass * 3) - 1])
            {
                return 'C';
            }
            if(averageGrade >= grades[(percentageOfClass * 4) - 1])
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
        public override void CalculateStudentStatistics(string name)
        {
            if(Students.Count < 5)
            {
                Console.WriteLine("Ranked Grading requires at least 5 students with grades in order to properly calculate a student's overall grade.");
                return;
            }
            base.CalculateStudentStatistics(name);
        }   
        
    }
   
}
