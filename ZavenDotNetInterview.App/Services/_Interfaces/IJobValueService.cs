using System;
using System.Collections.Generic;
using ZavenDotNetInterview.App.Models;

namespace ZavenDotNetInterview.App.Services._Interfaces
{
    public interface IJobValueService
    {
        IEnumerable<Jobs> GetAll();
        bool IsExist(string name);
        void Add(string name, DateTime? doAfter);
    }
}
