using System;
using System.Collections.Generic;
using System.Text;
namespace SearchFight.Services
{
    public interface IEngine
    {
        string name { get; }
        string endpoint { get; }
        int searchResultsCount(string query);
    }
}