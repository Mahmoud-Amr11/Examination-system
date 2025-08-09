using Examination_system.DataBase;
using Examination_system.Model;

namespace Examination_system.Repository
{
    public class SubjectRepository
    {
        public Subject GetSubjectByID(int id)
        {
            return SubjectDataBase.subjects[id];
        }
        public IEnumerable<Subject> GetAllSubjects()
        {
            return SubjectDataBase.subjects;
        }
    }
}
