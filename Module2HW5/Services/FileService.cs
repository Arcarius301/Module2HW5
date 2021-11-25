using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Module2HW5.Services.Abstractions;

namespace Module2HW5.Services
{
    public class FileService : IFileService
    {
        private readonly IConfigService _configService;
        private readonly FileStreamService _fileStreamService;
        private readonly string _path;

        public FileService(IConfigService configService)
        {
            _configService = configService;
            _path = _configService.Get().Path;

            if (!Directory.Exists(_path))
            {
                Directory.CreateDirectory(_path);
            }

            string[] files = Directory.GetFiles(_path);

            while (files.Length > 3)
            {
                var minDate = DateTime.UtcNow;

                foreach (string file in files)
                {
                    var fileInfo = new FileInfo(file);
                    if (fileInfo.CreationTimeUtc < minDate)
                    {
                        minDate = fileInfo.CreationTimeUtc;
                    }
                }

                foreach (string file in files)
                {
                    var fileInfo = new FileInfo(file);
                    if (fileInfo.CreationTimeUtc == minDate)
                    {
                        fileInfo.Delete();
                    }
                }

                files = Directory.GetFiles(_path);
            }

            _fileStreamService = new FileStreamService($"{_path}\\{DateTime.UtcNow:hh.mm.ss dd.MM.yyyy}.txt", FileMode.OpenOrCreate);
        }

        public void WriteLine(string text)
        {
            _fileStreamService.WriteLine(text);
        }
    }
}
