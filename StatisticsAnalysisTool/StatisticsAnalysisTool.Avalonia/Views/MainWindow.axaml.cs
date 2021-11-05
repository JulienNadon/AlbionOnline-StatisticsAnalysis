using Avalonia;
using Avalonia.Controls;
using Avalonia.Input;
using Avalonia.Markup.Xaml;
using StatisticsAnalysisTool.Avalonia.ViewModels;
// ReSharper disable UnusedParameter.Local
// ReSharper disable UnusedMember.Local

namespace StatisticsAnalysisTool.Avalonia.Views
{
    public class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
#if DEBUG
            this.AttachDevTools();
#endif
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }

        public void TrackingGeneral_OnPointerReleased()
        {
            var vm = (MainWindowViewModel)DataContext!;
            vm.NavigationContent = new TrackingGeneralViewModel();
        }

        public void ItemSearch_OnClick()
        {
            var vm = (MainWindowViewModel)DataContext!;
            vm.NavigationContent = new ItemSearchViewModel();
        }

        private void TitleBar_OnPointerPressed(object? sender, PointerPressedEventArgs e)
        {
            if (e.GetCurrentPoint(null).Properties.PointerUpdateKind == PointerUpdateKind.LeftButtonPressed)
            {
                PlatformImpl?.BeginMoveDrag(e);
            }
        }
    }
}
