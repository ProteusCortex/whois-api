using System.Collections.Generic;
using System.Linq;
using KowWhoisApi.Data;
using KowWhoisApi.Interfaces;
using KowWhoisApi.Models;
using Microsoft.EntityFrameworkCore;

namespace KowWhoisApi.Services
{
	public class SnapshotsService : ISnapshotsService
	{
		private WhoisContext _context;
		private INameServersService _nameServers;
		private IDomainsService _domains;
		private IRegistrarsService _registrars;

		public SnapshotsService(WhoisContext context, INameServersService nameServers, IDomainsService domains, IRegistrarsService registrars)
		{
			_context = context;
			_nameServers = nameServers;
			_domains = domains;
			_registrars = registrars;
		}

		public Snapshot Create(IPiosResult piosResult)
		{
			var snapshot = new Snapshot();

			snapshot.Domain = _domains.FindOrAdd(piosResult.Domain);

			if (piosResult.IsRegistered)
			{
				Registrar r = _registrars.FindOrAdd(piosResult.Registrar);

				foreach (var ns in piosResult.NameServers)
				{
					NameServer existing_ns = _nameServers.FindOrAdd(ns);
					snapshot.NameServers.Add(existing_ns);
				}
			}

			return snapshot;
		}

		public void Add(Snapshot snapshot)
		{
			_context.Snapshots.Add(snapshot);
			_context.SaveChanges();
		}

		public List<Snapshot> Get(uint? id, uint? domainId, string domainName = null)
		{
			return _context.Snapshots
				.Where(s => id == null || s.Id == id)
				.Where(s => domainId == null || s.DomainId == domainId)
				.Where(s => domainName == null || s.Domain.Name == domainName)
				.OrderByDescending(s => s.CreatedAt)
				.Include(s => s.Domain)
				.Include(s => s.Registrar)
				.Include(s => s.NameServers)
					.ThenInclude(ns => ns.Addresses)
				.ToList();
		}

		public IPagedResponse<Snapshot> GetPaged(uint? domainId, string domainName = null, int page = 0, int per_page = int.MaxValue)
		{
			var data = _context.Snapshots
				.Where(s => domainId == null || s.DomainId == domainId)
				.Where(s => domainName == null || s.Domain.Name == domainName)
				.OrderByDescending(s => s.CreatedAt)
				.Skip(page * per_page)
				.Take(per_page)
				.Include(s => s.Domain)
				.Include(s => s.Registrar)
				.Include(s => s.NameServers)
					.ThenInclude(ns => ns.Addresses)
				.ToList();

			var total = _context.Snapshots.Count();

			return new PagedResponse<Snapshot>(data, total, page, per_page);
		}
	}
}
