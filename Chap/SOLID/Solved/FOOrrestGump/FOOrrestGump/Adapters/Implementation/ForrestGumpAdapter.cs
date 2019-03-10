using System;
using FOOrrestGump.Adapters.Interfaces;
using FOOrrestGump.FGScenario;

namespace FOOrrestGump.Adapters.Implementation
{
    /// <summary>
    /// Specific implementation of an adapter of ForrestGump to IConsumer.
    /// </summary>
    public class ForrestGumpAdapter : AdapterBase<ForrestGump>, IConsumerAdapter<IConsumableAdapter<Chocolate>, ForrestGump>
    {
        private ForrestGump _forrestGump;

        public ForrestGumpAdapter(ForrestGump forrestGump) : base(forrestGump)
        {
            _forrestGump = forrestGump;
        }

        public void Consume(IConsumableAdapter<Chocolate> aConsumable)
        {
            _forrestGump.Eat(aConsumable.Adaptee);
        }

        public void PreConsumeAction()
        {
            _forrestGump.SayFavoriteProverb();
        }

        public void PostConsumeAction()
        {
            Console.WriteLine();
            Console.WriteLine();
        }
    }
}