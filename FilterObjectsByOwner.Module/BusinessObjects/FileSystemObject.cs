using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl;
using DevExpress.Xpo;
using System;
using System.Linq;

namespace FilterObjectsByOwner.Module.BusinessObjects
{
    public class FileSystemObject : BaseObject
    {
        public FileSystemObject(Session session) : base(session)
        { }

        string name;

        [Size(SizeAttribute.DefaultStringMappingFieldSize)]
        public string Name
        {
            get => name;
            set => SetPropertyValue(nameof(Name), ref name, value);
        }
        [Association("FileSystemObject-ApplicationUsers")]
        public XPCollection<ApplicationUser> ApplicationUsers
        {
            get
            {
                return GetCollection<ApplicationUser>(nameof(ApplicationUsers));
            }
        }

        [Association("FileSystemObject-Roles")]
        public XPCollection<ApplicationRole> ApplicationRoles
        {
            get
            {
                return GetCollection<ApplicationRole>(nameof(ApplicationRoles));
            }
        }
    }
}