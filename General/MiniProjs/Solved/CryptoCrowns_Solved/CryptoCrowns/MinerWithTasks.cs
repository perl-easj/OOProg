using System.Threading;
using System.Threading.Tasks;
using CryptoCrownLib;

namespace CryptoCrowns
{
    public class MinerWithTasks : MinerBase
    {
        public MinerWithTasks(string owner) : base(owner)
        {
        }

        public override void MineSingleCryptoCrown()
        {
            CancellationTokenSource tokenSource = new CancellationTokenSource();
            CancellationToken token = tokenSource.Token;

            Task taskA = new Task(() => MineInterval(0, CurrentMaxKey / 4, token), token);
            Task taskB = new Task(() => MineInterval(CurrentMaxKey / 4 + 1, CurrentMaxKey / 2, token), token);
            Task taskC = new Task(() => MineInterval(CurrentMaxKey / 2 + 1, (3* CurrentMaxKey) /4, token), token);
            Task taskD = new Task(() => MineInterval((3* CurrentMaxKey) /4 + 1, CurrentMaxKey, token), token);

            taskA.Start();
            taskB.Start();
            taskC.Start();
            taskD.Start();

            Task.WaitAny(taskA, taskB, taskC, taskD);

            tokenSource.Cancel();
        }

        private void MineInterval(int from, int to, CancellationToken token)
        {
            bool foundCrown = false;
            for (int key = from; (key < to) && !foundCrown && !token.IsCancellationRequested; key++)
            {
                foundCrown = AttemptToMineSingleCryptoCrown(key);
            }
        }
    }
}