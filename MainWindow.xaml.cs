using System;
using System.Windows;
using System.Windows.Media.Imaging;

namespace StoryGameApp
{
    public partial class MainWindow : Window
    {
        private int currentSlideIndex = 0;

        // Structured safety data matrices representing the slides
        private readonly string[] phaseHeaders = { "PHASE: INITIAL INSPECTION", "PHASE: POWER ON & CALIBRATION", "PHASE: FIELD PROCEDURE TEST" };
        private readonly string[] stepCounters = { "( 1 / 3 )", "( 2 / 3 )", "( 3 / 3 )" };
        private readonly string[] slideTitles = { "Pre-Operation External Inspection", "System Initialization & Calibration", "Live Field Mock Procedures" };

        private readonly string[] slideTexts = {
            "Walk around the perimeter of the machinery. Check for any loose fluid seals, clear external structural fractures, debris entry in ventilation channels, or ungrounded wiring.\n\nDepress the primary breaker switch to run internal power diagnostics. Confirm that visual output monitors display zero calibration thresholds within normal bounds before ignition.\n\nRun operational system cycles under safe simulated environments. Confirm mechanical telemetry responsiveness, hydraulic pressure cutoffs, and emergency stop triggers.",
            "Initiate the secure power sequence and synchronize on-board diagnostic sensors:\n\n• Clear the master ignition switch area and ensure the Emergency Stop (E-Stop) is functional.\n• Turn the primary breaker to ON and allow the central control unit to complete boot diagnostics.\n• Execute the sensor calibration routine via the control interface panel.\n• Verify telemetry baselines match safe environmental and equipment tolerances before moving forward.",
            "Conduct a controlled, functional live operational run-through:\n\n• Announce operational testing over local radio frequencies to clear field personnel.\n• Engage low-speed operational movements to confirm steering, braking, and load handling.\n• Monitor real-time status indicators on the telemetry console for unexpected temperature or pressure spikes.\n• Document successfully completed safety run criteria or halt operations if any variance occurs."
        };

        private readonly string[] imagePaths = { "Assets/Images/inspection.png", "Assets/Images/calibration.png", "Assets/Images/fieldtest.png" };

        private readonly string[] accessibilityDescriptions = {
            "Diagram showing external machinery walkthrough check vectors including fluid points and chassis safety indicators.",
            "Schematic mapping data calibration dashboards displaying parameter safety ranges and visual status indicators.",
            "Flowchart detailing simulation runtime loop, hydraulic limits, and highlighted manual emergency stop switch."
        };

        public MainWindow()
        {
            InitializeComponent();
            UpdateSlideDisplay();
        }

        private void UpdateSlideDisplay()
        {
            // Sync backend slide index safely with UI items
            PhaseTitle.Text = $"{phaseHeaders[currentSlideIndex]} - {slideTitles[currentSlideIndex]}";
            DescriptionText.Text = slideTexts[currentSlideIndex];
            TxtProgress.Text = $"Slide {stepCounters[currentSlideIndex]}";
            AccessibilityText.Text = $"Accessible Visual Description: {accessibilityDescriptions[currentSlideIndex]}";

            // Update Image Frame safely
            try
            {
                SlideImage.Source = new BitmapImage(new Uri(imagePaths[currentSlideIndex], UriKind.RelativeOrAbsolute));
            }
            catch (Exception)
            {
                SlideImage.Source = null;
            }

            // Update button navigation properties
            BtnPrevious.IsEnabled = currentSlideIndex > 0;

            if (currentSlideIndex == phaseHeaders.Length - 1)
            {
                BtnNext.Content = "FINISH";
                BtnNext.Background = System.Windows.Media.Brushes.DarkGreen;
            }
            else
            {
                BtnNext.Content = "NEXT ▶";
                BtnNext.Background = new System.Windows.Media.SolidColorBrush(System.Windows.Media.Color.FromRgb(0x25, 0x63, 0xEB));
            }
        }

        private void BtnPrevious_Click(object sender, RoutedEventArgs e)
        {
            if (currentSlideIndex > 0)
            {
                currentSlideIndex--;
                UpdateSlideDisplay();
            }
        }

        private void BtnNext_Click(object sender, RoutedEventArgs e)
        {
            if (currentSlideIndex < phaseHeaders.Length - 1)
            {
                currentSlideIndex++;
                UpdateSlideDisplay();
            }
            else
            {
                MessageBox.Show("Safety training slideshow completed! Ensure your pre-operational equipment verification steps are checked off.",
                                "Training Run Complete", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }
    }
}
