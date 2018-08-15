namespace RolePlayV23
{
    public class InsertCodeHere
    {
        public void MyCode()
        {
            // The FIRST line of code should be BELOW this line

            CharacterGroup redTeam = new CharacterGroup("Team Red");
            redTeam.AddCharacter(new Defender("Thorbjorn", 340, 8, 12));
            redTeam.AddCharacter(new Character("Angor", 200, 15, 25));
            redTeam.AddCharacter(new Character("Zurin", 170, 18, 30));
            redTeam.AddCharacter(new Damager("Allarin", 100, 15, 25));

            CharacterGroup greenTeam = new CharacterGroup("Team Green");
            greenTeam.AddCharacter(new Defender("Olaf", 400, 7, 13));
            greenTeam.AddCharacter(new Character("Baldur", 210, 12, 18));
            greenTeam.AddCharacter(new Character("Eliza", 160, 20, 35));
            greenTeam.AddCharacter(new Damager("Bezuron", 90, 10, 30));

            BattleHandler.DoBattle(redTeam, greenTeam);

            // The LAST line of code should be ABOVE this line
        }
    }
}