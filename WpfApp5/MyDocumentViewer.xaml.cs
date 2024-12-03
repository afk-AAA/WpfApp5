using System.Windows;
using System.Windows.Documents;
using System.Windows.Media;

namespace WpfApp5
{
    /// <summary>
    /// MyDocumentViewer.xaml 的互動邏輯
    /// </summary>
    public partial class MyDocumentViewer : Window
    {
        Color fontColor = Colors.Black;
        public MyDocumentViewer()
        {
            InitializeComponent ();
            fontColorPicker.SelectedColor = fontColor;

            foreach (FontFamily fontFamily in Fonts.SystemFontFamilies)
            {
                fontFamilyComboBox.Items.Add (fontFamily.Source);
            }
            fontFamilyComboBox.SelectedIndex = 13;

            fontSizeComboBox.ItemsSource = new List<double>() {8,9,10,12,14,16,18,20,
                22,24,32,40,50,60,80,100};
            fontSizeComboBox.SelectedIndex = 3;
        }

         private void NewCommand_Executed(object sender, System.Windows.Input.ExecutedRoutedEventArgs e)
        {
            MyDocumentViewer myDocumentViewer = new MyDocumentViewer();
            myDocumentViewer.Show();
        }
        private void OpenCommand_Executed(object sender, System.Windows.Input.ExecutedRoutedEventArgs e)
        {

        }

        private void SaveCommand_Executed(object sender, System.Windows.Input.ExecutedRoutedEventArgs e)
        {

        }

        private void fontColorPicker_SelectedColorChanged(object sender, RoutedPropertyChangedEventArgs<Color?> e)
        {
            fontColor = (Color)e.NewValue;
            SolidColorBrush fontBrush = new SolidColorBrush(fontColor);
            rtbEditor.Selection.ApplyPropertyValue(TextElement.ForegroundProperty, fontBrush);
        }

        private void fontSizeComboBox_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            if (fontSizeComboBox.SelectedItem != null)
            {
                rtbEditor.Selection.ApplyPropertyValue
                    (TextElement.FontSizeProperty, fontSizeComboBox.SelectedItem);
            }
        }

        private void fontFamilyComboBox_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            if (fontFamilyComboBox.SelectedItem != null)
            {
                rtbEditor.Selection.ApplyPropertyValue
                    (TextElement.FontFamilyProperty, fontFamilyComboBox.SelectedItem);
            }
        }

    }
}
