using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace KowWhoisApi.Models
{
	[Table("rel_nameserver_address")]
	public class NameServerAddress
	{
		[Column("nameserver_id")]
		[Required]
		public uint NameServerId { get; set; }
		[JsonIgnore]
		public virtual NameServer NameServer { get; set; }

		[Column("address_id")]
		[Required]
		public uint AddressId { get; set; }
		[JsonIgnore]
		public virtual Address Address { get; set; }

		[Column("created_at")]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public DateTime CreatedAt { get; set; }

		[Column("updated_at")]
		[DatabaseGenerated(DatabaseGeneratedOption.Computed)]
		public DateTime UpdatedAt { get; set; }
	}
}