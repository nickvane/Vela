namespace Vela.AM.Assertions
{
    /// <summary>
    /// Enumeration type for operator types in assertion expressions.
    /// Use as the type of operators in the Assertion package, or for related uses.
    /// </summary>
    public enum OperatorKind
    {
        /// <summary>
        /// Equals operator (‘=’ or ‘==’)
        /// </summary>
        OpEq = 2001,
        /// <summary>
        /// Not equals operator (‘!=’ or ‘/=’ or ‘&lt>’)
        /// </summary>
        OpNe = 2002,
        /// <summary>
        /// Less-than or equals operator (‘&lt=’)
        /// </summary>
        OpLe = 2003,
    	/// <summary>
    	/// Less-than operator (‘&lt’)
    	/// </summary>
    	OpLt = 2004,
        /// <summary>
        /// Greater-than or equals operator (‘>=’)
        /// </summary>
        OpGe = 2005,
        /// <summary>
        /// Greater-than operator (‘>’)
        /// </summary>
        OpGt = 2006,
        /// <summary>
        /// Matches operator (‘matches’ or ‘is_in’)
        /// </summary>
        OpMatches = 2007,
        /// <summary>
        /// Not logical operator
        /// </summary>
        OpNot = 2010,
        /// <summary>
        /// And logical operator
        /// </summary>
        OpAnd = 2011,
        /// <summary>
        /// Or logical operator
        /// </summary>
        OpOr = 2012,
        /// <summary>
        /// Xor logical operator
        /// </summary>
        OpXor = 2013,
        /// <summary>
        /// Implies logical operator
        /// </summary>
        OpImplies = 2014,
        /// <summary>
        /// For-all quantifier operator
        /// </summary>
        OpForAll = 2015,
        /// <summary>
        /// Exists quantifier operator
        /// </summary>
        OpExists = 2016,
        /// <summary>
        /// Plus operator (‘+’)
        /// </summary>
        OpPlus = 2020,
        /// <summary>
        /// Minus operator (‘-’)
        /// </summary>
        OpMinus = 2021,
        /// <summary>
        /// Multiply operator (‘*’)
        /// </summary>
        OpMultiply = 2022,
        /// <summary>
        /// Divide operator (‘/’)
        /// </summary>
        OpDivide = 2023
    }
}