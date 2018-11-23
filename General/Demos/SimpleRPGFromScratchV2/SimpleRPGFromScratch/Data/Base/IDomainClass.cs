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
    }
}