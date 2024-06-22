using MovieCollection.Query.View.Base;
using MovieCollection.Query.View.Ref;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieCollection.Query.View
{
    public class MovieSelectionMovieView:BaseView
    {
        public MovieView Movie { get; set; }

        public MovieSelectionView MovieSelection { get; set; }
    }
}
