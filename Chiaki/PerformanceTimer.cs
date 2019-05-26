using System;
using System.Diagnostics;

namespace Chiaki
{
    /// <summary>
    /// Records how long an action or actions take to execute. Use this class in a using statement.
    /// </summary>
    public class PerformanceTimer : IDisposable
    {
        private readonly string _category;
        private readonly Stopwatch _stopwatch;

        /// <summary>
        /// Constructs a new instance of the Performance timer.
        /// </summary>
        /// <param name="category">Optional category name to write to the Trace.Listeners collection.</param>
        public PerformanceTimer(string category = null)
        {
            _category = category;
            _stopwatch = Stopwatch.StartNew();
        }

        /// <summary>
        /// Stops the timer and writes the execution time to the Trace.Listeners collection.
        /// </summary>
        public void Dispose()
        {
            _stopwatch.Stop();

            if (string.IsNullOrWhiteSpace(_category))
            {
                Trace.WriteLine($"Execution took {_stopwatch.Elapsed}.");
            }
            else
            {
                Trace.WriteLine($"Execution took {_stopwatch.Elapsed}.", _category);
            }
        }
    }
}