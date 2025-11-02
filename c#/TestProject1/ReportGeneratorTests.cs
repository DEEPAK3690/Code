using Xunit;
using SRP;
using Moq;


namespace TestProject1
{
    // Component Access Modifier Notes
    //Test Class  public Required for xUnit to detect it
    //Test Method public Required for xUnit to run it
    //Application Class   internal or public Use InternalsVisibleTo for internal
    //Application Method  internal or public Private methods should be tested indirectly
    public class ReportGeneratorTests // should be public class
    {
        [Fact] // Marks this as a test method
        public void Test1() // should be public and can also be static
        {
            //arrange
            ReportGenerator generator = new ReportGenerator();

            //act
            string report = generator.GenerateReport("Report content");

            //assert
            Assert.Equal("Report: Report content", report);
        }

        [Theory]//The [Theory] attribute allows testing with multiple sets of data.        Reduces redundant test methods.
        [InlineData("Report content", "Report: Report content")]
        [InlineData("Report content 2", "Report: Report content 2")]
        public void Test2(string content, string expected)
        {
            //arrange
            ReportGenerator generator = new ReportGenerator();

            //act
            string report = generator.GenerateReport(content);

            //assert
            Assert.Equal(expected, report);
        }
    }

}