using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using StudentDetail.Core.IRepository;
using StudentDetail.Core.IService;
using StudentDetail.Repository;
using StudentDetail.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentDetail.Utility
{
    public class DIResolver
    {
        public static void ConfigureServices(IServiceCollection services)
        {

            #region Http context
            //for accessing the http context by interface in view level
            services.AddTransient<IHttpContextAccessor, HttpContextAccessor>();
            #endregion

            #region Service
            //for service accesssing
            services.AddScoped<IStudentDetailService,StudentDetailService> ();
            #endregion

            #region Repository
            //for Repository accessing 
            services.AddScoped<IStudentDetailRepository,StudentDetailRepository>();
            #endregion
        }
    }
}
