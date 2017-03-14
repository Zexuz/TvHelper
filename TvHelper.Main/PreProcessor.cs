using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TvHelper.Domain.Interfaces;
using TvHelper.Domain.Models;
using TvHelper.Domain.Servicies;

namespace TvHelper.Main
{
    public class PreProcessor
    {
        public int TimeOutInSec { get; set; }
        public bool IsRunning { get; set; }

        private readonly IVideoRepository _videoRepository;
        private readonly string _downloadedTorrentPath;
        private readonly IPreProcessorService _preProcessorService;
        private readonly IFileReaderService _fileReaderService;

        public PreProcessor(
            IVideoRepository videoRepository,
            string downloadedTorrentPath,
            IPreProcessorService preProcessorService,
            IFileReaderService fileReaderService
        )
        {
            _videoRepository = videoRepository;
            _downloadedTorrentPath = downloadedTorrentPath;
            _preProcessorService = preProcessorService;
            _fileReaderService = fileReaderService;
        }

        public void Start()
        {
            IsRunning = true;
            Run();
        }

        public void Stop()
        {
            IsRunning = false;
        }

        private async void Run()
        {
            while (IsRunning)
            {
                var oldVideos = _videoRepository.GetAllVideosFromDatabase();
                var allVideos = _fileReaderService.GetOnlyVideosInPath(_downloadedTorrentPath);

                var newVideos = _preProcessorService.GetNewVidosFromAllVideos(allVideos, oldVideos);

                if (newVideos.Count > 0)
                {
                    LogAndInsertVideoInDb(newVideos);
                }

                await Task.Delay(TimeOutInSec == 0 ? 120 : TimeOutInSec);
            }
        }

        private void LogAndInsertVideoInDb(List<Video> newVideos)
        {
            foreach (var video in newVideos)
            {
                Console.WriteLine($"New video found {VideoToStringParser.ToSortString(video)}");
            }
            _videoRepository.InsertVideos(newVideos);
        }
    }
}