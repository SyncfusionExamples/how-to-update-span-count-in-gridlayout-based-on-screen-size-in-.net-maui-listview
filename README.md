# how-to-update-span-count-in-gridlayout-based-on-screen-size-in-.net-maui-listview

This example demonstrates about how to update the span column count in GridLayout view in .NET MAUI ListView.

## Sample

```xaml
<syncfusion:SfListView x:Name="listView" 
                  SelectionMode="Multiple"
                  ItemsSource="{Binding GalleryInfo}"
                  Grid.Row="1"
                  ItemSize="{OnIdiom Phone='150',Tablet='150',Desktop='170'}"
                  ItemSpacing="3">
            <syncfusion:SfListView.ItemsLayout>
                <syncfusion:GridLayout SpanCount="2"/>
            </syncfusion:SfListView.ItemsLayout>

            <syncfusion:SfListView.ItemTemplate>
                <DataTemplate>
                    <Grid RowSpacing="0" ColumnSpacing="0">
                        <Image Source="{Binding Image}"
                Aspect="AspectFill"
                       MinimumHeightRequest="40" MinimumWidthRequest="40" />
                        <Grid VerticalOptions="End" ColumnSpacing="0" Opacity="0.75" BackgroundColor="#CDCDCD" HeightRequest="{OnIdiom Phone='30' , Tablet='40',Desktop='40'}">

                            <Label Text="{Binding ImageTitle}" TextColor="Black"
                  VerticalTextAlignment="Center"
                  Margin="20,0,0,0"
                  HorizontalTextAlignment="Start" FontSize="{OnPlatform WinUI=14,Android=12, Default=10 }">

                            </Label>
                        </Grid>
                    </Grid>
                </DataTemplate>
            </syncfusion:SfListView.ItemTemplate>
        </syncfusion:SfListView>       
```

```C#

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

```

## Requirements to run the demo

* [Visual Studio 2017](https://visualstudio.microsoft.com/downloads/) or [Visual Studio for Mac](https://visualstudio.microsoft.com/vs/mac/)
* Xamarin add-ons for Visual Studio (available via the Visual Studio installer).

## Troubleshooting

### Path too long exception

If you are facing path too long exception when building this example project, close Visual Studio and rename the repository to short and build the project.
