using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace WCFStudent1
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Service1 : IService1
    {
        List<vwResult> IService1.GetAllResults()
        {
            try
            {
                using (StudentEntities2 context = new StudentEntities2())
                {
                    List<vwResult> list = new List<vwResult>();
                    list = (from x in context.vwResults select x).ToList();
                    return list;
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Exception" + ex.Message.ToString());
                return null;
            }
        }

        vwResult IService1.AddResults(vwResult result)
        {
            try
            {
                using (StudentEntities2 context = new StudentEntities2())
                {

                    if (result.ResultID == 0)
                    {
                        tblResult newResult = new tblResult();
                        newResult.StudentName = result.StudentName;
                        newResult.SubjectName = result.SubjectName;
                        newResult.Grade = result.Grade;
                        newResult.Date = result.Date;
                        newResult.StudentID = result.StudentID;
                        newResult.SubjectID = result.SubjectID;
                        context.tblResults.Add(newResult);
                        context.SaveChanges();
                        result.ResultID = newResult.ResultID;
                        return result;
                    }
                    else
                    {
                        tblResult resultToEdit = (from s in context.tblResults where s.ResultID == result.ResultID select s).First();
                        resultToEdit.ResultID = result.ResultID;
                        resultToEdit.StudentName = result.StudentName;
                        resultToEdit.SubjectName = result.SubjectName;
                        resultToEdit.Grade = result.Grade;
                        resultToEdit.Date = result.Date;
                        resultToEdit.StudentID = result.StudentID;
                        resultToEdit.SubjectID = result.SubjectID;           
                        context.SaveChanges();      
                        return result;
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Exception" + ex.Message.ToString());
                return null;
            }
        }

        void IService1.DeleteResults(int ResultID, int a)
        {
            //try
            //{
            //    using (StudentEntities2 context = new StudentEntities2())
            //    {
            //        tblResult resultToDelete = (from s in context.tblResults where s.ResultID == ResultID select s).First();
            //        context.tblResults.Remove(resultToDelete);
            //        context.SaveChanges();

            //    }
            //}
            //catch (Exception ex)
            //{
            //    System.Diagnostics.Debug.WriteLine("Exception" + ex.Message.ToString());
            //    return;
            //}
        }

        vwResult IService1.GetResultsDetail(int ResultID)
        {
            try
            {
                using (StudentEntities2 context = new StudentEntities2())
                {
                    vwResult s1 = new vwResult();
                    s1 = (from s in context.vwResults where s.ResultID == ResultID select s).FirstOrDefault();
                    return s1;

                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Exception" + ex.Message.ToString());
                return null;
            }
        }


        bool IService1.IsResultID(int resultID)
        {
            try
            {
                using (StudentEntities2 context = new StudentEntities2())
                {
                    int result = (from x in context.vwResults where x.ResultID == resultID select x.ResultID).FirstOrDefault();
                    if (result != 0)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }


            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Exception" + ex.Message.ToString());
                return false;
            }
        }


        //--------------------------------------------------------

        List<vwSubject> IService1.GetSubjectList()
        {
            try
            {
                using (StudentEntities2 context = new StudentEntities2())
                {
                    List<vwSubject> list = new List<vwSubject>();
                    list = (from x in context.vwSubjects select x).ToList();
                    return list;
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Exception" + ex.Message.ToString());
                return null;
            }
        }

        vwSubject IService1.AddSubject(vwSubject subject)
        {
            try
            {
                using (StudentEntities2 context = new StudentEntities2())
                {
                    if (subject.SubjectID == 0)
                    {
                        tblSubject newSubject = new tblSubject();
                        newSubject.SubjectName = subject.SubjectName;
                        newSubject.Professor = subject.Professor;
                        newSubject.Semestre = subject.Semestre;
                        context.tblSubjects.Add(newSubject);
                        context.SaveChanges();
                        subject.SubjectID = newSubject.SubjectID;
                        return subject;
                    }
                    else
                    {
                        tblSubject subjectToEdit = (from s in context.tblSubjects where s.SubjectID == subject.SubjectID select s).First();
                        subjectToEdit.SubjectName = subject.SubjectName;
                        subjectToEdit.Professor = subject.Professor;
                        subjectToEdit.Semestre = subject.Semestre;
                        subjectToEdit.SubjectID = subject.SubjectID;
                        context.SaveChanges();
                        return subject;
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Exception" + ex.Message.ToString());
                return null;
            }
        }

        void IService1.DeleteSubject(int SubjectID)
        {
            try
            {
                using (StudentEntities2 context = new StudentEntities2())
                {
                    tblSubject subjectToDelete = (from s in context.tblSubjects where s.SubjectID == SubjectID select s).First();
                    context.tblSubjects.Remove(subjectToDelete);
                    context.SaveChanges();

                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Exception" + ex.Message.ToString());
                return;
            }
        }

        vwSubject IService1.GetOneSubject(int SubjectID)
        {
            try
            {
                using (StudentEntities2 context = new StudentEntities2())
                {
                    vwSubject s1 = new vwSubject();
                    s1 = (from s in context.vwSubjects where s.SubjectID == SubjectID select s).FirstOrDefault();
                    return s1;

                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Exception" + ex.Message.ToString());
                return null;
            }
        }


        bool IService1.IsSubjectID(int subjectID)
        {
            try
            {
                using (StudentEntities2 context = new StudentEntities2())
                {
                    int result = (from x in context.vwResults where x.SubjectID == subjectID select x.ResultID).FirstOrDefault();
                    if (result != 0)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }


            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Exception" + ex.Message.ToString());
                return false;
            }
        }

        //------------------------------------------------------------

        List<vwStudent> IService1.GetStudentList()
        {
            try
            {
                using (StudentEntities2 context = new StudentEntities2())
                {
                    List<vwStudent> list = new List<vwStudent>();
                    list = (from x in context.vwStudents select x).ToList();
                    return list;
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Exception" + ex.Message.ToString());
                return null;
            }
        }

        vwStudent IService1.AddStudent(vwStudent student)
        {
            try
            {
                using (StudentEntities2 context = new StudentEntities2())
                {
                    if (student.StudentID == 0)
                    {
                        tblStudent newStudent = new tblStudent();
                        newStudent.IndexNumber = student.IndexNumber;
                        newStudent.StudentName = student.StudentName;
                        newStudent.StudentSurname = student.StudentSurname;
                        newStudent.Adress = student.Adress;
                        newStudent.BirthDate = student.BirthDate;
                        newStudent.Sex = student.Sex;
                        context.tblStudents.Add(newStudent);
                        context.SaveChanges();
                        student.StudentID = newStudent.StudentID;
                        return student;
                    }
                    else
                    {
                        tblStudent studenttoEdit = (from s in context.tblStudents where s.StudentID == student.StudentID select s).First();
                        studenttoEdit.IndexNumber = student.IndexNumber;
                        studenttoEdit.StudentName = student.StudentName;
                        studenttoEdit.StudentSurname = student.StudentSurname;
                        studenttoEdit.Adress = student.Adress;
                        studenttoEdit.BirthDate = student.BirthDate;
                        studenttoEdit.Sex = student.Sex;
                        studenttoEdit.StudentID = student.StudentID;
                        context.SaveChanges();
                        return student;
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Exception" + ex.Message.ToString());
                return null;
            }
        }

        void IService1.DeleteStudent(int StudentID)
        {
            try
            {
                using (StudentEntities2 context = new StudentEntities2())
                {
                    tblStudent studentToDelete = (from s in context.tblStudents where s.StudentID == StudentID select s).First();
                    context.tblStudents.Remove(studentToDelete);
                    context.SaveChanges();

                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Exception" + ex.Message.ToString());
                return;
            }
        }

        vwStudent IService1.GetOneStudent(int StudentID)
        {
            try
            {
                using (StudentEntities2 context = new StudentEntities2())
                {
                    vwStudent s1 = new vwStudent();
                    s1 = (from s in context.vwStudents where s.StudentID == StudentID select s).FirstOrDefault();
                    return s1;

                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Exception" + ex.Message.ToString());
                return null;
            }

        }

        bool IService1.IsStudentID(int studentID)
        {
            try
            {
                using (StudentEntities2 context = new StudentEntities2())
                {
                    int result = (from x in context.vwResults where x.StudentID == studentID select x.ResultID).FirstOrDefault();
                    if (result != 0)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }


            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Exception" + ex.Message.ToString());
                return false;
            }
        }

        vwStudent IService1.getStudentByID(int studentID)
        {

            try
            {
                vwStudent student;
                using (StudentEntities2 context = new StudentEntities2())
                {
                    student = (from x in context.vwStudents where x.StudentID == studentID select x).FirstOrDefault();
                    return student;
                }
            }
            catch (Exception Ex)
            {
                System.Diagnostics.Debug.WriteLine("Exception " + Ex.Message.ToString());
                return null;
            }
        }

        vwSubject IService1.getSubjectByID(int subjectID)
        {
            try
            {
                vwSubject subject;
                using (StudentEntities2 context = new StudentEntities2())
                {
                    subject = (from x in context.vwSubjects where x.SubjectID == subjectID select x).FirstOrDefault();
                    return subject;
                }
            }
            catch (Exception Ex)
            {
                System.Diagnostics.Debug.WriteLine("Exception " + Ex.Message.ToString());
                return null;
            }
        }
    }
}
