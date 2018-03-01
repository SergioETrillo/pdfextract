using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PdfTextExtractor;

namespace ConsoleExtractor
{
    class Program
    {
        static void Main(string[] args)
        {
            PdfTextExtractor.PdfTextExtractor extractor = new global::PdfTextExtractor.PdfTextExtractor();
            extractor.ExtractTextToFile(@"C:\Users\sergio.trillo\Documents\MayFly18\Najib\test.pdf", @"C:\Users\sergio.trillo\Documents\MayFly18\Najib\test.txt");
        }
    }
}
