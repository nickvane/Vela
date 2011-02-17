using System;
using Vela.RM.Core.Support;

namespace Vela.RM.Core.DataTypes.UriPackage
{
	/// <summary>
	/// A reference to an object which conforms to the Universal Resource Identifier (URI) standard, as defined by W3C RFC 2936. See "Universal Resource Identifiers in WWW" by Tim Berners-Lee at http://www.ietf.org/rfc/rfc2396.txt. This  is  a  World-Wide  Web  RFC for  global identification  of resources. See http://www.w3.org/Addressing for a starting point on URIs. See  http://www.ietf.org/rfc/rfc2806.txt for new URI types like telephone, fax and modem numbers.
	/// USE: Enables external resources to be referenced from within the content of the EHR. A number of functions return the logical subparts of the URI string.
	/// </summary>
	[Serializable, OpenEhrName("DV_URI")]
	public class Uri
	{
		public Uri(string value)
		{
			Value = value;
		}

		/// <summary>
		/// Value of URI as a String.
		/// </summary>
		[OpenEhrName("value")]
		public virtual string Value
		{
			get;
			set;
		}

		/// <summary>
		/// A distributed information "space" in which information objects exist. The scheme simultaneously specifies an information space and a mechanism for accessing objects in that space. For example if scheme = "ftp", it identifies the information space in which all ftpable objects exist, and also the application - ftp - which can be used to access them. Values may include: "ftp", "telnet", "mailto", "gopher" and many others. Refer to WWW URI RFC for a full list.
		/// </summary>
		[OpenEhrName("scheme")]
		public string Scheme
		{
			get
			{
				throw new NotImplementedException();
			}
		}

		/// <summary>
		/// A string whose format is a function of the scheme. Identifies the location in <scheme>-space of an information entity. Typical values include hierarchical directory paths for any machine. For example, with scheme = "ftp", path might be /pub/images/image_01. The strings "." and ".." are reserved for use in the path. Paths may include internet/intranet location identifiers of the form: sub_domain...domain, e.g. "info.cern.ch"
		/// </summary>
		[OpenEhrName("path")]
		public string Path
		{
			get
			{
				throw new NotImplementedException();
			}
		}

		/// <summary>
		/// A part of, a fragment or a sub-function within an object. Allows references to sub-parts of objects, such as a certain line and character position in a text object. The syntax and semantics are defined by the application responsible for the object.
		/// </summary>
		[OpenEhrName("fragment_id")]
		public string FragmentId
		{
			get
			{
				throw new NotImplementedException();
			}
		}

		/// <summary>
		/// Query string to send to application implied by scheme and path Enables queries to applications, including databases to be included in the URI Any query meaningful to the server, including SQL.
		/// </summary>
		[OpenEhrName("query")]
		public string Query
		{
			get
			{
				throw new NotImplementedException();
			}
		}
	}
}
