using DevExpress.Persistent.Base;
using DevExpress.Xpo;
using System;
using System.Linq;

namespace FilterObjectsByOwner.Module.BusinessObjects
{
    [DefaultClassOptions]
    [MapInheritance(MapInheritanceType.ParentTable)]
    public class File : FileSystemObject
    {
        public File(Session session) : base(session)
        { }


    }
}