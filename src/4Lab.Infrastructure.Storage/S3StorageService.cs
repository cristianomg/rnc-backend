using _4Lab.Core.Configs;
using Amazon.S3;
using Amazon.S3.Model;
using Microsoft.Extensions.Options;
using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace _4lab.Infrastructure.Storage
{
    public class S3StorageService : IStorageService
    {
        private readonly string _bucketName;
        private readonly IAmazonS3 _s3Client;

        public S3StorageService(IOptions<S3Config> s3Config, IAmazonS3 s3Client)
        {
            _bucketName = s3Config.Value.BucketName;
            _s3Client = s3Client;
        }

        public async Task<bool> UploadFileAsync(string objectKey, MemoryStream fileContent)
        {
            try
            {
                await _s3Client.UploadObjectFromStreamAsync(_bucketName, objectKey, fileContent, null, CancellationToken.None);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<MemoryStream> GetFileAsync(string objectKey)
        {
            try
            {
                GetObjectRequest request = new GetObjectRequest
                {
                    BucketName = _bucketName,
                    Key = objectKey,
                };

                using (GetObjectResponse response = await _s3Client.GetObjectAsync(request))
                using (Stream responseStream = response.ResponseStream)
                {
                    var memoryStream = new MemoryStream();
                    await responseStream.CopyToAsync(memoryStream);
                    return memoryStream;
                }
            }
            catch (AmazonS3Exception e)
            {
                return default;
            }
        }

        public async Task<string> GetGetPreSignedURL(string objectKey)
        {
            return await Task.FromResult(_s3Client.GetPreSignedURL(new GetPreSignedUrlRequest
            {
                BucketName = _bucketName,
                Expires = DateTime.Now.AddMinutes(30),
                Key = objectKey
            }));
        }

        public async Task DeleteFileAsync(string objectKey)
        {
            await _s3Client.DeleteObjectAsync(new DeleteObjectRequest
            {
                BucketName = _bucketName,
                Key = objectKey
            });
        }
    }
}
