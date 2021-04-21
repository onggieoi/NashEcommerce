using System;
using System.IO;
using System.Threading.Tasks;
using backend.Services;
using Microsoft.AspNetCore.Http;
using Moq;

namespace backend.Tests
{
    public static class BlobService
    {
        public static IBlobService BlobServiceUpload()
        {
            var mock = new Mock<IBlobService>();
            var fileMock = new Mock<IFormFile>();
            var content = "Hello World from a Fake File";
            var fileName = "test.pdf";
            var ms = new MemoryStream();
            var writer = new StreamWriter(ms);
            writer.Write(content);
            writer.Flush();
            ms.Position = 0;
            fileMock.Setup(_ => _.OpenReadStream()).Returns(ms);
            fileMock.Setup(_ => _.FileName).Returns(fileName);

            mock.Setup(blob =>
                    blob.UploadFileBlobAsync("container", fileMock.Object.OpenReadStream(), fileMock.Object.ContentType, "name"))
                .Returns(Task.FromResult(new Uri("https://www.google.com.vn")));

            return mock.Object;
        }
    }
}