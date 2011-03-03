namespace Vela.AM.Assertions
{
    /// <summary>
    /// Enumeration type for operator types in assertion expressions.
    /// Use as the type of operators in the Assertion package, or for related uses.
    /// </summary>
    public class OperatorKind
    {
        /// <summary>
        /// Equals operator (‘=’ or ‘==’)
        /// </summary>
        public const int OpEq = 2001;
        /// <summary>
        /// Not equals operator (‘!=’ or ‘/=’ or ‘&lt>’)
        /// </summary>
        public const int OpNe = 2002;
        /// <summary>
        /// Less-than or equals operator (‘&lt=’)
        /// </summary>
        public const int OpLe = 2003;

    	/// <summary>
    	/// Less-than operator (‘&lt’)
    	/// </summary>
    	public const int OpLt = 2004;
        /// <summary>
        /// Greater-than or equals operator (‘>=’)
        /// </summary>
        public const int OpGe = 2005;
        /// <summary>
        /// Greater-than operator (‘>’)
        /// </summary>
        public const int OpGt = 2006;
        /// <summary>
        /// Matches operator (‘matches’ or ‘is_in’)
        /// </summary>
        public const int OpMatches = 2007;
        /// <summary>
        /// Not logical operator
        /// </summary>
        public const int OpNot = 2010;
        /// <summary>
        /// And logical operator
        /// </summary>
        public const int OpAnd = 2011;
        /// <summary>
        /// Or logical operator
        /// </summary>
        public const int OpOr = 2012;
        /// <summary>
        /// Xor logical operator
        /// </summary>
        public const int OpXor = 2013;
        /// <summary>
        /// Implies logical operator
        /// </summary>
        public const int OpImplies = 2014;
        /// <summary>
        /// For-all quantifier operator
        /// </summary>
        public const int OpForAll = 2015;
        /// <summary>
        /// Exists quantifier operator
        /// </summary>
        public const int OpExists = 2016;
        /// <summary>
        /// Plus operator (‘+’)
        /// </summary>
        public const int OpPlus = 2020;
        /// <summary>
        /// Minus operator (‘-’)
        /// </summary>
        public const int OpMinus = 2021;
        /// <summary>
        /// Multiply operator (‘*’)
        /// </summary>
        public const int OpMultiply = 2022;
        /// <summary>
        /// Divide operator (‘/’)
        /// </summary>
        public const int OpDivide = 2023;
    }
}