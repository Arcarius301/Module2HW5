using System;
using System.Text;
using System.IO;

namespace Module2HW5.Services
{
    public class FileStreamService : IDisposable
    {
        private readonly FileStream _stream = null;

        public FileStreamService(string filename, FileMode mode)
        {
            _stream = new FileStream(filename, mode);
        }

        public bool WriteLine(string text)
        {
            if (_stream.CanWrite)
            {
                byte[] info = new UTF8Encoding(true).GetBytes($"{text}\n");
                _stream.Write(info, 0, info.Length);
                _stream.Flush();

                return true;
            }

            return false;
        }

        public void Dispose()
        {
            if (_stream != null)
            {
                _stream.Dispose();
            }

            GC.SuppressFinalize(this);
        }
    }
}
