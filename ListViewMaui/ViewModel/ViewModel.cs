using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListViewMaui
{
    public class ListViewGridLayoutViewModel : INotifyPropertyChanged
    {
        #region Fields

        private ObservableCollection<ListViewGalleryInfo> galleryinfo;

        #endregion

        #region Constructor

        public ListViewGridLayoutViewModel()
        {
            GenerateSource();
        }

        #endregion

        #region Properties

        public ObservableCollection<ListViewGalleryInfo> GalleryInfo
        {
            get { return galleryinfo; }
            set { this.galleryinfo = value; }
        }

        #endregion

        #region ItemSource

        public void GenerateSource()
        {
            ListViewGalleryInfoRepository bookRepository = new ListViewGalleryInfoRepository();
            galleryinfo = bookRepository.GetGalleryInfo();
        }

        #endregion

        #region INotifyPropertyChanged

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string name)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(name));
        }

        #endregion
    }
}
