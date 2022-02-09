using HHPassport.DAL.Models;
using System.Collections.Generic;

namespace HHPassport.BAL.Interface
{
    public interface ICourseBusiness
    {
        int AddUpdateCourse(CourseModel model);
        List<CourseModel> GetAllCourses();

        List<CourseModel> GetAllCoursesFrontEnd();

        int ChangeStatus(int id, bool status);

        List<StudentStudyingModel> GetAllStudentOfStudyingList();
        List<UniversityModel> GetAllUniversites(int id);

    }
}
