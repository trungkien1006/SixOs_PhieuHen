using PuppeteerSharp;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.PixelFormats;
using SixLabors.ImageSharp.Processing;

namespace SixOs_Test_2.PDFDocuments.P0402
{
    public static class P0402HTMLToImage
    {
        public static async Task<byte[]> RenderHtmlAsync(string htmlContent, int fixedWidth = 595)
        {
            if (htmlContent == "")
            {
                return [];
            }

            var browser = await Puppeteer.LaunchAsync(new LaunchOptions
            {
                ExecutablePath = @"C:\Program Files\Google\Chrome\Application\chrome.exe",
                Headless = true
            });

            using var page = await browser.NewPageAsync();

            // Load nội dung HTML
            await page.SetContentAsync(htmlContent);

            // Lấy kích thước thực của nội dung
            var height = 475;
            var contentHeight = await page.EvaluateExpressionAsync<int>("document.body.scrollHeight");

            height = contentHeight > 660 ? contentHeight : height;

            // Set viewport: width cố định, height auto (theo content)
            await page.SetViewportAsync(new ViewPortOptions
            {
                Width = fixedWidth,
                Height = height,
            });

            // Chụp full page (có thể crop theo kích thước nếu muốn)
            var screenshot = await page.ScreenshotDataAsync(new ScreenshotOptions
            {
                FullPage = true,
                Type = ScreenshotType.Png,  // hoặc Jpeg
            });

            return screenshot; // trả về byte[] hình ảnh
        }

        public static List<byte[]> SplitImageToA5Pages(byte[] imageBytes, int firstPageHeight = 660)
        {
            if (imageBytes.Length == 0)
            {
                return [];
            }

            using var image = Image.Load<Rgba32>(imageBytes);

            int a5Width = 595;  
            int a5Height = 842; 

            var pages = new List<byte[]>();

            int y = 0;
            int pageHeight = firstPageHeight; // Trang đầu có thể nhỏ hơn

            while (y < image.Height)
            {
                int sliceHeight = Math.Min(pageHeight, image.Height - y);

                var slice = image.Clone(ctx => ctx.Crop(new Rectangle(0, y, a5Width, sliceHeight)));

                using var ms = new MemoryStream();
                slice.SaveAsPng(ms);
                pages.Add(ms.ToArray());

                // Sau trang đầu thì dùng full A5 height
                pageHeight = a5Height;
                y += sliceHeight;
            }

            return pages;
        }
    }
}
