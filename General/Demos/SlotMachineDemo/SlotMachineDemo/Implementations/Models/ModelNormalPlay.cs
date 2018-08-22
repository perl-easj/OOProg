using System.Collections.Generic;
using System.Threading.Tasks;
using SlotMachineDemo.Implementations.Controllers;
using SlotMachineDemo.Implementations.Properties;
using SlotMachineDemo.Interfaces.Controllers;
using SlotMachineDemo.Interfaces.Logic;
using SlotMachineDemo.Interfaces.Models;
using SlotMachineDemo.Interfaces.Properties;
using SlotMachineDemo.Types;

namespace SlotMachineDemo.Implementations.Models
{
    /// <summary>
    /// This class handles of all the functionality related to normal play.
    /// The class contains the normal-play logic (methods), and maintains
    /// the state of the normal play session through a number of properties
    /// </summary>
    public class ModelNormalPlay : PropertySourceSink, IModelNormalPlay
    {
        #region Instance fields
        private int _noOfRotationsPerSpin;
        private int _rotationDelayMilliSecs;

        private int _noOfCredits;
        private WheelSymbolList _symbols;
        private Enums.NormalPlayState _currentNormalPlayState;        

        private ICommandExtended _spinCommand;
        private ICommandExtended _addCreditCommand;

        private ILogicCalculateWinnings _logicCalculateWinnings;
        private ILogicSymbolGenerator _logicSymbolGenerator;
        #endregion

        #region Constructor
        public ModelNormalPlay(
            ILogicCalculateWinnings logicCalculateWinnings,
            ILogicSymbolGenerator logicSymbolGenerator, 
            int initialCredits,
            int noOfRotationsPerSpin,
            int rotationDelayMilliSecs) : base(new List<IPropertySource>())
        {
            _noOfRotationsPerSpin = noOfRotationsPerSpin;
            _rotationDelayMilliSecs = rotationDelayMilliSecs;

            _noOfCredits = initialCredits;
            _symbols = new WheelSymbolList();
            CurrentNormalPlayState = Enums.NormalPlayState.BeforeFirstInteraction;

            _spinCommand = new SpinControllerCommand(this);
            _addCreditCommand = new AddCreditsControllerCommand(this);

            _logicCalculateWinnings = logicCalculateWinnings;
            _logicSymbolGenerator = logicSymbolGenerator;

            AddCommandDependency(nameof(IModelNormalPlay.CurrentNormalPlayState), _spinCommand);
            AddCommandDependency(nameof(IModelNormalPlay.CurrentNormalPlayState), _addCreditCommand);
        }
        #endregion

        #region Public properties
        /// <summary>
        /// Gets/sets the of credits available for the player.
        /// </summary>
        public int NoOfCredits
        {
            get { return _noOfCredits; }
            set
            {
                _noOfCredits = value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// Gets the number of credits won after the most recent game.
        /// </summary>
        public int CreditsWon
        {
            get { return _logicCalculateWinnings.CalculateWinnings(_symbols ); }
        }

        /// <summary>
        /// Gets/sets the wheels symbols currently showing
        /// </summary>
        public WheelSymbolList WheelSymbols
        {
            get { return _symbols; }
        }

        /// <summary>
        /// Gets/sets the current state of the game session
        /// </summary>
        public Enums.NormalPlayState CurrentNormalPlayState
        {
            get { return _currentNormalPlayState; }
            set
            {
                _currentNormalPlayState = value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// Property to retrieve the command for initiating
        /// a single game (i.e. a "spin").
        /// </summary>
        public ICommandExtended SpinCommand
        {
            get { return _spinCommand; }
        }

        /// <summary>
        /// Property to retrieve the command for adding
        /// a single credit to the player's balance
        /// </summary>
        public ICommandExtended AddCreditCommand
        {
            get { return _addCreditCommand; }
        }
        #endregion

        #region Public methods
        /// <summary>
        /// Invokes a single game (i.e. a "spin"). The game will take some  
        /// seconds to complete, and updates the WheelSymbols property after
        /// each rotation, causing the UI to update the wheel symbol images.
        /// </summary>
        public async Task Spin()
        {
            for (int rotation = 0; rotation < _noOfRotationsPerSpin; rotation++)
            {
                _symbols.Rotate(_logicSymbolGenerator);
                OnPropertyChanged(nameof(WheelSymbols));
                await Task.Delay(_rotationDelayMilliSecs);
            }

            OnPropertyChanged(nameof(CreditsWon));
        }
        #endregion
    }
}
