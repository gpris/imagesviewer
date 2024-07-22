using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace imagesViewer
{
    /// <summary>
    /// MainWindow.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            ImagesViewerViewModel viewModel = (ImagesViewerViewModel)DataContext;
        }
        private void OnSelectImagesButtonClick(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Filter = "Image files (*.png;*.jpeg;*.jpg)|*.png;*.jpeg;*.jpg|All files (*.*)|*.*",
                InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures),
                Multiselect = true // 여러 파일 선택 활성화
            };

            if (openFileDialog.ShowDialog() == true)
            {
                List<BitmapImage> images = new List<BitmapImage>();
                foreach (string file in openFileDialog.FileNames)
                {
                    BitmapImage image = new BitmapImage(new Uri(file));
                    images.Add(image);
                }
                //ImagesList.ItemsSource = images; // ItemsControl에 이미지 목록 바인딩

                ImagesViewerViewModel viewModel = (ImagesViewerViewModel)DataContext;
                foreach (BitmapImage image in images)
                {
                    viewModel.Images.Add(new ImageInfo { ImagePath = "", Thumbnail = image });
                }
            }
        }
    }
}
