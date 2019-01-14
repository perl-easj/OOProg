using System.Collections.Generic;
using System.Linq;

namespace ModernFamily
{
    /// <summary>
    /// This class represents a "node" in a family tree,
    /// for one specific Person
    /// </summary>
    public class FamilyTreeNode
    {
        #region Properties (simple)
        public Person Self { get; set; }
        public FamilyTreeNode Father { get; set; }
        public FamilyTreeNode Mother { get; set; }
        public FamilyTreeNode Spouse { get; set; }
        public List<FamilyTreeNode> Children { get; set; }
        #endregion

        #region Properties (aggregated)
        public bool HasAnyChildren
        {
            get { return Children.Count > 0; }
        }

        public bool HasAnyParents
        {
            get { return Father != null || Mother != null; }
        }

        public bool HasSpouse
        {
            get { return Spouse != null; }
        }

        public bool HasAnyFamily
        {
            get { return HasAnyChildren || HasAnyParents || HasSpouse; }
        }
        #endregion

        #region Properties (private)
        private string SpouseDescription
        {
            get { return Spouse != null ? $" (married to {Spouse.Self.Name})" : ""; }
        }

        private string ParentDescription
        {
            get
            {
                string motherDesc = Mother != null ? Mother.Self.Name : "(none)";
                string fatherDesc = Father != null ? Father.Self.Name : "(none)";
                return $"{motherDesc}, {fatherDesc}";
            }
        }

        private string ChildrenDescription
        {
            get
            {
                return Children.Aggregate("", (s, p) => s + p.Self.Name + ", ", s => s.Length > 1 ? s.Remove(s.Length - 2, 2) : s);
            }
        }
        #endregion

        #region Constructor
        public FamilyTreeNode(Person self)
        {
            Self = self;
            Children = new List<FamilyTreeNode>();
        }
        #endregion

        #region Methods (public)
        public void CreateFatherNode(Person father)
        {
            Father = new FamilyTreeNode(father);
        }

        public void CreateMotherNode(Person mother)
        {
            Mother = new FamilyTreeNode(mother);
        }

        public void CreateSpouseNode(Person spouse)
        {
            Spouse = new FamilyTreeNode(spouse);
        }

        public void CreateChildNode(Person child)
        {
            Children.Add(new FamilyTreeNode(child));
        }

        /// <summary>
        /// Given a Relation, this method will try to extend the FamilyTreeNode,
        /// if the Relation has relevance for the FamilyTreeNode.
        /// Note that the method return a reference to the object itself,
        /// making it usable in e.g. a call of the LINQ method Aggregate...
        /// </summary>
        public FamilyTreeNode ExtendNodeFromRelation(Relation rel)
        {
            if (!IsRelationApplicable(rel)) return this;

            if (rel.RelationAtoB == RelationType.spouse) // Case spouse
            {
                CreateSpouseNode(SelfIsPersonA(rel) ? rel.PersonB : rel.PersonA);
            }
            else // Case parent/child
            {
                CreateParentOrChildNode(rel);
            }

            return this;
        }

        public override string ToString()
        {
            return $"{Self.Name}{SpouseDescription}, Parents [{ParentDescription}]  Children: [{ChildrenDescription}]";
        }
        #endregion

        #region Methods (private)
        private bool IsRelationApplicable(Relation rel)
        {
            bool meaningful = rel.PersonA != null && rel.PersonB != null;
            bool concernsSelf = SelfIsPersonA(rel) || SelfIsPersonB(rel);
            bool familyType = rel.RelationAtoB == RelationType.child ||
                              rel.RelationAtoB == RelationType.parent ||
                              rel.RelationAtoB == RelationType.spouse;

            return meaningful && concernsSelf && familyType;
        }

        private void CreateParentOrChildNode(Relation rel)
        {
            // Case: Self is parent of B; B is thus child of Self
            if (rel.RelationAtoB == RelationType.parent && SelfIsPersonA(rel))
            {
                CreateChildNode(rel.PersonB);
            }

            // Case: A is parent of Self
            if (rel.RelationAtoB == RelationType.parent && SelfIsPersonB(rel))
            {
                CreateParentNode(rel.PersonA);
            }

            // Case: Self is child of B; B is thus parent of Self
            if (rel.RelationAtoB == RelationType.child && SelfIsPersonA(rel))
            {
                CreateParentNode(rel.PersonB);
            }

            // Case: A is child of Self
            if (rel.RelationAtoB == RelationType.child && SelfIsPersonB(rel))
            {
                CreateChildNode(rel.PersonA);
            }
        }

        private void CreateParentNode(Person aPerson)
        {
            if (aPerson.Gender)
            {
                CreateFatherNode(aPerson);
            }
            else
            {
                CreateMotherNode(aPerson);
            }
        }

        private bool SelfIsPersonA(Relation aRelation)
        {
            return aRelation.PersonA.Name == Self.Name;
        }

        private bool SelfIsPersonB(Relation aRelation)
        {
            return aRelation.PersonB.Name == Self.Name;
        }
        #endregion
    }
}