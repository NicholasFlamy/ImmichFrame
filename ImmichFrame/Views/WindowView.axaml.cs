using Avalonia;
using Avalonia.Controls;
using Avalonia.VisualTree;
using ImmichFrame.ViewModels;
using System;

namespace ImmichFrame.Views
{
    public partial class WindowView : BaseView
    {
        public static TopLevel? MainTopLevel;
        public WindowView()
        {
            InitializeComponent();
            this.AttachedToVisualTree += OnAttachedToVisualTree!;
            //this.DataContext = new MainWindowViewModel();
        }
        private void OnAttachedToVisualTree(object sender, VisualTreeAttachmentEventArgs e)
        {
            // Access the TopLevel here
            MainTopLevel = this.GetVisualRoot() as TopLevel;
            this.DataContext = new MainWindowViewModel();
        }
    }
}
