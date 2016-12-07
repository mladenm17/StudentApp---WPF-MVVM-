using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using WPFStudent.Commands;
using WPFStudent.ServiceReference2;


namespace WPFStudent.ViewModels
{
    class MainWindowViewModel : ViewModelBase
    {
        MainWindow main;

        #region Constructor

        public MainWindowViewModel(MainWindow MainOpen)
        {
            
            main = MainOpen;
            using (Service1Client wcf = new Service1Client())
            {
                ResultsList = wcf.GetAllResults().ToList();
                StudentsList = wcf.GetStudentList().ToList();
                SubjectsList = wcf.GetSubjectList().ToList();
            }
        } 

        public MainWindowViewModel(MainWindow MainOpen, vwResult resultForEdit)
        {
            
            main = MainOpen;
            
            using (Service1Client wcf = new Service1Client())
            {
                ResultsList = wcf.GetAllResults().ToList();
                StudentsList = wcf.GetStudentList().ToList();
                SubjectsList = wcf.GetSubjectList().ToList();
            }

        }
        #endregion

        #region Properties

        private Visibility viewStudent = Visibility.Collapsed;
        public Visibility ViewStudent
        {
            get
            {
                return viewStudent;
            }
            set
            {
                viewStudent = value;
                OnPropertyChanged("ViewStudent");
            }
        }

        private Visibility viewSubject = Visibility.Collapsed;
        public Visibility ViewSubject
        {
            get
            {
                return viewSubject;
            }
            set
            {
                viewSubject = value;
                OnPropertyChanged("ViewSubject");
            }
        }
        
        
        private vwResult result;
        public vwResult Result { get { return result; } set { result = value; OnPropertyChanged("Result"); } }
        private vwStudent student;
        public vwStudent Student { get { return student; } set { student = value; OnPropertyChanged("Student"); } }
        private vwSubject subject;
        public vwSubject Subject { get { return subject; } set { subject = value; OnPropertyChanged("Subject"); } }

        private List<vwResult> resultList;
        public List<vwResult> ResultsList { get { return resultList; } set { resultList = value; OnPropertyChanged("ResultList"); } }
        private List<vwSubject> subjectList;
        public List<vwSubject> SubjectsList { get { return subjectList; } set { subjectList = value; OnPropertyChanged("SubjectsList"); } }
        private List<vwStudent> studentList;
        public List<vwStudent> StudentsList { get { return studentList; } set { studentList = value; OnPropertyChanged("StudentsList"); } }


        #endregion
        //-----------------------------------------------------------------------------
        #region Commands
        private ICommand menageStudent;
        public ICommand MenageStudent
        {
            get
            {
                if (menageStudent == null)
                {
                    menageStudent = new RelayCommand(param => MenageStudentExecute(), param => CanMenageStudentExecute());
                }
                return menageStudent;
            }
        }

        private void MenageStudentExecute()
        {
            try
            {
                ViewStudent = Visibility.Visible;
                ViewSubject = Visibility.Hidden;
                Result = null;
                Student = null;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

        }

        private bool CanMenageStudentExecute()
        {
            return true;         
        }

        private ICommand menageSubject;
        public ICommand MenageSubject
        {
            get
            {
                if (menageSubject == null)
                {
                    menageSubject = new RelayCommand(param => MenageSubjectExecute(), param => CanMenageSubjectExecute());
                }
                return menageSubject;
            }
        }

        private void MenageSubjectExecute()
        {
            try
            {
                ViewStudent = Visibility.Hidden;
                ViewSubject = Visibility.Visible;
                Result = null;
                Subject = null;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

        }

        private bool CanMenageSubjectExecute()
        {
            return true;
        }

        //----------------------------------------------------------------Add, Edit, Delete za student
        private ICommand addNewStudent;
        public ICommand AddNewStudent
        {
            get
            {
                if (addNewStudent == null)
                {
                    addNewStudent = new RelayCommand(param => AddNewStudentExecute(), param => CanAddNewStudentExecute());
                }
                return addNewStudent;
            }
        }

        private void AddNewStudentExecute()
        {
            try
            {
                AddStudent addStudent = new AddStudent();
                addStudent.ShowDialog();
                if ((addStudent.DataContext as AddStudentViewModel).IsUpdateStudent == true)
                {
                    using(Service1Client wcf = new Service1Client())
                    {
                        StudentsList = wcf.GetStudentList().ToList();
                    }
                }
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

        }
        private bool CanAddNewStudentExecute()
        {
            return true;
        }

        private ICommand editStudent;
        public ICommand EditStudent
        {
            get
            {
                if (editStudent == null)
                {
                    editStudent = new RelayCommand(param => EditStudentExecute(), param => CanEditStudentExecute());
                }
                return editStudent;
            }
        }

        private void EditStudentExecute()
        {
            try
            {
                if(Student != null)
                {
                    AddStudent addStudent = new AddStudent(Student);
                    addStudent.ShowDialog();
                
                if((addStudent.DataContext as AddStudentViewModel).IsUpdateStudent == false)
                {
                    using(Service1Client wcf = new Service1Client())
                    {
                        StudentsList = wcf.GetStudentList().ToList();
                    }
                }
                }
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

        }
        private bool CanEditStudentExecute()
        {
            if (Student == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        private ICommand deleteStudent;
        public ICommand DeleteStudent
        {
            get
            {
                if (deleteStudent == null)
                {
                    deleteStudent = new RelayCommand(param => DeleteStudentExecute(), param => CanDeleteStudentExecute());
                }
                return deleteStudent;
            }
        }

        private void DeleteStudentExecute()
        {
            try
            {
                if(Student != null)
                {
                    
                    using(Service1Client wcf = new Service1Client())
                    {
                        int studentID = Student.StudentID;
                        bool isStudent = wcf.IsStudentID(studentID);
                        if(isStudent == false)
                        {
                            wcf.DeleteStudent(studentID);
                            StudentsList = wcf.GetStudentList().ToList();
                        }
                        else
                        {
                            MessageBox.Show("Can't delete student! It's in result list!");
                        }
                    }
                }
                
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private bool CanDeleteStudentExecute()
        {
            if (Student == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        //----------------------------------------------------------------Add, Edit, Delete za subject
        private ICommand addNewSubject;
        public ICommand AddNewSubject
        {
            get
            {
                if (addNewSubject == null)
                {
                    addNewSubject = new RelayCommand(param => AddNewSubjectExecute(), param => CanAddNewSubjectExecute());
                }
                return addNewSubject;
            }
        }

        private void AddNewSubjectExecute()
        {
            try
            {
                AddSubject addSubject = new AddSubject();
                addSubject.ShowDialog();
                if ((addSubject.DataContext as AddSubjectViewModel).IsUpdateSubject == true)
                {
                    using (Service1Client wcf = new Service1Client())
                    {
                        SubjectsList = wcf.GetSubjectList().ToList();
                    }
                }
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

        }
        private bool CanAddNewSubjectExecute()
        {
            return true;
        }


        private ICommand editSubject;
        public ICommand EditSubject
        {
            get
            {
                if (editSubject == null)
                {
                    editSubject = new RelayCommand(param => EditSubjectExecute(), param => CanEditSubjectExecute());
                }
                return editSubject;
            }
        }

        private void EditSubjectExecute()
        {
            try
            {
                if (Subject != null)
                {
                    AddSubject addSubject = new AddSubject(Subject);
                    addSubject.ShowDialog();

                    if ((addSubject.DataContext as AddSubjectViewModel).IsUpdateSubject == false)
                    {
                        using (Service1Client wcf = new Service1Client())
                        {
                            SubjectsList = wcf.GetSubjectList().ToList();
                        }
                    }
                }
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

        }
        private bool CanEditSubjectExecute()
        {
            if (Subject == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        private ICommand deleteSubject;
        public ICommand DeleteSubject
        {
            get
            {
                if (deleteSubject == null)
                {
                    deleteSubject = new RelayCommand(param => DeleteSubjectExecute(), param => CanDeleteSubjectExecute());
                }
                return deleteSubject;
            }
        }

        private void DeleteSubjectExecute()
        {
            try
            {
                if (Subject != null)
                {

                    using (Service1Client wcf = new Service1Client())
                    {
                        int SubjectID = Subject.SubjectID;
                        bool isSubject = wcf.IsSubjectID(SubjectID);
                        if (isSubject == false)
                        {
                            wcf.DeleteSubject(SubjectID);
                            SubjectsList = wcf.GetSubjectList().ToList();
                        }
                        else
                        {
                            MessageBox.Show("Can't delete subject! It's in result list!");
                        }
                    }
                }

            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private bool CanDeleteSubjectExecute()
        {
            if (Subject == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        //----------------------------------------------------------------Add, Edit, Delete za result

        private ICommand addNewResult;
        public ICommand AddNewResult
        {
            get
            {
                if (addNewResult == null)
                {
                    addNewResult = new RelayCommand(param => AddNewResultExecute(), param => CanAddNewResultExecute());
                }
                return addNewResult;
            }
        }

        private void AddNewResultExecute()
        {
            try
            {
                AddResult addResult = new AddResult();
                addResult.ShowDialog();
                if ((addResult.DataContext as AddResultViewModel).IsUpdateResult == true)
                {
                    using (Service1Client wcf = new Service1Client())
                    {
                        ResultsList = wcf.GetAllResults().ToList();
                        main.DataGridResults.ItemsSource = ResultsList;
                    }
                }
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

        }
        private bool CanAddNewResultExecute()
        {
            return true;
        }

        private ICommand editResult;
        public ICommand EditResult
        {
            get
            {
                if (editResult == null)
                {
                    editResult = new RelayCommand(param => EditResultExecute(), param => CanEditResultExecute());
                }
                return editResult;
            }
        }

        private void EditResultExecute()
        {
            try
            {
                if (Result != null)
                {
                    AddResult addResult = new AddResult(Result);
                    addResult.ShowDialog();

                    if ((addResult.DataContext as AddResultViewModel).IsUpdateResult == false)
                    {
                        using (Service1Client wcf = new Service1Client())
                        {
                            ResultsList = wcf.GetAllResults().ToList();
                        }
                    }
                }
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

        }
        private bool CanEditResultExecute()
        {
            if (Result == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        private ICommand deleteResult;
        public ICommand DeleteResult
        {
            get
            {
                if (deleteResult == null)
                {
                    deleteResult = new RelayCommand(param => DeleteResultExecute(), param => CanDeleteResultExecute());
                }
                return deleteResult;
            }
        }

        private void DeleteResultExecute()
        {
            try
            {
                if (Result != null)
                {

                    using (Service1Client wcf = new Service1Client())
                    {
                        int resultID = result.ResultID;
                        wcf.DeleteResults(resultID);
                        ResultsList = wcf.GetAllResults().ToList();
                        main.DataGridResults.ItemsSource = ResultsList;
                    }
                }

            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private bool CanDeleteResultExecute()
        {
            if (Result == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
   
        #endregion
    }
}
