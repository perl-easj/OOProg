namespace TicketsToBoardingPasses
{
    /// <summary>
    /// It is assumed that a passenger can be associated with (i.e. employed) at a Company.
    /// A company can then earn Bonus Points, and each company will thus have a bonus
    /// point "account".
    /// </summary>
    public class Company
    {
        #region Properties
        public string Name { get; }
        public int BonusPoints { get; set; }
        #endregion

        #region Constructor
        public Company(string name, int bonusPoints)
        {
            Name = name;
            BonusPoints = bonusPoints;
        } 
        #endregion

        public override string ToString()
        {
            return $"{Name}, har accumulated {BonusPoints} bonus points";
        }
    }
}