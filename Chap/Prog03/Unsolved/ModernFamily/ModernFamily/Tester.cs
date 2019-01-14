using System;
using System.Collections.Generic;
using System.Linq;

namespace ModernFamily
{
    public class Tester
    {
        private List<Person> _allPersons;
        private List<Relation> _allRelations;

        public Tester()
        {
            _allPersons = new List<Person>();
            _allRelations = new List<Relation>();
        }

        public void Run()
        {
            #region Creation of Persons
            Person alice = new Person("Alice", 46, false);
            Person benny = new Person("Benny", 45, true);
            Person carol = new Person("Carol", 48, false);
            Person daniel = new Person("Daniel", 51, true);

            Person eric = new Person("Eric", 17, true);
            Person fiona = new Person("Fiona", 12, false);
            Person gary = new Person("Gary", 21, true);
            Person harry = new Person("Harry", 15, true);
            Person ian = new Person("Ian", 10, true);
            Person jacob = new Person("Jacob", 6, true);
            Person karen = new Person("Karen", 9, false);

            Person alicesMom = new Person("Alice's mom", 78, false);
            Person alicesDad = new Person("Alice's dad", 80, true);
            Person bennysMom = new Person("Benny's mom", 75, false);
            Person carolsDad = new Person("Carol's dad", 83, true);
            Person danielsMom = new Person("Daniel's mom", 81, false);
            Person danielsDad = new Person("Daniel's dad", 85, true);

            Person liam = new Person("Liam", 44, true);
            Person mary = new Person("Mary", 38, false);
            Person neil = new Person("Neil", 52, true);
            Person oscar = new Person("Oscar", 41, true);
            Person pamela = new Person("Pamela", 29, false);
            Person quincy = new Person("Quincy", 49, true);
            Person robert = new Person("Robert", 56, true);
            Person sandra = new Person("Sandra", 36, false);
            Person tony = new Person("Tony", 32, true);
            Person ursula = new Person("Ursula", 57, false);
            #endregion


            #region Creation of Relations
            Relation aliceBenny = new Relation(alice, benny, RelationType.exSpouse);
            Relation carolDaniel = new Relation(carol, daniel, RelationType.exSpouse);
            Relation aliceDaniel = new Relation(alice, daniel, RelationType.spouse);
            Relation carolBenny = new Relation(carol, benny, RelationType.spouse);

            Relation aliceEric = new Relation(alice, eric, RelationType.parent);
            Relation aliceFiona = new Relation(alice, fiona, RelationType.parent);
            Relation aliceIan = new Relation(alice, ian, RelationType.parent);
            Relation aliceJacob = new Relation(alice, jacob, RelationType.parent);

            Relation bennyEric = new Relation(benny, eric, RelationType.parent);
            Relation bennyFiona = new Relation(benny, fiona, RelationType.parent);
            Relation bennyKaren = new Relation(benny, karen, RelationType.parent);

            Relation carolGary = new Relation(carol, gary, RelationType.parent);
            Relation carolHarry = new Relation(carol, harry, RelationType.parent);
            Relation carolKaren = new Relation(carol, karen, RelationType.parent);

            Relation danielGary = new Relation(daniel, gary, RelationType.parent);
            Relation danielHarry = new Relation(daniel, harry, RelationType.parent);
            Relation danielIan = new Relation(daniel, ian, RelationType.parent);
            Relation danielJacob = new Relation(daniel, jacob, RelationType.parent);

            Relation aliceAliceMom = new Relation(alice, alicesMom, RelationType.child);
            Relation aliceAliceDad = new Relation(alice, alicesDad, RelationType.child);
            Relation bennyBennyMom = new Relation(benny, bennysMom, RelationType.child);
            Relation carolCarolDad = new Relation(carol, carolsDad, RelationType.child);
            Relation danielDanielMom = new Relation(daniel, danielsMom, RelationType.child);
            Relation danielDanielDad = new Relation(daniel, danielsDad, RelationType.child);

            Relation aliceF1 = new Relation(alice, liam, RelationType.friend);
            Relation aliceF2 = new Relation(alice, mary, RelationType.friend);
            Relation aliceF3 = new Relation(alice, oscar, RelationType.friend);
            Relation aliceF4 = new Relation(alice, sandra, RelationType.friend);
            Relation aliceF5 = new Relation(alice, ursula, RelationType.friend);

            Relation bennyF1 = new Relation(benny, liam, RelationType.friend);
            Relation bennyF2 = new Relation(benny, neil, RelationType.friend);
            Relation bennyF3 = new Relation(benny, robert, RelationType.friend);
            Relation bennyF4 = new Relation(benny, sandra, RelationType.friend);
            Relation bennyF5 = new Relation(benny, ursula, RelationType.friend);

            Relation carolF1 = new Relation(carol, liam, RelationType.friend);
            Relation carolF2 = new Relation(carol, mary, RelationType.friend);
            Relation carolF3 = new Relation(carol, oscar, RelationType.friend);
            Relation carolF4 = new Relation(carol, quincy, RelationType.friend);
            Relation carolF5 = new Relation(carol, tony, RelationType.friend);
            Relation carolF6 = new Relation(carol, ursula, RelationType.friend);

            Relation danielF1 = new Relation(daniel, mary, RelationType.friend);
            Relation danielF2 = new Relation(daniel, neil, RelationType.friend);
            Relation danielF3 = new Relation(daniel, oscar, RelationType.friend);
            Relation danielF4 = new Relation(daniel, pamela, RelationType.friend);
            Relation danielF5 = new Relation(daniel, robert, RelationType.friend);
            Relation danielF6 = new Relation(daniel, ursula, RelationType.friend);
            #endregion


            #region Polulation of collections
            _allPersons = new List<Person>
            {
                alice, benny, carol, daniel, eric, fiona, gary, harry, ian, jacob, karen,
                alicesMom, alicesDad, bennysMom, carolsDad, danielsMom, danielsDad,
                liam, mary, neil, oscar, pamela, quincy, robert, sandra, tony, ursula
            };

            _allRelations = new List<Relation>
            {
                aliceBenny, carolDaniel, aliceDaniel, carolBenny,
                aliceEric, aliceFiona, aliceIan, aliceJacob,
                bennyEric, bennyFiona, bennyKaren,
                carolGary, carolHarry, carolKaren,
                danielGary, danielHarry, danielIan, danielJacob,
                aliceAliceMom, aliceAliceDad, bennyBennyMom, carolCarolDad, danielDanielMom, danielDanielDad,
                aliceF1, aliceF2, aliceF3, aliceF4, aliceF5,
                bennyF1, bennyF2, bennyF3, bennyF4, bennyF5,
                carolF1, carolF2, carolF3, carolF4, carolF5, carolF6,
                danielF1, danielF2, danielF3, danielF4, danielF5, danielF6
            };
            #endregion


            #region Step 1: List of Persons who are common friends for Alice and her spouse
            // TODO - Implement Step 1 correctly
            List<Person> commonFriends = new List<Person>();

            PrintPersons("Common friends of Alice and Alice's spouse", commonFriends);
            #endregion


            #region Step 2: List of Persons who are friends with either Carol or her spouse (or both)
            // TODO - Implement Step 2 correctly
            List<Person> allFriends = new List<Person>();

            PrintPersons("Friends of Carol or Carol's spouse (or both)", allFriends);
            #endregion


            #region Step 3: Find a secret date for the person not invited
            // TODO - Implement Step 3 correctly
            Person notInvited = null;
            Person datingNotInvited = null;

            Console.WriteLine($"A secret date was arranged between {notInvited?.Name} and {datingNotInvited?.Name}...");
            Console.WriteLine();
            Console.WriteLine();
            #endregion


            #region Step 4: Print out Family Tree Nodes for all persons
            // TODO - Implement Step 4 correctly
            #endregion
        }

        #region Helper methods for selection/transformation and printing
        /// <summary>
        /// Given a Person, a collection of Relations and a relation type,
        /// this method will return a list of Persons, all of which will
        /// have the given relation to aPerson.
        /// </summary>
        private List<Person> PersonToPersonsWithRelation(Person aPerson, IEnumerable<Relation> relations, RelationType typeOfRelation)
        {
            if (aPerson == null)
            {
                throw new ArgumentException("FindPersonsWithRelation called with aPerson = null");
            }

            var enumerated = relations.ToList();
            if (relations == null || !enumerated.Any())
            {
                return new List<Person>();
            }

            IEnumerable<Person> relationsAB = enumerated
                .Where(r => (r.PersonA.Name == aPerson.Name && r.RelationAtoB == typeOfRelation))
                .Select(r => r.PersonB).ToList();

            IEnumerable<Person> relationsBA = enumerated
                .Where(r => (r.PersonB.Name == aPerson.Name && r.RelationBtoA == typeOfRelation))
                .Select(r => r.PersonA).ToList();

            return relationsAB.Union(relationsBA).Distinct().ToList();
        }

        /// <summary>
        /// Given a collection of Relations and a relation type, this method
        /// will return a list of Persons which are part of at least one
        /// relation of the given relation type.
        /// </summary>
        private List<Person> AllPersonsWithRelation(IEnumerable<Relation> relations, RelationType typeOfRelation)
        {
            return relations
                .Where(r => ((r.RelationAtoB == typeOfRelation) || (r.RelationBtoA == typeOfRelation)))
                .SelectMany(r => new[] { r.PersonA, r.PersonB })
                .Distinct()
                .ToList();
        }

        /// <summary>
        /// Simply prints out a list of all Persons in the
        /// given Person collection.
        /// </summary>
        private void PrintPersons(string description, IEnumerable<Person> persons)
        {
            Console.WriteLine();
            Console.WriteLine($"List of {description}:");
            Console.WriteLine("--------------------------------------");
            foreach (Person p in persons)
            {
                Console.WriteLine(p);
            }
            Console.WriteLine();
        }

        /// <summary>
        /// Generate the FamilyTreeNode corresponding to the given Person. 
        /// </summary>
        private FamilyTreeNode GenerateFamilyTreeNode(Person p)
        {
            // TODO - Implement GenerateFamilyTreeNode correctly (Hint: Aggregate...)
            return null;
        }

        /// <summary>
        /// Generate - and subsequently print - a FamilyTreeNode
        /// for the given Person.
        /// </summary>
        private void GenerateAndPrintFamilyTreeNode(Person p)
        {
            PrintFamilyTreeNodeCompact(GenerateFamilyTreeNode(p));
        }

        /// <summary>
        /// Print a single FamilyTreeNode object, with a bit of formatting.
        /// </summary>
        private void PrintFamilyTreeNode(FamilyTreeNode ftn, bool includeNoFamily = false)
        {
            if (PrintCondition(ftn, includeNoFamily))
            {
                Console.WriteLine();
                Console.WriteLine($"--- Family Tree Node for {ftn.Self.Name} ---");
                Console.WriteLine(ftn);
                Console.WriteLine();
            }
        }

        /// <summary>
        /// Print a single FamilyTreeNode object, with a bit of formatting.
        /// This method prints the object in a more compact form than PrintFamilyTreeNode.
        /// </summary>
        private void PrintFamilyTreeNodeCompact(FamilyTreeNode ftn, bool includeNoFamily = false)
        {
            if (PrintCondition(ftn, includeNoFamily))
            {
                Console.WriteLine($"FTN for {ftn.Self.Name}: {ftn}");
            }
        }

        /// <summary>
        ///  Condition for printing when in compact mode. 
        /// </summary>
        private bool PrintCondition(FamilyTreeNode ftn, bool includeNoFamily)
        {
            return ftn != null && (includeNoFamily || ftn.HasAnyFamily);
        }
        #endregion
    }
}