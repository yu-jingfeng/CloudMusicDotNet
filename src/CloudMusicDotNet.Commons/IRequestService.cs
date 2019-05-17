using System.Threading.Tasks;

namespace CloudMusicDotNet.Commons
{
    public interface IRequestService
    {
        Task<string> Request(string name, string data, string queryString = "");
    }
}
