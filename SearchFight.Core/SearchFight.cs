using System;
using System.Collections.Generic;
using System.Text;
using SearchFight.Services;
using SearchFight.Core.Model;
using System.Linq;
namespace SearchFight.Core
{
    public class SearchFight
    {
        private IEnumerable<IEngine> _Engines;
        private StringBuilder _sb;
        public SearchFight(IEnumerable<IEngine> Engines) 
        {
            _Engines = Engines;
            _sb = new StringBuilder();
        }
        public string loadResults(List<string> query) 
        {
            List<Result> results = new List<Result>();
            foreach (var word in query)
            {
                foreach (var engine in _Engines)
                {
                    results.Add(new Result
                    {
                        engineName = engine.name,
                        query = word,
                        resultsCount = engine.searchResultsCount(word),
                    });
                    _sb.Append(word + ": " + results.Last().engineName + ": " + results.Last().resultsCount + " ");
                }
                _sb.AppendLine();
            }
            getWinners(results);
            getTotalWinner(results);
            return _sb.ToString();
        }
        private void getSearchResults(List<Result> results) 
        {
            foreach (var r in results)
            {
                _sb.AppendLine(r.query + ": " + r.engineName + ": " + r.resultsCount);
            }
        }
        private void getWinners(List<Result> results) 
        {
            Result[] winners = results.Select(result => result.engineName).Distinct()
                .Select(engine => results.Where(result => result.engineName == engine)
                .OrderByDescending(model => model.resultsCount).First()).ToArray();
            foreach (var w in winners)
            {
                _sb.AppendLine(w.engineName + " winner: " + w.query);
            }
        }
        private void getTotalWinner(List<Result> results) 
        {
            _sb.AppendLine("Total winner: " + results
                .GroupBy(o => o.query).Distinct()
                .Select(grouping => new { Word = grouping.Key, Total = grouping.Sum(o => o.resultsCount) })
                .OrderByDescending(o => o.Total).First().Word);
        }
    }
}
