using AlbionDataAvalonia.ViewModels;
using Avalonia.Controls;

namespace AlbionDataAvalonia.Views
{
    public partial class OrderView : UserControl
    {
        public OrderView(OrderViewModel radarViewModel)
        {
            InitializeComponent();
            this.DataContext = radarViewModel;
        }        
    }
}