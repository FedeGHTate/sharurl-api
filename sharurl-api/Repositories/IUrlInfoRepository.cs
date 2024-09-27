using sharurl_api.Model;
using System.Xml;

namespace sharurl_api.Repositories
{
    public interface IUrlInfoRepository
    {
        Task<UrlInfo> GetByIdAsync(string id);
        Task<UrlInfo> SaveAsync(UrlInfo entity);
        Task<bool> DeleteAsync(string id);
        Task<UrlInfo> UpdateAsync(UrlInfo entity);
        Task<UrlInfo> FindByCodeAsync(string code);
        Task<List<UrlInfo>> FindAll();

    }
}
