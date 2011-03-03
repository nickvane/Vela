using System;
using Vela.RM.Core.DataTypes.TextPackage;
using Vela.RM.Core.Support;

namespace Vela.RM.Core.DataTypes.EncapsulatedPackage
{
	/// <summary>
	/// A specialisation of <see cref="Encapsulated" /> for audiovisual and biosignal types. Includes further metadata relating to multimedia types which are not applicable to other subtypes of <see cref="Encapsulated" />.
	/// </summary>
	[Serializable, OpenEhrName("DV_MULTIMEDIA")]
	public class Multimedia : Encapsulated
	{
		/// <summary>
		/// Text to display in lieu of multimedia display/replay
		/// </summary>
		[OpenEhrName("alternate_text")]
		public string AlternateText
		{
			get;
			set;
		}

		/// <summary>
		/// URI reference to electronic information stored outside the record as a file, database entry etc, if supplied as a reference.
		/// </summary>
		[OpenEhrName("uri")]
		public Uri Uri
		{
			get;
			set;
		}

		/// <summary>
		/// The actual data found at uri, if supplied inline
		/// </summary>
		[OpenEhrName("data")]
		public Byte[] Data
		{
			get;
			set;
		}

		/// <summary>
		/// Data media type coded from openEHR code set “media types” (interface for the IANA MIME types code set).
		/// </summary>
		[OpenEhrName("media_type")]
		public CodePhrase MediaType
		{
			get;
			set;
		}

		/// <summary>
		/// Compression type, a coded value from the openEHR “Integrity check” code set. Void means no compression.
		/// </summary>
		[OpenEhrName("compression_algorithm")]
		public CodePhrase CompressionAlgorithm
		{
			get;
			set;
		}

		/// <summary>
		/// Binary cryptographic integrity checksum
		/// </summary>
		[OpenEhrName("integrity_check")]
		public Byte[] IntegrityCheck
		{
			get;
			set;
		}

		/// <summary>
		/// Type of integrity check, a coded value from the openEHR “Integrity check” code set
		/// </summary>
		[OpenEhrName("integrity_check_algorithm")]
		public CodePhrase IntegrityCheckAlgorithm
		{
			get;
			set;
		}

		/// <summary>
		/// The thumbnail for this item, if one exists; mainly for graphics formats.
		/// </summary>
		[OpenEhrName("thumbnail")]
		public Multimedia Thumbnail
		{
			get;
			set;
		}

		/// <summary>
		/// Size in bytes of data, if present, or else of the object referred to by uri.
		/// </summary>
		[OpenEhrName("size")]
		public override int Size
		{
			get;
			set;
		}
	}
}
