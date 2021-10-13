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
        public void GivenNullMoodMessage_WhenAnalyseMood_ShouldReturnHAPPY()
        {
            MoodAnalyser moodAnalyser = new MoodAnalyser("");
            string result = moodAnalyser.AnalyseMood();
            Assert.AreEqual("HAPPY", result);
        }
    }
}