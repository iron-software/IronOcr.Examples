# Optical Character Recognition (OCR) on AWS Lambda Using IronOCR

> Full guide: [Optical Character Recognition (OCR) on AWS Lambda Using IronOCR](https://ironsoftware.com/csharp/ocr/get-started/aws/)

<div class="container-fluid">
    <div class="row">
        <div class="col-md-2">
            <img src="https://ironsoftware.com/img/platforms/Amazon_Lambda_architecture_logo.svg">
        </div>
    </div>
</div>

In this tutorial, we will guide you through configuring and running an AWS Lambda function that uses IronOCR to read documents from an S3 bucket.

## Prerequisites

To execute this guide, you'll need the **[AWSSDK.S3](https://www.nuget.org/packages/AWSSDK.S3/4.0.0-preview.3)** for handling operations with an S3 bucket.

Essentially, when working with the IronOCR ZIP, specifying the temporary directory is mandatory.

```csharp
// Configure IronOCR temporary folder and log file directory.
var awsTemporaryFolderPath = @"/tmp/";
IronOcr.Installation.InstallationPath = awsTemporaryFolderPath;
IronOcr.Installation.LogFilePath = awsTemporaryFolderPath;
```

## Initializing an AWS Lambda Project

Begin by setting up a new AWS Lambda project in Visual Studio:
- First, integrate the [AWS Toolkit for Visual Studio](https://aws.amazon.com/visualstudio/).
- Choose 'AWS Lambda Project (.NET Core - C#)'.
- Opt for a '.NET 8 (Container Image)' blueprint and click 'Finish'.

![Blueprint selection](https://ironsoftware.com/static-assets/ocr/how-to/iron-ocr-aws-tutorial/Blueprint.png)

## Including Package Dependencies

Integrating the IronOCR library into .NET 8 on AWS Lambda simplifies the process as no additional package installations are required. Adapt the Dockerfile of your project as follows:

```dockerfile
FROM public.ecr.aws/lambda/dotnet:8

# Update all system packages

RUN dnf update -y

WORKDIR /var/task

# Transfer build artifacts from your local environment to the Docker container

COPY "bin/Release/lambda-publish" .
```

## Configuring the FunctionHandler

This scenario involves fetching an image from an S3 bucket, processing it using OCR, and storing the result as a searchable PDF in the same bucket. Ensure the temp folder is configured correctly if you're using IronOCR ZIP since it needs file write access to operate properly.

```csharp
using Amazon.Lambda.Core;
using Amazon.S3;
using Amazon.S3.Model;
using IronOcr;
using System;
using System.IO;
using System.Threading.Tasks;

// Allows converting Lambda function's JSON input into a .NET class.
[assembly: LambdaSerializer(typeof(Amazon.Lambda.Serialization.SystemTextJson.DefaultLambdaJsonSerializer))]

namespace IronOcrZipAwsLambda
{
    public class Function
    {
        // Initialize the S3 client with a specific region endpoint
        private static readonly IAmazonS3 _s3Client = new AmazonS3Client(Amazon.RegionEndpoint.APSoutheast1);

        /// The process involves retrieving a PDF from S3, performing OCR, and storing it back.
        public async Task FunctionHandler(ILambdaContext context)
        {
            var awsTemporaryFolderPath = @"/tmp/";
            IronOcr.Installation.InstallationPath = awsTemporaryFolderPath;
            IronOcr.Installation.LogFilePath = awsTemporaryFolderPath;

            // IronOCR license key
            IronOcr.License.LicenseKey = "IRONOCR-MYLICENSE-KEY-1EF01";

            string bucketName = "deploymenttestbucket";
            string pdfName = "sample";
            string objectKey = $"IronPdfZip/{pdfName}.pdf";
            string searchablePdfObjectKey = $"IronPdfZip/{pdfName}-SearchablePdf.pdf";

            try
            {
                var pdfData = await GetPdfFromS3Async(bucketName, objectKey);
                IronTesseract ocrReader = new IronTesseract();
                OcrInput ocrInput = new OcrInput();
                ocrInput.LoadPdf(pdfData);
                OcrResult ocrResult = ocrReader.Read(ocrInput);

                context.Logger.LogLine($"OCR extracted text: {ocrResult.Text}");

                // Save and upload OCR'd PDF
                await UploadPdfToS3Async(bucketName, searchablePdfObjectKey, ocrResult.SaveAsSearchablePdfBytes());
                context.Logger.LogLine($"Searchable PDF stored successfully in {bucketName}/{searchablePdfObjectKey}");
            }
            catch (Exception e)
            {
                context.Logger.LogLine($"[ERROR] FunctionHandler: {e.Message}");
            }
        }
    }
}
```

## Memory and Timeout Settings

Memory allocation and timeout settings should be configured based on document size and processing needs. Set initial memory to 512 MB and timeout to 300 seconds.

```json
{
    "function-memory-size": 512,
    "function-timeout": 300
}
```

Be aware that low memory availability might cause the function to fail, as indicated by 'Runtime exited with error: signal: killed'. Refer to [AWS Lambda - Runtime Exited Signal: Killed](https://ironsoftware.com/csharp/ocr/troubleshooting/aws-lambda-runtime-exited-signal-killed/) for troubleshooting.

## Publishing the Function

To deploy, use Visual Studio's 'Publish to AWS Lambda...' option, appropriately setting the deployment specifics. Further details are available in the [AWS Lambda publishing guide](https://docs.aws.amazon.com/toolkit-for-visual-studio/latest/user-guide/lambda-creating-project-in-visual-studio.html#publish-to-lam).

## Deployment Testing

Activate and test your Lambda function either via the [AWS Lambda console](https://console.aws.amazon.com/lambda) or directly through Visual Studio settings.