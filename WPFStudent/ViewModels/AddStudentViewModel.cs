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
    class AddStudentViewModel : ViewModelBase
    {
        AddStudent addStudent;
      
        #region Constructor
        public AddStudentViewModel(AddStudent AddStudentOpen)
        {
            student = new vwStudent();
            addStudent = AddStudentOpen;
        }

        public AddStudentViewModel(AddStudent AddStudentOpen, vwStudent studentEdit)
        {
            student = studentEdit;
            addStudent = AddStudentOpen;
        }
        #endregion

        #region Properties
        private vwStudent student;
        public vwStudent Student
        {
            get
            {
                return student;
            }
            set
            {
                student = value;
                OnPropertyChanged("Student");
            }
        }

        private bool  isUpdateStudent;
        public bool  IsUpdateStudent
        {
            get
            {
                return isUpdateStudent;
            }
            set
            {
                isUpdateStudent = value;
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
                    wcf.AddStudent(Student);
                    isUpdateStudent = true;
                    addStudent.Close();
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            
        }

        private bool CanSaveExecute()
        {
            if(string.IsNullOrEmpty(student.StudentName))
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
              addStudent.Close();               
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
