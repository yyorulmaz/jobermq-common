using JoberMQ.Library.Database.Base;

namespace JoberMQ.Library.DatabaseObjects.Dbos
{
    public class UserDbo : DboPropertyGuidBase, IDboBase
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
