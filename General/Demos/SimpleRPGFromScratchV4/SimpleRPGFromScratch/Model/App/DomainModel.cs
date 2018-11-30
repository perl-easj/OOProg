using System;
using SimpleRPGFromScratch.Model.Base;
using SimpleRPGFromScratch.Model.Catalog;

namespace SimpleRPGFromScratch.Model.App
{
    /// <summary>
    /// Denne klasse repræsenterer hele domæne-modellen, opfattet som samlingen af
    /// alle Catalog-objekter. Klassen er implementeret som en Singleton.
    /// Man benytter metoden GetCatalog til at få en reference til et Catalog-objekt
    /// indeholdende objekter af typen T.
    /// </summary>
    public class DomainModel
    {
        private static DomainModel _instance;
        public static DomainModel Instance { get { return _instance ?? (_instance = new DomainModel()); }}

        private ICatalog<Character> Characters { get; }
        private ICatalog<CharacterConfig> CharacterConfigs { get; }
        private ICatalog<Jewel> Jewels { get; }
        private ICatalog<JewelCutQuality> JewelCutQualitys { get; }
        private ICatalog<JewelModel> JewelModels { get; }
        private ICatalog<RarityTier> RarityTiers { get; }
        private ICatalog<Weapon> Weapons { get; }
        private ICatalog<WeaponJewelMatch> WeaponJewelMatchs { get; }
        private ICatalog<WeaponModel> WeaponModels { get; }
        private ICatalog<WeaponType> WeaponTypes { get; }

        private DomainModel()
        {
            Characters = new CharacterCatalog();
            CharacterConfigs = new CharacterConfigCatalog();
            Jewels = new JewelCatalog();
            JewelCutQualitys = new JewelCutQualityCatalog();
            JewelModels = new JewelModelCatalog();
            RarityTiers = new RarityTierCatalog();
            Weapons = new WeaponCatalog();
            WeaponJewelMatchs = new WeaponJewelMatchCatalog();
            WeaponModels = new WeaponModelCatalog();
            WeaponTypes = new WeaponTypeCatalog();
        }

        /// <summary>
        /// Denne metode returnerer en reference til et Catalog-objekt, som rummer objekter
        /// af typen T. Metoden kan opfattes som en Factory-metode, hvor informationen om
        /// hvilken objeket der skal returneres ligger i type-parameteren T.
        /// </summary>
        /// <typeparam name="T">Typen af de domæne-objekter, som der ønskes en Catalog-reference til.</typeparam>
        /// <returns>Reference til Catalog-objekt rummende objekter af typen T.</returns>
        public static ICatalog<T> GetCatalog<T>()
        {
            if (typeof(T) == typeof(Character))
            {
                return (ICatalog<T>)Instance.Characters;
            }

            if (typeof(T) == typeof(CharacterConfig))
            {
                return (ICatalog<T>)Instance.CharacterConfigs;
            }

            if (typeof(T) == typeof(Jewel))
            {
                return (ICatalog<T>)Instance.Jewels;
            }

            if (typeof(T) == typeof(JewelCutQuality))
            {
                return (ICatalog<T>)Instance.JewelCutQualitys;
            }

            if (typeof(T) == typeof(JewelModel))
            {
                return (ICatalog<T>)Instance.JewelModels;
            }

            if (typeof(T) == typeof(RarityTier))
            {
                return (ICatalog<T>)Instance.RarityTiers;
            }

            if (typeof(T) == typeof(Weapon))
            {
                return (ICatalog<T>)Instance.Weapons;
            }

            if (typeof(T) == typeof(WeaponJewelMatch))
            {
                return (ICatalog<T>)Instance.WeaponJewelMatchs;
            }

            if (typeof(T) == typeof(WeaponModel))
            {
                return (ICatalog<T>)Instance.WeaponModels;
            }

            if (typeof(T) == typeof(WeaponType))
            {
                return (ICatalog<T>)Instance.WeaponTypes;
            }

            throw new ArgumentException($"No Catalog found for type {typeof(T)}");
        }
    }
}