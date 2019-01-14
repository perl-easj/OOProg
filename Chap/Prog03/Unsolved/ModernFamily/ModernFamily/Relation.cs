using System;

namespace ModernFamily
{
    /// <summary>
    /// A Relation represents a relation between two specific Persons.
    /// A relation may be family-oriented (e.g. child, parent, spouse),
    /// or may be social-oriented (e.g. friend).
    /// A Relation object explicitly represents a relation from Person A
    /// to Person B - the "reverse" relation (i.e from B to A) is calculated.
    /// </summary>
    public class Relation
    {
        #region Properties
        public Person PersonA { get; }
        public Person PersonB { get; }
        public RelationType RelationAtoB { get; }

        public RelationType RelationBtoA
        {
            get
            {
                switch (RelationAtoB)
                {
                    case RelationType.friend:
                        return RelationType.friend;
                    case RelationType.parent:
                        return RelationType.child;
                    case RelationType.child:
                        return RelationType.parent;
                    case RelationType.spouse:
                        return RelationType.spouse;
                    case RelationType.exSpouse:
                        return RelationType.exSpouse;
                    default:
                        throw new NotImplementedException("No conversion implemented for {RelationAtoB}");
                }
            }
        }
        #endregion

        #region Constructor
        public Relation(Person personA, Person personB, RelationType relationAtoB)
        {
            PersonA = personA;
            PersonB = personB;
            RelationAtoB = relationAtoB;
        } 
        #endregion

        public override string ToString()
        {
            return $"{PersonA} is a {RelationAtoB} of {PersonB} [and {PersonB} is a {RelationBtoA} of {PersonA}]";
        }
    }
}