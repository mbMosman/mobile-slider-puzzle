using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace SliderPuzzleApp
{
    class SliderImagePart : Image
    {
        private Image _image;
        public Image Image
        {
            get { return _image; }
        }

        private int _position;
        public int Position
        {
            get { return _position; }
        }

        public SliderImagePart(Image image, int position)
        {
            _image = image;
            _position = position;
        }

        
    }
}
