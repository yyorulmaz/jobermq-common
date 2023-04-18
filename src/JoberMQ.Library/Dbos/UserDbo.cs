﻿using JoberMQ.Library.Database.Base;

namespace JoberMQ.Library.Dbos
{
    public class UserDbo : DboPropertyGuidBase, IDboBase
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Authority { get; set; }

    }
}
