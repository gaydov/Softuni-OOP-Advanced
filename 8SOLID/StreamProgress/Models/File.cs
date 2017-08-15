using StreamProgress.Interfaces;

namespace StreamProgress.Models
{
    public class File : IStreamable
    {
        private string name;

        public File(string name, int length, int bytesSent)
        {
            this.name = name;
            this.Length = length;
            this.BytesSent = bytesSent;
        }

        public int Length { get; }

        public int BytesSent { get; }
    }
}