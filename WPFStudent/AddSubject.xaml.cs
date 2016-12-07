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
    /// Interaction logic for AddSubject.xaml
    /// </summary>
    public partial class AddSubject : Window
    {      
            public AddSubject()
            {
                InitializeComponent();
                this.DataContext = new AddSubjectViewModel(this);
            }

            public AddSubject(vwSubject SubjectEdit)
            {
                InitializeComponent();
                this.DataContext = new AddSubjectViewModel(this, SubjectEdit);
            }        
    }
}
