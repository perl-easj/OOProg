using SimpleRPGFromScratch.Data.Base;

namespace SimpleRPGFromScratch.ViewModel.Base
{
    /// <summary>
    /// Dette er den DataViewModel-klasse, som alle de klasse-specifikke DataViewModel-klasser
    /// i denne applikation skal arve fra. Her beslutter vi, at alle DataViewModel-klasser
    /// skal override den abstrake metode ItemDescription, for at gennemtvinge en faktisk
    /// implementation af Tostring.
    /// </summary>
    /// <typeparam name="T">Typen for det domæne-objekt, der refereres til.</typeparam>
    public abstract class DataViewModelAppBase<T> : DataViewModelBase<T> where T : IDomainClass
    {
        protected DataViewModelAppBase() {}
        protected DataViewModelAppBase(T obj) : base(obj) {}

        /// <summary>
        /// Ved at override ToString i base-klassen, kan man tvinge de nedarvede
        /// klasser til at implementere ItemDescription, og benytte denne til at
        /// angive, hvordan et DVM-objekt vil se ud i f.eks. et ListView, hvis
        /// man ikke angiver nogen DataTemplate.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return ItemDescription;
        }

        /// <summary>
        /// Denne property skal implementeres i de nedarvede klasser.
        /// </summary>
        protected abstract string ItemDescription { get; }
    }
}