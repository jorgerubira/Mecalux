using Mecalux.Domain.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Mecalux.WPF
{
    /// <summary>
    /// Lógica de interacción para WordsUI.xaml
    /// </summary>
    public partial class WordsUI : Window
    {
        private readonly ITextService _textService;
        private readonly ITextAnalyticsService _textAnalyticsService;

        public WordsUI(ITextService textService, ITextAnalyticsService textAnalyticsService)
        {
            _textService = textService;
            _textAnalyticsService = textAnalyticsService;
            InitializeComponent();
        }

        private void btnStatistics_Click(object sender, RoutedEventArgs e)
        {
            var info=_textAnalyticsService.GetAnalytics(txtInput.Text);
            lstResult.Items.Clear();
            lstResult.Items.Add("Hyphens:" + info.Hyphens);
            lstResult.Items.Add("Words:" + info.Words);
            lstResult.Items.Add("Spaces:" + info.Spaces);

        }

        private void btnSort_Click(object sender, RoutedEventArgs e)
        {
            var words=_textService.GetOrderedText(txtInput.Text, cbOptions.Text);
            lstResult.Items.Clear();
            words.ForEach(w => lstResult.Items.Add(w));
            
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            var options = _textService.GetOptions();
            cbOptions.Items.Clear();
            options.ForEach(w => cbOptions.Items.Add(w));
            if (options.Count > 0)
            {
                cbOptions.SelectedIndex = 0;
            }


        }
    }
}
