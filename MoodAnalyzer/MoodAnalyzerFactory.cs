using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;

namespace MoodAnalyzer
{
    public class MoodAnalyzerFactory
    {
        private string moodMessage;
        public MoodAnalyzerFactory(string moodMessage)
        {
            this.moodMessage = moodMessage;
        }
        public static object CreateMoodAnalyser(string className, string constructorName)
        {
            string pattern = @"." + constructorName + "$";
            Match result = Regex.Match(className, pattern);
            if (result.Success)
            {
                try
                {

                    Assembly executing = Assembly.GetExecutingAssembly();
                    Type moodAnalyseType = executing.GetType(className);
                    return Activator.CreateInstance(moodAnalyseType);
                }
                catch (ArgumentNullException)
                {
                    throw new CustomExceptions(CustomExceptions.ExceptionType.NO_SUCH_CLASS, "No such class found");

                }
            }
            else
            {
                throw new CustomExceptions(CustomExceptions.ExceptionType.NO_SUCH_METHOD, "No such Constructor found");
            }
        }

    }
}
