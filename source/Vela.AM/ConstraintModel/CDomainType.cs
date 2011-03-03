namespace Vela.AM.ConstraintModel
{
    /// <summary>
    /// Abstract parent type of domain-specific constrainer types, to be defined in external packages.
    /// </summary>
    public abstract class CDomainType : CDefinedObject
    {
        /// <summary>
        /// Standard (i.e. C_OBJECT) form of constraint.
        /// </summary>
        public CComplexObject StandardEquivalent { get; set; }
    }
}
