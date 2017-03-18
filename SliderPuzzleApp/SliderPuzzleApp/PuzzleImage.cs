using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace SliderPuzzleApp
{
    /**
     *  This class builds a set of images from an image folder.  
     *  The images must be added as Embedded Resources in the Portable project.
     *  
     *  The images are expected to be numbered from 01 to 16, 
     *  with an image named full that shows the completed picture.
     */
    class PuzzleImage
    {

        private static Random rng = new Random();

        private String _imageFolder;
        private String _fileExtension;
        private List<SliderImagePart> _parts;
        private Image _fullImage;
        

        public PuzzleImage(String folderName, String fileExtension = ".jpg")
        {
            _imageFolder = folderName;
            _fileExtension = fileExtension;
            createImages();

            String resource = this.GetType().Namespace.ToString() + ".Images." + _imageFolder + ".full" + _fileExtension;
            _fullImage = new Image
            {
                Source = ImageSource.FromResource(resource),
                VerticalOptions = LayoutOptions.Fill,
                HorizontalOptions = LayoutOptions.Fill
            };
        }

        public String Name
        {
            get { return _imageFolder; }
        }

        public SliderImagePart[] ShuffledParts
        {
            get
            {
                SliderImagePart[] array = _parts.ToArray();
                Shuffle(array);
                return array;
            }
        }

        public SliderImagePart[] Parts 
        {
            get
            {
                return _parts.ToArray();
            }
        }

        public Image FullImage
        {
            get
            {
                return _fullImage;
            }
        }

        private static void Shuffle(SliderImagePart[] list)
        {
            int n = list.Count();
            while (n > 1)
            {
                n--;
                int k = rng.Next(n + 1);
                var value = list[k];
                list[k] = list[n];
                list[n] = value;
            }
        }

        private void createImages()
        {
            _parts = new List<SliderImagePart>();

            for (int i=1; i<=16; i++)
            {
                String imgName = buildImageName(i);
                String resource = this.GetType().Namespace + ".Images." + _imageFolder + "." + imgName;
                SliderImagePart image = new SliderImagePart(new Image
                {
                    Source = ImageSource.FromResource(resource),
                    VerticalOptions = LayoutOptions.Fill,
                    HorizontalOptions = LayoutOptions.Fill
                }, i);
                _parts.Add(image);
            }
        }

        private String buildImageName(int num)
        {
            String imgName = "";
            if (num < 10)
            {
                imgName += "0";
            }
            imgName += num + _fileExtension;
            return imgName;
        }

        
    }
}
