using StreamProgress.Interfaces;

namespace StreamProgress.Models
{
    public class StreamProgressInfo
    {
        private readonly IStreamable streamableFile;

        public StreamProgressInfo(IStreamable streamableFile)
        {
            this.streamableFile = streamableFile;
        }

        public int CalculateCurrentPercent()
        {
            return (this.streamableFile.BytesSent * 100) / this.streamableFile.Length;
        }
    }
}