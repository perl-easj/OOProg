// HISTORIK:
// v.1.0 : Oprettet, kun entry for Weapon View
// v.1.1 : Tilføjet entry for WeaponModel View
// v.1.2 : Tilføjet entry for Character View
//

using System;
using System.Collections.Generic;
using Windows.UI.Xaml.Controls;
using SimpleRPGFromScratch.Command;
using SimpleRPGFromScratch.View.Domain;

namespace SimpleRPGFromScratch.ViewModel.App
{
    /// <summary>
    /// Denne klasse bliver Data Context for MainPage, som primært vil blive brugt
    /// til navigation i applikationen. Den skal derfor rumme:
    /// 1) Properties til Data Binding for MainPage.
    /// 2) Funktionalitet som understøtter navigation
    /// </summary>
    public class MainPageViewModel
    {
        // Disse to instance fields er static, da det er en anelse gnidret
        // at få sat en reference korrekt op til den Frame-kontrol, som de
        // klasse-specifikke views skal vises i.
        private static Frame _appFrame;
        private static Dictionary<string, NavigationCommand> _navigationCommands;

        private NavigationViewItem _selectedMenuItem;

        public MainPageViewModel()
        {
            _selectedMenuItem = null;
        }

        /// <summary>
        /// Denne property skal bruges til Data Binding, specifikt til property'en
        /// SelectedItem i den NavigationView-kontrol, som rummes af MainPage.
        /// </summary>
        public NavigationViewItem SelectedMenuItem
        {
            get { return _selectedMenuItem; }
            set
            {
                // Når et nyt menupunkt vælges, checkes først for null.
                // Hvis null, skal vi ikke gøre yderligere
                _selectedMenuItem = value;
                if (_selectedMenuItem == null) return;

                // Nu ved vi, at _selectedMenuItem != null. Derfor uddrager vi nu
                // værdien af Tag, idet den benyttes til at afgøre, hvilket view
                // der nu skal navigeres hen til. Hvis der ikke findes noget view
                // som passer til Tag, smides en Exception.
                string tag = _selectedMenuItem.Tag.ToString();
                if (!_navigationCommands.ContainsKey(tag))
                {
                    throw new ArgumentException(NoNavigationCommandMessage(tag));
                }

                // Udfør navigationen til det view, som passer med Tag.
                _navigationCommands[tag].Execute(null);
            }
        }

        /// <summary>
        /// Denne metode søger for, at initialiseringen sker i den rigtige orden.
        /// 1) Først sikrer vi os, at _appFrame er sat.
        /// 2) Så kan vi lave en ny Dictionary, hvor de mulige Tag-værdier er nøgler,
        ///    og de tilsvarende Commands til navigation er værdier.
        /// 3) Til sidst indsættes specifikke Tag/Commmand-par i denne Dictionary.
        /// </summary>
        /// <param name="appFrame">Den Frame-kontrol, som alle views vises i.</param>
        public static void SetAppFrame(Frame appFrame)
        {
            _appFrame = appFrame;
            _navigationCommands = new Dictionary<string, NavigationCommand>();
            AddCommands();
        }

        /// <summary>
        /// Fylder specifikke Tag/Commmand-par ind i _navigationCommands.
        /// </summary>
        private static void AddCommands()
        {
            _navigationCommands.Add("OpenWeaponView", CreateNavigationCommand(typeof(WeaponView)));
            _navigationCommands.Add("OpenWeaponModelView", CreateNavigationCommand(typeof(WeaponModelView)));
            _navigationCommands.Add("OpenCharacterView", CreateNavigationCommand(typeof(CharacterView)));
            _navigationCommands.Add("OpenCharacterConfigView", CreateNavigationCommand(typeof(CharacterConfigView)));
            _navigationCommands.Add("OpenRarityTierView", CreateNavigationCommand(typeof(RarityTierView)));
            _navigationCommands.Add("OpenWeaponTypeView", CreateNavigationCommand(typeof(WeaponTypeView)));
            _navigationCommands.Add("OpenJewelCutQualityView", CreateNavigationCommand(typeof(JewelCutQualityView)));
            _navigationCommands.Add("OpenJewelModelView", CreateNavigationCommand(typeof(JewelModelView)));
            _navigationCommands.Add("OpenWeaponJewelMatchView", CreateNavigationCommand(typeof(WeaponJewelMatchView)));
            _navigationCommands.Add("OpenJewelView", CreateNavigationCommand(typeof(JewelView)));
        }

        /// <summary>
        /// Konstruerer et specifikt NavigationCommand-objekt, svarende
        /// til et specifikt view (angivet ved dets type)
        /// </summary>
        /// <param name="viewType">Typen for et specifikt view.</param>
        /// <returns></returns>
        private static NavigationCommand CreateNavigationCommand(Type viewType)
        {
            return new NavigationCommand(_appFrame, viewType);
        }

        /// <summary>
        /// Dette er blot den besked som tilføjes det Exception-objekt, som
        /// smides i tilfælde af forsøg på fejlagtig navigation.
        /// </summary>
        /// <param name="tag">Besked til at indsætte i Exception-objekt.</param>
        /// <returns></returns>
        private static string NoNavigationCommandMessage(string tag)
        {
            return $"No navigation command associated with Tag {tag}";
        }
    }
}