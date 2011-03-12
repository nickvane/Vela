//-----------------------------------------------------------------------
// <copyright file="Text.cs" company="Vela">
//     Copyright © Vela. All rights reserved.
// </copyright>
// <author>Nick Van Eeckhout</author>
//-----------------------------------------------------------------------

using System;
using System.Collections.Generic;
using Vela.RM.Core.DataTypes.BasicPackage;
using Vela.RM.Core.Support;

namespace Vela.RM.Core.DataTypes.TextPackage
{
	/// <summary>
	/// A text item, which may contain any amount of legal characters arranged as e.g. words, sentences etc (i.e. one DV_TEXT may be more than one word). Visual formatting and hyperlinks may be included. A <see cref="Text"/> can be “coded” by adding mappings to it.
	/// Use: Fragments of text, whether coded or not are used on their own as values, or to make up larger tracts of  text which may be marked up in some way, eventually going to make up paragraphs.
	/// </summary>
	[Serializable, OpenEhrName("DV_TEXT")]
	public class Text : DataValue
	{
		private IList<TerminologyMapping> _mappings;

		/// <summary>
		/// 
		/// </summary>
		/// <param name="value">Displayable rendition of the item, regardless of its underlying structure. For DV_CODED_TEXT, this is the rubric of the complete term as provided by the terminology service. No carriage returns, line feeds, or other non-printing characters permitted.</param>
		public Text(string value)
		{
			Value = value;
		}

		/// <summary>
		/// Displayable rendition of the item, regardless of its underlying structure. For DV_CODED_TEXT, this is the rubric of the complete term as provided by the terminology service. No carriage returns, line feeds, or other non-printing characters permitted.
		/// </summary>
		[OpenEhrName("value")]
		public string Value
		{
			get;
			set;
		}

		/// <summary>
		/// Returns terms from other terminologies most closely matching this term, typically used where the originator (e.g. pathology lab) of information uses a local terminology but also supplies one or more equivalents from wellknown terminologies (e.g. LOINC).
		/// </summary>
		[OpenEhrName("mappings")]
		public IList<TerminologyMapping> Mappings
		{
			get
			{
				return _mappings ?? (_mappings = new List<TerminologyMapping>());
			}
		}

		/// <summary>
		/// A format string of the form “name:value; name:value...”, e.g. "font-weight : bold; font-family : Arial; font-size : 12pt;". Values taken from W3C CSS2 properties lists “background” and “font”.
		/// </summary>
		[OpenEhrName("formatting")]
		public string Formatting
		{
			get;
			set;
		}

		/// <summary>
		/// Optional link sitting behind a section of plain text or coded term item.
		/// </summary>
		[OpenEhrName("hyperlink")]
		public UriPackage.Uri Hyperlink
		{
			get;
			set;
		}

		/// <summary>
		/// Optional indicator of the localised language in which the value is written. Coded from openEHR Code Set “languages”. Only used when either the text object is in a different language from the enclosing ENTRY, or else the text object is being used outside of an ENTRY or other enclosing structure which indicates the language.
		/// </summary>
		[OpenEhrName("language")]
		public CodePhrase Language
		{
			get;
			set;
		}

		/// <summary>
		/// Name of character encoding scheme in which this value is encoded. Coded from openEHR Code Set “character sets”. Unicode is the default assumption in openEHR, with UTF-8 being the assumed encoding. This attribute allows for variations from these assumptions.
		/// </summary>
		[OpenEhrName("encoding")]
		public CodePhrase Encoding
		{
			get;
			set;
		}
	}
}