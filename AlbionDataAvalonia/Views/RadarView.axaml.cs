using AlbionDataAvalonia.ViewModels;
using Avalonia.Controls;

namespace AlbionDataAvalonia.Views
{
    public partial class RadarView : UserControl
    {
        public RadarView(RadarViewModel radarViewModel)
        {
            InitializeComponent();
            this.DataContext = radarViewModel;
        }        
    }
}