using System;
using System.Threading.Tasks;

namespace ProducerConsumer
{
    /// <summary>
    /// This class sets up a scenario of participants.
    /// A participant can be a Queue, Producer, Consumer or Reporter.
    /// Currently, the scenario only contains a single participant
    /// of each type.
    /// </summary>
    public class Scenario<T> where T : new()
    {
        #region Instance fields
        private QueueWithLimit<T> _queue;
        private Producer<T> _producer;
        private Consumer<T> _consumer;
        private Reporter<T> _reporter;
        private int _iterations;
        private int _producerDelay;
        private int _consumerDelay;
        #endregion

        #region Constructor
        /// <summary>
        /// Sets up a scenario with a single participant
        /// of each type.
        /// </summary>
        public Scenario(int queueLimit, int initialElements, int iterations,
                        int producerDelay, int consumerDelay, Reporter<T>.ReportMode mode)
        {
            _queue = new QueueWithLimit<T>(queueLimit, initialElements);
            _producer = new Producer<T>(_queue);
            _consumer = new Consumer<T>(_queue);
            _reporter = new Reporter<T>(_queue, _producer, _consumer, mode);

            _iterations = iterations;
            _producerDelay = producerDelay;
            _consumerDelay = consumerDelay;
        }
        #endregion

        #region Methods
        /// <summary>
        /// Kicks off the scenario. Currently, this amounts to
        /// starting a producer task and a consumer task.
        /// </summary>
        /// <returns></returns>
        public async Task RunAsync()
        {
            Task taskProduce = Task.Run(() => ProduceWithRandomDelay(_iterations, _producerDelay));
            Task taskConsume = Task.Run(() => ConsumeWithRandomDelay(_iterations, _consumerDelay));

            await taskProduce;
            await taskConsume;

            _reporter.ReportFinal();
            Console.WriteLine("Done...");
        }

        /// <summary>
        /// Performs the specified number of production iterations.
        /// A production iteration consists of:
        /// 1) Producing an object (by calling Produce)
        /// 2) Call Report, so the change can be reported.
        /// 3) Wait for a number of milli-seconds (between 0 and maxDelay)
        /// </summary>
        private async Task ProduceWithRandomDelay(int iterations, int maxDelay)
        {
            Random rng = new Random();
            for (int i = 0; i < iterations; i++)
            {
                _producer.Produce();
                _reporter.Report();

                await Task.Delay(rng.Next(maxDelay));
            }
        }

        /// <summary>
        /// Performs the specified number of consumption iterations.
        /// A consumption iteration consists of:
        /// 1) Consume an object (by calling Consume)
        /// 2) Call Report, so the change can be reported.
        /// 3) Wait for a number of milli-seconds (between 0 and maxDelay)
        /// </summary>
        private async Task ConsumeWithRandomDelay(int iterations, int maxDelay)
        {
            Random rng = new Random();
            for (int i = 0; i < iterations; i++)
            {
                _consumer.Consume();
                _reporter.Report();

                await Task.Delay(rng.Next(maxDelay));
            }
        } 
        #endregion
    }
}