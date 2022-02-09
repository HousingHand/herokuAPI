using HHPassport.DAL.Models;
using System.Collections.Generic;

namespace HHPassport.BAL.Interface
{
    public interface IStudentOfStudyingBusiness
    {
        int AddUpdateStudentOfStudying(StudentStudyingModel model);
        List<StudentStudyingModel> GetAllStudentOfStudyingList();
        int ChangeStatus(int id, bool status);

        List<StudentStudyingModel> GetAllStudentOfStudyingListFrontEnd();

    }
}
