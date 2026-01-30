using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proxy
{
    public interface IImage
    {
        void Display();
    }

    public class RealImage : IImage
    {
        private readonly string _fileName;

        public RealImage(string fileName)
        {
            _fileName = fileName;
            LoadFromDisk();
        }

        private void LoadFromDisk()
        {
            Console.WriteLine($"Loading image {_fileName} from disk...");
        }

        public void Display()
        {
            Console.WriteLine($"Displaying {_fileName}");
        }
    }

    public class ImageProxy : IImage
    {
        private readonly string _fileName;
        private RealImage _realImage;

        public ImageProxy(string fileName)
        {
            _fileName = fileName;
        }

        public void Display()
        {
            if (_realImage == null)
            {
                _realImage = new RealImage(_fileName);
            }

            _realImage.Display();
        }
    }
    class Program
    {
        static void Main()
        {
            IImage image = new ImageProxy("photo.jpg");

            Console.WriteLine("Image object created");
            Console.WriteLine("Now displaying image");

            // Image object is made when display is called
            image.Display();
        }
    }
}
