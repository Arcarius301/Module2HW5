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
        private readonly FileStreamService _fileStreamService;
        private readonly string _path = @"logs";

        public FileService()
        {
            if (!Directory.Exists(_path))
            {
                Directory.CreateDirectory(_path);
            }

            string[] files = Directory.GetFiles(_path);
            while (files.Length > 3)
            {
                File.Delete($@"{_path}\{files[0]}");
                var buffer = new string[files.Length - 1];
                Array.Copy(files, 0, buffer, 1, buffer.Length);
                files = buffer;
            }

            _fileStreamService = new FileStreamService(_path, FileMode.OpenOrCreate);
        }

        public void WriteLine(string text)
        {
            _fileStreamService.WriteLine(text);
        }
    }
}
