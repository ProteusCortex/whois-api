using System.Threading.Tasks;

namespace KowWhoisApi.Interfaces
{
	public interface IPiosService
	{
		IPiosResult AskPios(string domain, bool fresh = false);
	}
}
