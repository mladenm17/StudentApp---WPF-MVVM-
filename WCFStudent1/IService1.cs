using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace WCFStudent1
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IService1
    {
        [OperationContract]
        bool IsResultID(int resultID);

        [OperationContract]
        List<vwResult> GetAllResults();

        [OperationContract]
        vwResult AddResults(vwResult result);

        [OperationContract]
        void DeleteResults(int ResultID);

        [OperationContract]
        vwResult GetResultsDetail(int ResultID);

        //-----------
        [OperationContract]
        vwSubject getSubjectByID(int subjectID);

        [OperationContract]
        bool IsSubjectID(int subjectID);

        [OperationContract]
        List<vwSubject> GetSubjectList();

        [OperationContract]
        vwSubject AddSubject(vwSubject subject);

        [OperationContract]
        void DeleteSubject(int SubjectID);

        [OperationContract]
        vwSubject GetOneSubject(int SubjectID);

        //-----------
        [OperationContract]
        vwStudent getStudentByID(int studentID);

        [OperationContract]
        bool IsStudentID(int studentID);

        [OperationContract]
        List<vwStudent> GetStudentList();

        [OperationContract]
        vwStudent AddStudent(vwStudent student);

        [OperationContract]
        void DeleteStudent(int StudentID);

        [OperationContract]
        vwStudent GetOneStudent(int StudentID);
    }

}
