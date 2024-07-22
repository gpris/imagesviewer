using System.Collections.ObjectModel;
using System.Windows.Media.Imaging;
namespace imagesViewer
{
    public class ImageInfo
    {
        public string ImagePath { get; set; }
        public BitmapImage Thumbnail { get; set; }
    }

    public class ImagesViewerViewModel
    {
        public ObservableCollection<ImageInfo> Images { get; set; }
        public ImageInfo SelectedImage { get; set; }

        public ImagesViewerViewModel()
        {
            Images = new ObservableCollection<ImageInfo>();
            // 이미지 목록 초기화 로직
        }
    }
}