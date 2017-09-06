using System;
using System.Collections.Generic;
using System.Linq;
using BashSoft.Contracts;
using BashSoft.StaticData;

namespace BashSoft.Repository
{
    public class RepositorySorter : IDataSorter
    {
        public void OrderAndTake(IDictionary<string, double> studentsMarks, string comparison, int studentsToTake)
        {
            comparison = comparison.ToLower();

            if (comparison.Equals("ascending"))
            {
                this.PrintStudents(studentsMarks
                    .OrderBy(x => x.Value)
                    .Take(studentsToTake)
                    .ToDictionary(pair => pair.Key, pair => pair.Value));
            }
            else if (comparison.Equals("descending"))
            {
                this.PrintStudents(studentsMarks
                    .OrderByDescending(x => x.Value)
                    .Take(studentsToTake)
                    .ToDictionary(pair => pair.Key, pair => pair.Value));
            }
            else
            {
                throw new ArgumentException(ExceptionMessages.InvalidComparisonQuery);
            }
        }

        private void PrintStudents(IDictionary<string, double> studentsSorted)
        {
            foreach (KeyValuePair<string, double> student in studentsSorted)
            {
                OutputWriter.PrintStudent(student);
            }
        }
    }
}
