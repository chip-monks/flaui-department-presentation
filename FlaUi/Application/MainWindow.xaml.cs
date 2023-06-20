namespace Application
{
    using System.Windows;

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MainWindow"/> class.
        /// </summary>
        public MainWindow()
        {
            this.InitializeComponent();
        }

        /// <summary>
        /// Event handler that is raised, when the <see cref="DoorButton"/> is clicked.
        /// Updates text on <see cref="UserInfoLabel"/>.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="eventArgs">
        /// The event args.
        /// </param>
        private void OnDoorButtonClick(object sender, RoutedEventArgs eventArgs)
        {
            this.UserInfoLabel.Content = "Hello World!";
        }
    }
}