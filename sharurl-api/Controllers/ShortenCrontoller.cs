using Microsoft.AspNetCore.Mvc;
using sharurl_api.DTOs;
using sharurl_api.Model;
using UrlGeneratorTest;

namespace sharurl_api.Controllers
{
    [Route("api/shorten")]
    [ApiController]
    public class ShortenCrontoller : ControllerBase
    {

        private UrlShortenerService urlShortenerService;

        public ShortenCrontoller(UrlShortenerService urlShortenerService)
        {
            this.urlShortenerService = urlShortenerService;
        }

        [HttpGet("{code}")]
        public async Task<IActionResult> Get(string code)
        {
            UrlInfo urlInfo = await urlShortenerService.GetUrlInfoByCode(code);

            UrlInfoResponseDTO urlFound = new UrlInfoResponseDTO(urlInfo);

            ResponseDTO responseDTO = new ResponseDTO("Url found", urlFound);

            return Ok(responseDTO);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] UrlRequest urlReq)
        {
            if (urlReq == null)
            {
                return BadRequest();
            }

            UrlInfo urlInfo = await urlShortenerService.CreateUrl(urlReq.Url);

            UrlInfoResponseDTO urlCreated = new UrlInfoResponseDTO(urlInfo);

            ResponseDTO responseDTO = new ResponseDTO("Created", urlCreated);
            return Created(urlCreated.ShortCode, responseDTO);
        }

        [HttpPatch("{code}")]
        public async Task<IActionResult> Patch(string code, [FromBody] UrlRequest urlRequest)
        {
            if (urlRequest == null)
            {
                return BadRequest();
            }

            UrlInfo urlInfo = await urlShortenerService.UpdateByCode(code, urlRequest.Url);

            UrlInfoResponseDTO urlResponse = new UrlInfoResponseDTO(urlInfo);

            return Ok(urlResponse);
        }

        [HttpDelete("{code}")]
        public async Task<IActionResult> Delete(string code)
        {
            await urlShortenerService.DeleteByCode(code);

            return NoContent();
        }

        [HttpGet("{code}/stats")]
        public async Task<IActionResult> Stats(string code)
        {
            UrlInfo urlInfo = await urlShortenerService.getStats(code);

            UrlInfoResponseDTO urlResponse = new UrlInfoWithStatsResponseDTO(urlInfo);


            ResponseDTO responseDTO = new ResponseDTO("Stats", urlResponse);

            return Ok(responseDTO);
        }
    }
}
