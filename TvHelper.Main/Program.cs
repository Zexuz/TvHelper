using System;
using TvHelper.Domain.Repositories;
using TvHelper.Domain.Servicies;

namespace TvHelper.Main
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            var fileReaderService = new FileReaderService();
            var videoRepository = new VideoRepository();
            var preProcessorService = new PreProcessorService();
            const string downloadedTorretPath = "D:\\Downloads\\TorrentDay";

            var preProcessor = new PreProcessor(videoRepository,downloadedTorretPath,preProcessorService,fileReaderService);

            preProcessor.Start();

            Console.WriteLine("Press any key to exit");
            Console.ReadLine();
        }
    }
}