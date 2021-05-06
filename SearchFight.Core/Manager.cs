using System;
using System.Collections.Generic;
using System.Text;
using SearchFight.Services;
using SearchFight.Core.Model;
using System.Linq;
using System.Threading.Tasks;
namespace SearchFight.Core
{
    public class Manager
    {
        private IEnumerable<IEngine> _Engines;
        private StringBuilder _sb;
        public Manager(IEnumerable<IEngine> Engines)
        {
            _Engines = Engines;
            _sb = new StringBuilder();
        }
        public async Task<string> loadResults(List<string> query)
        {
            List<Result> results = new List<Result>();
            foreach (var word in query)
            {
                _sb.Append(word + ": ");
                foreach (var engine in _Engines)
                {
                    results.Add(new Result
                    {
                        query = word,
                        engineName = engine.name,
                        total = await engine.searchResultsCount(word),
                    });
                    _sb.Append(results.Last().engineName + ": " + results.Last().total + " ");
                }
                _sb.AppendLine();
            }
            getWinners(results);
            getTotalWinner(results);
            return _sb.ToString();
        }
        private void getWinners(List<Result> results)
        {
            Result[] winners = results.Select(result => result.engineName).Distinct()
                .Select(engine => results.Where(result => result.engineName == engine)
                .OrderByDescending(model => model.total).First()).ToArray();
            foreach (var w in winners)
            {
                _sb.AppendLine(w.engineName + " winner: " + w.query);
            }
        }
        private void getTotalWinner(List<Result> results)
        {
            _sb.AppendLine("Total winner: " + results
                .GroupBy(o => o.query).Distinct()
                .Select(grouping => new { Word = grouping.Key, Total = grouping.Sum(o => o.total) })
                .OrderByDescending(o => o.Total).First().Word);
        }
    }
}