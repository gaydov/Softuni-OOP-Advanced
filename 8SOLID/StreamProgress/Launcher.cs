using System;
using StreamProgress.Interfaces;
using StreamProgress.Models;

namespace StreamProgress
{
    public class Launcher
    {
        public static void Main()
        {
            IStreamable txtFile = new File("report.txt", 240, 16);
            IStreamable mp3File = new Music("Elvis", "Promised land", 3800, 48);
            StreamProgressInfo txtFileInfo = new StreamProgressInfo(txtFile);
            StreamProgressInfo musicFileInfo = new StreamProgressInfo(mp3File);

            Console.WriteLine(txtFileInfo.CalculateCurrentPercent());
            Console.WriteLine(musicFileInfo.CalculateCurrentPercent());
        }
    }
}
