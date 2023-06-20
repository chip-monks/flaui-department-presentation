namespace Application.Tests
{
    using System;
    using System.Drawing;
    using System.Threading.Tasks;

    using FlaUI.Core.AutomationElements;
    using FlaUI.UIA3;

    using Xunit;

    /// <summary>
    /// Test they verify the application behavior.
    /// </summary>
    public class ApplicationScenarioTests
    {
        /// <summary>
        /// Tests if the user clicks the "Open Door" button, text hello world is displayed on the screen. 
        /// </summary>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        [Fact]
        public async Task Button_Clicked_HelloWorldTextDisplayed()
        {
            var app = FlaUI.Core.Application.Launch("Application.exe");
            using (var automation = new UIA3Automation())
            {
                var window = app.GetMainWindow(automation);
                Assert.Equal("FlaUI - Demo", window.Title);

                var doorButton = window.FindFirstDescendant(cf => cf.ByAutomationId("DoorToTheWorld")).AsButton();

                await Task.Delay(TimeSpan.FromSeconds(10));
                doorButton.Click();

                var userInfoLabel = window.FindFirstDescendant("UserInfoLabel").AsLabel();
                
                Assert.Equal("Hello World!", userInfoLabel.Text);
            }

            await Task.Delay(TimeSpan.FromSeconds(10));
            app.Close();
        }
    }
}