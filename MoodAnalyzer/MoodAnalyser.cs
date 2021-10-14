using System;
using System.Collections.Generic;
using System.Text;

namespace MoodAnalyzer
{
    public class MoodAnalyser
    {
        private string moodMessage;
        public MoodAnalyser(string moodMessage)
        {
            this.moodMessage = moodMessage;
        }
        public MoodAnalyser()
        {

        }
        public string AnalyseMood()
        {
            try
            {
                if (this.moodMessage.Equals(string.Empty))
                {
                    throw new CustomExceptions(CustomExceptions.ExceptionType.EMPTY_MOOD, "Empty message passed.");
                }
                if (this.moodMessage.ToLower().Contains("sad"))
                {
                    return "SAD";
                }
                return "HAPPY";
            }
            catch(NullReferenceException)
            {
                // throw new CustomExceptions(CustomExceptions.ExceptionType.NULL_MOOD, "Null message passed.");
                return "HAPPY";
            }
        }
    }
}
