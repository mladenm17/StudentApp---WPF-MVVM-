using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WPFStudent.Commands;
using WPFStudent.ServiceReference2;
using System.Windows;

namespace WPFStudent.ViewModels
{
    class AddSubjectViewModel : ViewModelBase
    {
        AddSubject addSubject;
      
        #region Constructor
        public AddSubjectViewModel(AddSubject AddSubjectOpen)
        {
            subject = new vwSubject();
            addSubject = AddSubjectOpen;

        }

        public AddSubjectViewModel(AddSubject AddSubjectOpen, vwSubject subjectEdit)
        {
            subject = subjectEdit;
            addSubject = AddSubjectOpen;
        }
        #endregion

        #region Properties
        private vwSubject subject;
        public vwSubject Subject
        {
            get
            {
                return subject;
            }
            set
            {
                subject = value;
                OnPropertyChanged("Subject");
            }
        }

        private bool isUpdateSubject;
        public bool IsUpdateSubject
        {
            get
            {
                return isUpdateSubject;
            }
            set
            {
                isUpdateSubject = value; 
            }
        }
        #endregion

        #region Commands
        private ICommand save;
        public ICommand Save
        {
            get
            {
                if(save == null)
                {
                    save = new RelayCommand(param => SaveExecute(), param => CanSaveExecute());
                }
                return save;
            }
        }
     
        private void SaveExecute()
        {
            try
            {
                using (Service1Client wcf = new Service1Client())
                {
                    wcf.AddSubject(Subject);
                    isUpdateSubject = true;
                    addSubject.Close();
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            
        }

        private bool CanSaveExecute()
        {
            if(string.IsNullOrEmpty(subject.SubjectName))
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        private ICommand close;
        public ICommand Close
        {
            get
            {
                if (close == null)
                {
                    close = new RelayCommand(param => CloseExecute(), param => CanCloseExecute());
                }
                return close;
            }
        }

        private void CloseExecute()
        {
            try
            {
                addSubject.Close();               
            }

            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            
        }
        private bool CanCloseExecute()
        {
            return true;
        }
        #endregion
    }
}
