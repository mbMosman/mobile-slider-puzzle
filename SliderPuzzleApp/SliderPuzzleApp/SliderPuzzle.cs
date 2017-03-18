using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace SliderPuzzleApp
{
    class SliderPuzzle : Grid
    {
        private PuzzleImage _image;
        private Image _emptyImage;

        public SliderPuzzle()
        {
            String resource = this.GetType().Namespace.ToString() + ".Images.empty.jpg";
            _emptyImage = new Image
            {
                Source = ImageSource.FromResource(resource),
                VerticalOptions = LayoutOptions.Fill,
                HorizontalOptions = LayoutOptions.Fill
            };

            this.VerticalOptions = LayoutOptions.Center;
            this.HorizontalOptions = LayoutOptions.Center;
            this.RowSpacing = 1;
            this.ColumnSpacing = 1;

            ColumnDefinitions = new ColumnDefinitionCollection
                {
                    new ColumnDefinition { Width = new GridLength(10) },
                    new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) },
                    new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) },
                    new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) },
                    new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) },
                    new ColumnDefinition { Width = new GridLength(10) }
                };

            RowDefinitions = new RowDefinitionCollection
                {
                    new RowDefinition { Height = new GridLength(10)},
                    new RowDefinition { Height = new GridLength(1, GridUnitType.Star) },
                    new RowDefinition { Height = new GridLength(1, GridUnitType.Star) },
                    new RowDefinition { Height = new GridLength(1, GridUnitType.Star) },
                    new RowDefinition { Height = new GridLength(1, GridUnitType.Star) },
                    new RowDefinition { Height = new GridLength(10) }
                };
            

            BoxView top = new BoxView { Color = Color.Blue };
            Grid.SetRow(top, 0);
            Grid.SetColumn(top, 0);
            Grid.SetColumnSpan(top, 6);
            Children.Add(top);

            BoxView bottom = new BoxView { Color = Color.Blue };
            Grid.SetRow(bottom, 5);
            Grid.SetColumn(bottom, 0);
            Grid.SetColumnSpan(bottom, 6);
            Children.Add(bottom);

            BoxView left = new BoxView { Color = Color.Blue };
            Grid.SetRow(left, 0);
            Grid.SetColumn(left, 0);
            Grid.SetRowSpan(left, 6);
            Children.Add(left);

            BoxView right = new BoxView { Color = Color.Blue };
            Grid.SetRow(right, 0);
            Grid.SetColumn(right, 5);
            Grid.SetRowSpan(right, 6);
            Children.Add(right);
        }

        public String PuzzleImage {
            get { return _image.Name; }
            
            set
            {
                _image = new PuzzleImage(value, ".jpg");
                SliderImagePart[] list = _image.ShuffledParts;
                var imgCount = 0;
                for (var row=1; row<5; row++)
                {
                    for (var col=1; col<5; col++, imgCount++)
                    {
                        SliderImagePart part = list[imgCount];
                        if (part.Position == 16)
                        {
                            Children.Add(new SliderImagePart(_emptyImage, 16), col, row);
                        }
                        else
                        {
                            Children.Add(part, col, row);
                        }
                    }
                }
            }
        }
    }
}


 

