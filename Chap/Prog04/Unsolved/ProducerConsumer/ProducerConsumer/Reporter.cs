using System;

namespace ProducerConsumer
{
    /// <summary>
    /// This class reports the current status of a 
    /// (Consumer, Producer, Queue) scenario 
    /// </summary>
    public class Reporter<T> where T : new()
    {
        public enum ReportMode
        {
            silent,
            verbose
        }

        #region Instance fields
        private QueueWithLimit<T> _queue;
        private Producer<T> _producer;
        private Consumer<T> _consumer;
        private ReportMode _mode;
        private int _goodBalances;
        private int _badBalances;
        #endregion

        #region Constructor
        public Reporter(
            QueueWithLimit<T> queue, 
            Producer<T> producer, 
            Consumer<T> consumer,
            ReportMode mode = ReportMode.verbose)
        {
            _queue = queue;
            _producer = producer;
            _consumer = consumer;
            _mode = mode;
            _goodBalances = 0;
            _badBalances = 0;
        }
        #endregion

        #region Methods
        /// <summary>
        /// Reports the current status of the scenario. 
        /// These two sums should always be in balance:
        /// (elements currently in queue) + (items consumed)
        /// and
        /// (elements initially in queue) + (items produced)
        /// </summary>
        public void Report()
        {
            bool balanceIsGood = _queue.CountCurrent + _consumer.ItemsConsumed ==
                                    _queue.CountInitial + _producer.ItemsProduced;
            if (balanceIsGood)
            {
                _goodBalances++;
            }
            else
            {
                _badBalances++;
            }

            // In "verbose" mode, the stats are printed whenever Report is called.
            if (_mode == ReportMode.verbose)
            {
                Console.Clear();
                Console.SetCursorPosition(0, 0);
                Console.WriteLine($"Items in queue : {_queue.CountCurrent}");
                Console.WriteLine($"Items produced : {_producer.ItemsProduced}");
                Console.WriteLine($"Items consumed : {_consumer.ItemsConsumed}");
                Console.WriteLine("------------------------------");
                Console.WriteLine(balanceIsGood ? "All is fine..." : "Oops, inconsistent balance!");
            }
        }

        /// <summary>
        /// This method should be called when the scenario has completed.
        /// It will then report the final number of good and bad balances observed.
        /// </summary>
        public void ReportFinal()
        {
            Console.WriteLine($"Balances: Good {_goodBalances} - Bad {_badBalances}");
        } 
        #endregion
    }
}