using DevExpress.Data.Filtering;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Actions;
using DevExpress.ExpressApp.Editors;
using DevExpress.ExpressApp.Layout;
using DevExpress.ExpressApp.Model.NodeGenerators;
using DevExpress.ExpressApp.SystemModule;
using DevExpress.ExpressApp.Templates;
using DevExpress.ExpressApp.Utils;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl.PermissionPolicy;
using DevExpress.Persistent.Validation;
using FilterObjectsByOwner.Module.BusinessObjects;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace FilterObjectsByOwner.Module.Controllers
{

    public class FilterPersonListViewController : ObjectViewController<ListView, FileSystemObject>
    {
        protected override void OnActivated()
        {
            base.OnActivated();
          
            var CurrentUser= SecuritySystem.CurrentUser as ApplicationUser;
            CurrentUser = this.ObjectSpace.GetObject<ApplicationUser>(CurrentUser);

            
        
            var InRolesNames= new InOperator(nameof(ApplicationRole.Name), CurrentUser.Roles.Select(r => r.Name).ToList());
            var UserNameCriteria = new BinaryOperator(nameof(ApplicationUser.UserName), CurrentUser.UserName);
            //[Application Roles][[Name] In('Administrators')]
            //[Application Users][[User Name] In('Jose', 'Emilio')]



            ContainsOperator ContainsRoleCriteria = new ContainsOperator(nameof(FileSystemObject.ApplicationRoles), InRolesNames);
            ContainsOperator ContainsUser = new ContainsOperator(nameof(FileSystemObject.ApplicationUsers), UserNameCriteria);
            Debug.WriteLine(ContainsRoleCriteria);
            Debug.WriteLine(ContainsUser);
            var FullCriteria = CriteriaOperator.Or(ContainsRoleCriteria, ContainsUser);
            Debug.WriteLine(FullCriteria);
            View.CollectionSource.Criteria["Owners1"] = FullCriteria;

           
            
        }
    }
}
