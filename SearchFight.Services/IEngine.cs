using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
namespace SearchFight.Services
{
    public interface IEngine
    {
        string name { get; }
        string endpoint { get; }
        Task<int> searchResultsCount(string query);
    }
}