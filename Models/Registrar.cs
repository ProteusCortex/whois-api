using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace kow_whois_api
{
	[Table("registrar")]
	public class Registrar
	{
		[Column("id")]
		public int Id { get; set; }

		[Column("name")]
		public string Name { get; set; }

		[Column("url")]
		public string url { get; set; }

		[Column("email")]
		public string email { get; set; }

		[Column("phone")]
		[MaxLength(20)]
		public string phone { get; set; }

		[Column("created_at")]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public DateTime CreatedAt { get; set; }

		[Column("updated_at")]
		[DatabaseGenerated(DatabaseGeneratedOption.Computed)]
		public DateTime UpdatedAt { get; set; }

		public virtual ICollection<Snapshot> Snapshots { get; set; }

		public Registrar()
		{
			Snapshots = new List<Snapshot>();
		}
	}
}
