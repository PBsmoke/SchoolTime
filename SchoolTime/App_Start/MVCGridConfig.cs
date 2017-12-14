[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(SchoolTime.MVCGridConfig), "RegisterGrids")]

namespace SchoolTime
{
    using System;
    using System.Web;
    using System.Web.Mvc;
    using System.Linq;
    using System.Collections.Generic;

    using MVCGrid.Models;
    using MVCGrid.Web;
    using SchoolTime.Models;
    using SchoolTime.DAL;

    public static class MVCGridConfig 
    {
        
        public static void RegisterGrids()
        {
            GridDefaults gridDefaults = new GridDefaults()
            {
                Paging = true,
                ItemsPerPage = 20,
                Sorting = true,
                NoResultsMessage = "Sorry, no results were found"
            };
            ColumnDefaults colDefaults = new ColumnDefaults()
            {
                EnableSorting = true
            };

            MVCGridDefinitionTable.Add("StudentGrid", new MVCGridBuilder<tblStudent>(colDefaults)
                .WithAuthorizationType(AuthorizationType.AllowAnonymous)
                .AddColumns(cols =>
                {
                    // Add your columns here
                    cols.Add("StudID").WithValueExpression(p => p.StudID.ToString());
                    cols.Add("StudCode").WithValueExpression(p => p.StudCode.ToString());
                    cols.Add("FullName").WithHeaderText("FullName")
                        .WithValueExpression(p => p.FullName);
                })
                .WithSorting(true, "StudCode")
                .WithPaging(true, 10)
                .WithRetrieveDataMethod((context) =>
                {
                    var result = new QueryResult<tblStudent>();
                    using (var db = new SchoolTimeContext())
                    {
                        result.Items = db.tblStudents.ToList();
                    }
                    return result;
                })
            );

            MVCGridDefinitionTable.Add("SujectsGrid", new MVCGridBuilder<tblSuject>()
                .WithAuthorizationType(AuthorizationType.AllowAnonymous)
                .AddColumns(cols =>
                {
                    // Add your columns here
                    cols.Add("SujectID").WithValueExpression(p => p.SujectID.ToString());
                    cols.Add("SujectCode").WithValueExpression(p => p.SujectCode.ToString());
                    cols.Add("SujectName").WithValueExpression(p => p.SujectName.ToString());
                })
                .WithRetrieveDataMethod((context) =>
                {
                    var result = new QueryResult<tblSuject>();
                    using (var db = new SchoolTimeContext())
                    {
                        result.Items = db.tblSujects.ToList();
                    }
                    return result;
                })
            );

            MVCGridDefinitionTable.Add("TeacherGrid", new MVCGridBuilder<tblTeacher>()
                .WithAuthorizationType(AuthorizationType.AllowAnonymous)
                .AddColumns(cols =>
                {
                    // Add your columns here
                    cols.Add("teachID").WithValueExpression(p => p.teachID.ToString());
                    cols.Add("teachCode").WithValueExpression(p => p.teachCode.ToString());
                    cols.Add("FullName").WithValueExpression(p => p.FullName.ToString());
                })
                .WithRetrieveDataMethod((context) =>
                {
                    var result = new QueryResult<tblTeacher>();
                    using (var db = new SchoolTimeContext())
                    {
                        result.Items = db.tblTeachers.ToList();
                    }
                    return result;
                })
            );
        }
    }
}