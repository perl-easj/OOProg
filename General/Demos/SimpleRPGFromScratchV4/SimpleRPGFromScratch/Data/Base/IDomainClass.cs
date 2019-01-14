namespace SimpleRPGFromScratch.Data.Base
{
    /// <summary>
    /// Dette interface rummer de (minimale) krav, vi stiller til at en klasse
    /// vil blive opfattet som en "domæne-klasse", d.v.s. en klasse som er en
    /// del af vores domæne-model.
    /// </summary>
    public interface IDomainClass
    {
        /// <summary>
        /// Alle domæne-objekter skal kunne returnere et unikt Id af typen int.
        /// Således kan objektet godt internt have en anden nøgle end f.eks. en
        /// property ved navn Id.
        /// Id skal ikke være globalt unikt, blot må to domæne-objekter af samme
        /// klasse ikke have det samme id.
        /// </summary>
        /// <returns>Unik nøgle for objektet</returns>
        int GetId();

        /// <summary>
        /// For alle domæne-objekter skal Id kunne sættes.
        /// </summary>
        void SetId(int id);

        /// <summary>
        /// Alle domæne-objekter skal kunne kopiere sig selv.
        /// </summary>
        /// <returns>Kopi af objektet</returns>
        IDomainClass Copy();

        void CopyValuesFrom(IDomainClass obj);

        void SetInitialValues();

        bool IsValid { get; }
    }
}