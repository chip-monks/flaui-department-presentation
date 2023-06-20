namespace Application.Tests
{
    using System;
    using System.Threading.Tasks;

    using FlaUI.Core.AutomationElements;
    using FlaUI.Core.Input;
    using FlaUI.UIA3;

    using Xunit;

    /// <summary>
    /// This class shows a example that the FalUI framework is not only useful to do coded ui testing, you can also use it to automate clicking jobs in other applications.
    /// </summary>
    public class WindowsCalculatorAutomation
    {
        /// <summary>
        /// Tests that the windows calculator, calculates 4+4 = 8;
        /// </summary>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        /// <remarks>Runs since Windows 8. Previous windows versions does not provide the calculator via Microsoft App Store.</remarks>
        [Fact]
        public async Task Calculator_FourAddFour_Eight()
        {
            var app = FlaUI.Core.Application.LaunchStoreApp("Microsoft.WindowsCalculator_8wekyb3d8bbwe!App");
            using (var automation = new UIA3Automation())
            {
                var window = app.GetMainWindow(automation);

                var fourButton = window.FindFirstDescendant(cf => cf.ByAutomationId("num4Button")).AsButton();
                var plusButton = window.FindFirstDescendant(cf => cf.ByAutomationId("plusButton")).AsButton();
                var equalButton = window.FindFirstDescendant(cf => cf.ByAutomationId("equalButton")).AsButton();

                fourButton.Click();
                plusButton.Click();
                fourButton.Click();
                equalButton.Click();

                Wait.UntilInputIsProcessed();
            }

            await Task.Delay(TimeSpan.FromSeconds(10));
            app.Close();
        }
    }
}