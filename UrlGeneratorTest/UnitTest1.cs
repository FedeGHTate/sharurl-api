using sharurl_api.Model;
using sharurl_api.Shorteners;
using Moq;
using sharurl_api.Repositories;

namespace UrlGeneratorTest
{
    public class Tests
    {

        UrlShortenerService urlGenerator;
        ICodeGenerator urlShortenerMock;

        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test1()
        {
            string testUrl = "http://locahost:8080/api";
            string shortUrl = "123";

            var urlShortenerMock = new Mock<ICodeGenerator>();
            var urlRepositoryMock = new Mock<IUrlInfoRepository>();

            urlShortenerMock.Setup(m => m.CreateCode()).Returns(shortUrl);

            urlRepositoryMock.Setup(r => r.SaveAsync(It.IsAny<UrlInfo>())).Returns(Task.FromResult(new UrlInfo(testUrl,shortUrl)));

            this.urlGenerator = new UrlShortenerService(urlShortenerMock.Object, urlRepositoryMock.Object);


            UrlInfo url = urlGenerator.CreateUrl(testUrl).Result;


            Assert.AreEqual(url.ShortCode, shortUrl);
            urlShortenerMock.Verify(s => s.CreateCode(), Times.Once);


        }
    }
}