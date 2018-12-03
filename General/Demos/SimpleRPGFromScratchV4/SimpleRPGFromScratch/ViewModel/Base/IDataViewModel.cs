using SimpleRPGFromScratch.Data.Base;

namespace SimpleRPGFromScratch.ViewModel.Base
{
    /// <summary>
    /// Minimalt interface for en Data View Model (DVM) - klasse.
    /// Et DVM-objekt vil være et objekt som
    /// 1) Rummer properties, som et view kan bruge til Data Binding for
    ///    et enkelt objekt.
    /// 2) Har en reference til et domæne-objekt af typen T. Det er meningen,
    ///    at metoden DataObject netop skal returnere denne reference.
    /// </summary>
    /// <typeparam name="T">Typen for det domæne-objekt, der refereres til.</typeparam>
    public interface IDataViewModel<T> where T : IDomainClass
    {
        /// <summary>
        /// Returnerer en reference til det domæne-objekt, som DVM-objektet selv refererer til.
        /// </summary>
        /// <returns>Reference til domæne-objekt.</returns>
        T DataObject();

        /// <summary>
        /// Sætter referencen til det domæne-objekt, som DVM-objektet skal referere til.
        /// Denne metode er medtaget for at kunne have en parameterløs constructor.
        /// </summary>
        /// <param name="obj">Reference til domæne-objekt.</param>
        void SetDataObject(T obj);
    }
}