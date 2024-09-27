using System.Text;

namespace sharurl_api.Shorteners
{
    public class RandomShortenerImpl : ICodeGenerator
    {
        private string alphanumerics = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
        private Random random = new Random();
        private int maxSize;

        public RandomShortenerImpl(int maxSize = 6)
        {
            this.maxSize = maxSize;
        }

        public string CreateCode()
        {

            int randomNumber = random.Next();
            StringBuilder stringBuilder = new StringBuilder();

            int alphanumericsSize = alphanumerics.Length;

            for (int i = 0; i < maxSize; i++)
            {
                char character = alphanumerics[randomNumber%alphanumericsSize];
                stringBuilder.Append(character);
                randomNumber = random.Next();
            }

            return stringBuilder.ToString();
        }
    }
}
