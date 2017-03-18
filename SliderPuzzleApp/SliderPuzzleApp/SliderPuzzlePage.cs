using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace SliderPuzzleApp
{
    class SliderPuzzlePage : ContentPage
    {
        private SliderPuzzle _puzzle;

        public SliderPuzzlePage() {
            Title = "Slider Puzzle";
            Padding = new Thickness(0, Device.OnPlatform(20, 0, 0), 0, 0);

            _puzzle = new SliderPuzzle();
            _puzzle.PuzzleImage = "BoxKitties";

            Content = _puzzle;
        }
    }


}
