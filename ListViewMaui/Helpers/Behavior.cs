using Microsoft.Maui.Controls;
using Syncfusion.Maui.DataSource;
using Syncfusion.Maui.ListView;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListViewMaui
{
    public class Behavior:Behavior<ContentPage>
    {
        #region Fields
        Syncfusion.Maui.ListView.SfListView listview;

        #endregion

        #region Override Methods

        protected override void OnAttachedTo(ContentPage bindable)
        {
            listview = bindable.FindByName<Syncfusion.Maui.ListView.SfListView>("listView");
            bindable.PropertyChanged += Bindable_PropertyChanged;
        }

        private void Bindable_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (e.PropertyName == "Width" || e.PropertyName == "Height")
            {
                var size = Application.Current.MainPage.Width / listview.ItemSize;

                if (DeviceInfo.Platform == DevicePlatform.Android || DeviceInfo.Platform == DevicePlatform.iOS)
                    (listview.ItemsLayout as GridLayout).SpanCount = DeviceInfo.Idiom == DeviceIdiom.Phone ? 2 : 4;
                else if (DeviceInfo.Platform == DevicePlatform.WinUI)
                {
                    (listview.ItemsLayout as GridLayout).SpanCount = DeviceInfo.Idiom == DeviceIdiom.Desktop || DeviceInfo.Idiom == DeviceIdiom.Desktop ? 4 : 2;
                    listview.ItemSize = DeviceInfo.Idiom == DeviceIdiom.Desktop || DeviceInfo.Idiom == DeviceIdiom.Tablet ? 230 : 140;
                }
               (listview.ItemsLayout as GridLayout).SpanCount = (int)size;
            }
        }
        protected override void OnDetachingFrom(BindableObject bindable)
        {
            bindable.PropertyChanged -= Bindable_PropertyChanged;
            bindable = null;
            listview = null;
        }
        #endregion
    }
}
