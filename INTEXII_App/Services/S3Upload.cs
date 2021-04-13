using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Amazon;
using Amazon.S3;
using Amazon.S3.Transfer;
using Amazon.S3.Model;

namespace INTEXII_App //adding the data class got rid of the .models
{
    public class S3Upload
    {
        private static readonly RegionEndpoint bucketRegion = RegionEndpoint.USEast1;
        private static IAmazonS3 s3Client;
        public static async Task UploadFileAsync(Stream FileStream, string bucketName, string keyName)
        {
            s3Client = new AmazonS3Client(bucketRegion);
            var fileTransferUtility = new TransferUtility(s3Client);
            await fileTransferUtility.UploadAsync(FileStream, bucketName, keyName);
            PutACLRequest request = new PutACLRequest
            {
                BucketName = bucketName,
                Key = keyName,
                CannedACL = S3CannedACL.PublicRead
            };
            await s3Client.PutACLAsync(request);
        }

        public static string GeneratePreSignedURL(string objectKey)
        {

            s3Client = new AmazonS3Client(bucketRegion);

            var request = new GetPreSignedUrlRequest
            {
                BucketName = "arn:aws:s3:us-east-1:524546685232:accesspoint/is410",
                Key = objectKey,
                Verb = HttpVerb.GET,
                Expires = DateTime.UtcNow.AddHours(24)
            };

            string url = s3Client.GetPreSignedURL(request);
            return url;
        }
    }
}