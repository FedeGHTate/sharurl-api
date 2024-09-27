using sharurl_api.Exceptions;
using sharurl_api.Model;
using sharurl_api.Repositories;
using sharurl_api.Shorteners;

namespace UrlGeneratorTest
{
    public class UrlShortenerService
    {
        private ICodeGenerator codeGenerator;
        private IUrlInfoRepository urlInfoRepository;

        public UrlShortenerService(ICodeGenerator codeGenerator, IUrlInfoRepository urlInfoRepository)
        {
            this.urlInfoRepository = urlInfoRepository;
            this.codeGenerator = codeGenerator;
        }

        public async Task<UrlInfo> CreateUrl(string url)
        {
            string shortCode = this.codeGenerator.CreateCode();

            UrlInfo urlInfoCollision = await urlInfoRepository.FindByCodeAsync(shortCode);

            while(urlInfoCollision != null)
            {
                shortCode = this.codeGenerator.CreateCode();
                urlInfoCollision = await urlInfoRepository.FindByCodeAsync(shortCode);
            }

            UrlInfo urlInfo = new UrlInfo(url, shortCode);

            UrlInfo urlInfoSaved = await urlInfoRepository.SaveAsync(urlInfo);

            return urlInfoSaved;
        }

        public async Task<UrlInfo> GetUrlInfoByCode(string code)
        {
            UrlInfo urlInfoFound = await this.FindByCode(code);

            urlInfoFound.addAccess();

            UrlInfo urlInfo = await this.UpdateUrlInfo(urlInfoFound);

            return urlInfo;
        }

        public async Task DeleteByCode(string code)
        {
            bool deleted = await urlInfoRepository.DeleteAsync(code);

            if(!deleted)
            {
                throw new DeleteFailedException();
            }

        }

        public async Task<UrlInfo> UpdateByCode(string code, string newCode)
        {
            UrlInfo urlInfoFound = await this.FindByCode(code);

            urlInfoFound.updateCode(newCode);

            UrlInfo urlInfoUpdated = await this.UpdateUrlInfo(urlInfoFound);

            return urlInfoUpdated;
        }

        public async Task<UrlInfo> getStats(string code)
        {
            return await this.FindByCode(code);
        }

        private async Task<UrlInfo> UpdateUrlInfo(UrlInfo urlInfo)
        {

            UrlInfo urlInfoUpdated = await urlInfoRepository.UpdateAsync(urlInfo);

            if (urlInfoUpdated == null)
            {
                throw new UpdateFailedException();
            }

            return urlInfoUpdated;
        }

        private async Task<UrlInfo> FindByCode(string code)
        {
            UrlInfo urlsInfo = await urlInfoRepository.FindByCodeAsync(code);

            if (urlsInfo == null)
            {
                throw new CodeNotFoundException(code);
            }

            return urlsInfo;
        }
    }
}