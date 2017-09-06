using System;
using System.Collections.Generic;
using BashSoft.Contracts;
using BashSoft.StaticData;

namespace BashSoft.Repository
{
    public class RepositoryFilter : IDataFilter
    {
        public void FilterAndTake(IDictionary<string, double> studentsWithMarks, string wantedFilter, int studentsToTake)
        {
            if (wantedFilter.Equals("excellent"))
            {
                this.FilterAndTake(studentsWithMarks, x => x >= 5.00, studentsToTake);
            }
            else if (wantedFilter.Equals("average"))
            {
                this.FilterAndTake(studentsWithMarks, x => x >= 3.5 && x < 5.00, studentsToTake);
            }
            else if (wantedFilter.Equals("poor"))
            {
                this.FilterAndTake(studentsWithMarks, x => x < 3.50, studentsToTake);
            }
            else
            {
                throw new ArgumentException(ExceptionMessages.InvalidStudentFilter);
            }
        }

        private void FilterAndTake(IDictionary<string, double> studentsWithMarks, Predicate<double> givenFilter, int studentsToTake)
        {
            int countedForPrinted = 0;

            foreach (KeyValuePair<string, double> studentMark in studentsWithMarks)
            {
                if (countedForPrinted == studentsToTake)
                {
                    break;
                }

                if (givenFilter(studentMark.Value))
                {
                    OutputWriter.PrintStudent(new KeyValuePair<string, double>(studentMark.Key, studentMark.Value));
                    countedForPrinted++;
                }
            }
        }

        private double Average(IList<int> scoresOnTasks)
        {
            double totalScore = 0;
            foreach (int score in scoresOnTasks)
            {
                totalScore += score;
            }

            double percentageOfAll = totalScore / (scoresOnTasks.Count * 100);
            double mark = (percentageOfAll * 4) + 2;

            return mark;
        }
    }
}
