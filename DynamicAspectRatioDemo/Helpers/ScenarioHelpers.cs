using DynamicAspectRatioDemo.Scenarios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicAspectRatioDemo.Helpers
{
    public static class ScenarioHelpers
    {
        public const string ProjectTarget = "Forced Portrait Mode";

        public static List<Scenario> scenarios = new List<Scenario>
        {
            new Scenario() { Title="Adaptive Layout", ClassType=typeof(DynamicSreenHandling)},
            new Scenario() { Title="Aspect Ratio Lock", ClassType=typeof(ScreenLock)},
        };
    }
    public class Scenario
    {
        public string Title { get; set; }
        public Type ClassType { get; set; }
    }
}
