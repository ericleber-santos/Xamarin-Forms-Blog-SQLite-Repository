using System;
using System.Collections.Generic;
using Simulacao.ViewModels;
using Simulacao.Views;
using Xamarin.Forms;

namespace Simulacao
{
    public partial class AppShell : Xamarin.Forms.Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(PostsDetailPage), typeof(PostsDetailPage));
        }

    }
}
