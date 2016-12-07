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
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using WPFStudent.ServiceReference2;
using WPFStudent.ViewModels;

namespace WPFStudent
{
    /// <summary>
    /// Interaction logic for AddResult.xaml
    /// </summary>
    public partial class AddResult : Window
    {
        public AddResult()
        {
            InitializeComponent();
            this.DataContext = new AddResultViewModel(this);
        }

        public AddResult(vwResult ResultEdit)
        {
            InitializeComponent();
            this.DataContext = new AddResultViewModel(this, ResultEdit);
        }
    }
}
