namespace SimpleRPGDemo.Data
{
    public partial class CharacterConfig
    {
        public override int Id { get; set; }
        public int CharacterId { get; set; }
        public int? WeaponIdLeft { get; set; }
        public int? WeaponIdRight { get; set; }

        public Character Character { get; set; }
        public Weapon WeaponIdLeftNavigation { get; set; }
        public Weapon WeaponIdRightNavigation { get; set; }
    }
}
