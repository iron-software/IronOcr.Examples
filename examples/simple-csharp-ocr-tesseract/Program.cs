using IronOcr;

string imageText = new IronTesseract().Read(@"images\image.png").Text;
