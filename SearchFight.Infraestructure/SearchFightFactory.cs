using System;
using System.Collections.Generic;
using System.Text;
using SearchFight.Core;
using SearchFight.Services;
using System.Linq;
namespace SearchFight.Infraestructure
{
    public class SearchFightFactory
    {
        public static SearchFight.Core.SearchFight createEngines() 
        {
            var loadedAssemblies = AppDomain.CurrentDomain.GetAssemblies()
                ?.Where(assembly => assembly.FullName.StartsWith("SearchFight"));

            var searchEngines = loadedAssemblies
                .SelectMany(assembly => assembly.GetTypes())
                .Where(type => type.GetInterface(typeof(IEngine).ToString()) != null)
                .Select(type => Activator.CreateInstance(type) as IEngine);

            return new SearchFight.Core.SearchFight(searchEngines);
        }
    }
}