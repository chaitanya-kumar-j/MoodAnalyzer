using NUnit.Framework;
using MoodAnalyzer;

namespace MoodAnalyzerTestCases
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void GivenSadMoodMessage_WhenAnalyseMood_ShouldReturnSAD()
        {
            MoodAnalyser moodAnalyser = new MoodAnalyser("I am in Sad Mood.");
            string result = moodAnalyser.AnalyseMood();
            Assert.AreEqual("SAD",result);
        }
        [Test]
        public void GivenAnyMoodMessage_WhenAnalyseMood_ShouldReturnHAPPY()
        {
            MoodAnalyser moodAnalyser = new MoodAnalyser("I am in Any Mood.");
            string result = moodAnalyser.AnalyseMood();
            Assert.AreEqual("HAPPY", result);
        }
        [Test]
        public void GivenNullorEmptyMoodMessage_WhenAnalyseMood_ShouldReturnCustomException()
        {
            MoodAnalyser moodAnalyser = new MoodAnalyser(null);
            // Assert.AreEqual("HAPPY", moodAnalyser.AnalyseMood());
            try
            {
                string result = moodAnalyser.AnalyseMood();
                Assert.AreEqual("HAPPY", result);
            }
            catch (CustomExceptions ex)
            {
                Assert.AreEqual(ex.Message, "Null message passed.");
            }
        }
        [Test]
        public void GivenMoodAnalyserClassName_WhenCreateMoodAnalyserObject_ShouldReturnMoodAnalyserObject()
        {
            object expected = new MoodAnalyser();
            object result = MoodAnalyzerFactory.CreateMoodAnalyser("MoodAnalyzer.MoodAnalyser", "MoodAnalyser");
            expected.Equals(result);
        }
        [Test]
        public void GivenWrongClassName_WhenCreateMoodAnalyserObject_ShouldThrowException()
        {
            string expected = "No such class found";
            try
            {
                object obj = MoodAnalyzerFactory.CreateMoodAnalyser("MoodAnalyserProject.MoodAnalyzer", "MoodAnalyzer");
            }
            catch (CustomExceptions ex)
            {
                Assert.AreEqual(expected, ex.Message);
            }

        }
        [Test]
        public void GivenClassConstructerNotProper_WhenCreateMoodAnalyserObject_ShouldThrowException()
        {
            string expected = "No such Constructor found";
            try
            {
                object obj = MoodAnalyzerFactory.CreateMoodAnalyser("MoodAnalyserProject.MoodAnalyze", "MoodAnalyzer");
            }
            catch (CustomExceptions ex)
            {
                Assert.AreEqual(expected, ex.Message);
            }
        }
        [Test]
        public void GivenMoodAnalyser_WhenParameterizedConstructor_ShouldReturnMoodAnalyserObject()
        {
            object expected = new MoodAnalyser("Happy");
            object actual = MoodAnalyzerFactory.ParameterizedConstructor("MoodAnalyzerProject.MoodAnalyze", "MoodAnalyze", "Happy");
            expected.Equals(actual);
        }

        [Test]

        public void GivenMoodAnalyserWrongClassName_WhenParameterizedConstructor_ShouldThrowMoodAnalysisException()
        {
            string expected = "No such class found";
            try
            {
                object actual = MoodAnalyzerFactory.ParameterizedConstructor("MoodAnalyzerProject.MoodAnalyzer", "MoodAnalyzer", "Happy");
            }
            catch (CustomExceptions ex)
            {
                Assert.AreEqual(expected, ex.Message);
            }
        }

        [Test]

        public void GivenMoodAnalyserClassNameWithNoProperConstructor_WhenParameterizedConstructor_ShouldThrowMoodAnalysisException()
        {
            string expected = "No such Constructor found";
            try
            {
                object actual = MoodAnalyzerFactory.ParameterizedConstructor("MoodAnalyzerProject.MoodAnalyze", "MoodAnalyzer", "I am happy");
            }
            catch (CustomExceptions ex)
            {
                Assert.AreEqual(expected, ex.Message);
            }
        }
    }
}