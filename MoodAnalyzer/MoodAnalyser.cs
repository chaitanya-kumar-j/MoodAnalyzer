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
        public string AnalyseMood()
        {
            try
            {
                if (moodMessage.ToLower().Contains("sad"))
                {
                    return "SAD";
                }
                else
                {
                    return "HAPPY";
                }
            }
            catch(NullReferenceException)
            {
                return "HAPPY";
            }
        }
    }
}
