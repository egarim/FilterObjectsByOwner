using DevExpress.Persistent.BaseImpl.PermissionPolicy;
using DevExpress.Xpo;

namespace FilterObjectsByOwner.Module.BusinessObjects;


[MapInheritance(MapInheritanceType.ParentTable)]
public class ApplicationRole : PermissionPolicyRole
{
    /// <summary>
    /// <para>Initializes a new instance of the <see cref="ApplicationRole"/> class in a particular <see cref="DevExpress.Xpo.Session"/></para>
    /// </summary>
    /// <param name="session">A DevExpress.Xpo.Session object, which is a persistent objects cache where the role will be instantiated.</param>
    public ApplicationRole(Session session) : base(session)
    {

    }
    [Association("FileSystemObject-Roles")]
    public XPCollection<FileSystemObject> FileSystemObjects
    {
        get
        {
            return GetCollection<FileSystemObject>(nameof(FileSystemObjects));
        }
    }
}
