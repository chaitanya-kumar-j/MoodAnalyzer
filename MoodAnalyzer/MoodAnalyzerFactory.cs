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
        public static object ParameterizedConstructor(string className, string constructorName, string message)
        {
            Type type = Type.GetType(className);
            try
            {
                if (type.FullName.Equals(className) || type.Name.Equals(className))
                {
                    if (type.Name.Equals(constructorName))
                    {
                        ConstructorInfo info = type.GetConstructor(new[] { typeof(string) });
                        object instance = info.Invoke(new object[] { message });
                        return instance;
                    }
                    //if class and constructor name is not equal then it throws constructor not found exception
                    else
                    {
                        throw new CustomExceptions(CustomExceptions.ExceptionType.NO_SUCH_METHOD, "No such Constructor found");
                    }

                }
                //if class is not found then it throws class not found exception
                else
                {
                    throw new CustomExceptions(CustomExceptions.ExceptionType.NO_SUCH_CLASS, "No such class found");
                }
            }
            catch (Exception ex)
            {
                return ex;
            }
        }
    }
}
