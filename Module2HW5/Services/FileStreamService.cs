using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Module2HW5.Helpers;

namespace Module2HW5.Services
{
    public class FileStreamService : IDisposable
    {
        private readonly FileStream _stream = null;

        public FileStreamService(string filename, FileMode mode)
        {
            try
            {
                _stream = new FileStream(filename, mode);
            }
            catch (Exception e)
            {
                Console.WriteLine($"The process failed: {e}");
            }
        }

        public bool WriteLine(string text)
        {
            if (_stream.CanWrite)
            {
                StreamHelper.AddText(_stream, $"\n{text}");
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
