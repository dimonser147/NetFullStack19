using Google.Cloud.Vision.V1;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace NetFullStack19.Core.Moderation
{
    public class GoogleCloudModeration : IModeration
    {
         
        public ModerationResponse CheckAdult(string filePath)
        {

            // Instantiates a client
            var client = ImageAnnotatorClient.Create();
            // Load the image file into memory
            var image = Image.FromFile(filePath);
            // Performs label detection on the image file
            var response = client.DetectSafeSearch(image);
            string s = response.Adult.ToString();


            return ModerationResponse.Likely;
        }

        public ModerationResponse CheckMedical()
        {
            throw new NotImplementedException();
        }

        public ModerationResponse CheckViolence()
        {
            throw new NotImplementedException();
        }
    }
}
