using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPFStudent.ServiceReference2;
using System.Windows.Input;
using WPFStudent.Commands;
using System.Windows;

namespace WPFStudent.ViewModels
{
    class AddResultViewModel:ViewModelBase
    {
        AddResult addResult;

       #region Constructor
        public AddResultViewModel() { }

        public AddResultViewModel(AddResult AddResultOpen)
        {
            result = new vwResult();
            addResult = AddResultOpen;

            using (Service1Client wcf = new Service1Client())
            {
                StudentsList = wcf.GetStudentList().ToList();
                SubjectsList = wcf.GetSubjectList().ToList();
            }
        }

        public AddResultViewModel(AddResult addResultOpen, vwResult resultToEdit)
        {
            result = resultToEdit;
            addResult = addResultOpen;


            using (Service1Client wcf = new Service1Client())
            {
                StudentsList = wcf.GetStudentList().ToList();
                Student = wcf.getStudentByID(resultToEdit.StudentID);


                foreach (vwStudent st in StudentsList)
                {
                    if (st.StudentID == Student.StudentID)
                    {
                        StudentIndex = StudentsList.IndexOf(st);
                    }
                }

                addResult.cmbStudent.SelectedIndex = StudentIndex;
                addResult.cmbStudent.IsEnabled = false;

                SubjectsList = wcf.GetSubjectList().ToList();
                Subject = wcf.getSubjectByID(resultToEdit.SubjectID);

                foreach (vwSubject st in SubjectsList)
                {
                    if (st.SubjectID == Subject.SubjectID)
                    {
                        SubjectIndex = SubjectsList.IndexOf(st);
                    }
                }
                addResult.cmbSubject.SelectedIndex = SubjectIndex;
                addResult.cmbSubject.IsEnabled = false;
            }
        }

       #endregion

        //---------------------------------------------------------------

        #region Properties

        private vwResult result;
        public vwResult Result
        {
            get { return result; }
            set { result = value; OnPropertyChanged("Result"); }
        }

        private vwStudent student;
        public vwStudent Student
        {
            get { return student; }
            set { student = value; OnPropertyChanged("Student"); }
        }

        private vwSubject subject;
        public vwSubject Subject
        {
            get { return subject; }
            set { subject = value; OnPropertyChanged("Subject"); }
        }

        private bool isUpdateResult;
        public bool IsUpdateResult
        {
            get { return isUpdateResult; }
            set { isUpdateResult = value; }
        }

        private List<vwStudent> studentList;
        public List<vwStudent> StudentsList
        {
            get { return studentList; }
            set { studentList = value; }
        }

        private List<vwSubject> subjectList;
        public List<vwSubject> SubjectsList
        {
            get { return subjectList; }
            set { subjectList = value; }
        }

        private int studentIndex;
        public int StudentIndex
        {
            get { return studentIndex; }
            set { studentIndex = value; OnPropertyChanged("StudentIndex"); }
        }

        private int subjectIndex;
        public int SubjectIndex
        {
            get { return subjectIndex; }
            set { subjectIndex = value; OnPropertyChanged("SubjectIndex"); }
        }

        #endregion

        //----------------------------------------------------------------------------------------

        #region Commands
        private ICommand save;
        public ICommand Save
        {
            get
            {
                if (save == null)
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
                    result.StudentID = Student.StudentID;
                    result.SubjectID = Subject.SubjectID;
                    result.SubjectName = Subject.SubjectName;
                    result.StudentName = Student.StudentName;
                    wcf.AddResults(Result);
                    isUpdateResult = true;
                    addResult.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

        }

        private bool CanSaveExecute()
        {
            if (Student == null || Subject == null) { return false; }
            else { return true; }         
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
                addResult.Close();
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

        }
        private bool CanCloseExecute()
        {
            return true;
        }
        #endregion
        //-----------------------------------------------------------------------------------------
    }
}
